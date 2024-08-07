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
                keyValue: new Guid("97a7effd-490d-4673-9c91-8f0c2401eff4"));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Hamburgers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Hamburgers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Extras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Extras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Drinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Drinks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "Photo", "Surname", "Username" },
                values: new object[] { new Guid("b552f964-3a7e-44e8-b22e-d849ec558968"), "İstanbul", new DateTime(2024, 8, 7, 12, 4, 36, 701, DateTimeKind.Local).AddTicks(3322), null, "admin@admin.com", true, false, null, "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b552f964-3a7e-44e8-b22e-d849ec558968"));

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Hamburgers");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Hamburgers");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Extras");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Extras");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Drinks");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "Photo", "Surname", "Username" },
                values: new object[] { new Guid("97a7effd-490d-4673-9c91-8f0c2401eff4"), "İstanbul", new DateTime(2024, 8, 6, 14, 3, 21, 484, DateTimeKind.Local).AddTicks(1335), null, "admin@admin.com", true, false, null, "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }
    }
}
