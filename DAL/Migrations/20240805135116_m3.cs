using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c00d426e-32db-450a-b99c-b8ff136afd5e"));

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Users",
                newName: "PhotoUrl");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "PhotoUrl", "Surname", "Username" },
                values: new object[] { new Guid("9260798a-0fc2-40ad-b3f9-21cb8a216ace"), "İstanbul", new DateTime(2024, 8, 5, 16, 51, 15, 604, DateTimeKind.Local).AddTicks(2164), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9260798a-0fc2-40ad-b3f9-21cb8a216ace"));

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Users",
                newName: "Photo");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "Photo", "Surname", "Username" },
                values: new object[] { new Guid("c00d426e-32db-450a-b99c-b8ff136afd5e"), "İstanbul", new DateTime(2024, 8, 5, 14, 52, 38, 319, DateTimeKind.Local).AddTicks(2421), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }
    }
}
