using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HashSlinger.Api.Migrations
{
    /// <inheritdoc />
    public partial class ExposeAccessGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessGroupAgent_AccessGroup_AccessGroupsId",
                table: "AccessGroupAgent");

            migrationBuilder.DropForeignKey(
                name: "FK_AccessGroupUser_AccessGroup_AccessGroupsId",
                table: "AccessGroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_AccessGroup_AccessGroupId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Hashlist_AccessGroup_AccessGroupId",
                table: "Hashlist");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationVouchers_AccessGroup_AccessGroupId",
                table: "RegistrationVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskWrapper_AccessGroup_AccessGroupId",
                table: "TaskWrapper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessGroup",
                table: "AccessGroup");

            migrationBuilder.RenameTable(
                name: "AccessGroup",
                newName: "AccessGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessGroups",
                table: "AccessGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessGroupAgent_AccessGroups_AccessGroupsId",
                table: "AccessGroupAgent",
                column: "AccessGroupsId",
                principalTable: "AccessGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccessGroupUser_AccessGroups_AccessGroupsId",
                table: "AccessGroupUser",
                column: "AccessGroupsId",
                principalTable: "AccessGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AccessGroups_AccessGroupId",
                table: "Files",
                column: "AccessGroupId",
                principalTable: "AccessGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hashlist_AccessGroups_AccessGroupId",
                table: "Hashlist",
                column: "AccessGroupId",
                principalTable: "AccessGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationVouchers_AccessGroups_AccessGroupId",
                table: "RegistrationVouchers",
                column: "AccessGroupId",
                principalTable: "AccessGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskWrapper_AccessGroups_AccessGroupId",
                table: "TaskWrapper",
                column: "AccessGroupId",
                principalTable: "AccessGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessGroupAgent_AccessGroups_AccessGroupsId",
                table: "AccessGroupAgent");

            migrationBuilder.DropForeignKey(
                name: "FK_AccessGroupUser_AccessGroups_AccessGroupsId",
                table: "AccessGroupUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_AccessGroups_AccessGroupId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Hashlist_AccessGroups_AccessGroupId",
                table: "Hashlist");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationVouchers_AccessGroups_AccessGroupId",
                table: "RegistrationVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskWrapper_AccessGroups_AccessGroupId",
                table: "TaskWrapper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessGroups",
                table: "AccessGroups");

            migrationBuilder.RenameTable(
                name: "AccessGroups",
                newName: "AccessGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessGroup",
                table: "AccessGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessGroupAgent_AccessGroup_AccessGroupsId",
                table: "AccessGroupAgent",
                column: "AccessGroupsId",
                principalTable: "AccessGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccessGroupUser_AccessGroup_AccessGroupsId",
                table: "AccessGroupUser",
                column: "AccessGroupsId",
                principalTable: "AccessGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AccessGroup_AccessGroupId",
                table: "Files",
                column: "AccessGroupId",
                principalTable: "AccessGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hashlist_AccessGroup_AccessGroupId",
                table: "Hashlist",
                column: "AccessGroupId",
                principalTable: "AccessGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationVouchers_AccessGroup_AccessGroupId",
                table: "RegistrationVouchers",
                column: "AccessGroupId",
                principalTable: "AccessGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskWrapper_AccessGroup_AccessGroupId",
                table: "TaskWrapper",
                column: "AccessGroupId",
                principalTable: "AccessGroup",
                principalColumn: "Id");
        }
    }
}
