using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CofeeClub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class winningcoffeeNowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteSessions_Coffees_WinningCoffeeId",
                table: "VoteSessions");

            migrationBuilder.AlterColumn<Guid>(
                name: "WinningCoffeeId",
                table: "VoteSessions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteSessions_Coffees_WinningCoffeeId",
                table: "VoteSessions",
                column: "WinningCoffeeId",
                principalTable: "Coffees",
                principalColumn: "CoffeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteSessions_Coffees_WinningCoffeeId",
                table: "VoteSessions");

            migrationBuilder.AlterColumn<Guid>(
                name: "WinningCoffeeId",
                table: "VoteSessions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VoteSessions_Coffees_WinningCoffeeId",
                table: "VoteSessions",
                column: "WinningCoffeeId",
                principalTable: "Coffees",
                principalColumn: "CoffeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
