using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HashSlinger.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenamedIpAddressField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastIp",
                table: "Agents",
                newName: "LastSeenIpAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastSeenIpAddress",
                table: "Agents",
                newName: "LastIp");
        }
    }
}
