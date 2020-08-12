using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Data.Migrations
{
    public partial class changedOrderLineItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItems_Orders_OrderID",
                table: "OrderLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLineItems_Products_ProductId",
                table: "OrderLineItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Accounts_AccountID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Accounts_AccountID",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderID",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLineItems",
                table: "OrderLineItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderLineItemID",
                table: "OrderLineItems");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Payments",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_AccountID",
                table: "Payments",
                newName: "IX_Payments_AccountId");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "Orders",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AccountID",
                table: "Orders",
                newName: "IX_Orders_AccountId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderLineItems",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLineItems_ProductId",
                table: "OrderLineItems",
                newName: "IX_OrderLineItems_ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Payments",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Orders",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "OrderLineItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "OrderLineItems",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderLineItems",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Accounts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLineItems",
                table: "OrderLineItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_Orders_OrderID",
                table: "OrderLineItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_Products_ProductID",
                table: "OrderLineItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Accounts_AccountId",
                table: "Orders",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Accounts_AccountId",
                table: "Payments",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderID",
                table: "Payments",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "Id",
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
                name: "FK_Orders_Accounts_AccountId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Accounts_AccountId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderID",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLineItems",
                table: "OrderLineItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderLineItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Payments",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_AccountId",
                table: "Payments",
                newName: "IX_Payments_AccountID");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Orders",
                newName: "AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                newName: "IX_Orders_AccountID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "OrderLineItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLineItems_ProductID",
                table: "OrderLineItems",
                newName: "IX_OrderLineItems_ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "Payments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrderLineItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "OrderLineItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "OrderLineItemID",
                table: "OrderLineItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "PaymentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLineItems",
                table: "OrderLineItems",
                column: "OrderLineItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_Orders_OrderID",
                table: "OrderLineItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLineItems_Products_ProductId",
                table: "OrderLineItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Accounts_AccountID",
                table: "Orders",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Accounts_AccountID",
                table: "Payments",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderID",
                table: "Payments",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
