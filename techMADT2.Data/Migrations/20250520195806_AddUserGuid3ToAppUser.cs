using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techMADT2.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserGuid3ToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 5, 20, 22, 58, 5, 924, DateTimeKind.Local).AddTicks(5591), new Guid("4c38323d-a703-4b13-99b4-495db8bcdcc0"), new Guid("91816ba2-4a3a-4714-baa1-2dd0526fc0e5") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 5, 20, 22, 58, 5, 924, DateTimeKind.Local).AddTicks(6079));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 5, 20, 22, 58, 5, 924, DateTimeKind.Local).AddTicks(6082));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
