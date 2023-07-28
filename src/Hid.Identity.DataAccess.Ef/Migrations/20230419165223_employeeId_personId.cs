using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hid.Identity.DataAccess.Ef.Migrations
{
    /// <inheritdoc />
    public partial class employeeId_personId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "AspNetUsers",
                newName: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "AspNetUsers",
                newName: "EmployeeId");
        }
    }
}
