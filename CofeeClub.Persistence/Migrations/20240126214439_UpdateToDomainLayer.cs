using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CofeeClub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToDomainLayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_VoteSessions_VotingSessionId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_VoteSessions_CoffeeGroups_CoffeeGroupId",
                table: "VoteSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_VoteSessions_Coffees_WinningCoffeeId",
                table: "VoteSessions");

            migrationBuilder.DropTable(
                name: "GroupCoffeeVotings");

            migrationBuilder.DropIndex(
                name: "IX_VoteSessions_WinningCoffeeId",
                table: "VoteSessions");

            migrationBuilder.DropIndex(
                name: "IX_Payments_VotingSessionId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "WinningCoffeeId",
                table: "VoteSessions");

            migrationBuilder.DropColumn(
                name: "VotingSessionId",
                table: "Payments");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteSessions_CoffeeGroups_CoffeeGroupId",
                table: "VoteSessions",
                column: "CoffeeGroupId",
                principalTable: "CoffeeGroups",
                principalColumn: "CoffeeGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_VoteSessions_CoffeeGroups_CoffeeGroupId",
                table: "VoteSessions");

            migrationBuilder.AddColumn<Guid>(
                name: "WinningCoffeeId",
                table: "VoteSessions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VotingSessionId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "GroupCoffeeVotings",
                columns: table => new
                {
                    GroupCoffeeVotingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VotingSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupCoffeeVotings", x => x.GroupCoffeeVotingId);
                    table.ForeignKey(
                        name: "FK_GroupCoffeeVotings_CoffeeGroups_CoffeeGroupId",
                        column: x => x.CoffeeGroupId,
                        principalTable: "CoffeeGroups",
                        principalColumn: "CoffeeGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupCoffeeVotings_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "CoffeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupCoffeeVotings_VoteSessions_VotingSessionId",
                        column: x => x.VotingSessionId,
                        principalTable: "VoteSessions",
                        principalColumn: "VotingSessionId");
                });

            migrationBuilder.InsertData(
                table: "GroupCoffeeVotings",
                columns: new[] { "GroupCoffeeVotingId", "CoffeeGroupId", "CoffeeId", "VotingSessionId" },
                values: new object[] { new Guid("829e15ae-a92d-48ba-8519-2fb437736a19"), new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), new Guid("c510d21f-39f2-4a48-926e-7a9b2130fd2c"), new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22") });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("089f7464-800e-4a19-8254-e62a470183fd"),
                column: "VotingSessionId",
                value: new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22"));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("40c4591e-ff90-4cd3-8ff7-4582f2392883"),
                column: "VotingSessionId",
                value: new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22"));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("57200c32-3250-4c60-9090-720027577ef4"),
                column: "VotingSessionId",
                value: new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22"));

            migrationBuilder.UpdateData(
                table: "VoteSessions",
                keyColumn: "VotingSessionId",
                keyValue: new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22"),
                column: "WinningCoffeeId",
                value: new Guid("c510d21f-39f2-4a48-926e-7a9b2130fd2c"));

            migrationBuilder.CreateIndex(
                name: "IX_VoteSessions_WinningCoffeeId",
                table: "VoteSessions",
                column: "WinningCoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_VotingSessionId",
                table: "Payments",
                column: "VotingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupCoffeeVotings_CoffeeGroupId",
                table: "GroupCoffeeVotings",
                column: "CoffeeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupCoffeeVotings_CoffeeId",
                table: "GroupCoffeeVotings",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupCoffeeVotings_VotingSessionId",
                table: "GroupCoffeeVotings",
                column: "VotingSessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_VoteSessions_VotingSessionId",
                table: "Payments",
                column: "VotingSessionId",
                principalTable: "VoteSessions",
                principalColumn: "VotingSessionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoteSessions_CoffeeGroups_CoffeeGroupId",
                table: "VoteSessions",
                column: "CoffeeGroupId",
                principalTable: "CoffeeGroups",
                principalColumn: "CoffeeGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VoteSessions_Coffees_WinningCoffeeId",
                table: "VoteSessions",
                column: "WinningCoffeeId",
                principalTable: "Coffees",
                principalColumn: "CoffeeId");
        }
    }
}
