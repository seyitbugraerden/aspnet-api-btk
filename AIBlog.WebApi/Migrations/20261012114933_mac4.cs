using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIBlog.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mac4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLastVideoArticle",
                table: "Articles",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLastVideoArticle",
                table: "Articles");
        }
    }
}
