using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zuiderzorg.Migrations.Category
{
    public partial class AddLinkStrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "ExpLinks",
                table: "Products",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreLink",
                table: "Products",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "ExpLinks",
                table: "Categories",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreLink",
                table: "Categories",
                type: "text",
                nullable: true);
        }
    }
}
