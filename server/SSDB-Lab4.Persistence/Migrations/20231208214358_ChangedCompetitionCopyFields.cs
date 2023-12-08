using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSDB_Lab4.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCompetitionCopyFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "competition_copy_id",
                table: "competition_copies",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "competition_id",
                table: "competition_copies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "competition_id",
                table: "competition_copies");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "competition_copies",
                newName: "competition_copy_id");
        }
    }
}
