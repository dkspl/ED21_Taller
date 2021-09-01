using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class AddedDT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Repuestos",
                table: "Presupuesto",
                type: "float",
                nullable: true,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Recargos",
                table: "Presupuesto",
                type: "float",
                nullable: true,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Presupuesto",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 17, 18, 33, 16, 430, DateTimeKind.Local).AddTicks(7637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "Descuentos",
                table: "Presupuesto",
                type: "float",
                nullable: true,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldDefaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Repuestos",
                table: "Presupuesto",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Recargos",
                table: "Presupuesto",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldDefaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Presupuesto",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 17, 18, 33, 16, 430, DateTimeKind.Local).AddTicks(7637));

            migrationBuilder.AlterColumn<double>(
                name: "Descuentos",
                table: "Presupuesto",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldDefaultValue: 0.0);
        }
    }
}
