using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WasteWiseEatsAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class IncludeRestaurantroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SecurityProfileRole",
                columns: new[] { "ProfileId", "Role" },
                values: new object[,]
                {
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 21 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 22 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 23 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 24 },
                    { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SecurityProfileRole",
                keyColumns: new[] { "ProfileId", "Role" },
                keyValues: new object[] { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 21 });

            migrationBuilder.DeleteData(
                table: "SecurityProfileRole",
                keyColumns: new[] { "ProfileId", "Role" },
                keyValues: new object[] { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 22 });

            migrationBuilder.DeleteData(
                table: "SecurityProfileRole",
                keyColumns: new[] { "ProfileId", "Role" },
                keyValues: new object[] { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 23 });

            migrationBuilder.DeleteData(
                table: "SecurityProfileRole",
                keyColumns: new[] { "ProfileId", "Role" },
                keyValues: new object[] { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 24 });

            migrationBuilder.DeleteData(
                table: "SecurityProfileRole",
                keyColumns: new[] { "ProfileId", "Role" },
                keyValues: new object[] { new Guid("361a6151-97ee-470e-b901-6c9160b974a9"), 25 });
        }
    }
}
