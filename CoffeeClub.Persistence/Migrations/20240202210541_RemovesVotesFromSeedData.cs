using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeClub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovesVotesFromSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "VoteId",
                keyValue: new Guid("2a6dd843-d678-4c83-b43f-967c68ce0b45"));

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "VoteId",
                keyValue: new Guid("3de3afe4-1b83-400c-a203-663e76cd47ae"));

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "VoteId",
                keyValue: new Guid("b9b203a4-b522-4fe5-a49d-6ed60983253c"));

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "AnnouncementId",
                keyValue: new Guid("06e5377f-5188-4c2e-8933-45b4109aac63"),
                column: "AnnouncementDate",
                value: new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "AnnouncementId",
                keyValue: new Guid("c065e164-3203-499f-a58a-c229653c26c2"),
                column: "AnnouncementDate",
                value: new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "AnnouncementId",
                keyValue: new Guid("dfa3408f-99f8-48fc-82cc-e4d8d5e8ea55"),
                column: "AnnouncementDate",
                value: new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("089f7464-800e-4a19-8254-e62a470183fd"),
                column: "PaymentDate",
                value: new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("40c4591e-ff90-4cd3-8ff7-4582f2392883"),
                column: "PaymentDate",
                value: new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("57200c32-3250-4c60-9090-720027577ef4"),
                column: "PaymentDate",
                value: new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "VoteSessions",
                keyColumn: "VotingSessionId",
                keyValue: new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "AnnouncementId",
                keyValue: new Guid("06e5377f-5188-4c2e-8933-45b4109aac63"),
                column: "AnnouncementDate",
                value: new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "AnnouncementId",
                keyValue: new Guid("c065e164-3203-499f-a58a-c229653c26c2"),
                column: "AnnouncementDate",
                value: new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Announcements",
                keyColumn: "AnnouncementId",
                keyValue: new Guid("dfa3408f-99f8-48fc-82cc-e4d8d5e8ea55"),
                column: "AnnouncementDate",
                value: new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("089f7464-800e-4a19-8254-e62a470183fd"),
                column: "PaymentDate",
                value: new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("40c4591e-ff90-4cd3-8ff7-4582f2392883"),
                column: "PaymentDate",
                value: new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentId",
                keyValue: new Guid("57200c32-3250-4c60-9090-720027577ef4"),
                column: "PaymentDate",
                value: new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "VoteSessions",
                keyColumn: "VotingSessionId",
                keyValue: new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22"),
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "VoteId", "CoffeeId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "UserId", "VotingSessionId" },
                values: new object[,]
                {
                    { new Guid("2a6dd843-d678-4c83-b43f-967c68ce0b45"), new Guid("0668d9a2-c2d3-40ca-ab86-c41e897b1f51"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b5924414-d4f6-46c9-b7c1-4cc4c7dce5cc"), new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22") },
                    { new Guid("3de3afe4-1b83-400c-a203-663e76cd47ae"), new Guid("a07e3f88-57b8-4d26-889d-48b1cd2fdc08"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("ea7b094e-e934-4321-a2af-019e47fe30c3"), new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22") },
                    { new Guid("b9b203a4-b522-4fe5-a49d-6ed60983253c"), new Guid("c510d21f-39f2-4a48-926e-7a9b2130fd2c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6d053564-d24d-4e2e-aa56-916a06a158c2"), new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22") }
                });
        }
    }
}
