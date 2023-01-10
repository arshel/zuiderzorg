using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zuiderzorg.Migrations.Category
{
    public partial class ChangeLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExpLinks",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string[]>(
                name: "ExpLinks",
                table: "Products",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
