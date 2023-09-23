using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleArticleWebAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddModifiedParagraphColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModifiedParagraph",
                table: "Articlees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedParagraph",
                table: "Articlees");
        }
    }
}
