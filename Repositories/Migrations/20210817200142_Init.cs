using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repuesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repuesto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patente = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Automovil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    CantidadPuertas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automovil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automovil_Vehiculo_Id",
                        column: x => x.Id,
                        principalTable: "Vehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Desperfecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tiempo = table.Column<double>(type: "float", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desperfecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Desperfecto",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Cilindrada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moto_Vehiculo_Id",
                        column: x => x.Id,
                        principalTable: "Vehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presupuesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManoDeObra = table.Column<double>(type: "float", nullable: false),
                    Estacionamiento = table.Column<double>(type: "float", nullable: false),
                    Descuentos = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Recargos = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Repuestos = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesperfectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuesto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desperfecto_Presupuesto",
                        column: x => x.DesperfectoId,
                        principalTable: "Desperfecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepuestosRequeridos",
                columns: table => new
                {
                    RepuestoId = table.Column<int>(type: "int", nullable: false),
                    DesperfectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepuestosRequeridos", x => new { x.RepuestoId, x.DesperfectoId });
                    table.ForeignKey(
                        name: "FK_RepuestoDesperfecto_Desperfecto",
                        column: x => x.DesperfectoId,
                        principalTable: "Desperfecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RepuestoDesperfecto_Repuesto",
                        column: x => x.RepuestoId,
                        principalTable: "Repuesto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desperfecto_VehiculoId",
                table: "Desperfecto",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuesto_DesperfectoId",
                table: "Presupuesto",
                column: "DesperfectoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepuestosRequeridos_DesperfectoId",
                table: "RepuestosRequeridos",
                column: "DesperfectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_Patente",
                table: "Vehiculo",
                column: "Patente",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automovil");

            migrationBuilder.DropTable(
                name: "Moto");

            migrationBuilder.DropTable(
                name: "Presupuesto");

            migrationBuilder.DropTable(
                name: "RepuestosRequeridos");

            migrationBuilder.DropTable(
                name: "Desperfecto");

            migrationBuilder.DropTable(
                name: "Repuesto");

            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
