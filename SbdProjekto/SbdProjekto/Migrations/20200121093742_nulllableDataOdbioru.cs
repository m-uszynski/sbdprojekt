using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SbdProjekto.Migrations
{
    public partial class nulllableDataOdbioru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataOdbioru",
                table: "Zamowienia",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataOdbioru",
                table: "Zamowienia",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
