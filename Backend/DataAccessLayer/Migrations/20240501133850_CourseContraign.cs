using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CourseContraign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ajouter une contrainte d'unicité sur les colonnes 'Name' et 'Level'
            migrationBuilder.CreateIndex(
                name: "IX_Courses_Name_Level",
                table: "Courses",
                columns: new[] { "Name", "Level" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_Name_Level",
                table: "Courses");
        }
    }
}
