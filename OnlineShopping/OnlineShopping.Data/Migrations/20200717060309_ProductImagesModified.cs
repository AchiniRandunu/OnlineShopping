using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Data.Migrations
{
    public partial class ProductImagesModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
