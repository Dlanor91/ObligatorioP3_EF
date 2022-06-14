using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorios.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    OrigenAmericaSur = table.Column<bool>(nullable: true),
                    DescripcionSanitaria = table.Column<string>(nullable: true),
                    CostoFlete = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iluminacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIluminacion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iluminacion", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "TipoAmbiente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ambiente = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAmbiente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlanta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlanta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Contrasenia = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCientifico = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 500, nullable: false),
                    AlturaMax = table.Column<decimal>(nullable: false),
                    Foto = table.Column<string>(nullable: false),
                    TipoAmbienteId = table.Column<int>(nullable: false),
                    FrecuenciaRiego = table.Column<string>(nullable: false),
                    Temperatura = table.Column<decimal>(nullable: false),
                    TipoPlantaId = table.Column<int>(nullable: false),
                    TipoIlumincacionId = table.Column<int>(nullable: false),
                    NombresVulgares = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planta_TipoAmbiente_TipoAmbienteId",
                        column: x => x.TipoAmbienteId,
                        principalTable: "TipoAmbiente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planta_Iluminacion_TipoIlumincacionId",
                        column: x => x.TipoIlumincacionId,
                        principalTable: "Iluminacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planta_TipoPlanta_TipoPlantaId",
                        column: x => x.TipoPlantaId,
                        principalTable: "TipoPlanta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioUnitario = table.Column<decimal>(nullable: false),
                    CompraId = table.Column<int>(nullable: false),
                    PlantaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Compra_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_Planta_PlantaId",
                        column: x => x.PlantaId,
                        principalTable: "Planta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_CompraId",
                table: "Item",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_PlantaId",
                table: "Item",
                column: "PlantaId");

            migrationBuilder.CreateIndex(
                name: "IX_Planta_NombreCientifico",
                table: "Planta",
                column: "NombreCientifico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planta_TipoAmbienteId",
                table: "Planta",
                column: "TipoAmbienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Planta_TipoIlumincacionId",
                table: "Planta",
                column: "TipoIlumincacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Planta_TipoPlantaId",
                table: "Planta",
                column: "TipoPlantaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPlanta_Nombre",
                table: "TipoPlanta",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ParametroSistema");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Planta");

            migrationBuilder.DropTable(
                name: "TipoAmbiente");

            migrationBuilder.DropTable(
                name: "Iluminacion");

            migrationBuilder.DropTable(
                name: "TipoPlanta");
        }
    }
}
