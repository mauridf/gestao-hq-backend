using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace gestao_hq_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeEditora = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeHq = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    NomeOriginalHq = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Publicacao = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TotalEdicoes = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Sinopse = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HQs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TipoPersonagem = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Edicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Obs = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    HqId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edicoes_HQs_HqId",
                        column: x => x.HqId,
                        principalTable: "HQs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HqEditoras",
                columns: table => new
                {
                    HqId = table.Column<int>(type: "integer", nullable: false),
                    EditoraId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HqEditoras", x => new { x.HqId, x.EditoraId });
                    table.ForeignKey(
                        name: "FK_HqEditoras_Editoras_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Editoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HqEditoras_HQs_HqId",
                        column: x => x.HqId,
                        principalTable: "HQs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HqPersonagens",
                columns: table => new
                {
                    HqId = table.Column<int>(type: "integer", nullable: false),
                    PersonagemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HqPersonagens", x => new { x.HqId, x.PersonagemId });
                    table.ForeignKey(
                        name: "FK_HqPersonagens_HQs_HqId",
                        column: x => x.HqId,
                        principalTable: "HQs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HqPersonagens_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edicoes_HqId",
                table: "Edicoes",
                column: "HqId");

            migrationBuilder.CreateIndex(
                name: "IX_HqEditoras_EditoraId",
                table: "HqEditoras",
                column: "EditoraId");

            migrationBuilder.CreateIndex(
                name: "IX_HqPersonagens_PersonagemId",
                table: "HqPersonagens",
                column: "PersonagemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edicoes");

            migrationBuilder.DropTable(
                name: "HqEditoras");

            migrationBuilder.DropTable(
                name: "HqPersonagens");

            migrationBuilder.DropTable(
                name: "Editoras");

            migrationBuilder.DropTable(
                name: "HQs");

            migrationBuilder.DropTable(
                name: "Personagens");
        }
    }
}
