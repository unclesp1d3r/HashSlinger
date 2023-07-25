#nullable disable

namespace HashSlinger.Api.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Agents_AgentId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Tasks_TaskId",
                table: "Assignment");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Agents_AgentId",
                table: "Assignment",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Tasks_TaskId",
                table: "Assignment",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Agents_AgentId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Tasks_TaskId",
                table: "Assignment");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Agents_AgentId",
                table: "Assignment",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Tasks_TaskId",
                table: "Assignment",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
