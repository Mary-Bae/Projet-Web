using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class StudentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            table: "Students",
                            columns: new[] { "FirstName", "LastName", "UserName", "LevelId", "RoleId" },
                            values: new object[,]
                             {
                                 { "David", "Maurice", "SDMaurice","1", "3" },
                                 { "Alicia", "Serval", "SAServal","2", "3" },
                                 { "Frederic", "Swerta", "SFSwerta","2", "3" },
                                 { "Christian", "Clavier", "SCClavier","3", "3" },
                             });

            migrationBuilder.InsertData(
                            table: "Courses",
                            columns: new[] { "Name", "Schedule", "TeacherId", "Description", "LevelId" },
                            values: new object[,]
                             {
                                 { "Web", "Day", "6","Cours de web pour les Rookies", "1" },
                                 { "Reseau", "Day", "7", "Cours de reseau pour les débutants","2" },
                                 { "SQL", "Evening","6", "Cours de SQL pour les débutants","2"},
                                 { "Devops", "Evening","8", "Cours de devops pour les confirmés","3" },
                                 { "Web2", "Evening","8", "Cours de web pour les confirmés","3" },
                             });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Students",
            keyColumn: "Id",
            keyValues: new object[] { 1, 2, 3, 4 });

            migrationBuilder.DeleteData(
            table: "Courses",
            keyColumn: "Id",
            keyValues: new object[] { 1, 2, 3, 4, 5 });
        }
    }
}
