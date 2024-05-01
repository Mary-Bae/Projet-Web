using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class StudentCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            table: "CourseStudents",
                            columns: new[] { "StudentId", "CourseId" },
                            values: new object[,]
                             {
                                 { "1", "1" },
                                 { "2", "2" },
                                 { "2", "3" },
                                 { "3", "2" },
                                 { "3", "3" },
                                 { "4", "4" },
                                 { "4", "5" },
                             });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "CourseStudents",
            keyColumn: "Id",
            keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7 });
        }
    }
}
