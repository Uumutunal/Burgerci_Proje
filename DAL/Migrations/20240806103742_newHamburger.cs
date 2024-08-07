using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class newHamburger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("73faa0b4-2fa1-4437-a0d3-bf57a2fd58bf"));

            migrationBuilder.AddColumn<string>(
                name: "SelectedGarnitureIds",
                table: "Hamburgers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "PhotoUrl", "Surname", "Username" },
                values: new object[] { new Guid("39121a5b-877a-42ce-a88b-e88ac4198aca"), "İstanbul", new DateTime(2024, 8, 6, 13, 37, 41, 398, DateTimeKind.Local).AddTicks(4642), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("39121a5b-877a-42ce-a88b-e88ac4198aca"));

            migrationBuilder.DropColumn(
                name: "SelectedGarnitureIds",
                table: "Hamburgers");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "PhotoUrl", "Surname", "Username" },
                values: new object[] { new Guid("73faa0b4-2fa1-4437-a0d3-bf57a2fd58bf"), "İstanbul", new DateTime(2024, 8, 6, 12, 57, 51, 969, DateTimeKind.Local).AddTicks(5108), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }
    }
}
