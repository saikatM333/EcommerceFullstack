using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookOrderingSystem.Migrations
{
    /// <inheritdoc />
    public partial class addreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 8, 4, 6, 7, 17, 445, DateTimeKind.Utc).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 8, 4, 6, 7, 17, 445, DateTimeKind.Utc).AddTicks(1876));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 8, 4, 6, 7, 17, 445, DateTimeKind.Utc).AddTicks(1613));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 8, 4, 6, 7, 17, 445, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 8, 4, 6, 7, 17, 445, DateTimeKind.Utc).AddTicks(1620));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 8, 4, 6, 7, 17, 445, DateTimeKind.Utc).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 8, 4, 6, 7, 17, 445, DateTimeKind.Utc).AddTicks(1623));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CustomerId", "Date", "ProductId", "Rating" },
                values: new object[] { 6, "avg value for money.", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 7, 30, 13, 33, 24, 969, DateTimeKind.Utc).AddTicks(6568));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 7, 30, 13, 33, 24, 969, DateTimeKind.Utc).AddTicks(6572));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 7, 30, 13, 33, 24, 969, DateTimeKind.Utc).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 7, 30, 13, 33, 24, 969, DateTimeKind.Utc).AddTicks(6345));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 7, 30, 13, 33, 24, 969, DateTimeKind.Utc).AddTicks(6346));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2024, 7, 30, 13, 33, 24, 969, DateTimeKind.Utc).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2024, 7, 30, 13, 33, 24, 969, DateTimeKind.Utc).AddTicks(6349));
        }
    }
}
