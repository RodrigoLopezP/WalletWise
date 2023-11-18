using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletWise.Migrations
{
    /// <inheritdoc />
    public partial class CreateCurrencyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expen_currency",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "exdet_currency",
                table: "expense_details");

            migrationBuilder.AddColumn<int>(
                name: "expen_curr_id",
                table: "expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "exdet_curr_id",
                table: "expense_details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    curr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    curr_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_bin")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    curr_acronym = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_0900_bin")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.curr_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_bin");

            migrationBuilder.CreateIndex(
                name: "FK_currencies_expenses",
                table: "expenses",
                column: "expen_curr_id");

            migrationBuilder.CreateIndex(
                name: "FK_currency_expense_details",
                table: "expense_details",
                column: "exdet_curr_id");

            migrationBuilder.AddForeignKey(
                name: "FK_currency_expense_details",
                table: "expense_details",
                column: "exdet_curr_id",
                principalTable: "currencies",
                principalColumn: "curr_id");

            migrationBuilder.Sql(@$"
                INSERT INTO currencies
                (curr_id,curr_name,Curre_acronym)
                VALUES
                (1,'Euro','EUR');");
            migrationBuilder.Sql(@$"
                UPDATE expenses
                SET
                expen_curr_id = 1
                WHERE expen_curr_id is null
                OR expen_curr_id =0;");
            migrationBuilder.AddForeignKey(
                name: "FK_currencies_expenses",
                table: "expenses",
                column: "expen_curr_id",
                principalTable: "currencies",
                principalColumn: "curr_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_currency_expense_details",
                table: "expense_details");

            migrationBuilder.DropForeignKey(
                name: "FK_currency_expenses",
                table: "expenses");

            migrationBuilder.Sql(@$"
                DELETE FROM currencies
                WHERE curre_acronym='EUR' AND curr_name='Euro' AND curr_id=1;");

            migrationBuilder.DropTable(
                name: "currencies");

            migrationBuilder.DropIndex(
                name: "FK_currencies_expenses",
                table: "expenses");

            migrationBuilder.DropIndex(
                name: "FK_currency_expense_details",
                table: "expense_details");

            migrationBuilder.DropColumn(
                name: "expen_curr_id",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "exdet_curr_id",
                table: "expense_details");

            migrationBuilder.AddColumn<string>(
                name: "expen_currency",
                table: "expenses",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_bin")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "exdet_currency",
                table: "expense_details",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_bin")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
