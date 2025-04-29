using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppPiagetSampaio.Data.Migrations
{
    /// <inheritdoc />
    public partial class piaget : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alunoid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.id);
                    table.ForeignKey(
                        name: "FK_Professor_Aluno_alunoid",
                        column: x => x.alunoid,
                        principalTable: "Aluno",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professor_alunoid",
                table: "Professor",
                column: "alunoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
