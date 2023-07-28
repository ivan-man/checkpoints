using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hid.Checkpoint.DataAccess.Ef.Migrations
{
    /// <inheritdoc />
    public partial class countries_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Removed");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Removed");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Person.Removed");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Removed");

            migrationBuilder.RenameColumn(
                name: "max_period",
                table: "pass_request_type",
                newName: "validity_period");
            
            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "pass_request_type",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "is_checkpoint_issue",
                table: "pass_request_type",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "max_validity_period",
                table: "pass_request_type",
                type: "interval",
                nullable: true);

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "id", "created", "iso2", "iso3", "name", "name_ru", "normalized_name", "normalized_name_ru", "number", "removed", "updated" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AU", "AUS", "Australia", "Австралия", "AUSTRALIA", "АВСТРАЛИЯ", 36, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AT", "AUT", "Austria", "Австрия", "AUSTRIA", "АВСТРИЯ", 40, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AZ", "AZE", "Azerbaijan", "Азербайджан", "AZERBAIJAN", "АЗЕРБАЙДЖАН", 31, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AL", "ALB", "Albania", "Албания", "ALBANIA", "АЛБАНИЯ", 8, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DZ", "DZA", "Algeria", "Алжир", "ALGERIA", "АЛЖИР", 12, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AI", "AIA", "Anguilla", "Ангилья о. (GB)", "ANGUILLA", "АНГИЛЬЯ О. (GB)", 660, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AO", "AGO", "Angola", "Ангола", "ANGOLA", "АНГОЛА", 24, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AD", "AND", "Andorra", "Андорра", "ANDORRA", "АНДОРРА", 20, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQ", "ATA", "Antarctic", "Антарктика", "ANTARCTIC", "АНТАРКТИКА", 10, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AG", "ATG", "Antigua and Barbuda", "Антигуа и Барбуда", "ANTIGUA AND BARBUDA", "АНТИГУА И БАРБУДА", 28, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AN", "ANT", "Netherlands' An lles", "Антильские о‐ва (NL)", "NETHERLANDS' AN LLES", "АНТИЛЬСКИЕ О‐ВА (NL)", 530, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AR", "ARG", "Argentina", "Аргентина", "ARGENTINA", "АРГЕНТИНА", 32, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AM", "ARM", "Armenia", "Армения", "ARMENIA", "АРМЕНИЯ", 51, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AW", "ABW", "Aruba", "Аруба", "ARUBA", "АРУБА", 533, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AF", "AFG", "Afghanistan", "Афганистан", "AFGHANISTAN", "АФГАНИСТАН", 4, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BS", "BHS", "Bahamas", "Багамы", "BAHAMAS", "БАГАМЫ", 44, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BD", "BGD", "Bangladesh", "Бангладеш", "BANGLADESH", "БАНГЛАДЕШ", 50, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BB", "BB", "Barbados", "Барбадос", "BARBADOS", "БАРБАДОС", 52, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BH", "BHR", "Bahrain", "Бахрейн", "BAHRAIN", "БАХРЕЙН", 48, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BY", "BLR", "Belarus", "Беларусь", "BELARUS", "БЕЛАРУСЬ", 112, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BZ", "BLZ", "Belize", "Белиз", "BELIZE", "БЕЛИЗ", 84, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BE", "BEL", "Belgium", "Бельгия", "BELGIUM", "БЕЛЬГИЯ", 56, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BJ", "BEN", "Benin", "Бенин", "BENIN", "БЕНИН", 204, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BM", "BMU", "Bermuda", "Бермуды", "BERMUDA", "БЕРМУДЫ", 60, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BV", "BVT", "Bouvet Island", "Бове о. (NO)", "BOUVET ISLAND", "БОВЕ О. (NO)", 74, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BG", "BGR", "Bulgaria", "Болгария", "BULGARIA", "БОЛГАРИЯ", 100, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BO", "BOL", "Bolivia", "Боливия", "BOLIVIA", "БОЛИВИЯ", 68, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BA", "BIH", "Bosnia and Herzegovina", "Босния и Герцеговина", "BOSNIA AND HERZEGOVINA", "БОСНИЯ И ГЕРЦЕГОВИНА", 70, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BW", "BWA", "Botswana", "Ботсвана", "BOTSWANA", "БОТСВАНА", 72, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BR", "BRA", "Brazil", "Бразилия", "BRAZIL", "БРАЗИЛИЯ", 76, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BN", "BRN", "Brunei Darussalam", "Бруней Дарассалам", "BRUNEI DARUSSALAM", "БРУНЕЙ ДАРАССАЛАМ", 96, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BF", "BFA", "Burkina‐Faso", "Буркина‐Фасо", "BURKINA‐FASO", "БУРКИНА‐ФАСО", 854, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BI", "BDI", "Burundi", "Бурунди", "BURUNDI", "БУРУНДИ", 108, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BT", "BTN", "Bhutan", "Бутан", "BHUTAN", "БУТАН", 64, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VU", "VUT", "Vanuatu", "Вануату", "VANUATU", "ВАНУАТУ", 548, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VA", "VAT", "Vatican (Holy See)", "Ватикан", "VATICAN (HOLY SEE)", "ВАТИКАН", 336, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GB", "GBR", "Great Britain (United Kingdom)", "Великобритания", "GREAT BRITAIN (UNITED KINGDOM)", "ВЕЛИКОБРИТАНИЯ", 826, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HU", "HUN", "Hungary", "Венгрия", "HUNGARY", "ВЕНГРИЯ", 348, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VE", "VEN", "Venezuela", "Венесуэла", "VENEZUELA", "ВЕНЕСУЭЛА", 862, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VG", "VGB", "Virgin Islands, British", "Виргинские о‐ва (GB)", "VIRGIN ISLANDS, BRITISH", "ВИРГИНСКИЕ О‐ВА (GB)", 92, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VI", "VIR", "Virgin Islands, US", "Виргинские о‐ва (US)", "VIRGIN ISLANDS, US", "ВИРГИНСКИЕ О‐ВА (US)", 850, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AS", "ASM", "American Samoa", "Восточное Самоа (US)", "AMERICAN SAMOA", "ВОСТОЧНОЕ САМОА (US)", 16, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TP", "TMP", "East Timor", "Восточный Тимор", "EAST TIMOR", "ВОСТОЧНЫЙ ТИМОР", 626, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VN", "VNM", "Viet Nam", "Вьетнам", "VIET NAM", "ВЬЕТНАМ", 704, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GA", "GAB", "Gabon", "Габон", "GABON", "ГАБОН", 266, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HT", "HTI", "Haiti", "Гаити", "HAITI", "ГАИТИ", 332, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GY", "GUY", "Guyana", "Гайана", "GUYANA", "ГАЙАНА", 328, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GM", "GMB", "Gambia", "Гамбия", "GAMBIA", "ГАМБИЯ", 270, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GH", "GHA", "Ghana", "Гана", "GHANA", "ГАНА", 288, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GP", "GLP", "Guadeloupe", "Гваделупа", "GUADELOUPE", "ГВАДЕЛУПА", 312, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GT", "GTM", "Guatemala", "Гватемала", "GUATEMALA", "ГВАТЕМАЛА", 320, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GN", "GIN", "Guinea", "Гвинея", "GUINEA", "ГВИНЕЯ", 324, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GW", "GNB", "Guinea‐Bissau", "Гвинея‐Бисау", "GUINEA‐BISSAU", "ГВИНЕЯ‐БИСАУ", 624, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DE", "DEU", "Germany", "Германия", "GERMANY", "ГЕРМАНИЯ", 276, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GI", "GIB", "Gibraltar", "Гибралтар", "GIBRALTAR", "ГИБРАЛТАР", 292, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HN", "HND", "Honduras", "Гондурас", "HONDURAS", "ГОНДУРАС", 340, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HK", "HKG", "Hong Kong", "Гонконг (CN", "HONG KONG", "ГОНКОНГ (CN", 344, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GD", "GRD", "Grenada", "Гренада", "GRENADA", "ГРЕНАДА", 308, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GL", "GRL", "Greenland", "Гренландия (DK)", "GREENLAND", "ГРЕНЛАНДИЯ (DK)", 304, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GR", "GRC", "Greece", "Греция", "GREECE", "ГРЕЦИЯ", 300, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE", "GEO", "Georgia", "Грузия", "GEORGIA", "ГРУЗИЯ", 268, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GU", "GUM", "Guam", "Гуам", "GUAM", "ГУАМ", 316, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DK", "DNK", "Denmark", "Дания", "DENMARK", "ДАНИЯ", 208, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CD", "COD", "Congo, Democratic Republic of the", "Демократическая Республика Конго", "CONGO, DEMOCRATIC REPUBLIC OF THE", "ДЕМОКРАТИЧЕСКАЯ РЕСПУБЛИКА КОНГО", 180, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DJ", "DJI", "Djibouti", "Джибути", "DJIBOUTI", "ДЖИБУТИ", 262, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DM", "DMA", "Dominica", "Доминика", "DOMINICA", "ДОМИНИКА", 212, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DO", "DOM", "Dominican Republic", "Доминиканская Республика", "DOMINICAN REPUBLIC", "ДОМИНИКАНСКАЯ РЕСПУБЛИКА", 214, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EG", "EGY", "Egypt", "Египет", "EGYPT", "ЕГИПЕТ", 818, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZM", "ZMB", "Zambia", "Замбия", "ZAMBIA", "ЗАМБИЯ", 894, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EH", "ESH", "Western Sahara", "Западная Сахара", "WESTERN SAHARA", "ЗАПАДНАЯ САХАРА", 732, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZW", "ZWE", "Zimbabwe", "Зимбабве", "ZIMBABWE", "ЗИМБАБВЕ", 716, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IL", "ISR", "Israel", "Израиль", "ISRAEL", "ИЗРАИЛЬ", 376, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IN", "IND", "India", "Индия", "INDIA", "ИНДИЯ", 356, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ID", "IDN", "Indonesia", "Индонезия", "INDONESIA", "ИНДОНЕЗИЯ", 360, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JO", "JOR", "Jordan", "Иордания", "JORDAN", "ИОРДАНИЯ", 400, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IQ", "IRQ", "Iraq", "Ирак", "IRAQ", "ИРАК", 368, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IR", "IRN", "Iran", "Иран", "IRAN", "ИРАН", 364, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IE", "IRL", "Ireland", "Ирландия", "IRELAND", "ИРЛАНДИЯ", 372, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IS", "ISL", "Iceland", "Исландия", "ICELAND", "ИСЛАНДИЯ", 352, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ES", "ESP", "Spain", "Испания", "SPAIN", "ИСПАНИЯ", 724, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "ITA", "Italy", "Италия", "ITALY", "ИТАЛИЯ", 380, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YE", "YEM", "Yemen", "Йемен", "YEMEN", "ЙЕМЕН", 887, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CV", "CPV", "Cape Verde", "Кабо‐Верде", "CAPE VERDE", "КАБО‐ВЕРДЕ", 132, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KZ", "KAZ", "Kazakhstan", "Казахстан", "KAZAKHSTAN", "КАЗАХСТАН", 398, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KY", "CYM", "Cayman Islands", "Каймановы о‐ва (GB)", "CAYMAN ISLANDS", "КАЙМАНОВЫ О‐ВА (GB)", 136, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KH", "KHM", "Cambodia", "Камбоджа", "CAMBODIA", "КАМБОДЖА", 116, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CM", "CMR", "Cameroon", "Камерун", "CAMEROON", "КАМЕРУН", 120, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CA", "CAN", "Canada", "Канада", "CANADA", "КАНАДА", 124, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "QA", "QAT", "Qatar", "Катар", "QATAR", "КАТАР", 634, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KE", "KEN", "Kenya", "Кения", "KENYA", "КЕНИЯ", 404, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CY", "CYP", "Cyprus", "Кипр", "CYPRUS", "КИПР", 196, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KG", "KGZ", "Kirghizstan", "Киргизстан", "KIRGHIZSTAN", "КИРГИЗСТАН", 417, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KI", "KIR", "Kiribati", "Кирибати", "KIRIBATI", "КИРИБАТИ", 296, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CN", "CHN", "China", "Китай", "CHINA", "КИТАЙ", 156, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CC", "CCK", "Cocos (Keeling) Islands", "Кокосовые (Киилинг) о‐ва (AU)", "COCOS (KEELING) ISLANDS", "КОКОСОВЫЕ (КИИЛИНГ) О‐ВА (AU)", 166, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CO", "COL", "Colombia", "Колумбия", "COLOMBIA", "КОЛУМБИЯ", 170, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KM", "COM", "Comoros", "Коморские о‐ва", "COMOROS", "КОМОРСКИЕ О‐ВА", 174, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CG", "COG", "Congo", "Конго", "CONGO", "КОНГО", 178, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CR", "CRI", "Costa Rica", "Коста‐Рика", "COSTA RICA", "КОСТА‐РИКА", 188, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CI", "CIV", "Cote d'Ivoire", "Кот‐д'Ивуар", "COTE D'IVOIRE", "КОТ‐Д'ИВУАР", 384, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CU", "CUB", "Cuba", "Куба", "CUBA", "КУБА", 192, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KW", "KWT", "Kuwait", "Кувейт", "KUWAIT", "КУВЕЙТ", 414, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 103, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CK", "COK", "Cook Islands", "Кука о‐ва (NZ)", "COOK ISLANDS", "КУКА О‐ВА (NZ)", 184, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 104, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LA", "LAO", "Lao People's Democratic Republic", "Лаос", "LAO PEOPLE'S DEMOCRATIC REPUBLIC", "ЛАОС", 418, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LV", "LVA", "Latvia", "Латвия", "LATVIA", "ЛАТВИЯ", 428, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 106, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LS", "LSO", "Lesotho", "Лесото", "LESOTHO", "ЛЕСОТО", 426, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 107, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LR", "LBR", "Liberia", "Либерия", "LIBERIA", "ЛИБЕРИЯ", 430, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 108, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LB", "LBN", "Lebanon", "Ливан", "LEBANON", "ЛИВАН", 422, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 109, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LY", "LBY", "Libyan Arab Jamahiriya", "Ливия", "LIBYAN ARAB JAMAHIRIYA", "ЛИВИЯ", 434, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 110, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LT", "LTU", "Lithuania", "Литва", "LITHUANIA", "ЛИТВА", 440, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LI", "LIE", "Liechtenstein", "Лихтенштейн", "LIECHTENSTEIN", "ЛИХТЕНШТЕЙН", 438, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LU", "LUX", "Luxembourg", "Люксембург", "LUXEMBOURG", "ЛЮКСЕМБУРГ", 442, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 113, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MU", "MUS", "Mauritius", "Маврикий", "MAURITIUS", "МАВРИКИЙ", 480, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 114, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MR", "MRT", "Mauritania", "Мавритания", "MAURITANIA", "МАВРИТАНИЯ", 478, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 115, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MG", "MDG", "Madagascar", "Мадагаскар", "MADAGASCAR", "МАДАГАСКАР", 450, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 116, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YT", "MYT", "Mayotte", "Майотта о. (KM)", "MAYOTTE", "МАЙОТТА О. (KM)", 175, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 117, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MO", "MAC", "Macau (Macao)", "Макао (PT)", "MACAU (MACAO)", "МАКАО (PT)", 446, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 118, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MK", "MKD", "Macedonia", "Македония", "MACEDONIA", "МАКЕДОНИЯ", 807, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 119, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MW", "MWI", "Malawi", "Малави", "MALAWI", "МАЛАВИ", 454, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 120, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MY", "MYS", "Malaysia", "Малайзия", "MALAYSIA", "МАЛАЙЗИЯ", 458, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 121, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ML", "MLI", "Mali", "Мали", "MALI", "МАЛИ", 466, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 122, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MV", "MDV", "Maldives", "Мальдивы", "MALDIVES", "МАЛЬДИВЫ", 462, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 123, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MT", "MLT", "Malta", "Мальта", "MALTA", "МАЛЬТА", 470, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 124, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MA", "MAR", "Marocco", "Марокко", "MAROCCO", "МАРОККО", 504, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 125, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MQ", "MTQ", "Martinique", "Мартиника", "MARTINIQUE", "МАРТИНИКА", 474, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 126, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MH", "MHL", "Marshall Islands", "Маршалловы о‐ва", "MARSHALL ISLANDS", "МАРШАЛЛОВЫ О‐ВА", 584, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 127, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MX", "MEX", "Mexico", "Мексика", "MEXICO", "МЕКСИКА", 484, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 128, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FM", "FSM", "Federated States of Micronesia", "Микронезия (US)", "FEDERATED STATES OF MICRONESIA", "МИКРОНЕЗИЯ (US)", 583, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 129, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MZ", "MOZ", "Mozambique", "Мозамбик", "MOZAMBIQUE", "МОЗАМБИК", 508, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 130, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MD", "MDA", "Moldova", "Молдова", "MOLDOVA", "МОЛДОВА", 498, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 131, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MC", "MCO", "Monaco", "Монако", "MONACO", "МОНАКО", 492, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 132, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MN", "MNG", "Mongolia", "Монголия", "MONGOLIA", "МОНГОЛИЯ", 496, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 133, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MS", "MSR", "Montserrat", "Монсеррат о. (GB)", "MONTSERRAT", "МОНСЕРРАТ О. (GB)", 500, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 134, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MM", "MMR", "Myanmar", "Мьянма", "MYANMAR", "МЬЯНМА", 104, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 135, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NA", "NAM", "Namibia", "Намибия", "NAMIBIA", "НАМИБИЯ", 516, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 136, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NR", "NRU", "Nauru", "Науру", "NAURU", "НАУРУ", 520, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 137, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NP", "NPL", "Nepal", "Непал", "NEPAL", "НЕПАЛ", 524, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 138, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NE", "NER", "Niger", "Нигер", "NIGER", "НИГЕР", 562, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 139, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NG", "NGA", "Nigeria", "Нигерия", "NIGERIA", "НИГЕРИЯ", 566, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 140, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NL", "NLD", "Netherlands (Holland)", "Нидерланды", "NETHERLANDS (HOLLAND)", "НИДЕРЛАНДЫ", 528, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 141, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NI", "NIC", "Nicaragua", "Никарагуа", "NICARAGUA", "НИКАРАГУА", 558, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 142, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NU", "NIU", "Niue", "Ниуэ о. (NZ)", "NIUE", "НИУЭ О. (NZ)", 570, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 143, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NZ", "NZL", "New Zealand", "Новая Зеландия", "NEW ZEALAND", "НОВАЯ ЗЕЛАНДИЯ", 554, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 144, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NC", "NCL", "New Caledonia", "Новая Каледония о. (FR)", "NEW CALEDONIA", "НОВАЯ КАЛЕДОНИЯ О. (FR)", 540, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 145, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NO", "NOR", "Norway", "Норвегия", "NORWAY", "НОРВЕГИЯ", 578, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 146, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NF", "NFK", "Norfolk Island", "Норфолк о. (AU)", "NORFOLK ISLAND", "НОРФОЛК О. (AU)", 574, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 147, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AE", "ARE", "United Arab Emirates", "Объединенные Арабские Эмираты", "UNITED ARAB EMIRATES", "ОБЪЕДИНЕННЫЕ АРАБСКИЕ ЭМИРАТЫ", 784, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 148, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OM", "OMN", "Oman", "Оман", "OMAN", "ОМАН", 512, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 149, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PK", "PAK", "Pakistan", "Пакистан", "PAKISTAN", "ПАКИСТАН", 586, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 150, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PW", "PLW", "Palau", "Палау (US)", "PALAU", "ПАЛАУ (US)", 585, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 151, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PS", "PSE", "Pales nian Territory (occupied)", "Палестинская автономия", "PALES NIAN TERRITORY (OCCUPIED)", "ПАЛЕСТИНСКАЯ АВТОНОМИЯ", 275, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 152, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PA", "PAN", "Panama", "Панама", "PANAMA", "ПАНАМА", 591, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 153, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PG", "PNG", "Papua New Guinea", "Папуа‐Новая Гвинея", "PAPUA NEW GUINEA", "ПАПУА‐НОВАЯ ГВИНЕЯ", 598, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 154, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PY", "PRY", "Paraguay", "Парагвай", "PARAGUAY", "ПАРАГВАЙ", 600, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 155, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PE", "PER", "Peru", "Перу", "PERU", "ПЕРУ", 604, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 156, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PN", "PCN", "Pitcairn", "Питкэрн о‐ва (GB)", "PITCAIRN", "ПИТКЭРН О‐ВА (GB)", 612, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 157, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PL", "POL", "Poland", "Польша", "POLAND", "ПОЛЬША", 616, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 158, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PT", "PRT", "Portugal", "Португалия", "PORTUGAL", "ПОРТУГАЛИЯ", 620, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 159, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR", "PRI", "Puerto Rico", "Пуэрто‐Рико (US)", "PUERTO RICO", "ПУЭРТО‐РИКО (US)", 630, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 160, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RE", "REU", "Reunion", "Реюньон о. (FR)", "REUNION", "РЕЮНЬОН О. (FR)", 638, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 161, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CX", "CXR", "Christmas Island", "Рождества о. (AU)", "CHRISTMAS ISLAND", "РОЖДЕСТВА О. (AU)", 162, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 162, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RU", "RUS", "Russia (Russian Federation)", "Россия", "RUSSIA (RUSSIAN FEDERATION)", "РОССИЯ", 643, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 163, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RW", "RWA", "Rwanda", "Руанда", "RWANDA", "РУАНДА", 646, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 164, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RO", "ROM", "Romania", "Румыния", "ROMANIA", "РУМЫНИЯ", 642, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 165, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SV", "SLV", "El Salvador", "Сальвадор", "EL SALVADOR", "САЛЬВАДОР", 222, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 166, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WS", "WSM", "Samoa", "Самоа", "SAMOA", "САМОА", 882, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 167, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SM", "SMR", "San Marino", "Сан Марино", "SAN MARINO", "САН МАРИНО", 674, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 168, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ST", "STP", "Sao Tomea and Principe", "Сан‐Томе и Принсипи", "SAO TOMEA AND PRINCIPE", "САН‐ТОМЕ И ПРИНСИПИ", 678, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 169, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SA", "SAU", "Saudi Arabia", "Саудовская Аравия", "SAUDI ARABIA", "САУДОВСКАЯ АРАВИЯ", 682, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 170, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SZ", "SWZ", "Swaziland", "Свазиленд", "SWAZILAND", "СВАЗИЛЕНД", 748, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 171, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SJ", "SJM", "Svalbard and Jan Mayen Islands", "Свалбард и Ян Мейен о‐ва (NO)", "SVALBARD AND JAN MAYEN ISLANDS", "СВАЛБАРД И ЯН МЕЙЕН О‐ВА (NO)", 744, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 172, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SH", "SHN", "St. Helena", "Святой Елены о. (GB)", "ST. HELENA", "СВЯТОЙ ЕЛЕНЫ О. (GB)", 654, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 173, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KP", "PRK", "Korea (North)", "Северная Корея (КНДР)", "KOREA (NORTH)", "СЕВЕРНАЯ КОРЕЯ (КНДР)", 408, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 174, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MP", "MNP", "Northern Mariana Islands", "Северные Марианские", "NORTHERN MARIANA ISLANDS", "СЕВЕРНЫЕ МАРИАНСКИЕ", 580, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 175, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SC", "SYC", "Seychelles", "Сейшелы", "SEYCHELLES", "СЕЙШЕЛЫ", 690, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 176, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VC", "VCT", "Saint Vincent and the Grenadines", "Сен‐Винсент и Гренадины", "SAINT VINCENT AND THE GRENADINES", "СЕН‐ВИНСЕНТ И ГРЕНАДИНЫ", 670, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 177, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PM", "SPM", "St. Pierre and Miquelon", "Сен‐Пьер и Микелон (FR)", "ST. PIERRE AND MIQUELON", "СЕН‐ПЬЕР И МИКЕЛОН (FR)", 666, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 178, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SN", "SEN", "Senegal", "Сенегал", "SENEGAL", "СЕНЕГАЛ", 686, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 179, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KN", "KNA", "Saint Kitts (Christopher) and Nevis", "Сент‐Кристофер и Невис", "SAINT KITTS (CHRISTOPHER) AND NEVIS", "СЕНТ‐КРИСТОФЕР И НЕВИС", 659, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 180, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LC", "LCA", "Saint Lucia", "Сент‐Люсия", "SAINT LUCIA", "СЕНТ‐ЛЮСИЯ", 662, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 181, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SG", "SGP", "Singapore", "Сингапур", "SINGAPORE", "СИНГАПУР", 702, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 182, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SY", "SYR", "Syria", "Сирия", "SYRIA", "СИРИЯ", 760, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 183, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SK", "SVK", "Slovak Republic", "Словакия", "SLOVAK REPUBLIC", "СЛОВАКИЯ", 703, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 184, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SI", "SVN", "Slovenia", "Словения", "SLOVENIA", "СЛОВЕНИЯ", 705, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 185, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "US", "USA", "United States of America", "Соединенные Штаты Америки", "UNITED STATES OF AMERICA", "СОЕДИНЕННЫЕ ШТАТЫ АМЕРИКИ", 840, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 186, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SB", "SLB", "Solomon Islands", "Соломоновы о‐ва", "SOLOMON ISLANDS", "СОЛОМОНОВЫ О‐ВА", 90, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 187, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SO", "SOM", "Somali", "Сомали", "SOMALI", "СОМАЛИ", 706, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 188, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SD", "SDN", "Sudan", "Судан", "SUDAN", "СУДАН", 736, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 189, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SR", "SUR", "Surinam", "Суринам", "SURINAM", "СУРИНАМ", 740, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 190, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SL", "SLE", "Sierra Leone", "Сьерра‐Леоне", "SIERRA LEONE", "СЬЕРРА‐ЛЕОНЕ", 694, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 191, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TJ", "TJK", "Tadjikistan", "Таджикистан", "TADJIKISTAN", "ТАДЖИКИСТАН", 762, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 192, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TH", "THA", "Thailand", "Таиланд", "THAILAND", "ТАИЛАНД", 764, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 193, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TW", "TWN", "Taiwan", "Тайвань", "TAIWAN", "ТАЙВАНЬ", 158, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 194, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TZ", "TZA", "Tanzania", "Танзания", "TANZANIA", "ТАНЗАНИЯ", 834, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 195, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TC", "TCA", "Turks and Caicos Islands", "Теркс и Кайкос о‐ва (GB)", "TURKS AND CAICOS ISLANDS", "ТЕРКС И КАЙКОС О‐ВА (GB)", 796, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 196, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TG", "TGO", "Togo", "Того", "TOGO", "ТОГО", 768, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 197, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TK", "TKL", "Tokelau", "Токелау о‐ва (NZ)", "TOKELAU", "ТОКЕЛАУ О‐ВА (NZ)", 772, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 198, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TO", "TON", "Tonga", "Тонга", "TONGA", "ТОНГА", 776, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 199, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TT", "TTO", "Trinidad and Tobago", "Тринидад и Тобаго", "TRINIDAD AND TOBAGO", "ТРИНИДАД И ТОБАГО", 780, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 200, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TV", "TUV", "Tuvalu", "Тувалу", "TUVALU", "ТУВАЛУ", 798, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 201, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TN", "TUN", "Tunisia", "Тунис", "TUNISIA", "ТУНИС", 788, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 202, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TM", "TKM", "Turkmenistan", "Туркменистан", "TURKMENISTAN", "ТУРКМЕНИСТАН", 795, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 203, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TR", "TUR", "Turkey", "Турция", "TURKEY", "ТУРЦИЯ", 792, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 204, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UG", "UGA", "Uganda", "Уганда", "UGANDA", "УГАНДА", 800, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 205, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UZ", "UZB", "Uzbekistan", "Узбекистан", "UZBEKISTAN", "УЗБЕКИСТАН", 860, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 206, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UA", "UKR", "Ukraine", "Украина", "UKRAINE", "УКРАИНА", 804, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 207, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WF", "WLF", "Wallis and Futuna Islands", "Уоллис и Футунао‐ва (FR)", "WALLIS AND FUTUNA ISLANDS", "УОЛЛИС И ФУТУНАО‐ВА (FR)", 876, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 208, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UY", "URY", "Uruguay", "Уругвай", "URUGUAY", "УРУГВАЙ", 858, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 209, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FO", "FRO", "Faroe Islands", "Фарерские о‐ва (DK)", "FAROE ISLANDS", "ФАРЕРСКИЕ О‐ВА (DK)", 234, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 210, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FJ", "FJI", "Fiji", "Фиджи", "FIJI", "ФИДЖИ", 242, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 211, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PH", "PHL", "Philippines", "Филиппины", "PHILIPPINES", "ФИЛИППИНЫ", 608, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 212, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FI", "FIN", "Finland", "Финляндия", "FINLAND", "ФИНЛЯНДИЯ", 246, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 213, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FK", "FLK", "Falkland (Malvinas) Islands", "Фолклендские (Мальвинские) о‐ва (GB/AR)", "FALKLAND (MALVINAS) ISLANDS", "ФОЛКЛЕНДСКИЕ (МАЛЬВИНСКИЕ) О‐ВА (GB/AR)", 238, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 214, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FR", "FRA", "France", "Франция", "FRANCE", "ФРАНЦИЯ", 250, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 215, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GF", "GUF", "French Guyana", "Французская Гвиана (FR)", "FRENCH GUYANA", "ФРАНЦУЗСКАЯ ГВИАНА (FR)", 254, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 216, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PF", "PYF", "French Polynesia", "Французская Полинезия", "FRENCH POLYNESIA", "ФРАНЦУЗСКАЯ ПОЛИНЕЗИЯ", 258, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 217, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HM", "HMD", "Heard and McDonald Islands", "Херд и Макдональд о‐ва (AU)", "HEARD AND MCDONALD ISLANDS", "ХЕРД И МАКДОНАЛЬД О‐ВА (AU)", 334, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 218, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR", "HRV", "Croatia", "Хорватия", "CROATIA", "ХОРВАТИЯ", 191, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 219, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CF", "CAF", "Central African Republic", "Центрально‐африканская Республика", "CENTRAL AFRICAN REPUBLIC", "ЦЕНТРАЛЬНО‐АФРИКАНСКАЯ РЕСПУБЛИКА", 140, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 220, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TD", "TCD", "Chad", "Чад", "CHAD", "ЧАД", 148, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 221, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CZ", "CZE", "Czech Republic", "Чехия", "CZECH REPUBLIC", "ЧЕХИЯ", 203, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 222, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CL", "CHL", "Chili", "Чили", "CHILI", "ЧИЛИ", 152, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 223, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CH", "CHE", "Switzerland", "Швейцария", "SWITZERLAND", "ШВЕЙЦАРИЯ", 756, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 224, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SE", "SWE", "Sweden", "Швеция", "SWEDEN", "ШВЕЦИЯ", 752, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 225, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LK", "LKA", "Sri Lanka", "Шри‐Ланка", "SRI LANKA", "ШРИ‐ЛАНКА", 144, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 226, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EC", "ECU", "Ecuador", "Эквадор", "ECUADOR", "ЭКВАДОР", 218, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 227, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GQ", "GNQ", "Equatorial Guinea", "Экваториальная Гвинея", "EQUATORIAL GUINEA", "ЭКВАТОРИАЛЬНАЯ ГВИНЕЯ", 226, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 228, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ER", "ERI", "Eritrea", "Эритрия", "ERITREA", "ЭРИТРИЯ", 232, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 229, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EE", "EST", "Estonia", "Эстония", "ESTONIA", "ЭСТОНИЯ", 233, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 230, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ET", "ETH", "Ethiopia", "Эфиопия", "ETHIOPIA", "ЭФИОПИЯ", 231, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 231, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YU", "YUG", "Yugoslavia", "Югославия", "YUGOSLAVIA", "ЮГОСЛАВИЯ", 891, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 232, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZA", "ZAF", "South Africa", "Южная Африка", "SOUTH AFRICA", "ЮЖНАЯ АФРИКА", 710, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 233, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GS", "SGS", "South Georgia and the South Sandwich Islands", "Южная Георгия и Южные Сандвичевы о‐ва", "SOUTH GEORGIA AND THE SOUTH SANDWICH ISLANDS", "ЮЖНАЯ ГЕОРГИЯ И ЮЖНЫЕ САНДВИЧЕВЫ О‐ВА", 239, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 234, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KR", "KOR", "Korea (South)", "Южная Корея (Республика Корея)", "KOREA (SOUTH)", "ЮЖНАЯ КОРЕЯ (РЕСПУБЛИКА КОРЕЯ)", 410, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 235, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JM", "JAM", "Jamaica", "Ямайка", "JAMAICA", "ЯМАЙКА", 388, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 236, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JP", "JPN", "Japan", "Япония", "JAPAN", "ЯПОНИЯ", 392, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 237, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TF", "ATF", "French Southern Territories", "Французские южные территории (FR)", "FRENCH SOUTHERN TERRITORIES", "ФРАНЦУЗСКИЕ ЮЖНЫЕ ТЕРРИТОРИИ (FR)", 260, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 238, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IO", "IOT", "British Indian Ocean Territory", "Британская территория Индийского океана (GB)", "BRITISH INDIAN OCEAN TERRITORY", "БРИТАНСКАЯ ТЕРРИТОРИЯ ИНДИЙСКОГО ОКЕАНА (GB)", 86, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 239, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UM", "UMI", "United States Minor Outlying Islands", "Соединенные Штаты Америки Внешние малые острова (US)", "UNITED STATES MINOR OUTLYING ISLANDS", "СОЕДИНЕННЫЕ ШТАТЫ АМЕРИКИ ВНЕШНИЕ МАЛЫЕ ОСТРОВА (US)", 581, false, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "customizable_property",
                columns: new[] { "id", "created", "discriminator", "display_name", "interface_id", "is_hidden", "name", "removed", "type_full_name", "type_name", "updated" },
                values: new object[,]
                {
                    { "Hid.Checkpoint.Domain.Models.Organization.Removed", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Удалено", "Hid.Checkpoint.Domain.Models.Organization.Removed", false, "Removed", false, "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Removed", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Удалено", "Hid.Checkpoint.Domain.Models.PassRequest.Removed", false, "Removed", false, "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Person.Removed", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PersonProperty", "Удалено", "Hid.Checkpoint.Domain.Models.Person.Removed", false, "Removed", false, "Hid.Checkpoint.Domain.Models.Person", "Person", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Removed", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Удалено", "Hid.Checkpoint.Domain.Models.Profile.Removed", false, "Removed", false, "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Organization.Removed");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.PassRequest.Removed");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Person.Removed");

            migrationBuilder.DeleteData(
                table: "customizable_property",
                keyColumn: "id",
                keyValue: "Hid.Checkpoint.Domain.Models.Profile.Removed");

            migrationBuilder.DropColumn(
                name: "is_checkpoint_issue",
                table: "pass_request_type");

            migrationBuilder.DropColumn(
                name: "max_validity_period",
                table: "pass_request_type");

            

            migrationBuilder.RenameColumn(
                name: "validity_period",
                table: "pass_request_type",
                newName: "max_period");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "pass_request_type",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "customizable_property",
                columns: new[] { "id", "created", "discriminator", "display_name", "interface_id", "is_hidden", "removed", "name", "type_full_name", "type_name", "updated" },
                values: new object[,]
                {
                    { "Hid.Checkpoint.Domain.Models.Organization.Removed", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "OrganizationProperty", "Удалено", "Hid.Checkpoint.Domain.Models.Organization.Removed", false, false, "Removed", "Hid.Checkpoint.Domain.Models.Organization", "Organization", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.PassRequest.Removed", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "RequestProperty", "Удалено", "Hid.Checkpoint.Domain.Models.PassRequest.Removed", false, false, "Removed", "Hid.Checkpoint.Domain.Models.PassRequest", "PassRequest", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Person.Removed", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PersonProperty", "Удалено", "Hid.Checkpoint.Domain.Models.Person.Removed", false, false, "Removed", "Hid.Checkpoint.Domain.Models.Person", "Person", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "Hid.Checkpoint.Domain.Models.Profile.Removed", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileProperty", "Удалено", "Hid.Checkpoint.Domain.Models.Profile.Removed", false, false, "Removed", "Hid.Checkpoint.Domain.Models.Profile", "Profile", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
