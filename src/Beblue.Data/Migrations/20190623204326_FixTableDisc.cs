using Microsoft.EntityFrameworkCore.Migrations;

namespace Beblue.Data.Migrations
{
    public partial class FixTableDisc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpotifyId",
                table: "Discs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Discs",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Discs",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Discs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Discs",
                type: "varchar(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AddColumn<string>(
                name: "SpotifyId",
                table: "Discs",
                nullable: true);
        }
    }
}
