using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace senai.hroads.webApi.Migrations
{
    public partial class criandoBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    idClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.idClasse);
                });

            migrationBuilder.CreateTable(
                name: "TipoHabilidade",
                columns: table => new
                {
                    idTipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabilidade", x => x.idTipo);
                });

            migrationBuilder.CreateTable(
                name: "tipoUsuario",
                columns: table => new
                {
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoUsuario", x => x.idTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    idPersonagem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idClasse = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    CapacidadeMaxVida = table.Column<int>(type: "int", nullable: false),
                    CapacidadeMaxMana = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DATE", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.idPersonagem);
                    table.ForeignKey(
                        name: "FK_Personagens_Classes_idClasse",
                        column: x => x.idClasse,
                        principalTable: "Classes",
                        principalColumn: "idClasse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    idHabilidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTipo = table.Column<int>(type: "int", nullable: false),
                    Habilidade = table.Column<string>(type: "VARCHAR(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.idHabilidade);
                    table.ForeignKey(
                        name: "FK_Habilidades_TipoHabilidade_idTipo",
                        column: x => x.idTipo,
                        principalTable: "TipoHabilidade",
                        principalColumn: "idTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    senha = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_usuario_tipoUsuario_idTipoUsuario",
                        column: x => x.idTipoUsuario,
                        principalTable: "tipoUsuario",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassHab",
                columns: table => new
                {
                    idClassHab = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idClasse = table.Column<int>(type: "int", nullable: false),
                    idHabilidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassHab", x => x.idClassHab);
                    table.ForeignKey(
                        name: "FK_ClassHab_Classes_idClasse",
                        column: x => x.idClasse,
                        principalTable: "Classes",
                        principalColumn: "idClasse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassHab_Habilidades_idHabilidade",
                        column: x => x.idHabilidade,
                        principalTable: "Habilidades",
                        principalColumn: "idHabilidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "idClasse", "Nome" },
                values: new object[,]
                {
                    { 1, "Bárbaro" },
                    { 2, "Cruzado" },
                    { 3, "Caçadora de Demônios" },
                    { 4, "Monge" },
                    { 5, "Necromante" },
                    { 6, "Feiticeiro" },
                    { 7, "Arcanista" }
                });

            migrationBuilder.InsertData(
                table: "TipoHabilidade",
                columns: new[] { "idTipo", "Tipo" },
                values: new object[,]
                {
                    { 1, "Ataque" },
                    { 2, "Defesa" },
                    { 3, "Cura" },
                    { 4, "Magia" }
                });

            migrationBuilder.InsertData(
                table: "tipoUsuario",
                columns: new[] { "idTipoUsuario", "titulo" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "idHabilidade", "Habilidade", "idTipo" },
                values: new object[,]
                {
                    { 1, "Lança Mortal", 1 },
                    { 2, "Escudo Supremo", 2 },
                    { 3, "Recuperar Vida", 3 }
                });

            migrationBuilder.InsertData(
                table: "Personagens",
                columns: new[] { "idPersonagem", "CapacidadeMaxMana", "CapacidadeMaxVida", "DataAtualizacao", "DataCriacao", "Nome", "idClasse" },
                values: new object[,]
                {
                    { 1, 80, 100, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "DeuBug", 1 },
                    { 2, 100, 70, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "BitBug", 4 },
                    { 3, 60, 75, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fer8", 7 }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "idUsuario", "email", "idTipoUsuario", "senha" },
                values: new object[,]
                {
                    { 1, "admin@admin.com", 1, "admin" },
                    { 2, "cliente@cliente.com", 2, "cliente" }
                });

            migrationBuilder.InsertData(
                table: "ClassHab",
                columns: new[] { "idClassHab", "idClasse", "idHabilidade" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 4, 3, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 5, 4, 2 },
                    { 6, 4, 3 },
                    { 7, 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassHab_idClasse",
                table: "ClassHab",
                column: "idClasse");

            migrationBuilder.CreateIndex(
                name: "IX_ClassHab_idHabilidade",
                table: "ClassHab",
                column: "idHabilidade");

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_idTipo",
                table: "Habilidades",
                column: "idTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_idClasse",
                table: "Personagens",
                column: "idClasse");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_email",
                table: "usuario",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_idTipoUsuario",
                table: "usuario",
                column: "idTipoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassHab");

            migrationBuilder.DropTable(
                name: "Personagens");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "tipoUsuario");

            migrationBuilder.DropTable(
                name: "TipoHabilidade");
        }
    }
}
