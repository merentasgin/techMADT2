using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techMADT2.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdreslerEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdateDate", "UserGuid" },
                values: new object[] { new DateTime(2025, 5, 22, 20, 36, 55, 691, DateTimeKind.Local).AddTicks(250), new Guid("10b004e9-9673-4589-be37-997a4d14f97e"), new Guid("45ad0e56-999a-4e02-8b84-41b93c50c6ff") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 5, 22, 20, 36, 55, 691, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 5, 22, 20, 36, 55, 691, DateTimeKind.Local).AddTicks(829));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
