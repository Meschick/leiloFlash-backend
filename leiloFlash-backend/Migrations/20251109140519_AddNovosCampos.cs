using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace leiloFlash_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddNovosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "possui_chave",
                table: "Veiculo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "Lote",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "localizacao",
                table: "Lote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "Lote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tipo_retomada",
                table: "Lote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "valor_mercado",
                table: "Lote",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "possui_chave",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "descricao",
                table: "Lote");

            migrationBuilder.DropColumn(
                name: "localizacao",
                table: "Lote");

            migrationBuilder.DropColumn(
                name: "tipo",
                table: "Lote");

            migrationBuilder.DropColumn(
                name: "tipo_retomada",
                table: "Lote");

            migrationBuilder.DropColumn(
                name: "valor_mercado",
                table: "Lote");
        }
    }
}
