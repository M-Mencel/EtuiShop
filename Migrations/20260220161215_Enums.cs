using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Etui.Migrations
{
    public partial class Enums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Orders",
                newName: "Ulica");

            migrationBuilder.RenameColumn(
                name: "CustomerEmail",
                table: "Orders",
                newName: "NrTelefonu");

            migrationBuilder.RenameColumn(
                name: "ulica",
                table: "Dane_1",
                newName: "Ulica");

            migrationBuilder.RenameColumn(
                name: "nrtelefonu",
                table: "Dane_1",
                newName: "NrTelefonu");

            migrationBuilder.RenameColumn(
                name: "nrlokalu",
                table: "Dane_1",
                newName: "NrLokalu");

            migrationBuilder.RenameColumn(
                name: "nrdomu",
                table: "Dane_1",
                newName: "NrDomu");

            migrationBuilder.RenameColumn(
                name: "nazwisko",
                table: "Dane_1",
                newName: "Nazwisko");

            migrationBuilder.RenameColumn(
                name: "miejscowosc",
                table: "Dane_1",
                newName: "Miejscowosc");

            migrationBuilder.RenameColumn(
                name: "kodpocztowy",
                table: "Dane_1",
                newName: "KodPocztowy");

            migrationBuilder.RenameColumn(
                name: "imie",
                table: "Dane_1",
                newName: "Imie");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Dane_1",
                newName: "Email");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imie",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KodPocztowy",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Miejscowosc",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nazwisko",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NrDomu",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NrLokalu",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ulica",
                table: "Dane_1",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "NrTelefonu",
                table: "Dane_1",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "NrLokalu",
                table: "Dane_1",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Miejscowosc",
                table: "Dane_1",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "KodPocztowy",
                table: "Dane_1",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Imie",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "KodPocztowy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Miejscowosc",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Nazwisko",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NrDomu",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NrLokalu",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Ulica",
                table: "Orders",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "NrTelefonu",
                table: "Orders",
                newName: "CustomerEmail");

            migrationBuilder.RenameColumn(
                name: "Ulica",
                table: "Dane_1",
                newName: "ulica");

            migrationBuilder.RenameColumn(
                name: "NrTelefonu",
                table: "Dane_1",
                newName: "nrtelefonu");

            migrationBuilder.RenameColumn(
                name: "NrLokalu",
                table: "Dane_1",
                newName: "nrlokalu");

            migrationBuilder.RenameColumn(
                name: "NrDomu",
                table: "Dane_1",
                newName: "nrdomu");

            migrationBuilder.RenameColumn(
                name: "Nazwisko",
                table: "Dane_1",
                newName: "nazwisko");

            migrationBuilder.RenameColumn(
                name: "Miejscowosc",
                table: "Dane_1",
                newName: "miejscowosc");

            migrationBuilder.RenameColumn(
                name: "KodPocztowy",
                table: "Dane_1",
                newName: "kodpocztowy");

            migrationBuilder.RenameColumn(
                name: "Imie",
                table: "Dane_1",
                newName: "imie");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Dane_1",
                newName: "email");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ulica",
                table: "Dane_1",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "nrtelefonu",
                table: "Dane_1",
                type: "int",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nrlokalu",
                table: "Dane_1",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "miejscowosc",
                table: "Dane_1",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "kodpocztowy",
                table: "Dane_1",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
