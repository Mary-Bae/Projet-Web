using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class TeacherData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            table: "Teachers",
                            columns: new[] { "FirstName", "LastName" },
                            values: new object[,]
                             {
                                 { "Bertrand", "Xavier" },
                                 { "Alice", "Johnson" },
                                 { "Mark", "Smith" }
                             });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });
        }
    }
}
