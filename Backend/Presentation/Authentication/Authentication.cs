using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

    namespace Presentation
    {
        public class AuthenticationServices
        {

            private readonly List<User> users = new List<User> {
            new User("user1", "829792F8543443A91F7E", "Sunday", "User"),  //test
            new User("user2", "EE1D043DE283E12CD10A", "Sunday", "Admin"), //password
            new User("user3", "A06EE0913A1EBFCE55EF", "Sunday", "User") //secret
            //Rajouter un champ rôle
        };

            IConfiguration _config;
            public AuthenticationServices(IConfiguration config)
            {
                _config = config;
            }
            private string GenerateJSONWebToken(User user)
            {
                var secretKey = _config["Jwt:Key"];
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                // Create a ClaimsIdentity
                var claimsIdentity = new ClaimsIdentity();

                // Add claim for username
                 claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Username));

                // Add claim for role
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, user.Role));

                // Add other claims
                claimsIdentity.AddClaim(new Claim("custom_info", "info"));
                claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); ;

                var jwtIssuer = _config["Jwt:Issuer"];
                var jwtAudience = _config["Jwt:Audience"];

                var token = new JwtSecurityToken(
                    jwtIssuer,
                    jwtAudience,
                    claimsIdentity.Claims,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            private string HashPassword(string password, string salt)
            {

                var hash = Rfc2898DeriveBytes.Pbkdf2(
                            password: Encoding.UTF8.GetBytes(password),
                            salt: Encoding.UTF8.GetBytes(salt),
                            iterations: 10,
                            hashAlgorithm: HashAlgorithmName.SHA512,
                            outputLength: 10);
                return Convert.ToHexString(hash);
            }

            public void RegisterUser(string username, string password)
            {
                if (users.Any(user => user.Username.ToLower() == username.ToLower()))
                {
                    throw new Exception("User already exist");
                }
                var salt = DateTime.Now.ToString("dddd"); // get the day of week. Ex: Sunday
                var passwordHash = HashPassword(password, salt);
                var newUser = new User(username, passwordHash, salt);
                users.Add(newUser);
            }

            public object Login(string username, string password)
            {
                var user = users.FirstOrDefault(user => user.Username.ToLower() == username.ToLower()) ??
                                      throw new Exception("Login failed; Invalid userID or password");

                var passwordHash = HashPassword(password, user.Salt);
                if (user.Password == passwordHash)
                {
                    var token = GenerateJSONWebToken(user);
                    return new { token };
                }
                throw new Exception("Login failed; Invalid userID or password");
            }

            public string Refreshtoken([FromBody] string token)

            {
                var (principal, jwtToken) = DecodeJwtToken(token);
                if (jwtToken == null)
                {
                    throw new SecurityTokenException("Invalid token");
                }
                var userName = jwtToken.Subject;
                var user = users.FirstOrDefault(user => user.Username.ToLower() == userName.ToLower()); // Récupérez l'objet user
                if (user == null)
                {
                throw new Exception("User not found");
                }
            return GenerateJSONWebToken(user);
            }
            public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token)
            {
                JwtSecurityTokenHandler handler = null;
                ClaimsPrincipal principal = null;
                SecurityToken validatedToken = null;

                try
                {
                    handler = new JwtSecurityTokenHandler();
                    principal = handler
                    .ValidateToken(token,
                        new TokenValidationParameters
                        {
                            ValidIssuer = _config["Jwt:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
                            ValidAudience = _config["Jwt:Audience"],
                        },
                        out validatedToken);
                }
                catch (SecurityTokenExpiredException ex)
                {
                    JwtSecurityToken jwtToken = handler.ReadJwtToken(token) as JwtSecurityToken;
                    return (principal, jwtToken);
                }
                throw new SecurityTokenException("Invalid token");
            }
        public User GetUser(string username)
        {
            return users.FirstOrDefault(user => user.Username.ToLower() == username.ToLower());
        }
    }
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Salt { get; set; }
            public string Role { get; set; }

            public User(string username, string password, string salt, string role)
            {
                Username = username;
                Password = password;
                Salt = salt;
                Role = role;
        }
            public User(string username, string password, string role)
            {
                Username = username;
                Password = password;
                Role = role;
        }
        }
    }