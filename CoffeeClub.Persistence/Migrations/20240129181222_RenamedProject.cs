using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeClub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamedProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoffeeGroups",
                columns: table => new
                {
                    CoffeeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeGroups", x => x.CoffeeGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Coffees",
                columns: table => new
                {
                    CoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasingLink = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoastType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffees", x => x.CoffeeId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeSelections",
                columns: table => new
                {
                    CoffeeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeSelections", x => new { x.CoffeeGroupId, x.CoffeeId });
                    table.ForeignKey(
                        name: "FK_CoffeeSelections_CoffeeGroups_CoffeeGroupId",
                        column: x => x.CoffeeGroupId,
                        principalTable: "CoffeeGroups",
                        principalColumn: "CoffeeGroupId");
                    table.ForeignKey(
                        name: "FK_CoffeeSelections_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "CoffeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    AnnouncementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnouncementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.AnnouncementId);
                    table.ForeignKey(
                        name: "FK_Announcements_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLeader = table.Column<bool>(type: "bit", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.CreateTable(
                name: "VoteSessions",
                columns: table => new
                {
                    VotingSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteSessions", x => x.VotingSessionId);
                    table.ForeignKey(
                        name: "FK_VoteSessions_CoffeeGroups_CoffeeGroupId",
                        column: x => x.CoffeeGroupId,
                        principalTable: "CoffeeGroups",
                        principalColumn: "CoffeeGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoteSessions_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    VoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VotingSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.VoteId);
                    table.ForeignKey(
                        name: "FK_Votes_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "CoffeeId");
                    table.ForeignKey(
                        name: "FK_Votes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votes_VoteSessions_VotingSessionId",
                        column: x => x.VotingSessionId,
                        principalTable: "VoteSessions",
                        principalColumn: "VotingSessionId");
                });

            migrationBuilder.InsertData(
                table: "CoffeeGroups",
                columns: new[] { "CoffeeGroupId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.InsertData(
                table: "Coffees",
                columns: new[] { "CoffeeId", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "Name", "Origin", "Price", "PurchasingLink", "RoastType", "Size" },
                values: new object[,]
                {
                    { new Guid("0668d9a2-c2d3-40ca-ab86-c41e897b1f51"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Experience the unique characteristics of this coffee with its distinct flavor profile. It offers a smooth and light-bodied taste that will delight your senses.", null, null, "Glass Tank", "Ethiopia", 7.99m, "https://bogus.com", "Light", "8 oz" },
                    { new Guid("1bfa7e55-ee70-41de-9049-1896d20d9da3"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Embrace the vibrant flavors of this coffee that captures the essence of a beautiful sunrise. Its bright acidity and delicate notes create a refreshing and uplifting experience.", null, null, "Sunrise Delight", "Kenya", 9.99m, "https://sunrisedelightcoffee.com", "Light", "14 oz" },
                    { new Guid("2e6c6636-291d-42ca-816e-a48c6210693c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Celebrate the harvest season with this coffee that captures the essence of fall. It combines warm and comforting flavors with a hint of spice, creating a delightful cup of joy.", null, null, "Harvest Euphoria", "Honduras", 11.99m, "https://harvesteuphoriacoffee.com", "Medium", "12 oz" },
                    { new Guid("7a6b6f27-e187-40b6-99c9-effb683f8b42"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Immerse yourself in the enchanting symphony of flavors in this dark and velvety coffee. Its deep richness and complex undertones will leave you craving for more.", null, null, "Midnight Symphony", "Indonesia", 10.99m, "https://midnightsymphonycoffee.com", "Dark", "16 oz" },
                    { new Guid("9eb35c63-8680-46c5-a91d-fe4e00de6ce8"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indulge in the smooth and velvety texture of this coffee that unveils layers of exquisite flavors. It offers a luxurious drinking experience that will satisfy even the most refined palates.", null, null, "Velvet Dream", "Guatemala", 12.99m, "https://velvetdreamcoffee.com", "Medium", "8 oz" },
                    { new Guid("a07e3f88-57b8-4d26-889d-48b1cd2fdc08"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indulge in the richness of this dark coffee that promises a bold and intense flavor profile. Its robust taste will satisfy the most discerning coffee lovers.", null, null, "Trovão", "Brazil", 6.99m, "https://fake.com", "Dark", "16 oz" },
                    { new Guid("c510d21f-39f2-4a48-926e-7a9b2130fd2c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A smooth and silky blend of coffee guaranteed to wake you up in the morning. It offers a delightful balance of flavors and a rich aroma.", null, null, "Señor Juan", "Colombia", 5.99m, "https://example.com", "Medium", "12 oz" },
                    { new Guid("d32a4938-7db8-40cc-9ac9-e3503efc7507"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Start your day with this invigorating coffee that delivers a perfect balance of flavors and a hint of sweetness. Its smooth texture will awaken your senses.", null, null, "Morning Bliss", "Costa Rica", 8.99m, "https://morningblisscoffee.com", "Medium", "10 oz" },
                    { new Guid("e5abd4e3-2c99-48c9-bf0a-ec4dfceecf85"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Immerse yourself in the golden hues and flavors of this coffee that brings to mind vast fields and sun-kissed mornings. Its smooth and balanced profile will transport you to a place of tranquility.", null, null, "Golden Fields", "Peru", 10.99m, "https://goldenfieldscoffee.com", "Light", "16 oz" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "PaymentDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("089f7464-800e-4a19-8254-e62a470183fd"), 8.99m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b5924414-d4f6-46c9-b7c1-4cc4c7dce5cc") },
                    { new Guid("40c4591e-ff90-4cd3-8ff7-4582f2392883"), 10.99m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6d053564-d24d-4e2e-aa56-916a06a158c2") },
                    { new Guid("57200c32-3250-4c60-9090-720027577ef4"), 15.99m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ea7b094e-e934-4321-a2af-019e47fe30c3") }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e"), null, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Klingons" },
                    { new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6"), null, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Team Red" },
                    { new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a"), null, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Androids" }
                });

            migrationBuilder.InsertData(
                table: "Announcements",
                columns: new[] { "AnnouncementId", "AnnouncementDate", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Message", "TeamId" },
                values: new object[,]
                {
                    { new Guid("06e5377f-5188-4c2e-8933-45b4109aac63"), new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Limited edition coffee will be offered for free today", new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a") },
                    { new Guid("c065e164-3203-499f-a58a-c229653c26c2"), new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Change in Management", new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a") },
                    { new Guid("dfa3408f-99f8-48fc-82cc-e4d8d5e8ea55"), new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Coffee Leader will be going on holiday", new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedBy", "CreatedDate", "Email", "IsLeader", "LastModifiedBy", "LastModifiedDate", "Name", "TeamId" },
                values: new object[,]
                {
                    { new Guid("1bd14a32-2288-4210-b065-9cdbacfbfcfe"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniel@klingons.com", false, null, null, "Daniel", new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e") },
                    { new Guid("1c9c1e07-824f-4ab1-9899-2ed9d6d7cff6"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia@red.com", false, null, null, "Sophia", new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6") },
                    { new Guid("2cae5dd5-ee71-46a8-aed4-c97281e8c082"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joe@klingons.com", false, null, null, "Joe", new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e") },
                    { new Guid("5cf95f90-47f5-4d90-9acf-4e3296635050"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "robert@klingons.com", false, null, null, "Robert", new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e") },
                    { new Guid("6d053564-d24d-4e2e-aa56-916a06a158c2"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "marco@androids.com", false, null, null, "Marco", new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a") },
                    { new Guid("772c00c1-55b5-48f0-8230-50415f631471"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@androids.com", false, null, null, "John", new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a") },
                    { new Guid("781159fd-f06a-4e69-be3f-1e79740ea063"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "david@red.com", false, null, null, "David", new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6") },
                    { new Guid("8f529db0-90e1-424d-8e5c-48bf7fa9f5ec"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alex@red.com", false, null, null, "Alex", new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6") },
                    { new Guid("b50b0bd1-6519-4ba4-b0ef-7f5bc85c6212"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "julia@red.com", false, null, null, "Julia", new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6") },
                    { new Guid("b5924414-d4f6-46c9-b7c1-4cc4c7dce5cc"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mike@androids.com", false, null, null, "Mike", new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a") },
                    { new Guid("b6e37974-17d7-4830-b469-511935a0b09a"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "amy@klingons.com", false, null, null, "Amy", new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e") },
                    { new Guid("d2c891ce-74ca-45c2-a931-1b20b937bf62"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily@androids.com", false, null, null, "Emily", new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a") },
                    { new Guid("e9e6d858-5de5-44c6-a1e4-20a0056ecc51"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lisa@klingons.com", false, null, null, "Lisa", new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e") },
                    { new Guid("ea7b094e-e934-4321-a2af-019e47fe30c3"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah@androids.com", false, null, null, "Sarah", new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a") },
                    { new Guid("ec7f5960-7718-48ae-812b-fd22734f6a88"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Larry@red.com", false, null, null, "Larry", new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6") }
                });

            migrationBuilder.InsertData(
                table: "VoteSessions",
                columns: new[] { "VotingSessionId", "CoffeeGroupId", "CreatedBy", "CreatedDate", "EndDate", "LastModifiedBy", "LastModifiedDate", "StartDate", "TeamId" },
                values: new object[] { new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22"), new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a") });

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "VoteId", "CoffeeId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "UserId", "VotingSessionId" },
                values: new object[,]
                {
                    { new Guid("2a6dd843-d678-4c83-b43f-967c68ce0b45"), new Guid("0668d9a2-c2d3-40ca-ab86-c41e897b1f51"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b5924414-d4f6-46c9-b7c1-4cc4c7dce5cc"), new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22") },
                    { new Guid("3de3afe4-1b83-400c-a203-663e76cd47ae"), new Guid("a07e3f88-57b8-4d26-889d-48b1cd2fdc08"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("ea7b094e-e934-4321-a2af-019e47fe30c3"), new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22") },
                    { new Guid("b9b203a4-b522-4fe5-a49d-6ed60983253c"), new Guid("c510d21f-39f2-4a48-926e-7a9b2130fd2c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("6d053564-d24d-4e2e-aa56-916a06a158c2"), new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_TeamId",
                table: "Announcements",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeSelections_CoffeeId",
                table: "CoffeeSelections",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CoffeeId",
                table: "Votes",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_VotingSessionId",
                table: "Votes",
                column: "VotingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteSessions_CoffeeGroupId",
                table: "VoteSessions",
                column: "CoffeeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteSessions_TeamId",
                table: "VoteSessions",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "CoffeeSelections");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Coffees");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VoteSessions");

            migrationBuilder.DropTable(
                name: "CoffeeGroups");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
