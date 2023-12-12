using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletWise.Migrations
{
    /// <inheritdoc />
    public partial class InsertIntoCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.RenameIndex(
            //     name: "FK_currencies_expenses",
            //     table: "expenses",
            //     newName: "FK_currency_expenses");

            migrationBuilder.Sql(@"INSERT INTO currencies
                (curr_id,curr_name,curr_acronym)
                VALUES
                (2,'Dollar','USD');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.Sql(@"DELETE FROM currencies WHERE curr_acronym ='USD';");
            // migrationBuilder.RenameIndex(
            //     name: "FK_currency_expenses",
            //     table: "expenses",
            //     newName: "FK_currencies_expenses");
        }
    }
}
