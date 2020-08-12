using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Data.Migrations
{
	public partial class UnitOfworkChanged : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_OrderLineItems_Products_ProductID",
				table: "OrderLineItems");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Products",
				table: "Products");

			migrationBuilder.DropColumn(
				name: "ProductID",
				table: "Products");

			migrationBuilder.RenameColumn(
				name: "ProductID",
				table: "OrderLineItems",
				newName: "ProductId");

			migrationBuilder.RenameIndex(
				name: "IX_OrderLineItems_ProductID",
				table: "OrderLineItems",
				newName: "IX_OrderLineItems_ProductId");

			migrationBuilder.AddColumn<int>(
				name: "Id",
				table: "Products",
				nullable: false,
				defaultValue: 0)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Products",
				table: "Products",
				column: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_OrderLineItems_Products_ProductId",
				table: "OrderLineItems",
				column: "ProductId",
				principalTable: "Products",
				principalColumn: "Id",
				onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_OrderLineItems_Products_ProductId",
				table: "OrderLineItems");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Products",
				table: "Products");

			migrationBuilder.DropColumn(
				name: "Id",
				table: "Products");

			migrationBuilder.RenameColumn(
				name: "ProductId",
				table: "OrderLineItems",
				newName: "ProductID");

			migrationBuilder.RenameIndex(
				name: "IX_OrderLineItems_ProductId",
				table: "OrderLineItems",
				newName: "IX_OrderLineItems_ProductID");

			migrationBuilder.AddColumn<int>(
				name: "ProductID",
				table: "Products",
				type: "int",
				nullable: false,
				defaultValue: 0)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Products",
				table: "Products",
				column: "ProductID");

			migrationBuilder.AddForeignKey(
				name: "FK_OrderLineItems_Products_ProductID",
				table: "OrderLineItems",
				column: "ProductID",
				principalTable: "Products",
				principalColumn: "ProductID",
				onDelete: ReferentialAction.Restrict);
		}
	}
}
