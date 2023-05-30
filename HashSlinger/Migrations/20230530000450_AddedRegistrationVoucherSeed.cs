using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HashSlinger.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedRegistrationVoucherSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RegistrationVouchers",
                columns: new[] { "Id", "Expiration", "Voucher" },
                values: new object[] { 1, new DateTime(2024, 5, 30, 0, 4, 49, 982, DateTimeKind.Utc).AddTicks(4800), "test123456" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RegistrationVouchers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
