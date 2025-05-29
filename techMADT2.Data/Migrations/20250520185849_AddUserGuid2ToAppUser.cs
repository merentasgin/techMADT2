using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techMADT2.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserGuid2ToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 5, 20, 21, 58, 48, 335, DateTimeKind.Local).AddTicks(2832), new Guid("b4e04c20-7f76-4c30-b65b-f8ec26beba6e"), new Guid("514490ed-a9d8-46ad-bc39-f72eef6ba566") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 5, 20, 21, 58, 48, 335, DateTimeKind.Local).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 5, 20, 21, 58, 48, 335, DateTimeKind.Local).AddTicks(3433));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 5, 20, 16, 2, 47, 89, DateTimeKind.Local).AddTicks(3321), new Guid("439ba455-2570-44c6-9613-9559f1a1a4d0"), new Guid("f9ba585e-5b56-4e14-be08-e3195d0b7fac") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 5, 20, 16, 2, 47, 89, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 5, 20, 16, 2, 47, 89, DateTimeKind.Local).AddTicks(3834));
        }
    }
}
