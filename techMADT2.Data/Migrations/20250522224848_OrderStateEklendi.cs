using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techMADT2.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderStateEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderState",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AppUsers_AppUserId",
                table: "Orders",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AppUsers_AppUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderState",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 5, 22, 22, 41, 46, 782, DateTimeKind.Local).AddTicks(3600), new Guid("e0446434-7b82-42e1-a46e-4d573d7bd72c"), new Guid("66b0ce5a-240d-476b-85bb-73e20e4c5d76") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 5, 22, 22, 41, 46, 782, DateTimeKind.Local).AddTicks(4061));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 5, 22, 22, 41, 46, 782, DateTimeKind.Local).AddTicks(4065));
        }
    }
}
