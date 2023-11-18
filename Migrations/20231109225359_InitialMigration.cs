using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletWise.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AlterDatabase()
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "tags",
            //     columns: table => new
            //     {
            //         tag_id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         tag_user_id = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_bin")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         tag_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_bin")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         tag_description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false, collation: "utf8mb4_0900_bin")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         tag_mod_timestamp = table.Column<DateTime>(type: "datetime", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.tag_id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_bin");

            // migrationBuilder.CreateTable(
            //     name: "expenses",
            //     columns: table => new
            //     {
            //         expen_id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         expen_user_id = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_bin")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         expen_currency = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_0900_bin")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         expen_total_amount = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
            //         expen_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_bin")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         expen_date = table.Column<DateTime>(type: "date", nullable: false),
            //         expen_tag1 = table.Column<int>(type: "int", nullable: true),
            //         expen_tag2 = table.Column<int>(type: "int", nullable: true),
            //         expen_tag3 = table.Column<int>(type: "int", nullable: true),
            //         expen_tag4 = table.Column<int>(type: "int", nullable: true),
            //         expen_tag5 = table.Column<int>(type: "int", nullable: true),
            //         expen_location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_bin")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         expen_mod_timestamp = table.Column<DateTime>(type: "datetime", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.expen_id);
            //         table.ForeignKey(
            //             name: "FK_tags_expenses1",
            //             column: x => x.expen_tag1,
            //             principalTable: "tags",
            //             principalColumn: "tag_id");
            //         table.ForeignKey(
            //             name: "FK_tags_expenses2",
            //             column: x => x.expen_tag2,
            //             principalTable: "tags",
            //             principalColumn: "tag_id");
            //         table.ForeignKey(
            //             name: "FK_tags_expenses3",
            //             column: x => x.expen_tag3,
            //             principalTable: "tags",
            //             principalColumn: "tag_id");
            //         table.ForeignKey(
            //             name: "FK_tags_expenses4",
            //             column: x => x.expen_tag4,
            //             principalTable: "tags",
            //             principalColumn: "tag_id");
            //         table.ForeignKey(
            //             name: "FK_tags_expenses5",
            //             column: x => x.expen_tag5,
            //             principalTable: "tags",
            //             principalColumn: "tag_id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_bin");

            // migrationBuilder.CreateTable(
            //     name: "expense_details",
            //     columns: table => new
            //     {
            //         exdet_id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //         exdet_expen_id = table.Column<int>(type: "int", nullable: false),
            //         exdet_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_0900_bin")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         exdet_amount = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
            //         exdet_currency = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_0900_bin")
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         exdet_mod_timestamp = table.Column<DateTime>(type: "datetime", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.exdet_id);
            //         table.ForeignKey(
            //             name: "FK_expenses_expense_details",
            //             column: x => x.exdet_expen_id,
            //             principalTable: "expenses",
            //             principalColumn: "expen_id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4")
            //     .Annotation("Relational:Collation", "utf8mb4_0900_bin");

            // migrationBuilder.CreateIndex(
            //     name: "FK_expenses_expense_details",
            //     table: "expense_details",
            //     column: "exdet_expen_id");

            // migrationBuilder.CreateIndex(
            //     name: "FK_tags_expenses1",
            //     table: "expenses",
            //     column: "expen_tag1");

            // migrationBuilder.CreateIndex(
            //     name: "FK_tags_expenses2",
            //     table: "expenses",
            //     column: "expen_tag2");

            // migrationBuilder.CreateIndex(
            //     name: "FK_tags_expenses3",
            //     table: "expenses",
            //     column: "expen_tag3");

            // migrationBuilder.CreateIndex(
            //     name: "FK_tags_expenses4",
            //     table: "expenses",
            //     column: "expen_tag4");

            // migrationBuilder.CreateIndex(
            //     name: "FK_tags_expenses5",
            //     table: "expenses",
            //     column: "expen_tag5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "expense_details");

            // migrationBuilder.DropTable(
            //     name: "expenses");

            // migrationBuilder.DropTable(
            //     name: "tags");
        }
    }
}
