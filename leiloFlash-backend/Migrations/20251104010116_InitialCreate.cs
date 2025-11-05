using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace leiloFlash_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false),
                    cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    km_atual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_inicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senha = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status_usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    endereco_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usuario_Endereco_endereco_id",
                        column: x => x.endereco_id,
                        principalTable: "Endereco",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_upload = table.Column<DateTime>(type: "datetime2", nullable: false),
                    veiculo_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.id);
                    table.ForeignKey(
                        name: "FK_Imagem_Veiculo_veiculo_id",
                        column: x => x.veiculo_id,
                        principalTable: "Veiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leilao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status_leilao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leilao", x => x.id);
                    table.ForeignKey(
                        name: "FK_Leilao_Usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_lote = table.Column<int>(type: "int", nullable: false),
                    valor_inicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_atual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    valor_final = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    leilao_id = table.Column<int>(type: "int", nullable: true),
                    veiculo_id = table.Column<int>(type: "int", nullable: true),
                    usuario_id = table.Column<int>(type: "int", nullable: true),
                    ultimo_lance_usuario_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lote_Leilao_leilao_id",
                        column: x => x.leilao_id,
                        principalTable: "Leilao",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Lote_Usuario_ultimo_lance_usuario_id",
                        column: x => x.ultimo_lance_usuario_id,
                        principalTable: "Usuario",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Lote_Usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuario",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Lote_Veiculo_veiculo_id",
                        column: x => x.veiculo_id,
                        principalTable: "Veiculo",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Lance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    data_hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lote_id = table.Column<int>(type: "int", nullable: true),
                    usuario_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lance", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lance_Lote_lote_id",
                        column: x => x.lote_id,
                        principalTable: "Lote",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Lance_Usuario_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_veiculo_id",
                table: "Imagem",
                column: "veiculo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lance_lote_id",
                table: "Lance",
                column: "lote_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lance_usuario_id",
                table: "Lance",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Leilao_usuario_id",
                table: "Leilao",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_leilao_id",
                table: "Lote",
                column: "leilao_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_ultimo_lance_usuario_id",
                table: "Lote",
                column: "ultimo_lance_usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_usuario_id",
                table: "Lote",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_veiculo_id",
                table: "Lote",
                column: "veiculo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_endereco_id",
                table: "Usuario",
                column: "endereco_id",
                unique: true,
                filter: "[endereco_id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropTable(
                name: "Lance");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "Leilao");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
