using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WarehouseManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableInven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Warehouses_WarehouseID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_WarehouseID",
                table: "Inventory");

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "WarehouseID",
                table: "Inventory");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1,
                column: "TotalAmount",
                value: 43.960000000000001);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2,
                column: "TotalAmount",
                value: 74.950000000000003);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3,
                column: "TotalAmount",
                value: 69.450000000000003);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 4,
                column: "TotalAmount",
                value: 49.950000000000003);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 5,
                column: "TotalAmount",
                value: 62.93);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseID",
                table: "Inventory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 1,
                column: "WarehouseID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 2,
                column: "WarehouseID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 3,
                column: "WarehouseID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 4,
                column: "WarehouseID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 5,
                column: "WarehouseID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 6,
                column: "WarehouseID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 7,
                column: "WarehouseID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 8,
                column: "WarehouseID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 9,
                column: "WarehouseID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryID",
                keyValue: 10,
                column: "WarehouseID",
                value: 5);

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "InventoryID", "ProductID", "QuantityAvailable", "WarehouseID" },
                values: new object[,]
                {
                    { 11, 1, 80, 2 },
                    { 12, 2, 100, 3 },
                    { 13, 3, 65, 4 },
                    { 14, 4, 45, 5 },
                    { 15, 5, 110, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1,
                column: "TotalAmount",
                value: 150.0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2,
                column: "TotalAmount",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3,
                column: "TotalAmount",
                value: 350.0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 4,
                column: "TotalAmount",
                value: 400.0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 5,
                column: "TotalAmount",
                value: 250.0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_WarehouseID",
                table: "Inventory",
                column: "WarehouseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Warehouses_WarehouseID",
                table: "Inventory",
                column: "WarehouseID",
                principalTable: "Warehouses",
                principalColumn: "WarehouseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
