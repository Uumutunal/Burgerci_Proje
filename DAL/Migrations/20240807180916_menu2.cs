using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class menu2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("060d2c58-cf53-4d42-b043-ddb46873e775"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "Photo", "Surname", "Username" },
                values: new object[] { new Guid("4de248a1-5314-4f29-912f-bcc3ddf40fef"), "İstanbul", new DateTime(2024, 8, 7, 21, 9, 15, 292, DateTimeKind.Local).AddTicks(6874), null, "admin@admin.com", true, false, null, "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4de248a1-5314-4f29-912f-bcc3ddf40fef"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "IsAdmin", "IsDeleted", "ModifiedDate", "Name", "Password", "PhoneNumber", "Photo", "Surname", "Username" },
                values: new object[] { new Guid("060d2c58-cf53-4d42-b043-ddb46873e775"), "İstanbul", new DateTime(2024, 8, 7, 20, 58, 9, 522, DateTimeKind.Local).AddTicks(9635), null, "admin@admin.com", true, false, null, "adminadı", "123", "1234567890", null, "adminsoyadı", "admin" });
        }
    }
}
