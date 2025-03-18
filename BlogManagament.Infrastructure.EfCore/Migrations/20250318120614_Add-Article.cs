using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogManagament.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    CanonicalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_ArticleCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ArticleCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_CategoryId",
                table: "Article",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
