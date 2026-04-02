using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store_stock_tracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "ProductHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "ProductHistories");
        }
    }
}
