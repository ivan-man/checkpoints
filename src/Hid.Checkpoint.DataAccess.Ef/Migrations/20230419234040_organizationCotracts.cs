using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hid.Checkpoint.DataAccess.Ef.Migrations
{
    /// <inheritdoc />
    public partial class organizationCotracts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_property_metadata_request_type_id",
                table: "property_metadata");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.ContractDescription");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Title");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.FirstName");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.LastName");

            migrationBuilder.DropColumn(
                name: "contract_description",
                table: "organizations");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "profile",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "profile",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "ix_profile_phone_first_name_last_name_date_of_birth_organizati",
                table: "profile",
                newName: "ix_profile_phone_name_surname_date_of_birth_organization_id");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "organizations",
                newName: "name");

            migrationBuilder.CreateTable(
                name: "organization_contracts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    organization_id = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    valid_from = table.Column<DateOnly>(type: "date", nullable: true),
                    valid_to = table.Column<DateOnly>(type: "date", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    removed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organization_contracts", x => x.id);
                    table.ForeignKey(
                        name: "fk_organization_contracts_organizations_organization_id",
                        column: x => x.organization_id,
                        principalTable: "organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "id", "created", "discriminator", "display_name", "interface_id", "is_hidden", "removed", "name", "type_full_name", "type_name", "updated" },
                values: new object[,]
                {
                    { "Hid.Checkpoint.Domain.Models.Organization.Contracts", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Договоры", "Hid.Checkpoint.Domain.Models.Organization.Contracts", false, false, "Contracts", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.ContractsActual", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", null, "Hid.Checkpoint.Domain.Models.Organization.ContractsActual", false, false, "ContractsActual", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Name", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Название", "Hid.Checkpoint.Domain.Models.Organization.Name", false, false, "Name", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Contracts", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Договоры", "Hid.Checkpoint.Domain.Models.PassRequest.Contracts", false, false, "Contracts", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Person.Contracts", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PersonProperty", "Договоры", "Hid.Checkpoint.Domain.Models.Person.Contracts", false, false, "Contracts", "Hid.Checkpoint.Domain.Models.Person", "Person", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Name", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Имя", "Hid.Checkpoint.Domain.Models.Profile.Name", false, false, "Name", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Surname", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Фамилия", "Hid.Checkpoint.Domain.Models.Profile.Surname", false, false, "Surname", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "ix_property_metadata_request_type_id_role_employee_id_property",
                table: "property_metadata",
                columns: new[] { "request_type_id", "role", "employee_id", "property_id" },
                unique: true,
                filter: "removed is not true");

            migrationBuilder.CreateIndex(
                name: "ix_organizations_name",
                table: "organizations",
                column: "name",
                unique: true,
                filter: "removed is not true");

            migrationBuilder.CreateIndex(
                name: "ix_organization_contract_pass_request_pass_requests_id",
                table: "organization_contract_pass_request",
                column: "pass_requests_id");

            migrationBuilder.CreateIndex(
                name: "ix_organization_contract_person_persons_id",
                table: "organization_contract_person",
                column: "persons_id");

            migrationBuilder.CreateIndex(
                name: "ix_organization_contracts_organization_id",
                table: "organization_contracts",
                column: "organization_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organization_contract_pass_request");

            migrationBuilder.DropTable(
                name: "organization_contract_person");

            migrationBuilder.DropTable(
                name: "organization_contracts");

            migrationBuilder.DropIndex(
                name: "ix_property_metadata_request_type_id_role_employee_id_property",
                table: "property_metadata");

            migrationBuilder.DropIndex(
                name: "ix_organizations_name",
                table: "organizations");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Contracts");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.ContractsActual");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Name");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Contracts");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Person.Contracts");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Name");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Surname");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "profile",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "profile",
                newName: "first_name");

            migrationBuilder.RenameIndex(
                name: "ix_profile_phone_name_surname_date_of_birth_organization_id",
                table: "profile",
                newName: "ix_profile_phone_first_name_last_name_date_of_birth_organizati");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "organizations",
                newName: "title");

            migrationBuilder.AddColumn<string>(
                name: "contract_description",
                table: "organizations",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "customizable_property",
                columns: new[] { "id", "created", "discriminator", "display_name", "interface_id", "is_hidden", "removed", "name", "type_full_name", "type_name", "updated" },
                values: new object[,]
                {
                    { "Hid.Checkpoint.Domain.Models.Organization.ContractDescription", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Договор", "Hid.Checkpoint.Domain.Models.Organization.ContractDescription", false, false, "ContractDescription", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Title", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Заголовок", "Hid.Checkpoint.Domain.Models.Organization.Title", false, false, "Title", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.FirstName", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Имя", "Hid.Checkpoint.Domain.Models.Profile.FirstName", false, false, "FirstName", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.LastName", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Фамилия", "Hid.Checkpoint.Domain.Models.Profile.LastName", false, false, "LastName", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "ix_property_metadata_request_type_id",
                table: "property_metadata",
                column: "request_type_id");
        }
    }
}
