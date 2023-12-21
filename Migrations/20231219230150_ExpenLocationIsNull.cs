using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletWise.Migrations
{
    /// <inheritdoc />
    public partial class ExpenLocationIsNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "expen_location",
                table: "expenses",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8mb4_0900_bin",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_bin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "expenses",
                keyColumn: "expen_location",
                keyValue: null,
                column: "expen_location",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "expen_location",
                table: "expenses",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                collation: "utf8mb4_0900_bin",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_bin");
        }
    }
}
