using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Etui.Migrations
{
    public partial class _122134234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nazwisko",
                table: "Dane_1",
                newName: "nazwisko");

            migrationBuilder.RenameColumn(
                name: "Imie",
                table: "Dane_1",
                newName: "imie");

            migrationBuilder.AlterColumn<string>(
                name: "nrlokalu",
                table: "Dane_1",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nrdomu",
                table: "Dane_1",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "miejscowosc",
                table: "Dane_1",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nazwisko",
                table: "Dane_1",
                type: "nvarchar(160)",
                maxLength: 160,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "imie",
                table: "Dane_1",
                type: "nvarchar(160)",
                maxLength: 160,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nazwisko",
                table: "Dane_1",
                newName: "Nazwisko");

            migrationBuilder.RenameColumn(
                name: "imie",
                table: "Dane_1",
                newName: "Imie");

            migrationBuilder.AlterColumn<string>(
                name: "nrlokalu",
                table: "Dane_1",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "nrdomu",
                table: "Dane_1",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwisko",
                table: "Dane_1",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(160)",
                oldMaxLength: 160);

            migrationBuilder.AlterColumn<string>(
                name: "miejscowosc",
                table: "Dane_1",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Imie",
                table: "Dane_1",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(160)",
                oldMaxLength: 160);
        }
    }
}
