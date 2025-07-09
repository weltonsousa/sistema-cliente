using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCliente.Infrasctruture.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CodigoCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInsercao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CodigoCliente);
                });

            migrationBuilder.CreateTable(
                name: "TipoTelefones",
                columns: table => new
                {
                    CodigoTipoTelefone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoTipoTelefone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInsercao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTelefones", x => x.CodigoTipoTelefone);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    CodigoCliente = table.Column<int>(type: "int", nullable: false),
                    NumeroTelefone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodigoTipoTelefone = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Operadora = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioInsercao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioAlteracao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => new { x.CodigoCliente, x.NumeroTelefone });
                    table.ForeignKey(
                        name: "FK_Telefones_Clientes_CodigoCliente",
                        column: x => x.CodigoCliente,
                        principalTable: "Clientes",
                        principalColumn: "CodigoCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Telefones_TipoTelefones_CodigoTipoTelefone",
                        column: x => x.CodigoTipoTelefone,
                        principalTable: "TipoTelefones",
                        principalColumn: "CodigoTipoTelefone",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Documento",
                table: "Clientes",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_CodigoTipoTelefone",
                table: "Telefones",
                column: "CodigoTipoTelefone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoTelefones");
        }
    }
}
