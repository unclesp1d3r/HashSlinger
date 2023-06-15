using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HashSlinger.Api.Migrations
{
    /// <inheritdoc />
    public partial class GiveVouchersAccessGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiKey_Users_UserId",
                table: "ApiKey");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationSetting_Users_UserId",
                table: "NotificationSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Users_UserId",
                table: "Session");

            migrationBuilder.AddForeignKey(
                name: "FK_ApiKey_Users_UserId",
                table: "ApiKey",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationSetting_Users_UserId",
                table: "NotificationSetting",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Users_UserId",
                table: "Session",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiKey_Users_UserId",
                table: "ApiKey");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationSetting_Users_UserId",
                table: "NotificationSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_Session_Users_UserId",
                table: "Session");

            migrationBuilder.AddForeignKey(
                name: "FK_ApiKey_Users_UserId",
                table: "ApiKey",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationSetting_Users_UserId",
                table: "NotificationSetting",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Session_Users_UserId",
                table: "Session",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
