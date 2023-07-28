using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hid.Checkpoint.DataAccess.Ef.Migrations
{
    /// <inheritdoc />
    public partial class properties_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_approve_stage_persons_approver_id",
                table: "approve_stage");

            migrationBuilder.DropForeignKey(
                name: "fk_persons_approve_stage_approve_stage_id",
                table: "persons");

            migrationBuilder.DropIndex(
                name: "ix_persons_approve_stage_id",
                table: "persons");

            migrationBuilder.DropColumn(
                name: "approve_stage_id",
                table: "persons");

            migrationBuilder.AddColumn<int>(
                name: "approve_stage_id",
                table: "user",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "system_name",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_hidden",
                table: "customizable_property",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Additional",
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.ApproveChains",
                columns: new[] { "display_name", "is_hidden" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Author",
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Created",
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Date",
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Devices",
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.ExpiredDate",
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Guests",
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Id",
                columns: new[] { "display_name", "is_hidden" },
                values: new object[] { "", false });

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Removed",
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.RequestType",
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.RequestTypeId",
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Updated",
                column: "is_hidden",
                value: false);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.VisitPurpose",
                column: "is_hidden",
                value: false);

            migrationBuilder.InsertData(
                table: "customizable_property",
                columns: new[] { "id", "created", "discriminator", "display_name", "interface_id", "is_hidden", "removed", "name", "type_full_name", "type_name", "updated" },
                values: new object[,]
                {
                    { "Hid.Checkpoint.Domain.Models.Organization.Address", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Адрес", "Hid.Checkpoint.Domain.Models.Organization.Address", false, false, "Address", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Code", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Код организации", "Hid.Checkpoint.Domain.Models.Organization.Code", false, false, "Code", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.ContractDescription", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Договор", "Hid.Checkpoint.Domain.Models.Organization.ContractDescription", false, false, "ContractDescription", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Created", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Создано", "Hid.Checkpoint.Domain.Models.Organization.Created", false, false, "Created", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Description", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Описание", "Hid.Checkpoint.Domain.Models.Organization.Description", false, false, "Description", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.DisbandDate", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Дата расформирования", "Hid.Checkpoint.Domain.Models.Organization.DisbandDate", false, false, "DisbandDate", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.ExternalId", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Внешний идентификатор", "Hid.Checkpoint.Domain.Models.Organization.ExternalId", false, false, "ExternalId", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Id", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "", "Hid.Checkpoint.Domain.Models.Organization.Id", false, false, "Id", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Imns", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Код ИМНС", "Hid.Checkpoint.Domain.Models.Organization.Imns", false, false, "Imns", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.ImnsName", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Орган ИМНС", "Hid.Checkpoint.Domain.Models.Organization.ImnsName", false, false, "ImnsName", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Inn", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "ИНН", "Hid.Checkpoint.Domain.Models.Organization.Inn", false, false, "Inn", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Removed", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Удалено", "Hid.Checkpoint.Domain.Models.Organization.Removed", false, false, "Removed", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Kpp", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "КПП", "Hid.Checkpoint.Domain.Models.Organization.Kpp", false, false, "Kpp", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Okato", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "ОКАТО", "Hid.Checkpoint.Domain.Models.Organization.Okato", false, false, "Okato", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Okopf", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "ОКОПФ", "Hid.Checkpoint.Domain.Models.Organization.Okopf", false, false, "Okopf", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Okpo", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "ОКПО", "Hid.Checkpoint.Domain.Models.Organization.Okpo", false, false, "Okpo", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Oktmo", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "ОКМО", "Hid.Checkpoint.Domain.Models.Organization.Oktmo", false, false, "Oktmo", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Okved", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "ОКВЕД", "Hid.Checkpoint.Domain.Models.Organization.Okved", false, false, "Okved", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Subdivisions", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Подразделения", "Hid.Checkpoint.Domain.Models.Organization.Subdivisions", false, false, "Subdivisions", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Title", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Заголовок", "Hid.Checkpoint.Domain.Models.Organization.Title", false, false, "Title", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Type", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "", "Hid.Checkpoint.Domain.Models.Organization.Type", false, false, "Type", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Organization.Updated", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Обновлено", "Hid.Checkpoint.Domain.Models.Organization.Updated", false, false, "Updated", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Person.Created", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PersonProperty", "Создано", "Hid.Checkpoint.Domain.Models.Person.Created", false, false, "Created", "Hid.Checkpoint.Domain.Models.Person", "Person", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Person.Id", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PersonProperty", "", "Hid.Checkpoint.Domain.Models.Person.Id", false, false, "Id", "Hid.Checkpoint.Domain.Models.Person", "Person", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Person.Removed", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PersonProperty", "Удалено", "Hid.Checkpoint.Domain.Models.Person.Removed", false, false, "Removed", "Hid.Checkpoint.Domain.Models.Person", "Person", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Person.Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PersonProperty", "", "Hid.Checkpoint.Domain.Models.Person.Profile", false, false, "Profile", "Hid.Checkpoint.Domain.Models.Person", "Person", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Person.Profiles", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PersonProperty", "", "Hid.Checkpoint.Domain.Models.Person.Profiles", false, false, "Profiles", "Hid.Checkpoint.Domain.Models.Person", "Person", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Person.Updated", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PersonProperty", "Обновлено", "Hid.Checkpoint.Domain.Models.Person.Updated", false, false, "Updated", "Hid.Checkpoint.Domain.Models.Person", "Person", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Code", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Код физлица", "Hid.Checkpoint.Domain.Models.Profile.Code", false, false, "Code", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Country", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Страна", "Hid.Checkpoint.Domain.Models.Profile.Country", false, false, "Country", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.CountryId", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Id страны", "Hid.Checkpoint.Domain.Models.Profile.CountryId", false, false, "CountryId", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Created", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Создано", "Hid.Checkpoint.Domain.Models.Profile.Created", false, false, "Created", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.DateOfBirth", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Дата рождения", "Hid.Checkpoint.Domain.Models.Profile.DateOfBirth", false, false, "DateOfBirth", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.DisabledDate", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Дата создания новой версии профиля", "Hid.Checkpoint.Domain.Models.Profile.DisabledDate", true, false, "DisabledDate", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.DismissalDate", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Дата увольнения", "Hid.Checkpoint.Domain.Models.Profile.DismissalDate", false, false, "DismissalDate", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Email", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Электронная почта", "Hid.Checkpoint.Domain.Models.Profile.Email", false, false, "Email", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.EmploymentDate", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Дата найма", "Hid.Checkpoint.Domain.Models.Profile.EmploymentDate", false, false, "EmploymentDate", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.ExternalId", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Внешний Id", "Hid.Checkpoint.Domain.Models.Profile.ExternalId", false, false, "ExternalId", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.ExternalIndividual", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Внешний код", "Hid.Checkpoint.Domain.Models.Profile.ExternalIndividual", false, false, "ExternalIndividual", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.FirstName", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Имя", "Hid.Checkpoint.Domain.Models.Profile.FirstName", false, false, "FirstName", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Id", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "", "Hid.Checkpoint.Domain.Models.Profile.Id", false, false, "Id", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Inn", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "ИНН", "Hid.Checkpoint.Domain.Models.Profile.Inn", false, false, "Inn", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.IsEmployee", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Признак сотрудника", "Hid.Checkpoint.Domain.Models.Profile.IsEmployee", false, false, "IsEmployee", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Removed", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Удалено", "Hid.Checkpoint.Domain.Models.Profile.Removed", false, false, "Removed", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.LastName", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Фамилия", "Hid.Checkpoint.Domain.Models.Profile.LastName", false, false, "LastName", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Okpdtr", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Код должности в классифкаторе профессий и должностей", "Hid.Checkpoint.Domain.Models.Profile.Okpdtr", false, false, "Okpdtr", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.OkpdtrTitle", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Название должности из классификатора профессий и должностей", "Hid.Checkpoint.Domain.Models.Profile.OkpdtrTitle", false, false, "OkpdtrTitle", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Организация", "Hid.Checkpoint.Domain.Models.Profile.Organization", false, false, "Organization", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.OrganizationId", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Id организации", "Hid.Checkpoint.Domain.Models.Profile.OrganizationId", false, false, "OrganizationId", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Patronymic", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Отчество", "Hid.Checkpoint.Domain.Models.Profile.Patronymic", false, false, "Patronymic", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Phone", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Номер телефона", "Hid.Checkpoint.Domain.Models.Profile.Phone", false, false, "Phone", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Position", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Позиция", "Hid.Checkpoint.Domain.Models.Profile.Position", false, false, "Position", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.PositionCode", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Код должности", "Hid.Checkpoint.Domain.Models.Profile.PositionCode", false, false, "PositionCode", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.PositionId", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Id позиции", "Hid.Checkpoint.Domain.Models.Profile.PositionId", false, false, "PositionId", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.TabN", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Табельный номер", "Hid.Checkpoint.Domain.Models.Profile.TabN", false, false, "TabN", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Updated", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Обновлено", "Hid.Checkpoint.Domain.Models.Profile.Updated", false, false, "Updated", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_approve_stage_id",
                table: "user",
                column: "approve_stage_id");

            migrationBuilder.AddForeignKey(
                name: "fk_approve_stage_user_approver_id",
                table: "approve_stage",
                column: "approver_id",
                principalTable: "user",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_approve_stage_approve_stage_id",
                table: "user",
                column: "approve_stage_id",
                principalTable: "approve_stage",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_approve_stage_user_approver_id",
                table: "approve_stage");

            migrationBuilder.DropForeignKey(
                name: "fk_user_approve_stage_approve_stage_id",
                table: "user");

            migrationBuilder.DropIndex(
                name: "ix_user_approve_stage_id",
                table: "user");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Address");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Code");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.ContractDescription");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Created");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Description");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.DisbandDate");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.ExternalId");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Id");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Imns");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.ImnsName");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Inn");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Removed");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Kpp");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Okato");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Okopf");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Okpo");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Oktmo");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Okved");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Subdivisions");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Title");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Type");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Updated");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Person.Created");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Person.Id");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Person.Removed");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Person.Profile");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Person.Profiles");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Person.Updated");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Code");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Country");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.CountryId");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Created");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.DateOfBirth");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.DisabledDate");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.DismissalDate");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Email");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.EmploymentDate");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.ExternalId");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.ExternalIndividual");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.FirstName");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Id");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Inn");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.IsEmployee");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Removed");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.LastName");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Okpdtr");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.OkpdtrTitle");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Organization");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.OrganizationId");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Patronymic");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Phone");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Position");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.PositionCode");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.PositionId");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.TabN");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Updated");

            migrationBuilder.DropColumn(
                name: "approve_stage_id",
                table: "user");

            migrationBuilder.DropColumn(
                name: "system_name",
                table: "user");

            migrationBuilder.DropColumn(
                name: "is_hidden",
                table: "customizable_property");

            migrationBuilder.AddColumn<int>(
                name: "approve_stage_id",
                table: "persons",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.ApproveChains",
                column: "display_name",
                value: null);

            migrationBuilder.UpdateData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Id",
                column: "display_name",
                value: "ID");

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
                name: "fk_persons_approve_stage_approve_stage_id",
                table: "persons",
                column: "approve_stage_id",
                principalTable: "approve_stage",
                principalColumn: "id");
        }
    }
}
