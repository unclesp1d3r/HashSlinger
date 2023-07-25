#nullable disable

namespace HashSlinger.Api.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class AddedIndexesToFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Files_FileGuid",
                table: "Files",
                column: "FileGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileName",
                table: "Files",
                column: "FileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Files_FileGuid",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_FileName",
                table: "Files");
        }
    }
}
