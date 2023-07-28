using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hid.Checkpoint.DataAccess.Ef.Migrations
{
    /// <inheritdoc />
    public partial class properties_request_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "customizable_property",
                columns: new[] { "id", "created", "discriminator", "display_name", "interface_id", "removed", "name", "type_full_name", "type_name", "updated" },
                values: new object[,]
                {
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Additional", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Дополнительно", "Hid.Checkpoint.Domain.Models.PassRequest.Additional", false, "Additional", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.ApproveChains", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", null, "Hid.Checkpoint.Domain.Models.PassRequest.ApproveChains", false, "ApproveChains", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Author", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Автор", "Hid.Checkpoint.Domain.Models.PassRequest.Author", false, "Author", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Created", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Создано", "Hid.Checkpoint.Domain.Models.PassRequest.Created", false, "Created", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Date", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Дата запроса", "Hid.Checkpoint.Domain.Models.PassRequest.Date", false, "Date", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Devices", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Устройства", "Hid.Checkpoint.Domain.Models.PassRequest.Devices", false, "Devices", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.ExpiredDate", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Действует до", "Hid.Checkpoint.Domain.Models.PassRequest.ExpiredDate", false, "ExpiredDate", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Guests", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Посетители", "Hid.Checkpoint.Domain.Models.PassRequest.Guests", false, "Guests", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Id", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "ID", "Hid.Checkpoint.Domain.Models.PassRequest.Id", false, "Id", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Removed", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Удалено", "Hid.Checkpoint.Domain.Models.PassRequest.Removed", false, "Removed", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.RequestType", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Тип запроса", "Hid.Checkpoint.Domain.Models.PassRequest.RequestType", false, "RequestType", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.RequestTypeId", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Id типа запроса", "Hid.Checkpoint.Domain.Models.PassRequest.RequestTypeId", false, "RequestTypeId", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Updated", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Обновлено", "Hid.Checkpoint.Domain.Models.PassRequest.Updated", false, "Updated", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.VisitPurpose", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Цель визита", "Hid.Checkpoint.Domain.Models.PassRequest.VisitPurpose", false, "VisitPurpose", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Additional");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.ApproveChains");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Author");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Created");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Date");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Devices");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.ExpiredDate");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Guests");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Id");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Removed");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.RequestType");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.RequestTypeId");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Updated");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.VisitPurpose");
        }
    }
}
