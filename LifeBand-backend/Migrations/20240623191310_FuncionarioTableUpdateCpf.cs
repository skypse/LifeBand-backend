using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeBand_backend.Migrations
{
    /// <inheritdoc />
    public partial class FuncionarioTableUpdateCpf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Funcionarios",
                newName: "Cpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Funcionarios",
                newName: "CPF");
        }
    }
}
