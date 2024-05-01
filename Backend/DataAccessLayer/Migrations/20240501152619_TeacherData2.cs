using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class TeacherData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirtName",
                table: "Teachers",
                newName: "FirstName");

            migrationBuilder.InsertData(
                            table: "Teachers",
                            columns: new[] { "FirstName", "LastName", "UserName", "RoleId" },
                            values: new object[,]
                             {
                                 { "Administrateur", "General", "Admin", "1" },
                                 { "Alice", "Johnson", "TAJohnson", "2" },
                                 { "Mark", "Smith", "TMSmith", "2" },
                                 { "Bertrand", "Bekker", "TBBecker", "2" },
                             });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Teachers",
                newName: "FirtName");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4 });
        }
    }
}
