using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationRestric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Product_ProductID",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Product_ProductID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingDetails_Product_ProductID",
                table: "ReceivingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingDetails_Receivings_ReceivingID",
                table: "ReceivingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Receivings_Suppliers_SupplierID",
                table: "Receivings");

            migrationBuilder.DropForeignKey(
                name: "FK_Receivings_Warehouses_WarehouseID",
                table: "Receivings");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Product_ProductID",
                table: "Inventories",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Product_ProductID",
                table: "OrderDetails",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingDetails_Product_ProductID",
                table: "ReceivingDetails",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingDetails_Receivings_ReceivingID",
                table: "ReceivingDetails",
                column: "ReceivingID",
                principalTable: "Receivings",
                principalColumn: "ReceivingID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receivings_Suppliers_SupplierID",
                table: "Receivings",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receivings_Warehouses_WarehouseID",
                table: "Receivings",
                column: "WarehouseID",
                principalTable: "Warehouses",
                principalColumn: "WarehouseID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Product_ProductID",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Product_ProductID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingDetails_Product_ProductID",
                table: "ReceivingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingDetails_Receivings_ReceivingID",
                table: "ReceivingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Receivings_Suppliers_SupplierID",
                table: "Receivings");

            migrationBuilder.DropForeignKey(
                name: "FK_Receivings_Warehouses_WarehouseID",
                table: "Receivings");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Product_ProductID",
                table: "Inventories",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Product_ProductID",
                table: "OrderDetails",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingDetails_Product_ProductID",
                table: "ReceivingDetails",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingDetails_Receivings_ReceivingID",
                table: "ReceivingDetails",
                column: "ReceivingID",
                principalTable: "Receivings",
                principalColumn: "ReceivingID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receivings_Suppliers_SupplierID",
                table: "Receivings",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receivings_Warehouses_WarehouseID",
                table: "Receivings",
                column: "WarehouseID",
                principalTable: "Warehouses",
                principalColumn: "WarehouseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
