using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HashSlinger.Api.Migrations
{
    /// <inheritdoc />
    public partial class restorelinkage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HashBinary_Hashlists_HashlistId",
                table: "HashBinary");

            migrationBuilder.AddForeignKey(
                name: "FK_HashBinary_Hashlists_HashlistId",
                table: "HashBinary",
                column: "HashlistId",
                principalTable: "Hashlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HashBinary_Hashlists_HashlistId",
                table: "HashBinary");

            migrationBuilder.AddForeignKey(
                name: "FK_HashBinary_Hashlists_HashlistId",
                table: "HashBinary",
                column: "HashlistId",
                principalTable: "Hashlists",
                principalColumn: "Id");
        }
    }
}
