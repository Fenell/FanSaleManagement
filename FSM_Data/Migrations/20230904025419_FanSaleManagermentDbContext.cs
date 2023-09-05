using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSM_Data.Migrations
{
    public partial class FanSaleManagermentDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("702c6882-8782-481b-8d80-e5fb054bbdb2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Panasonic", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c579b0b0-3eb4-4052-868f-782a941e2a47"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Kangaroo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("428ffdfb-22df-4344-8298-c96975a3e832"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Quạt điều hoà", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("70e4623b-10b3-4935-b51d-381d7596cdb5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Quạt Cây", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "Address", "CreatedAt", "CustomerName", "IsDeleted", "PhoneNumber", "Status", "TotalAmount", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("303623c2-6719-4e94-90ab-6f578ff47b9e"), "Nghệ An", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lê Xuân Minh Chiến", true, "0866999999", 1, 2890000m, null },
                    { new Guid("d7b51740-ad10-45a2-914a-8d6382c61434"), "Thái Bình", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mai Tuấn Đạt", true, "1234567890", 1, 1950000m, null }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "IsDeleted", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("31f9ee52-fd3b-4684-8755-834865609cc4"), new Guid("702c6882-8782-481b-8d80-e5fb054bbdb2"), new Guid("70e4623b-10b3-4935-b51d-381d7596cdb5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Làm mát hiệu quả, tự động đảo chiều cho góc thổi rộng.\r\nKiểu dáng nhỏ gọn, trang nhã, chất liệu nhựa trơn bóng cao cấp.\r\nDiều khiển từ xa giúp điều chỉnh tốc độ gió, xoay chiều mà không phải di chuyển.", true, "F-409KBE", 2890000m, null });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "IsDeleted", "Name", "Price", "UpdatedAt" },
                values: new object[] { new Guid("b56cc91f-948f-494f-a4f6-e8b966c8e5cc"), new Guid("c579b0b0-3eb4-4052-868f-782a941e2a47"), new Guid("428ffdfb-22df-4344-8298-c96975a3e832"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quạt điều hòa công suất 100 W, làm mát trên diện tích 25 - 30 m2.\r\nTặng kèm hộp đá khô làm mát giúp giảm nhiệt độ tốt hơn.\r\nDung tích bình chứa nước 30 lít, sử dụng liên tục 10 - 15 tiếng.\r\n3 mức gió tùy chỉnh, tiện lợi với 3 chế độ gió thường - ngủ- tự nhiên.", true, "KG50F62", 1950000m, null });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "OrderId", "Price", "ProductId", "Quantity", "UpdatedAt" },
                values: new object[] { new Guid("14a3dd60-38fa-4151-9509-c335ee3a12c4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("303623c2-6719-4e94-90ab-6f578ff47b9e"), 2890000m, new Guid("31f9ee52-fd3b-4684-8755-834865609cc4"), 1, null });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "OrderId", "Price", "ProductId", "Quantity", "UpdatedAt" },
                values: new object[] { new Guid("9c893da5-203a-4056-8eb2-6caf385187f9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("d7b51740-ad10-45a2-914a-8d6382c61434"), 1950000m, new Guid("b56cc91f-948f-494f-a4f6-e8b966c8e5cc"), 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
