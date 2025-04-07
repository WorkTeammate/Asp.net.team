using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopsManagement.Infrastructure.EFcore.Migrations
{
    /// <inheritdoc />
    public partial class addFileProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileProducts",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileProducts",
                table: "Products");
        }
    }
}
