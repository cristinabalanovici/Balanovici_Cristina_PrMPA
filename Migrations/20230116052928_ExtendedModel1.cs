using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Balanovici_Cristina_PrMPA.Migrations
{
    public partial class ExtendedModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAngajare",
                table: "Veterinar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAngajare",
                table: "Veterinar");
        }
    }
}
