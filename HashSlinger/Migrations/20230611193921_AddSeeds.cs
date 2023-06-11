using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HashSlinger.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AccessGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Admins");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsValid", "LastLoginDate", "PasswordHash", "PasswordSalt", "RegisteredSince", "UserName" },
                values: new object[] { 2, "admin@localhost", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D67A512B30394510FF1241A04B2CB45FBAE0E1A8B675FAC2F51C0D5A3E9A15A01DF4B6C1B199606C60126E9005B2BE8E507365C4EFFA3580BC55DC4F24428D22", new byte[] { 173, 20, 26, 124, 85, 58, 38, 143, 252, 14, 40, 4, 253, 98, 186, 194, 91, 65, 144, 73, 135, 108, 243, 140, 69, 174, 159, 92, 223, 121, 0, 123, 123, 28, 204, 89, 66, 107, 96, 238, 170, 49, 121, 201, 72, 17, 107, 229, 61, 31, 23, 68, 58, 215, 249, 149, 96, 212, 4, 179, 166, 62, 129, 27 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AccessGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Admin");
        }
    }
}
