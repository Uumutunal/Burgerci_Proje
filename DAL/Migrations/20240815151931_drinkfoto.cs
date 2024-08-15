using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class drinkfoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("44f47377-269d-41c6-b6a2-34bade0ead7e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "Photo", "Surname", "Username" },
                values: new object[] { new Guid("f338fdda-f1c0-4f5b-8523-7e5faea7b80e"), "İstanbul", new DateTime(2024, 8, 15, 18, 19, 29, 653, DateTimeKind.Local).AddTicks(1706), null, "admin@admin.com", true, false, null, "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f338fdda-f1c0-4f5b-8523-7e5faea7b80e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "Photo", "Surname", "Username" },
                values: new object[] { new Guid("44f47377-269d-41c6-b6a2-34bade0ead7e"), "İstanbul", new DateTime(2024, 8, 15, 13, 28, 58, 871, DateTimeKind.Local).AddTicks(2287), null, "admin@admin.com", true, false, null, "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }
    }
}
