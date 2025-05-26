using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InclusaoDeColunaParaEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "endereco",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "regiao",
                table: "endereco",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "endereco");

            migrationBuilder.DropColumn(
                name: "regiao",
                table: "endereco");
        }
    }
}
