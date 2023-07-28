using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hid.Checkpoint.DataAccess.Ef.Migrations
{
    /// <inheritdoc />
    public partial class approve_permissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_stage_type_persons_author_id",
                table: "stage_type");

            migrationBuilder.DropTable(
                name: "approvers");

            migrationBuilder.DropIndex(
                name: "ix_stage_type_author_id",
                table: "stage_type");

            migrationBuilder.DropColumn(
                name: "author_id",
                table: "stage_type");

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "persons",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "is_disabled",
                table: "chain_template",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "approve_permission_id",
                table: "access_levels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "approver_permission_request_id",
                table: "access_levels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "comment",
                table: "access_levels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "approve_permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    pass_request_type_id = table.Column<int>(type: "integer", nullable: true),
                    stage_type_id = table.Column<int>(type: "integer", nullable: true),
                    stage_template_id = table.Column<int>(type: "integer", nullable: true),
                    stage_template_order = table.Column<int>(type: "integer", nullable: true),
                    stage_template_is_disabled = table.Column<bool>(type: "boolean", nullable: true),
                    stage_template_chain_template_id = table.Column<int>(type: "integer", nullable: true),
                    stage_template_type_id = table.Column<int>(type: "integer", nullable: true),
                    subdivision_id = table.Column<int>(type: "integer", nullable: true),
                    is_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_approve_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_approve_permissions_chain_template_stage_template_chain_tem",
                        column: x => x.stage_template_chain_template_id,
                        principalTable: "chain_template",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_approve_permissions_pass_request_type_pass_request_type_id",
                        column: x => x.pass_request_type_id,
                        principalTable: "pass_request_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_approve_permissions_persons_person_id",
                        column: x => x.person_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_approve_permissions_stage_type_stage_template_type_id",
                        column: x => x.stage_template_type_id,
                        principalTable: "stage_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_approve_permissions_stage_type_stage_type_id",
                        column: x => x.stage_type_id,
                        principalTable: "stage_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_approve_permissions_subdivision_subdivision_id",
                        column: x => x.subdivision_id,
                        principalTable: "subdivision",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "approver_permission_requests",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    author_id = table.Column<int>(type: "integer", nullable: false),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    pass_request_type_id = table.Column<int>(type: "integer", nullable: true),
                    subdivision_id = table.Column<int>(type: "integer", nullable: true),
                    stage_type_id = table.Column<int>(type: "integer", nullable: true),
                    stage_template_id = table.Column<int>(type: "integer", nullable: true),
                    stage_template_order = table.Column<int>(type: "integer", nullable: true),
                    stage_template_is_disabled = table.Column<bool>(type: "boolean", nullable: true),
                    stage_template_chain_template_id = table.Column<int>(type: "integer", nullable: true),
                    stage_template_type_id = table.Column<int>(type: "integer", nullable: true),
                    accepted = table.Column<bool>(type: "boolean", nullable: true),
                    reject_reason = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_approver_permission_requests", x => x.id);
                    table.ForeignKey(
                        name: "fk_approver_permission_requests_chain_template_stage_template_",
                        column: x => x.stage_template_chain_template_id,
                        principalTable: "chain_template",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_approver_permission_requests_pass_request_type_pass_request",
                        column: x => x.pass_request_type_id,
                        principalTable: "pass_request_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_approver_permission_requests_persons_author_id",
                        column: x => x.author_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_approver_permission_requests_persons_person_id",
                        column: x => x.person_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_approver_permission_requests_stage_type_stage_template_type",
                        column: x => x.stage_template_type_id,
                        principalTable: "stage_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_approver_permission_requests_stage_type_stage_type_id",
                        column: x => x.stage_type_id,
                        principalTable: "stage_type",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_approver_permission_requests_subdivision_subdivision_id",
                        column: x => x.subdivision_id,
                        principalTable: "subdivision",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "customizable_property",
                columns: new[] { "id", "created", "discriminator", "display_name", "interface_id", "is_hidden", "name", "removed", "type_full_name", "type_name", "updated" },
                values: new object[] { "Hid.Checkpoint.Domain.Models.Person.UserId", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PersonProperty", null, "Hid.Checkpoint.Domain.Models.Person.UserId", false, "UserId", false, "Hid.Checkpoint.Domain.Models.Person", "Person", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "ix_access_levels_approve_permission_id",
                table: "access_levels",
                column: "approve_permission_id");

            migrationBuilder.CreateIndex(
                name: "ix_access_levels_approver_permission_request_id",
                table: "access_levels",
                column: "approver_permission_request_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_permissions_pass_request_type_id",
                table: "approve_permissions",
                column: "pass_request_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_permissions_person_id",
                table: "approve_permissions",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_permissions_stage_template_chain_template_id",
                table: "approve_permissions",
                column: "stage_template_chain_template_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_permissions_stage_template_type_id",
                table: "approve_permissions",
                column: "stage_template_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_permissions_stage_type_id",
                table: "approve_permissions",
                column: "stage_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_permissions_subdivision_id",
                table: "approve_permissions",
                column: "subdivision_id");

            migrationBuilder.CreateIndex(
                name: "ix_approver_permission_requests_author_id",
                table: "approver_permission_requests",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_approver_permission_requests_pass_request_type_id",
                table: "approver_permission_requests",
                column: "pass_request_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_approver_permission_requests_person_id",
                table: "approver_permission_requests",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "ix_approver_permission_requests_stage_template_chain_template_",
                table: "approver_permission_requests",
                column: "stage_template_chain_template_id");

            migrationBuilder.CreateIndex(
                name: "ix_approver_permission_requests_stage_template_type_id",
                table: "approver_permission_requests",
                column: "stage_template_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_approver_permission_requests_stage_type_id",
                table: "approver_permission_requests",
                column: "stage_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_approver_permission_requests_subdivision_id",
                table: "approver_permission_requests",
                column: "subdivision_id");

            migrationBuilder.AddForeignKey(
                name: "fk_access_levels_approve_permissions_approve_permission_id",
                table: "access_levels",
                column: "approve_permission_id",
                principalTable: "approve_permissions",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_access_levels_approver_permission_requests_approver_permiss",
                table: "access_levels",
                column: "approver_permission_request_id",
                principalTable: "approver_permission_requests",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_access_levels_approve_permissions_approve_permission_id",
                table: "access_levels");

            migrationBuilder.DropForeignKey(
                name: "fk_access_levels_approver_permission_requests_approver_permiss",
                table: "access_levels");

            migrationBuilder.DropTable(
                name: "approve_permissions");

            migrationBuilder.DropTable(
                name: "approver_permission_requests");

            migrationBuilder.DropIndex(
                name: "ix_access_levels_approve_permission_id",
                table: "access_levels");

            migrationBuilder.DropIndex(
                name: "ix_access_levels_approver_permission_request_id",
                table: "access_levels");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Person.UserId");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "is_disabled",
                table: "chain_template");

            migrationBuilder.DropColumn(
                name: "approve_permission_id",
                table: "access_levels");

            migrationBuilder.DropColumn(
                name: "approver_permission_request_id",
                table: "access_levels");

            migrationBuilder.DropColumn(
                name: "comment",
                table: "access_levels");

            migrationBuilder.AddColumn<int>(
                name: "author_id",
                table: "stage_type",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "approvers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    approve_stage_template_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    approve_stage_template_chain_template_id = table.Column<int>(type: "integer", nullable: true),
                    approve_stage_template_type_id = table.Column<int>(type: "integer", nullable: true),
                    approve_stage_template_is_disabled = table.Column<bool>(type: "boolean", nullable: true),
                    approve_stage_template_order = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_approvers", x => x.id);
                    table.ForeignKey(
                        name: "fk_approvers_chain_template_approve_stage_template_chain_templ",
                        column: x => x.approve_stage_template_chain_template_id,
                        principalTable: "chain_template",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_approvers_persons_person_id",
                        column: x => x.person_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_approvers_stage_type_approve_stage_template_type_id",
                        column: x => x.approve_stage_template_type_id,
                        principalTable: "stage_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_stage_type_author_id",
                table: "stage_type",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_approvers_approve_stage_template_chain_template_id",
                table: "approvers",
                column: "approve_stage_template_chain_template_id");

            migrationBuilder.CreateIndex(
                name: "ix_approvers_approve_stage_template_type_id",
                table: "approvers",
                column: "approve_stage_template_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_approvers_person_id",
                table: "approvers",
                column: "person_id");

            migrationBuilder.AddForeignKey(
                name: "fk_stage_type_persons_author_id",
                table: "stage_type",
                column: "author_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
