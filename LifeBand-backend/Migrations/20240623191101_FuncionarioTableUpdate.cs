using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeBand_backend.Migrations
{
    /// <inheritdoc />
    public partial class FuncionarioTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Funcionarios");
        }
    }
}
