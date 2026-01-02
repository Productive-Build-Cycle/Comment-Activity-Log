using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentActivityLog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GetActivityLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetActivityLogs",
                columns: table => new
                {
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    task_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    comment_content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activity_action = table.Column<int>(type: "int", nullable: false),
                    activity_action_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetActivityLogs");
        }
    }
}
