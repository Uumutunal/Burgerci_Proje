using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class menu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("105d4402-e3b5-43de-95a2-0de4279a782b"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "PhotoUrl", "Surname", "Username" },
                values: new object[] { new Guid("5852b261-ea2a-4f2a-9dab-cc269482fcd6"), "İstanbul", new DateTime(2024, 8, 7, 16, 15, 47, 639, DateTimeKind.Local).AddTicks(8934), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5852b261-ea2a-4f2a-9dab-cc269482fcd6"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "PhotoUrl", "Surname", "Username" },
                values: new object[] { new Guid("105d4402-e3b5-43de-95a2-0de4279a782b"), "İstanbul", new DateTime(2024, 8, 7, 14, 34, 53, 99, DateTimeKind.Local).AddTicks(9886), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }
    }
}
