using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class DelStudentCourseIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IX_CourseStudent_StudentId_CourseId",
            table: "CourseStudents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
             name: "IX_CourseStudent_StudentId_CourseId",
             table: "CourseStudents",
             columns: new[] { "StudentId", "CourseId" },
             unique: true);
        }
    }
}
