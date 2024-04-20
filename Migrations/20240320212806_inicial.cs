using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmes_Jogos.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avaliacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogoss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desenvolvedora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avaliacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogoss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JogosFilmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JogoId = table.Column<int>(type: "int", nullable: false),
                    JogoId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    FilmeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogosFilmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JogosFilmes_Filmes_FilmeId1",
                        column: x => x.FilmeId1,
                        principalTable: "Filmes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JogosFilmes_Jogoss_JogoId1",
                        column: x => x.JogoId1,
                        principalTable: "Jogoss",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JogosFilmes_FilmeId1",
                table: "JogosFilmes",
                column: "FilmeId1");

            migrationBuilder.CreateIndex(
                name: "IX_JogosFilmes_JogoId1",
                table: "JogosFilmes",
                column: "JogoId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogosFilmes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Jogoss");
        }
    }
}
