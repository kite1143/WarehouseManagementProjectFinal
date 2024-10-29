using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class AlterOrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 2,
                column: "OrderID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 5,
                column: "OrderID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 8,
                column: "OrderID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 13,
                column: "Quantity",
                value: 13);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 15,
                column: "OrderID",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 1,
                column: "UnitPrice",
                value: 10.99);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 2,
                columns: new[] { "OrderID", "UnitPrice" },
                values: new object[] { 1, 15.49 });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 3,
                column: "UnitPrice",
                value: 10.99);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 4,
                column: "UnitPrice",
                value: 12.0);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 5,
                columns: new[] { "OrderID", "UnitPrice" },
                values: new object[] { 3, 15.49 });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 6,
                column: "UnitPrice",
                value: 8.5);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 7,
                column: "UnitPrice",
                value: 5.9900000000000002);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 8,
                columns: new[] { "OrderID", "UnitPrice" },
                values: new object[] { 4, 7.5 });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 9,
                column: "UnitPrice",
                value: 12.0);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 10,
                column: "UnitPrice",
                value: 3.9900000000000002);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 11,
                column: "UnitPrice",
                value: 6.4900000000000002);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 12,
                column: "UnitPrice",
                value: 14.99);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 13,
                columns: new[] { "Quantity", "UnitPrice" },
                values: new object[] { 3, 9.9900000000000002 });

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 14,
                column: "UnitPrice",
                value: 10.99);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailsID",
                keyValue: 15,
                columns: new[] { "OrderID", "UnitPrice" },
                values: new object[] { 5, 15.49 });
        }
    }
}
