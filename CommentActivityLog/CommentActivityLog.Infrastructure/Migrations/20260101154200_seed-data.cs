using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommentActivityLog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "لطفا در ویژوال استادیو یک پروژه وب جدید ایجاد کنید", "ایجاد پروژه ی جدید" },
                    { 2, "لطفا معماری پروژه را تعیین کنید", "ایجاد معماری" },
                    { 3, "لطفا مدل و موجودیت های خود را مشخص کنید", "ایجاد مدل" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "UserName" },
                values: new object[,]
                {
                    { 1, "mahyaaa.khashkhashi@gmail.com", "Mahya" },
                    { 2, "HosseinDinarvand@gmail.com", "Hosein" },
                    { 3, "AlirezaEntezari@gmail.com", "Alireza" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
