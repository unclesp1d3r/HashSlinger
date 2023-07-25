#nullable disable

namespace HashSlinger.Api.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class ExposedChunks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentError_Chunk_ChunkId",
                table: "AgentError");

            migrationBuilder.DropForeignKey(
                name: "FK_Chunk_Agents_AgentId",
                table: "Chunk");

            migrationBuilder.DropForeignKey(
                name: "FK_Chunk_Tasks_TaskId",
                table: "Chunk");

            migrationBuilder.DropForeignKey(
                name: "FK_HashBase_Chunk_ChunkId",
                table: "HashBase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chunk",
                table: "Chunk");

            migrationBuilder.RenameTable(
                name: "Chunk",
                newName: "Chunks");

            migrationBuilder.RenameIndex(
                name: "IX_Chunk_TaskId",
                table: "Chunks",
                newName: "IX_Chunks_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Chunk_AgentId",
                table: "Chunks",
                newName: "IX_Chunks_AgentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chunks",
                table: "Chunks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentError_Chunks_ChunkId",
                table: "AgentError",
                column: "ChunkId",
                principalTable: "Chunks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chunks_Agents_AgentId",
                table: "Chunks",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chunks_Tasks_TaskId",
                table: "Chunks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HashBase_Chunks_ChunkId",
                table: "HashBase",
                column: "ChunkId",
                principalTable: "Chunks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentError_Chunks_ChunkId",
                table: "AgentError");

            migrationBuilder.DropForeignKey(
                name: "FK_Chunks_Agents_AgentId",
                table: "Chunks");

            migrationBuilder.DropForeignKey(
                name: "FK_Chunks_Tasks_TaskId",
                table: "Chunks");

            migrationBuilder.DropForeignKey(
                name: "FK_HashBase_Chunks_ChunkId",
                table: "HashBase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chunks",
                table: "Chunks");

            migrationBuilder.RenameTable(
                name: "Chunks",
                newName: "Chunk");

            migrationBuilder.RenameIndex(
                name: "IX_Chunks_TaskId",
                table: "Chunk",
                newName: "IX_Chunk_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Chunks_AgentId",
                table: "Chunk",
                newName: "IX_Chunk_AgentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chunk",
                table: "Chunk",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentError_Chunk_ChunkId",
                table: "AgentError",
                column: "ChunkId",
                principalTable: "Chunk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chunk_Agents_AgentId",
                table: "Chunk",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chunk_Tasks_TaskId",
                table: "Chunk",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HashBase_Chunk_ChunkId",
                table: "HashBase",
                column: "ChunkId",
                principalTable: "Chunk",
                principalColumn: "Id");
        }
    }
}
