using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopsManagement.Infrastructure.EFcore.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountForCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AccountId",
                table: "ProductCategory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "ProductCategory");
        }
    }
}
