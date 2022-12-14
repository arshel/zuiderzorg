using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zuiderzorg.Migrations.Category
{
    public partial class AddMinMaxPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "PriceMin");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceMax",
                table: "Products",
                type: "numeric",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceMax",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PriceMin",
                table: "Products",
                newName: "Price");
        }
    }
}
