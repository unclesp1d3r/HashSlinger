#nullable disable

namespace HashSlinger.Api.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class EvenMoreOnDeleteChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hashlists_HashTypes_HashTypeId",
                table: "Hashlists");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthChecks_DownloadableBinaries_CrackerBinaryId",
                table: "HealthChecks");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthChecks_HashTypes_HashTypeId",
                table: "HealthChecks");

            migrationBuilder.AddForeignKey(
                name: "FK_Hashlists_HashTypes_HashTypeId",
                table: "Hashlists",
                column: "HashTypeId",
                principalTable: "HashTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthChecks_DownloadableBinaries_CrackerBinaryId",
                table: "HealthChecks",
                column: "CrackerBinaryId",
                principalTable: "DownloadableBinaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthChecks_HashTypes_HashTypeId",
                table: "HealthChecks",
                column: "HashTypeId",
                principalTable: "HashTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hashlists_HashTypes_HashTypeId",
                table: "Hashlists");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthChecks_DownloadableBinaries_CrackerBinaryId",
                table: "HealthChecks");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthChecks_HashTypes_HashTypeId",
                table: "HealthChecks");

            migrationBuilder.AddForeignKey(
                name: "FK_Hashlists_HashTypes_HashTypeId",
                table: "Hashlists",
                column: "HashTypeId",
                principalTable: "HashTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthChecks_DownloadableBinaries_CrackerBinaryId",
                table: "HealthChecks",
                column: "CrackerBinaryId",
                principalTable: "DownloadableBinaries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthChecks_HashTypes_HashTypeId",
                table: "HealthChecks",
                column: "HashTypeId",
                principalTable: "HashTypes",
                principalColumn: "Id");
        }
    }
}
