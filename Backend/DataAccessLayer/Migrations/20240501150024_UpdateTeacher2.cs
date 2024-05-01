using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeacher2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Teachers");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_RoleId",
                table: "Teachers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Roles_RoleId",
                table: "Teachers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Roles_RoleId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_RoleId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Teachers");
        }
    }
}
