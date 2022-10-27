using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassRoom.Persistence.Migrations
{
    public partial class UpdIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserSobrenome",
                table: "AspNetUsers",
                newName: "UltimoNome");

            migrationBuilder.RenameColumn(
                name: "UserNome",
                table: "AspNetUsers",
                newName: "PrimeiroNome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UltimoNome",
                table: "AspNetUsers",
                newName: "UserSobrenome");

            migrationBuilder.RenameColumn(
                name: "PrimeiroNome",
                table: "AspNetUsers",
                newName: "UserNome");
        }
    }
}
