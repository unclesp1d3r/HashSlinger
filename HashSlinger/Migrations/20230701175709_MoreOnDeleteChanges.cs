#nullable disable

namespace HashSlinger.Api.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class MoreOnDeleteChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentStat_Agents_AgentId",
                table: "AgentStat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chunks_Tasks_TaskId",
                table: "Chunks");

            migrationBuilder.DropForeignKey(
                name: "FK_DownloadableBinaries_CrackerBinaryTypes_CrackerBinaryTypeId",
                table: "DownloadableBinaries");

            migrationBuilder.DropForeignKey(
                name: "FK_FileDownload_Files_FileId",
                table: "FileDownload");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_AccessGroups_AccessGroupId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthCheckAgents_Agents_AgentId",
                table: "HealthCheckAgents");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentStat_Agents_AgentId",
                table: "AgentStat",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chunks_Tasks_TaskId",
                table: "Chunks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DownloadableBinaries_CrackerBinaryTypes_CrackerBinaryTypeId",
                table: "DownloadableBinaries",
                column: "CrackerBinaryTypeId",
                principalTable: "CrackerBinaryTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileDownload_Files_FileId",
                table: "FileDownload",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AccessGroups_AccessGroupId",
                table: "Files",
                column: "AccessGroupId",
                principalTable: "AccessGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthCheckAgents_Agents_AgentId",
                table: "HealthCheckAgents",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentStat_Agents_AgentId",
                table: "AgentStat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chunks_Tasks_TaskId",
                table: "Chunks");

            migrationBuilder.DropForeignKey(
                name: "FK_DownloadableBinaries_CrackerBinaryTypes_CrackerBinaryTypeId",
                table: "DownloadableBinaries");

            migrationBuilder.DropForeignKey(
                name: "FK_FileDownload_Files_FileId",
                table: "FileDownload");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_AccessGroups_AccessGroupId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthCheckAgents_Agents_AgentId",
                table: "HealthCheckAgents");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentStat_Agents_AgentId",
                table: "AgentStat",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chunks_Tasks_TaskId",
                table: "Chunks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DownloadableBinaries_CrackerBinaryTypes_CrackerBinaryTypeId",
                table: "DownloadableBinaries",
                column: "CrackerBinaryTypeId",
                principalTable: "CrackerBinaryTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FileDownload_Files_FileId",
                table: "FileDownload",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AccessGroups_AccessGroupId",
                table: "Files",
                column: "AccessGroupId",
                principalTable: "AccessGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthCheckAgents_Agents_AgentId",
                table: "HealthCheckAgents",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");
        }
    }
}
