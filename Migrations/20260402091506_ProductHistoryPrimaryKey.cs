using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace store_stock_tracker.Migrations
{
    /// <inheritdoc />
    public partial class ProductHistoryPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "Id",
                table: "ProductHistories",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Id",
                table: "ProductHistories");
        }
    }
}
