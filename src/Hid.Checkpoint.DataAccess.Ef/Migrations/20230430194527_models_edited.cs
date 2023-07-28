using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hid.Checkpoint.DataAccess.Ef.Migrations
{
    /// <inheritdoc />
    public partial class models_edited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "approve_stage_template");

            migrationBuilder.DropTable(
                name: "approve_chain_template");

            migrationBuilder.DropTable(
                name: "approve_stage_type");

            migrationBuilder.RenameColumn(
                name: "holidays_access",
                table: "access_levels",
                newName: "weekend_access");

            migrationBuilder.AlterColumn<decimal>(
                name: "role",
                table: "property_metadata",
                type: "numeric(20,0)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "person_id",
                table: "devices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "name_ru",
                table: "country",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "normalized_name_ru",
                table: "country",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "number",
                table: "country",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "type_id",
                table: "approve_stage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "chain_template",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chain_template", x => x.id);
                    table.ForeignKey(
                        name: "fk_chain_template_pass_request_type_type_id",
                        column: x => x.type_id,
                        principalTable: "pass_request_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stage_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    multiple_stage = table.Column<bool>(type: "boolean", nullable: false),
                    approvers_list_opened = table.Column<bool>(type: "boolean", nullable: false),
                    week_end_access = table.Column<bool>(type: "boolean", nullable: false),
                    author_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_type", x => x.id);
                    table.ForeignKey(
                        name: "fk_stage_type_persons_author_id",
                        column: x => x.author_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "approvers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    approve_stage_template_id = table.Column<int>(type: "integer", nullable: false),
                    approve_stage_template_order = table.Column<int>(type: "integer", nullable: true),
                    approve_stage_template_is_disabled = table.Column<bool>(type: "boolean", nullable: true),
                    approve_stage_template_chain_template_id = table.Column<int>(type: "integer", nullable: true),
                    approve_stage_template_type_id = table.Column<int>(type: "integer", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "chain_template_stages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order = table.Column<int>(type: "integer", nullable: false),
                    is_disabled = table.Column<bool>(type: "boolean", nullable: false),
                    chain_template_id = table.Column<int>(type: "integer", nullable: false),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    approve_chain_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chain_template_stages", x => x.id);
                    table.ForeignKey(
                        name: "fk_chain_template_stages_chain_template_chain_template_id",
                        column: x => x.approve_chain_id,
                        principalTable: "chain_template",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_chain_template_stages_chain_template_chain_template_id1",
                        column: x => x.chain_template_id,
                        principalTable: "chain_template",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_chain_template_stages_stage_type_type_id",
                        column: x => x.type_id,
                        principalTable: "stage_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_devices_person_id",
                table: "devices",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_stage_type_id",
                table: "approve_stage",
                column: "type_id");

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

            migrationBuilder.CreateIndex(
                name: "ix_chain_template_type_id",
                table: "chain_template",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_chain_template_stages_approve_chain_id",
                table: "chain_template_stages",
                column: "approve_chain_id");

            migrationBuilder.CreateIndex(
                name: "ix_chain_template_stages_chain_template_id",
                table: "chain_template_stages",
                column: "chain_template_id");

            migrationBuilder.CreateIndex(
                name: "ix_chain_template_stages_type_id",
                table: "chain_template_stages",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_stage_type_author_id",
                table: "stage_type",
                column: "author_id");

            migrationBuilder.AddForeignKey(
                name: "fk_approve_stage_stage_type_type_id",
                table: "approve_stage",
                column: "type_id",
                principalTable: "stage_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_devices_persons_person_id",
                table: "devices",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_approve_stage_stage_type_type_id",
                table: "approve_stage");

            migrationBuilder.DropForeignKey(
                name: "fk_devices_persons_person_id",
                table: "devices");

            migrationBuilder.DropTable(
                name: "approvers");

            migrationBuilder.DropTable(
                name: "chain_template_stages");

            migrationBuilder.DropTable(
                name: "chain_template");

            migrationBuilder.DropTable(
                name: "stage_type");

            migrationBuilder.DropIndex(
                name: "ix_devices_person_id",
                table: "devices");

            migrationBuilder.DropIndex(
                name: "ix_approve_stage_type_id",
                table: "approve_stage");

            migrationBuilder.DropColumn(
                name: "person_id",
                table: "devices");

            migrationBuilder.DropColumn(
                name: "name_ru",
                table: "country");

            migrationBuilder.DropColumn(
                name: "normalized_name_ru",
                table: "country");

            migrationBuilder.DropColumn(
                name: "number",
                table: "country");

            migrationBuilder.DropColumn(
                name: "type_id",
                table: "approve_stage");

            migrationBuilder.RenameColumn(
                name: "weekend_access",
                table: "access_levels",
                newName: "holidays_access");

            migrationBuilder.AlterColumn<int>(
                name: "role",
                table: "property_metadata",
                type: "integer",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "approve_chain_template",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_approve_chain_template", x => x.id);
                    table.ForeignKey(
                        name: "fk_approve_chain_template_pass_request_type_type_id",
                        column: x => x.type_id,
                        principalTable: "pass_request_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "approve_stage_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    author_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_multiple_stage = table.Column<bool>(type: "boolean", nullable: false),
                    removed = table.Column<bool>(type: "boolean", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_approve_stage_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "approve_stage_template",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stage_type_id = table.Column<int>(type: "integer", nullable: false),
                    approve_chain_id = table.Column<int>(type: "integer", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_approve_stage_template", x => x.id);
                    table.ForeignKey(
                        name: "fk_approve_stage_template_approve_chain_template_approve_chain_t",
                        column: x => x.approve_chain_id,
                        principalTable: "approve_chain_template",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_approve_stage_template_approve_stage_type_stage_type_id",
                        column: x => x.stage_type_id,
                        principalTable: "approve_stage_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_approve_chain_template_type_id",
                table: "approve_chain_template",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_stage_template_approve_chain_id",
                table: "approve_stage_template",
                column: "approve_chain_id");

            migrationBuilder.CreateIndex(
                name: "ix_approve_stage_template_stage_type_id",
                table: "approve_stage_template",
                column: "stage_type_id");
        }
    }
}
