using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAsociados.Migrations
{
    /// <inheritdoc />
    public partial class AddSalarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_logico",
                table: "departamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_logico",
                table: "asociados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "anio_ingreso",
                table: "asociados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "salarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_depto = table.Column<int>(type: "int", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Categoria_salario = table.Column<int>(type: "int", nullable: false),
                    Id_logico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "salarios");

            migrationBuilder.DropColumn(
                name: "Id_logico",
                table: "departamentos");

            migrationBuilder.DropColumn(
                name: "Id_logico",
                table: "asociados");

            migrationBuilder.DropColumn(
                name: "anio_ingreso",
                table: "asociados");
        }
    }
}
