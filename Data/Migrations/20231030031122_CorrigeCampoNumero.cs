using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppPedido.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeCampoNumero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Número",
                table: "EnderecoCliente",
                newName: "Numero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "EnderecoCliente",
                newName: "Número");
        }
    }
}
