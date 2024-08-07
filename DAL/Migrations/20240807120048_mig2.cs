using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fc3d6b00-0971-4a49-b240-4d74f4409e66"));

            migrationBuilder.AlterColumn<string>(
                name: "SelectedGarnitureIds",
                table: "Hamburgers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "Photo", "Surname", "Username" },
                values: new object[] { new Guid("3a307356-78ec-464e-9966-18da2940930a"), "İstanbul", new DateTime(2024, 8, 7, 15, 0, 47, 974, DateTimeKind.Local).AddTicks(4367), null, "admin@admin.com", true, false, null, "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a307356-78ec-464e-9966-18da2940930a"));

            migrationBuilder.AlterColumn<string>(
                name: "SelectedGarnitureIds",
                table: "Hamburgers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "Photo", "Surname", "Username" },
                values: new object[] { new Guid("fc3d6b00-0971-4a49-b240-4d74f4409e66"), "İstanbul", new DateTime(2024, 8, 7, 14, 34, 21, 818, DateTimeKind.Local).AddTicks(5752), null, "admin@admin.com", true, false, null, "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }
    }
}
