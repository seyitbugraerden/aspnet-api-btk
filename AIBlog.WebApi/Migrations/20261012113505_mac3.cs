using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIBlog.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mac3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainVideoUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainVideoUrl",
                table: "Articles");
        }
    }
}
