using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techMADT2.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductImagesEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    Alt = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 5, 24, 2, 28, 39, 559, DateTimeKind.Local).AddTicks(6377), new Guid("41293a43-a6e3-4c4e-bfa2-6279b5909702"), new Guid("66c91c3b-04fb-48d1-853b-3b7cd4dd49f4") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 5, 24, 2, 28, 39, 559, DateTimeKind.Local).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 5, 24, 2, 28, 39, 559, DateTimeKind.Local).AddTicks(6963));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 5, 23, 1, 48, 47, 180, DateTimeKind.Local).AddTicks(109), new Guid("1acdfa2e-0cdf-45db-b57d-3045778f77e3"), new Guid("7086ab86-b84d-44b3-8379-5657e471c89a") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 5, 23, 1, 48, 47, 180, DateTimeKind.Local).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 5, 23, 1, 48, 47, 180, DateTimeKind.Local).AddTicks(565));
        }
    }
}
