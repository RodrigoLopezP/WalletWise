using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletWise.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnExpenNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "expen_note",
                table: "expenses",
                type: "text",
                nullable: true,
                collation: "utf8mb4_0900_bin")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expen_note",
                table: "expenses");
        }
    }
}
