using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Market.Infrastructure.Persistence.Migrations
{
    public partial class AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagen1",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagen2",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagen3",
                table: "Anuncios",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen1",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "Imagen2",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "Imagen3",
                table: "Anuncios");
        }
    }
}
