using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hid.Checkpoint.DataAccess.Ef.Migrations
{
    /// <inheritdoc />
    public partial class organization_contract_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organization_contract_pass_request");

            migrationBuilder.DropTable(
                name: "organization_contract_person");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Contracts");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Person.Contracts");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "organization_contracts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "organization_contract_relations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    organization_contract_id = table.Column<int>(type: "integer", nullable: true),
                    pass_request_id = table.Column<int>(type: "integer", nullable: false),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organization_contract_relations", x => x.id);
                    table.ForeignKey(
                        name: "fk_organization_contract_relations_organization_contracts_orga",
                        column: x => x.organization_contract_id,
                        principalTable: "organization_contracts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_organization_contract_relations_pass_requests_pass_request_",
                        column: x => x.pass_request_id,
                        principalTable: "pass_requests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organization_contract_relations_persons_person_id",
                        column: x => x.person_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customizable_property",
                columns: new[] { "id", "created", "discriminator", "display_name", "interface_id", "is_hidden", "name", "removed", "type_full_name", "type_name", "updated" },
                values: new object[] { "Hid.Checkpoint.Domain.Models.PassRequest.GuestContractRelations", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "", "Hid.Checkpoint.Domain.Models.PassRequest.GuestContractRelations", false, "GuestContractRelations", false, "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "ix_organization_contract_relations_organization_contract_id",
                table: "organization_contract_relations",
                column: "organization_contract_id");

            migrationBuilder.CreateIndex(
                name: "ix_organization_contract_relations_pass_request_id",
                table: "organization_contract_relations",
                column: "pass_request_id");

            migrationBuilder.CreateIndex(
                name: "ix_organization_contract_relations_person_id",
                table: "organization_contract_relations",
                column: "person_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organization_contract_relations");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.GuestContractRelations");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "organization_contracts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "organization_contract_pass_request",
                columns: table => new
                {
                    contracts_id = table.Column<int>(type: "integer", nullable: false),
                    pass_requests_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organization_contract_pass_request", x => new { x.contracts_id, x.pass_requests_id });
                    table.ForeignKey(
                        name: "fk_organization_contract_pass_request_organization_contracts_c",
                        column: x => x.contracts_id,
                        principalTable: "organization_contracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organization_contract_pass_request_pass_requests_pass_reque",
                        column: x => x.pass_requests_id,
                        principalTable: "pass_requests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organization_contract_person",
                columns: table => new
                {
                    contracts_id = table.Column<int>(type: "integer", nullable: false),
                    persons_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organization_contract_person", x => new { x.contracts_id, x.persons_id });
                    table.ForeignKey(
                        name: "fk_organization_contract_person_organization_contracts_contrac",
                        column: x => x.contracts_id,
                        principalTable: "organization_contracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organization_contract_person_persons_persons_id",
                        column: x => x.persons_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customizable_property",
                columns: new[] { "id", "created", "discriminator", "display_name", "interface_id", "is_hidden", "name", "removed", "type_full_name", "type_name", "updated" },
                values: new object[,]
                {
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Contracts", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Договоры", "Hid.Checkpoint.Domain.Models.PassRequest.Contracts", false, "Contracts", false, "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Person.Contracts", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PersonProperty", "Договоры", "Hid.Checkpoint.Domain.Models.Person.Contracts", false, "Contracts", false, "Hid.Checkpoint.Domain.Models.Person", "Person", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "ix_organization_contract_pass_request_pass_requests_id",
                table: "organization_contract_pass_request",
                column: "pass_requests_id");

            migrationBuilder.CreateIndex(
                name: "ix_organization_contract_person_persons_id",
                table: "organization_contract_person",
                column: "persons_id");
        }
    }
}
