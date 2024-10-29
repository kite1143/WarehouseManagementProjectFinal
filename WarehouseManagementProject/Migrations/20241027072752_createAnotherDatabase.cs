using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WarehouseManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class createAnotherDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receivings",
                columns: table => new
                {
                    ReceivingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    WarehouseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivings", x => x.ReceivingID);
                    table.ForeignKey(
                        name: "FK_Receivings_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receivings_Warehouses_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    WarehouseID = table.Column<int>(type: "int", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryID);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_Warehouses_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailsID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceivingDetails",
                columns: table => new
                {
                    ReceivingDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivingID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingDetails", x => x.ReceivingDetailsID);
                    table.ForeignKey(
                        name: "FK_ReceivingDetails_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceivingDetails_Receivings_ReceivingID",
                        column: x => x.ReceivingID,
                        principalTable: "Receivings",
                        principalColumn: "ReceivingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Electronics", null },
                    { 2, "Household Items", null },
                    { 3, "Office Supplies", null },
                    { 4, "Outdoor Gear", null },
                    { 5, "Sports Equipment", null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "ContactInfo", "CustomerName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St, City A", "alice.johnson@email.com", "Alice Johnson", "123-456-7890" },
                    { 2, "456 Elm St, City B", "bob.smith@email.com", "Bob Smith", "234-567-8901" },
                    { 3, "789 Maple Ave, City C", "carol.white@email.com", "Carol White", "345-678-9012" },
                    { 4, "101 Pine Rd, City D", "david.brown@email.com", "David Brown", "456-789-0123" },
                    { 5, "202 Oak Blvd, City E", "eva.green@email.com", "Eva Green", "567-890-1234" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "Address", "ContactInfo", "PhoneNumber", "SupplierName" },
                values: new object[,]
                {
                    { 1, "101 Alpha Ave, City A", "contact@alphasupplies.com", "123-456-7890", "Alpha Supplies" },
                    { 2, "202 Beta Blvd, City B", "info@betaindustries.com", "234-567-8901", "Beta Industries" },
                    { 3, "303 Gamma St, City C", "support@gammagoods.com", "345-678-9012", "Gamma Goods" },
                    { 4, "404 Delta Rd, City D", "sales@deltawholesale.com", "456-789-0123", "Delta Wholesale" },
                    { 5, "505 Epsilon Ln, City E", "inquiry@epsilon.com", "567-890-1234", "Epsilon Enterprises" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseID", "Location", "WarehouseName" },
                values: new object[,]
                {
                    { 1, "Downtown City A", "Central Warehouse" },
                    { 2, "Uptown City B", "Northside Warehouse" },
                    { 3, "East District City C", "East End Warehouse" },
                    { 4, "Westside City D", "Westside Warehouse" },
                    { 5, "Southside City E", "Southpoint Warehouse" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "OrderDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 150.0 },
                    { 2, 2, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 200.0 },
                    { 3, 3, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 350.0 },
                    { 4, 4, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shipped", 400.0 },
                    { 5, 5, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled", 250.0 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "CategoryID", "Description", "ImageURL", "ProductName", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, "High-performance laptop", "", "Laptop", 999.99000000000001 },
                    { 2, 2, "Bagless vacuum cleaner", "", "Vacuum Cleaner", 150.0 },
                    { 3, 3, "Ergonomic office chair", "", "Office Chair", 120.5 },
                    { 4, 4, "Two-person tent", "", "Tent", 200.75 },
                    { 5, 5, "Standard size soccer ball", "", "Soccer Ball", 30.0 },
                    { 6, 1, "Latest model smartphone", "", "Smartphone", 699.99000000000001 },
                    { 7, 2, "High-speed blender", "", "Blender", 49.990000000000002 },
                    { 8, 3, "LED desk lamp", "", "Desk Lamp", 25.75 },
                    { 9, 4, "Water-resistant backpack", "", "Backpack", 45.5 },
                    { 10, 5, "Professional basketball", "", "Basketball", 25.0 }
                });

            migrationBuilder.InsertData(
                table: "Receivings",
                columns: new[] { "ReceivingID", "ReceivingDate", "SupplierID", "WarehouseID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2023, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 4, new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 },
                    { 5, new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "InventoryID", "ProductID", "QuantityAvailable", "WarehouseID" },
                values: new object[,]
                {
                    { 1, 1, 100, 1 },
                    { 2, 2, 50, 1 },
                    { 3, 3, 75, 2 },
                    { 4, 4, 120, 2 },
                    { 5, 5, 30, 3 },
                    { 6, 6, 60, 3 },
                    { 7, 7, 40, 4 },
                    { 8, 8, 90, 4 },
                    { 9, 9, 55, 5 },
                    { 10, 10, 25, 5 },
                    { 11, 1, 80, 2 },
                    { 12, 2, 100, 3 },
                    { 13, 3, 65, 4 },
                    { 14, 4, 45, 5 },
                    { 15, 5, 110, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailsID", "OrderID", "ProductID", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 10.99 },
                    { 2, 1, 2, 1, 15.49 },
                    { 3, 2, 1, 3, 10.99 },
                    { 4, 2, 3, 1, 12.0 },
                    { 5, 3, 2, 2, 15.49 },
                    { 6, 3, 4, 1, 8.5 },
                    { 7, 4, 5, 4, 5.9900000000000002 },
                    { 8, 4, 6, 2, 7.5 },
                    { 9, 5, 3, 1, 12.0 },
                    { 10, 5, 7, 5, 3.9900000000000002 },
                    { 11, 1, 8, 1, 6.4900000000000002 },
                    { 12, 2, 9, 2, 14.99 },
                    { 13, 3, 10, 3, 9.9900000000000002 },
                    { 14, 4, 1, 1, 10.99 },
                    { 15, 5, 2, 2, 15.49 }
                });

            migrationBuilder.InsertData(
                table: "ReceivingDetails",
                columns: new[] { "ReceivingDetailsID", "ProductID", "Quantity", "ReceivingID" },
                values: new object[,]
                {
                    { 1, 1, 50, 1 },
                    { 2, 2, 30, 1 },
                    { 3, 3, 40, 2 },
                    { 4, 4, 60, 2 },
                    { 5, 5, 20, 3 },
                    { 6, 6, 25, 3 },
                    { 7, 7, 15, 4 },
                    { 8, 8, 35, 4 },
                    { 9, 9, 50, 5 },
                    { 10, 10, 20, 5 },
                    { 11, 3, 45, 1 },
                    { 12, 4, 55, 2 },
                    { 13, 5, 10, 3 },
                    { 14, 6, 30, 4 },
                    { 15, 7, 60, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductID",
                table: "Inventory",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_WarehouseID",
                table: "Inventory",
                column: "WarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingDetails_ProductID",
                table: "ReceivingDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingDetails_ReceivingID",
                table: "ReceivingDetails",
                column: "ReceivingID");

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_SupplierID",
                table: "Receivings",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_WarehouseID",
                table: "Receivings",
                column: "WarehouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ReceivingDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Receivings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
