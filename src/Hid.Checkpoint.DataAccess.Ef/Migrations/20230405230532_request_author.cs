using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hid.Checkpoint.DataAccess.Ef.Migrations
{
    /// <inheritdoc />
    public partial class request_author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pass_requests_persons_author_id",
                table: "pass_requests");

            migrationBuilder.AddForeignKey(
                name: "fk_pass_requests_user_author_id",
                table: "pass_requests",
                column: "author_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pass_requests_user_author_id",
                table: "pass_requests");

            migrationBuilder.AddForeignKey(
                name: "fk_pass_requests_persons_author_id",
                table: "pass_requests",
                column: "author_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
