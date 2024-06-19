using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeBand_backend.Migrations
{
    /// <inheritdoc />
    public partial class TabelaFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado_Civil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RF = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Formacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carga_Horaria = table.Column<int>(type: "int", nullable: false),
                    Expediente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
