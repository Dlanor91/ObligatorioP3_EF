using Microsoft.EntityFrameworkCore.Migrations;

namespace Vivero.Migrations
{
    public partial class dos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParametroSistema",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TasaIVA = table.Column<decimal>(nullable: false),
                    TasaImportacionDGI = table.Column<decimal>(nullable: false),
                    DescuentoAmericaSur = table.Column<decimal>(nullable: false),
                    ValorMinimoDescripcion = table.Column<int>(nullable: false),
                    ValorMaximoDescripcion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroSistema", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParametroSistema");
        }
    }
}
