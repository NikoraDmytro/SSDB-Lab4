using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSDB_Lab4.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedDivisionCheckConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CHK_divisions_weight",
                table: "divisions",
                sql: "min_weight IS NOT NULL OR  max_weight IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_divisions_weight",
                table: "divisions");
        }
    }
}
