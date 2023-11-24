using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSDB_Lab4.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreatedCompetitorConpetitionDivisionEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "competitions",
                columns: table => new
                {
                    competition_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competitions", x => x.competition_id);
                });

            migrationBuilder.CreateTable(
                name: "divisions",
                columns: table => new
                {
                    division_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    min_weight = table.Column<float>(type: "real", nullable: true),
                    max_weight = table.Column<float>(type: "real", nullable: true),
                    min_age = table.Column<int>(type: "int", nullable: false),
                    max_age = table.Column<int>(type: "int", nullable: false),
                    sex = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_divisions", x => x.division_id);
                    table.CheckConstraint("CHK_divisions_sex", "sex IN ('M', 'F')");
                    table.CheckConstraint("CHK_divisions_weight", "min_weight IS NOT NULL OR  max_weight IS NOT NULL");
                });

            migrationBuilder.CreateTable(
                name: "competitors",
                columns: table => new
                {
                    competitor_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sportsman_id = table.Column<int>(type: "int", nullable: false),
                    competition_id = table.Column<int>(type: "int", nullable: false),
                    weighting_result = table.Column<float>(type: "real", nullable: true),
                    division_id = table.Column<int>(type: "int", nullable: true),
                    lap_num = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competitors", x => x.competitor_id);
                    table.ForeignKey(
                        name: "FK_competitors_competitions_competition_id",
                        column: x => x.competition_id,
                        principalTable: "competitions",
                        principalColumn: "competition_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_competitors_divisions_division_id",
                        column: x => x.division_id,
                        principalTable: "divisions",
                        principalColumn: "division_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_competitors_sportsmen_sportsman_id",
                        column: x => x.sportsman_id,
                        principalTable: "sportsmen",
                        principalColumn: "sportsman_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_competitions_name_start_date",
                table: "competitions",
                columns: new[] { "name", "start_date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_competitors_competition_id",
                table: "competitors",
                column: "competition_id");

            migrationBuilder.CreateIndex(
                name: "IX_competitors_division_id",
                table: "competitors",
                column: "division_id");

            migrationBuilder.CreateIndex(
                name: "IX_competitors_sportsman_id",
                table: "competitors",
                column: "sportsman_id");

            migrationBuilder.CreateIndex(
                name: "IX_divisions_Name",
                table: "divisions",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "competitors");

            migrationBuilder.DropTable(
                name: "competitions");

            migrationBuilder.DropTable(
                name: "divisions");
        }
    }
}
