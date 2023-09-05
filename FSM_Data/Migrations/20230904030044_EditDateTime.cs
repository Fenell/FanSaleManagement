using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSM_Data.Migrations
{
    public partial class EditDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("303623c2-6719-4e94-90ab-6f578ff47b9e"),
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("d7b51740-ad10-45a2-914a-8d6382c61434"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OrderDetail",
                keyColumn: "Id",
                keyValue: new Guid("14a3dd60-38fa-4151-9509-c335ee3a12c4"),
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OrderDetail",
                keyColumn: "Id",
                keyValue: new Guid("9c893da5-203a-4056-8eb2-6caf385187f9"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("31f9ee52-fd3b-4684-8755-834865609cc4"),
                column: "CreatedAt",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("b56cc91f-948f-494f-a4f6-e8b966c8e5cc"),
                column: "CreatedAt",
                value: new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("303623c2-6719-4e94-90ab-6f578ff47b9e"),
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: new Guid("d7b51740-ad10-45a2-914a-8d6382c61434"),
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OrderDetail",
                keyColumn: "Id",
                keyValue: new Guid("14a3dd60-38fa-4151-9509-c335ee3a12c4"),
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "OrderDetail",
                keyColumn: "Id",
                keyValue: new Guid("9c893da5-203a-4056-8eb2-6caf385187f9"),
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("31f9ee52-fd3b-4684-8755-834865609cc4"),
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("b56cc91f-948f-494f-a4f6-e8b966c8e5cc"),
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
