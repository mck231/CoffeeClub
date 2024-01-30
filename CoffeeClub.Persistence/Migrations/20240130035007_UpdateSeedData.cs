using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeClub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CoffeeSelections",
                columns: new[] { "CoffeeGroupId", "CoffeeId" },
                values: new object[,]
                {
                    { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("0668d9a2-c2d3-40ca-ab86-c41e897b1f51") },
                    { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("1bfa7e55-ee70-41de-9049-1896d20d9da3") },
                    { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("2e6c6636-291d-42ca-816e-a48c6210693c") },
                    { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("a07e3f88-57b8-4d26-889d-48b1cd2fdc08") },
                    { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("c510d21f-39f2-4a48-926e-7a9b2130fd2c") },
                    { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("d32a4938-7db8-40cc-9ac9-e3503efc7507") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CoffeeSelections",
                keyColumns: new[] { "CoffeeGroupId", "CoffeeId" },
                keyValues: new object[] { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("0668d9a2-c2d3-40ca-ab86-c41e897b1f51") });

            migrationBuilder.DeleteData(
                table: "CoffeeSelections",
                keyColumns: new[] { "CoffeeGroupId", "CoffeeId" },
                keyValues: new object[] { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("1bfa7e55-ee70-41de-9049-1896d20d9da3") });

            migrationBuilder.DeleteData(
                table: "CoffeeSelections",
                keyColumns: new[] { "CoffeeGroupId", "CoffeeId" },
                keyValues: new object[] { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("2e6c6636-291d-42ca-816e-a48c6210693c") });

            migrationBuilder.DeleteData(
                table: "CoffeeSelections",
                keyColumns: new[] { "CoffeeGroupId", "CoffeeId" },
                keyValues: new object[] { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("a07e3f88-57b8-4d26-889d-48b1cd2fdc08") });

            migrationBuilder.DeleteData(
                table: "CoffeeSelections",
                keyColumns: new[] { "CoffeeGroupId", "CoffeeId" },
                keyValues: new object[] { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("c510d21f-39f2-4a48-926e-7a9b2130fd2c") });

            migrationBuilder.DeleteData(
                table: "CoffeeSelections",
                keyColumns: new[] { "CoffeeGroupId", "CoffeeId" },
                keyValues: new object[] { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("d32a4938-7db8-40cc-9ac9-e3503efc7507") });
        }
    }
}
