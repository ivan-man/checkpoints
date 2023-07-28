using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hid.Checkpoint.DataAccess.Ef.Migrations
{
    /// <inheritdoc />
    public partial class changes_for_auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_approve_stage_user_approver_id",
                table: "approve_stage");

            migrationBuilder.DropForeignKey(
                name: "fk_pass_requests_user_author_id",
                table: "pass_requests");

            migrationBuilder.DropForeignKey(
                name: "fk_property_metadata_user_user_id",
                table: "property_metadata");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "property_metadata",
                newName: "employee_id");

            migrationBuilder.RenameIndex(
                name: "ix_property_metadata_user_id",
                table: "property_metadata",
                newName: "ix_property_metadata_employee_id");

            migrationBuilder.AddColumn<int>(
                name: "access_level_id",
                table: "persons",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "approve_stage_id",
                table: "persons",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.DateOfBirth",
                column: "display_name",
                value: "Дата рождения");

            migrationBuilder.CreateIndex(
                name: "ix_persons_access_level_id",
                table: "persons",
                column: "access_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_persons_approve_stage_id",
                table: "persons",
                column: "approve_stage_id");

            migrationBuilder.AddForeignKey(
                name: "fk_approve_stage_persons_approver_id",
                table: "approve_stage",
                column: "approver_id",
                principalTable: "persons",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_pass_requests_persons_author_id",
                table: "pass_requests",
                column: "author_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_persons_access_levels_access_level_id",
                table: "persons",
                column: "access_level_id",
                principalTable: "access_levels",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_persons_approve_stage_approve_stage_id",
                table: "persons",
                column: "approve_stage_id",
                principalTable: "approve_stage",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_property_metadata_persons_employee_id",
                table: "property_metadata",
                column: "employee_id",
                principalTable: "persons",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_approve_stage_persons_approver_id",
                table: "approve_stage");

            migrationBuilder.DropForeignKey(
                name: "fk_pass_requests_persons_author_id",
                table: "pass_requests");

            migrationBuilder.DropForeignKey(
                name: "fk_persons_access_levels_access_level_id",
                table: "persons");

            migrationBuilder.DropForeignKey(
                name: "fk_persons_approve_stage_approve_stage_id",
                table: "persons");

            migrationBuilder.DropForeignKey(
                name: "fk_property_metadata_persons_employee_id",
                table: "property_metadata");

            migrationBuilder.DropIndex(
                name: "ix_persons_access_level_id",
                table: "persons");

            migrationBuilder.DropIndex(
                name: "ix_persons_approve_stage_id",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "access_level_id",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "approve_stage_id",
                table: "persons");

            migrationBuilder.RenameColumn(
                name: "employee_id",
                table: "property_metadata",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "ix_property_metadata_employee_id",
                table: "property_metadata",
                newName: "ix_property_metadata_user_id");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<int>(type: "integer", nullable: false),
                    access_level_id = table.Column<int>(type: "integer", nullable: true),
                    approve_stage_id = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    roles_value = table.Column<int>(type: "integer", nullable: true),
                    system_name = table.Column<string>(type: "text", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_access_levels_access_level_id",
                        column: x => x.access_level_id,
                        principalTable: "access_levels",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_user_approve_stage_approve_stage_id",
                        column: x => x.approve_stage_id,
                        principalTable: "approve_stage",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_user_persons_employee_id",
                        column: x => x.employee_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.DateOfBirth",
                column: "display_name",
                value: null);

            migrationBuilder.CreateIndex(
                name: "ix_user_access_level_id",
                table: "user",
                column: "access_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_approve_stage_id",
                table: "user",
                column: "approve_stage_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_employee_id",
                table: "user",
                column: "employee_id");

            migrationBuilder.AddForeignKey(
                name: "fk_approve_stage_user_approver_id",
                table: "approve_stage",
                column: "approver_id",
                principalTable: "user",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_pass_requests_user_author_id",
                table: "pass_requests",
                column: "author_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_property_metadata_user_user_id",
                table: "property_metadata",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id");
        }
    }
}
