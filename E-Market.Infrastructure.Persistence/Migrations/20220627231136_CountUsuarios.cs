using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Market.Infrastructure.Persistence.Migrations
{
    public partial class CountUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantUsuarios",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_UsuariosId",
                table: "Categorias",
                column: "UsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Usuarios_UsuariosId",
                table: "Categorias",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Usuarios_UsuariosId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_UsuariosId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "CantUsuarios",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "Categorias");
        }
    }
}
