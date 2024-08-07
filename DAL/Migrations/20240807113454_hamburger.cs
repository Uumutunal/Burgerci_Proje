using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class hamburger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("39121a5b-877a-42ce-a88b-e88ac4198aca"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "PhotoUrl", "Surname", "Username" },
                values: new object[] { new Guid("105d4402-e3b5-43de-95a2-0de4279a782b"), "İstanbul", new DateTime(2024, 8, 7, 14, 34, 53, 99, DateTimeKind.Local).AddTicks(9886), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("105d4402-e3b5-43de-95a2-0de4279a782b"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "PhotoUrl", "Surname", "Username" },
                values: new object[] { new Guid("39121a5b-877a-42ce-a88b-e88ac4198aca"), "İstanbul", new DateTime(2024, 8, 6, 13, 37, 41, 398, DateTimeKind.Local).AddTicks(4642), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }
    }
}
