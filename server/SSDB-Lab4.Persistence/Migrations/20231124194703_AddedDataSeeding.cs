using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SSDB_Lab4.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_divisions_weight",
                table: "divisions");

            migrationBuilder.AlterColumn<double>(
                name: "min_weight",
                table: "divisions",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "max_weight",
                table: "divisions",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "weighting_result",
                table: "competitors",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "competitions",
                columns: new[] { "competition_id", "city", "duration", "name", "start_date" },
                values: new object[,]
                {
                    { 1, "Черкаси", 2, "Кубок України серед старших юнаків, юніорів, дорослих", new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Вінниця", 3, "Чемпіонат України серед старших юнаків, юніорів, дорослих", new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Вінниця", 2, "Чемпіонат Вінницької області", new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Дніпро", 1, "Чемпіонат Дніпровської області", new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Полтава", 1, "Відкритий Кубок Полтавської області", new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Вінниця", 2, "Відкритий кубок міста Вінниці", new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Запоріжжя", 1, "Відкритий турнір СК \"Прайд\"", new DateTime(2022, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "divisions",
                columns: new[] { "division_id", "max_age", "max_weight", "min_age", "min_weight", "Name", "sex" },
                values: new object[,]
                {
                    { 1, 13, 35.0, 11, 30.0, "Дівчата 11-13 років -35кг", "F" },
                    { 2, 15, 45.0, 14, null, "Юніори 14-15 років -45кг", "M" },
                    { 3, 15, 50.0, 14, 45.0, "Юніори 14-15 років -50кг", "M" },
                    { 4, 17, 57.0, 16, 51.0, "Юніори 16-17 років -57кг", "M" },
                    { 5, 39, 62.0, 18, 57.0, "Жінки 18-39 років -62кг", "F" },
                    { 6, 39, 64.0, 18, 58.0, "Чоловіки 18-39 років -64кг", "M" }
                });

            migrationBuilder.InsertData(
                table: "sportsmen",
                columns: new[] { "sportsman_id", "birth_date", "first_name", "last_name", "sex" },
                values: new object[,]
                {
                    { 1, new DateTime(2007, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вадим", "Жадан", "M" },
                    { 2, new DateTime(2007, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Владислав", "Безкровний", "M" },
                    { 3, new DateTime(2007, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Руслан", "Солдатенко", "M" },
                    { 4, new DateTime(2009, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дмитро", "Белькевич", "M" },
                    { 5, new DateTime(2008, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Данило", "Савко", "M" },
                    { 6, new DateTime(2009, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Андрій", "Баштан", "M" },
                    { 7, new DateTime(2009, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Роман", "Кондратюк", "M" },
                    { 8, new DateTime(2008, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Євген", "Наливайко", "M" },
                    { 9, new DateTime(2012, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Анна", "Шишацька", "F" },
                    { 10, new DateTime(2011, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Галина", "Неділько", "F" }
                });

            migrationBuilder.InsertData(
                table: "competitors",
                columns: new[] { "competitor_id", "competition_id", "division_id", "lap_num", "sportsman_id", "weighting_result" },
                values: new object[,]
                {
                    { 1, 1, 4, 3, 1, 54.0 },
                    { 2, 1, 4, 1, 2, 54.0 },
                    { 3, 1, 4, 2, 3, 55.0 },
                    { 4, 1, 2, 2, 4, 44.0 },
                    { 5, 1, 2, 1, 5, 43.0 },
                    { 6, 2, 3, 3, 6, 46.0 },
                    { 7, 2, 3, 1, 7, 47.0 },
                    { 8, 2, 3, 2, 8, 48.0 },
                    { 9, 3, 1, 1, 9, 34.0 },
                    { 10, 3, 1, 2, 10, 35.0 },
                    { 11, 4, 4, 2, 1, 54.0 },
                    { 12, 4, 4, 1, 2, 54.0 },
                    { 13, 5, 2, 4, 4, 42.0 },
                    { 14, 5, 2, 1, 5, 42.0 },
                    { 15, 5, 2, 1, 6, 44.0 },
                    { 16, 5, 2, 3, 7, 45.0 },
                    { 17, 5, 2, 2, 8, 45.0 },
                    { 18, 4, 1, 1, 9, 34.0 },
                    { 19, 4, 1, 2, 10, 35.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "competitions",
                keyColumn: "competition_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "competitions",
                keyColumn: "competition_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "competitors",
                keyColumn: "competitor_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "divisions",
                keyColumn: "division_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "divisions",
                keyColumn: "division_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "competitions",
                keyColumn: "competition_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "competitions",
                keyColumn: "competition_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "competitions",
                keyColumn: "competition_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "competitions",
                keyColumn: "competition_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "competitions",
                keyColumn: "competition_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "divisions",
                keyColumn: "division_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "divisions",
                keyColumn: "division_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "divisions",
                keyColumn: "division_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "divisions",
                keyColumn: "division_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "sportsmen",
                keyColumn: "sportsman_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "sportsmen",
                keyColumn: "sportsman_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "sportsmen",
                keyColumn: "sportsman_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "sportsmen",
                keyColumn: "sportsman_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "sportsmen",
                keyColumn: "sportsman_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "sportsmen",
                keyColumn: "sportsman_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "sportsmen",
                keyColumn: "sportsman_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "sportsmen",
                keyColumn: "sportsman_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "sportsmen",
                keyColumn: "sportsman_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "sportsmen",
                keyColumn: "sportsman_id",
                keyValue: 10);

            migrationBuilder.AlterColumn<float>(
                name: "min_weight",
                table: "divisions",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "max_weight",
                table: "divisions",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "weighting_result",
                table: "competitors",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CHK_divisions_weight",
                table: "divisions",
                sql: "min_weight IS NOT NULL OR  max_weight IS NOT NULL");
        }
    }
}
