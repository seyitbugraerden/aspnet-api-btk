using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIBlog.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Categories",
                newName: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "MyProperty");
        }
    }
}
