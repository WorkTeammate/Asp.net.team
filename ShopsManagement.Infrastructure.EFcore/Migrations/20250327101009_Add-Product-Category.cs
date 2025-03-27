using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopsManagement.Infrastructure.EFcore.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureAlt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyWords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
