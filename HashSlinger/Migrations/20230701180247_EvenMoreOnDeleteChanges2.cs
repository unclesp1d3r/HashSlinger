#nullable disable

namespace HashSlinger.Api.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class EvenMoreOnDeleteChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Users_UserId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskWrapper_TaskWrapperId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Users_UserId",
                table: "Agents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskWrapper_TaskWrapperId",
                table: "Tasks",
                column: "TaskWrapperId",
                principalTable: "TaskWrapper",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Users_UserId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskWrapper_TaskWrapperId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Users_UserId",
                table: "Agents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskWrapper_TaskWrapperId",
                table: "Tasks",
                column: "TaskWrapperId",
                principalTable: "TaskWrapper",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
