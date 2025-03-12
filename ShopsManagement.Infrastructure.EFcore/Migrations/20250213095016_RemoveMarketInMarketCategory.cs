using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopsManagement.Infrastructure.EFcore.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMarketInMarketCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarketsId",
                table: "MarketCategories");

            migrationBuilder.AddColumn<string>(
                name: "KewWords",
                table: "Markets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Markets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KewWords",
                table: "Markets");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Markets");

            migrationBuilder.AddColumn<long>(
                name: "MarketsId",
                table: "MarketCategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
