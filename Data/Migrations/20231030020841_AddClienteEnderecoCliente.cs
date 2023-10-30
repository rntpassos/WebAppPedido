using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppPedido.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddClienteEnderecoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR ProximoID"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CpfCnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoCliente",
                columns: table => new
                {
                    EnderecoClienteID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR ProximoID"),
                    Denominacao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Número = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoCliente", x => x.EnderecoClienteID);
                    table.ForeignKey(
                        name: "FK_EnderecoCliente_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoCliente_ClienteId",
                table: "EnderecoCliente",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecoCliente");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
