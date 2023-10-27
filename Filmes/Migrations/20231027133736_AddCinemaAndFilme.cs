using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes.Migrations
{
    /// <inheritdoc />
    public partial class AddCinemaAndFilme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao");

            migrationBuilder.DropIndex(
                name: "IX_Sessao_FilmeId",
                table: "Sessao");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sessao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao",
                columns: new[] { "FilmeId", "CinemaId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sessao",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessao",
                table: "Sessao",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessao_FilmeId",
                table: "Sessao",
                column: "FilmeId");
        }
    }
}
