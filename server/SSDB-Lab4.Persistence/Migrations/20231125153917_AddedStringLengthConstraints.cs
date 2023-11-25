using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSDB_Lab4.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedStringLengthConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_divisions_Name",
                table: "divisions");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "divisions",
                newName: "name");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "sportsmen",
                type: "varchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "sportsmen",
                type: "varchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "divisions",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_divisions_name",
                table: "divisions",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_divisions_name",
                table: "divisions");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "divisions",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "sportsmen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "sportsmen",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "divisions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_divisions_Name",
                table: "divisions",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }
    }
}
