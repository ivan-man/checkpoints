using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hid.Checkpoint.DataAccess.Ef.Migrations
{
    /// <inheritdoc />
    public partial class seed_pass_request_types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "pass_request_type",
                columns: new[] { "id", "created", "description", "display_name", "enabled", "is_checkpoint_issue", "max_validity_period", "removed", "updated", "validity_period" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Постоянный пропуск", "Постоянный пропуск", true, false, null, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Разовый пропуск", "Разовый пропуск", true, false, new TimeSpan(1, 0, 0, 0, 0), false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(1, 0, 0, 0, 0) },
                    { 3, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Иностранный посетитель", "Иностранный посетитель", true, false, null, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Единый пропуск", "Единый пропуск ", true, false, new TimeSpan(180, 0, 0, 0, 0), false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Списочный пропуск", "Списочный пропуск", true, true, new TimeSpan(30, 0, 0, 0, 0), false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Выход в выходной день", "Выход в выходной день", true, true, new TimeSpan(1, 0, 0, 0, 0), false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Материальный пропуск", "Материальный пропуск", true, true, null, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пропуск посетителя ", "Пропуск посетителя ", true, false, new TimeSpan(90, 0, 0, 0, 0), false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "pass_request_type",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "pass_request_type",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "pass_request_type",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "pass_request_type",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "pass_request_type",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "pass_request_type",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "pass_request_type",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "pass_request_type",
                keyColumn: "id",
                keyValue: 8);
        }
    }
}
