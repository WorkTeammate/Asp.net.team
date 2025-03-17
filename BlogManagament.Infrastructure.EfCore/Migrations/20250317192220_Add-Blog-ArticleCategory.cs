using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogManagament.Infrastructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddBlogArticleCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(4000)", nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    KeyWords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanonicalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowOrder = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategory");
        }
    }
}
