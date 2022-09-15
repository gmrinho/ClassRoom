using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassRoom.API.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocos",
                columns: table => new
                {
                    BlocoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    StatusBloco = table.Column<string>(type: "TEXT", nullable: true),
                    Local = table.Column<string>(type: "TEXT", nullable: true),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocos", x => x.BlocoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocos");
        }
    }
}
