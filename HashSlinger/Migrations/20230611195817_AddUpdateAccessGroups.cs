using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HashSlinger.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdateAccessGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_TaskWrapper_AccessGroups_AccessGroupId",
                table: "TaskWrapper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessGroups",
                table: "AccessGroups");

            migrationBuilder.RenameTable(
                name: "AccessGroups",
                newName: "AccessGroup");

            migrationBuilder.AddColumn<int>(
                name: "AccessGroupId",
                table: "RegistrationVouchers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessGroup",
                table: "AccessGroup",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "RegistrationVouchers",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccessGroupId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "AA05D0A144D88656ED26CBBEFDC4B84DEBD276117C960321FB17F969A2A9E834981315C022C7A0CE8966F7BFD138367D789F95B123F190E6766AF9501F73F473", new byte[] { 47, 121, 222, 175, 51, 196, 236, 172, 227, 128, 123, 42, 188, 223, 181, 193, 162, 130, 75, 70, 161, 224, 160, 205, 58, 161, 27, 231, 9, 214, 99, 196, 184, 204, 51, 36, 49, 219, 104, 91, 132, 47, 251, 222, 173, 189, 88, 156, 247, 99, 162, 76, 60, 218, 132, 253, 123, 39, 71, 99, 192, 135, 199, 232 } });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationVouchers_AccessGroupId",
                table: "RegistrationVouchers",
                column: "AccessGroupId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_RegistrationVouchers_AccessGroupId",
                table: "RegistrationVouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessGroup",
                table: "AccessGroup");

            migrationBuilder.DropColumn(
                name: "AccessGroupId",
                table: "RegistrationVouchers");

            migrationBuilder.RenameTable(
                name: "AccessGroup",
                newName: "AccessGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessGroups",
                table: "AccessGroups",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "D67A512B30394510FF1241A04B2CB45FBAE0E1A8B675FAC2F51C0D5A3E9A15A01DF4B6C1B199606C60126E9005B2BE8E507365C4EFFA3580BC55DC4F24428D22", new byte[] { 173, 20, 26, 124, 85, 58, 38, 143, 252, 14, 40, 4, 253, 98, 186, 194, 91, 65, 144, 73, 135, 108, 243, 140, 69, 174, 159, 92, 223, 121, 0, 123, 123, 28, 204, 89, 66, 107, 96, 238, 170, 49, 121, 201, 72, 17, 107, 229, 61, 31, 23, 68, 58, 215, 249, 149, 96, 212, 4, 179, 166, 62, 129, 27 } });

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
                name: "FK_TaskWrapper_AccessGroups_AccessGroupId",
                table: "TaskWrapper",
                column: "AccessGroupId",
                principalTable: "AccessGroups",
                principalColumn: "Id");
        }
    }
}
