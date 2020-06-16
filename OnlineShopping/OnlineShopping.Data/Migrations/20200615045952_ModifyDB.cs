using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Data.Migrations
{
    public partial class ModifyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_ProductID",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_ShoppingCarts_ShoppingCartID",
                table: "LineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItem_Orders_OrderID",
                table: "OrderLineItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItem_Products_ProductID",
                table: "OrderLineItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLineItem",
                table: "OrderLineItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineItems",
                table: "LineItems");

            migrationBuilder.RenameTable(
                name: "OrderLineItem",
                newName: "OrderLineItems");

            migrationBuilder.RenameTable(
                name: "LineItems",
                newName: "ShoppingCartLineItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLineItem_ProductID",
                table: "OrderLineItems",
                newName: "IX_OrderLineItems_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLineItem_OrderID",
                table: "OrderLineItems",
                newName: "IX_OrderLineItems_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_ShoppingCartID",
                table: "ShoppingCartLineItems",
                newName: "IX_ShoppingCartLineItems_ShoppingCartID");

            migrationBuilder.RenameIndex(
                name: "IX_LineItems_ProductID",
                table: "ShoppingCartLineItems",
                newName: "IX_ShoppingCartLineItems_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLineItems",
                table: "OrderLineItems",
                column: "OrderLineItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartLineItems",
                table: "ShoppingCartLineItems",
                column: "ShoppingCartLineItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_Orders_OrderID",
                table: "OrderLineItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_Products_ProductID",
                table: "OrderLineItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartLineItems_Products_ProductID",
                table: "ShoppingCartLineItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartLineItems_ShoppingCarts_ShoppingCartID",
                table: "ShoppingCartLineItems",
                column: "ShoppingCartID",
                principalTable: "ShoppingCarts",
                principalColumn: "ShoppingCartID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItems_Orders_OrderID",
                table: "OrderLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItems_Products_ProductID",
                table: "OrderLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartLineItems_Products_ProductID",
                table: "ShoppingCartLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartLineItems_ShoppingCarts_ShoppingCartID",
                table: "ShoppingCartLineItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartLineItems",
                table: "ShoppingCartLineItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLineItems",
                table: "OrderLineItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCartLineItems",
                newName: "LineItems");

            migrationBuilder.RenameTable(
                name: "OrderLineItems",
                newName: "OrderLineItem");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartLineItems_ShoppingCartID",
                table: "LineItems",
                newName: "IX_LineItems_ShoppingCartID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartLineItems_ProductID",
                table: "LineItems",
                newName: "IX_LineItems_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLineItems_ProductID",
                table: "OrderLineItem",
                newName: "IX_OrderLineItem_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLineItems_OrderID",
                table: "OrderLineItem",
                newName: "IX_OrderLineItem_OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineItems",
                table: "LineItems",
                column: "ShoppingCartLineItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLineItem",
                table: "OrderLineItem",
                column: "OrderLineItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_ProductID",
                table: "LineItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_ShoppingCarts_ShoppingCartID",
                table: "LineItems",
                column: "ShoppingCartID",
                principalTable: "ShoppingCarts",
                principalColumn: "ShoppingCartID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItem_Orders_OrderID",
                table: "OrderLineItem",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItem_Products_ProductID",
                table: "OrderLineItem",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
