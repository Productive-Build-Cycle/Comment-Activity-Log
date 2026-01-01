using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentActivityLog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addIsDeleteProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Comment",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Comment");
        }
    }
}
