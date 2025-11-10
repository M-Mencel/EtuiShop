using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Etui.Migrations
{
    public partial class _21312233 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Support",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    temat = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    wiadomosc = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Support", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Support");
        }
    }
}
