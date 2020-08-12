using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Data.Migrations
{
	public partial class ProductImagesAdded : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "CategoryID",
				table: "Products",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<string>(
				name: "PhotoName",
				table: "Products",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "CategoryID",
				table: "Products");

			migrationBuilder.DropColumn(
				name: "PhotoName",
				table: "Products");
		}
	}
}
