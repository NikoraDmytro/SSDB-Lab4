using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSDB_Lab4.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreatedHelperTablesForTriggers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "competition_copies",
                columns: table => new
                {
                    competition_copy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competition_copies", x => x.competition_copy_id);
                });

            migrationBuilder.CreateTable(
                name: "competitor_logs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    competitor_id = table.Column<int>(type: "int", nullable: false),
                    modified_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_competitor_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_competitor_logs_competitors_competitor_id",
                        column: x => x.competitor_id,
                        principalTable: "competitors",
                        principalColumn: "competitor_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "failed_insert_competitor_logs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sportsman_id = table.Column<int>(type: "int", nullable: false),
                    competition_id = table.Column<int>(type: "int", nullable: false),
                    failed_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_failed_insert_competitor_logs", x => x.id);
                    table.ForeignKey(
                        name: "FK_failed_insert_competitor_logs_competitions_competition_id",
                        column: x => x.competition_id,
                        principalTable: "competitions",
                        principalColumn: "competition_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_failed_insert_competitor_logs_sportsmen_sportsman_id",
                        column: x => x.sportsman_id,
                        principalTable: "sportsmen",
                        principalColumn: "sportsman_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_competitor_logs_competitor_id",
                table: "competitor_logs",
                column: "competitor_id");

            migrationBuilder.CreateIndex(
                name: "IX_failed_insert_competitor_logs_competition_id",
                table: "failed_insert_competitor_logs",
                column: "competition_id");

            migrationBuilder.CreateIndex(
                name: "IX_failed_insert_competitor_logs_sportsman_id",
                table: "failed_insert_competitor_logs",
                column: "sportsman_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "competition_copies");

            migrationBuilder.DropTable(
                name: "competitor_logs");

            migrationBuilder.DropTable(
                name: "failed_insert_competitor_logs");
        }
    }
}
