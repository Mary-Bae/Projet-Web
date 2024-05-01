using Domain;
using Microsoft.IdentityModel.Tokens;

namespace DataAccessLayer
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDbContext _context;
        public CourseRepository(CourseDbContext dbContext)
        {
            _context = dbContext;
        }

        //private static List<Course> _db = new List<Course>
        //{
        //    new Course("Web","Beginner","Day", "Teacher 1", "Cours de Web"),
        //    new Course("Développement","Beginner","Day", "Teacher 2","Cours de développement"),
        //    new Course("Java","Beginner","Day", "Teacher 3", "Cours de Java"),
        //    new Course("C#","Beginner","Day", "Teacher 4","Cours de C#")
        // };

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }
        public Course Get(int id)
        {
            return _context.Courses.Find(id);
        }
        public void addCourse(Course course)
        {
            _context.Courses.Add(course);
        }
        public void deleteCourse(Course course)
        {
            _context.Courses.Remove(course);
        }
        public void UpdateCourse(Course course)
        {
            var existingCourse = _context.Courses.FirstOrDefault(c => c.Name.ToLower() == course.Name.ToLower());
            if (existingCourse != null)
            {
                existingCourse.Level = course.Level;
                existingCourse.Schedule = course.Schedule;
                existingCourse.User = course.User;
                existingCourse.Description = course.Description;
            }
            else
            {
                throw new Exception("Course not found");
            }
        }

    }
}