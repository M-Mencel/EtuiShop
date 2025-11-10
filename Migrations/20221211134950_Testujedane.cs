using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Etui.Migrations
{
    public partial class Testujedane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dane_1",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nrdomu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nrlokalu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kodpocztowy = table.Column<int>(type: "int", nullable: false),
                    miejscowosc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nrtelefonu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dane_1", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dane_1");
        }
    }
}
