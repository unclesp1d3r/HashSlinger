using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HashSlinger.Api.Migrations
{
    /// <inheritdoc />
    public partial class MergedHashAndHashbinary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Essid",
                table: "Hash");

            migrationBuilder.RenameColumn(
                name: "Hash",
                table: "HashBinary",
                newName: "HashBytes");

            migrationBuilder.AlterColumn<string>(
                name: "Plaintext",
                table: "HashBinary",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashBytes",
                table: "HashBinary",
                newName: "Hash");

            migrationBuilder.AlterColumn<string>(
                name: "Plaintext",
                table: "HashBinary",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Essid",
                table: "Hash",
                type: "text",
                nullable: true);
        }
    }
}
