using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hid.Checkpoint.Audit.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "audit_records",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<int>(type: "integer", nullable: true),
                    profile_id = table.Column<int>(type: "integer", nullable: true),
                    user_info = table.Column<string>(type: "text", nullable: false),
                    display_name = table.Column<string>(type: "text", nullable: true),
                    entity_id = table.Column<string>(type: "text", nullable: false),
                    entity_type = table.Column<string>(type: "text", nullable: false),
                    entity_full_type = table.Column<string>(type: "text", nullable: false),
                    changes_type = table.Column<int>(type: "integer", nullable: true),
                    initiator_type = table.Column<int>(type: "integer", nullable: false),
                    stamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    expired = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_records", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "audit_member_record",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    display_name = table.Column<string>(type: "text", nullable: true),
                    property_name = table.Column<string>(type: "text", nullable: false),
                    old_value = table.Column<string>(type: "text", nullable: false),
                    new_value = table.Column<string>(type: "text", nullable: false),
                    audit_entity_record_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_member_record", x => x.id);
                    table.ForeignKey(
                        name: "fk_audit_member_record_audit_records_audit_entity_record_id",
                        column: x => x.audit_entity_record_id,
                        principalTable: "audit_records",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_audit_member_record_audit_entity_record_id",
                table: "audit_member_record",
                column: "audit_entity_record_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "audit_member_record");

            migrationBuilder.DropTable(
                name: "audit_records");
        }
    }
}
