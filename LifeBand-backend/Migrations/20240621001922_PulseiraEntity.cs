using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeBand_backend.Migrations
{
    /// <inheritdoc />
    public partial class PulseiraEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pulseiras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContatoEmergenciaNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContatoEmergenciaTelefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoencaCronica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrauDeRisco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pulseiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pulseiras_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pulseiras_UserId",
                table: "Pulseiras",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pulseiras");
        }
    }
}
