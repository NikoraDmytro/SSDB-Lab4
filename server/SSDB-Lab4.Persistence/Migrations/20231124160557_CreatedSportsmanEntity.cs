using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSDB_Lab4.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreatedSportsmanEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sportsmen",
                columns: table => new
                {
                    sportsman_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sex = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sportsmen", x => x.sportsman_id);
                    table.CheckConstraint("CHK_sportsmen_sex", "sex IN ('M', 'F')");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sportsmen");
        }
    }
}
