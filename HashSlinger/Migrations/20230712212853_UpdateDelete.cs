#nullable disable

namespace HashSlinger.Api.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class UpdateDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskWrapper_Hashlists_HashlistId",
                table: "TaskWrapper");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskWrapper_Hashlists_HashlistId",
                table: "TaskWrapper",
                column: "HashlistId",
                principalTable: "Hashlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskWrapper_Hashlists_HashlistId",
                table: "TaskWrapper");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskWrapper_Hashlists_HashlistId",
                table: "TaskWrapper",
                column: "HashlistId",
                principalTable: "Hashlists",
                principalColumn: "Id");
        }
    }
}
