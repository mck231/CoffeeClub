﻿// <auto-generated />
using System;
using CoffeeClub.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeeClub.Persistence.Migrations
{
    [DbContext(typeof(CoffeeClubDbContext))]
    [Migration("20240129181222_RenamedProject")]
    partial class RenamedProject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoffeeClub.Domain.Entities.Announcement", b =>
                {
                    b.Property<Guid>("AnnouncementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AnnouncementDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AnnouncementId");

                    b.HasIndex("TeamId");

                    b.ToTable("Announcements");

                    b.HasData(
                        new
                        {
                            AnnouncementId = new Guid("c065e164-3203-499f-a58a-c229653c26c2"),
                            AnnouncementDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Message = "Change in Management",
                            TeamId = new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a")
                        },
                        new
                        {
                            AnnouncementId = new Guid("dfa3408f-99f8-48fc-82cc-e4d8d5e8ea55"),
                            AnnouncementDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Message = "Coffee Leader will be going on holiday",
                            TeamId = new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a")
                        },
                        new
                        {
                            AnnouncementId = new Guid("06e5377f-5188-4c2e-8933-45b4109aac63"),
                            AnnouncementDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Message = "Limited edition coffee will be offered for free today",
                            TeamId = new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a")
                        });
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.Coffee", b =>
                {
                    b.Property<Guid>("CoffeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("PurchasingLink")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasAnnotation("RegularExpression", "^(http|https)://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?$");

                    b.Property<string>("RoastType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasAnnotation("RegularExpression", "^\\d+(\\s+(oz|lb))$");

                    b.HasKey("CoffeeId");

                    b.ToTable("Coffees", (string)null);

                    b.HasData(
                        new
                        {
                            CoffeeId = new Guid("c510d21f-39f2-4a48-926e-7a9b2130fd2c"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "A smooth and silky blend of coffee guaranteed to wake you up in the morning. It offers a delightful balance of flavors and a rich aroma.",
                            Name = "Señor Juan",
                            Origin = "Colombia",
                            Price = 5.99m,
                            PurchasingLink = "https://example.com",
                            RoastType = "Medium",
                            Size = "12 oz"
                        },
                        new
                        {
                            CoffeeId = new Guid("a07e3f88-57b8-4d26-889d-48b1cd2fdc08"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Indulge in the richness of this dark coffee that promises a bold and intense flavor profile. Its robust taste will satisfy the most discerning coffee lovers.",
                            Name = "Trovão",
                            Origin = "Brazil",
                            Price = 6.99m,
                            PurchasingLink = "https://fake.com",
                            RoastType = "Dark",
                            Size = "16 oz"
                        },
                        new
                        {
                            CoffeeId = new Guid("0668d9a2-c2d3-40ca-ab86-c41e897b1f51"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Experience the unique characteristics of this coffee with its distinct flavor profile. It offers a smooth and light-bodied taste that will delight your senses.",
                            Name = "Glass Tank",
                            Origin = "Ethiopia",
                            Price = 7.99m,
                            PurchasingLink = "https://bogus.com",
                            RoastType = "Light",
                            Size = "8 oz"
                        },
                        new
                        {
                            CoffeeId = new Guid("d32a4938-7db8-40cc-9ac9-e3503efc7507"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Start your day with this invigorating coffee that delivers a perfect balance of flavors and a hint of sweetness. Its smooth texture will awaken your senses.",
                            Name = "Morning Bliss",
                            Origin = "Costa Rica",
                            Price = 8.99m,
                            PurchasingLink = "https://morningblisscoffee.com",
                            RoastType = "Medium",
                            Size = "10 oz"
                        },
                        new
                        {
                            CoffeeId = new Guid("1bfa7e55-ee70-41de-9049-1896d20d9da3"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Embrace the vibrant flavors of this coffee that captures the essence of a beautiful sunrise. Its bright acidity and delicate notes create a refreshing and uplifting experience.",
                            Name = "Sunrise Delight",
                            Origin = "Kenya",
                            Price = 9.99m,
                            PurchasingLink = "https://sunrisedelightcoffee.com",
                            RoastType = "Light",
                            Size = "14 oz"
                        },
                        new
                        {
                            CoffeeId = new Guid("7a6b6f27-e187-40b6-99c9-effb683f8b42"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Immerse yourself in the enchanting symphony of flavors in this dark and velvety coffee. Its deep richness and complex undertones will leave you craving for more.",
                            Name = "Midnight Symphony",
                            Origin = "Indonesia",
                            Price = 10.99m,
                            PurchasingLink = "https://midnightsymphonycoffee.com",
                            RoastType = "Dark",
                            Size = "16 oz"
                        },
                        new
                        {
                            CoffeeId = new Guid("9eb35c63-8680-46c5-a91d-fe4e00de6ce8"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Indulge in the smooth and velvety texture of this coffee that unveils layers of exquisite flavors. It offers a luxurious drinking experience that will satisfy even the most refined palates.",
                            Name = "Velvet Dream",
                            Origin = "Guatemala",
                            Price = 12.99m,
                            PurchasingLink = "https://velvetdreamcoffee.com",
                            RoastType = "Medium",
                            Size = "8 oz"
                        },
                        new
                        {
                            CoffeeId = new Guid("2e6c6636-291d-42ca-816e-a48c6210693c"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Celebrate the harvest season with this coffee that captures the essence of fall. It combines warm and comforting flavors with a hint of spice, creating a delightful cup of joy.",
                            Name = "Harvest Euphoria",
                            Origin = "Honduras",
                            Price = 11.99m,
                            PurchasingLink = "https://harvesteuphoriacoffee.com",
                            RoastType = "Medium",
                            Size = "12 oz"
                        },
                        new
                        {
                            CoffeeId = new Guid("e5abd4e3-2c99-48c9-bf0a-ec4dfceecf85"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Immerse yourself in the golden hues and flavors of this coffee that brings to mind vast fields and sun-kissed mornings. Its smooth and balanced profile will transport you to a place of tranquility.",
                            Name = "Golden Fields",
                            Origin = "Peru",
                            Price = 10.99m,
                            PurchasingLink = "https://goldenfieldscoffee.com",
                            RoastType = "Light",
                            Size = "16 oz"
                        });
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.CoffeeGroup", b =>
                {
                    b.Property<Guid>("CoffeeGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CoffeeGroupId");

                    b.ToTable("CoffeeGroups");

                    b.HasData(
                        new
                        {
                            CoffeeGroupId = new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.CoffeeSelection", b =>
                {
                    b.Property<Guid>("CoffeeGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoffeeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CoffeeGroupId", "CoffeeId");

                    b.HasIndex("CoffeeId");

                    b.ToTable("CoffeeSelections");
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            PaymentId = new Guid("40c4591e-ff90-4cd3-8ff7-4582f2392883"),
                            Amount = 10.99m,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("6d053564-d24d-4e2e-aa56-916a06a158c2")
                        },
                        new
                        {
                            PaymentId = new Guid("57200c32-3250-4c60-9090-720027577ef4"),
                            Amount = 15.99m,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ea7b094e-e934-4321-a2af-019e47fe30c3")
                        },
                        new
                        {
                            PaymentId = new Guid("089f7464-800e-4a19-8254-e62a470183fd"),
                            Amount = 8.99m,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PaymentDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("b5924414-d4f6-46c9-b7c1-4cc4c7dce5cc")
                        });
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a"),
                            CreatedDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Androids"
                        },
                        new
                        {
                            TeamId = new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e"),
                            CreatedDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Klingons"
                        },
                        new
                        {
                            TeamId = new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6"),
                            CreatedDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Team Red"
                        });
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsLeader")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("6d053564-d24d-4e2e-aa56-916a06a158c2"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "marco@androids.com",
                            IsLeader = false,
                            Name = "Marco",
                            TeamId = new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a")
                        },
                        new
                        {
                            UserId = new Guid("2cae5dd5-ee71-46a8-aed4-c97281e8c082"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Joe@klingons.com",
                            IsLeader = false,
                            Name = "Joe",
                            TeamId = new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e")
                        },
                        new
                        {
                            UserId = new Guid("ec7f5960-7718-48ae-812b-fd22734f6a88"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Larry@red.com",
                            IsLeader = false,
                            Name = "Larry",
                            TeamId = new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6")
                        },
                        new
                        {
                            UserId = new Guid("ea7b094e-e934-4321-a2af-019e47fe30c3"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sarah@androids.com",
                            IsLeader = false,
                            Name = "Sarah",
                            TeamId = new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a")
                        },
                        new
                        {
                            UserId = new Guid("b5924414-d4f6-46c9-b7c1-4cc4c7dce5cc"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mike@androids.com",
                            IsLeader = false,
                            Name = "Mike",
                            TeamId = new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a")
                        },
                        new
                        {
                            UserId = new Guid("d2c891ce-74ca-45c2-a931-1b20b937bf62"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "emily@androids.com",
                            IsLeader = false,
                            Name = "Emily",
                            TeamId = new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a")
                        },
                        new
                        {
                            UserId = new Guid("772c00c1-55b5-48f0-8230-50415f631471"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john@androids.com",
                            IsLeader = false,
                            Name = "John",
                            TeamId = new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a")
                        },
                        new
                        {
                            UserId = new Guid("5cf95f90-47f5-4d90-9acf-4e3296635050"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "robert@klingons.com",
                            IsLeader = false,
                            Name = "Robert",
                            TeamId = new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e")
                        },
                        new
                        {
                            UserId = new Guid("b6e37974-17d7-4830-b469-511935a0b09a"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "amy@klingons.com",
                            IsLeader = false,
                            Name = "Amy",
                            TeamId = new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e")
                        },
                        new
                        {
                            UserId = new Guid("e9e6d858-5de5-44c6-a1e4-20a0056ecc51"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lisa@klingons.com",
                            IsLeader = false,
                            Name = "Lisa",
                            TeamId = new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e")
                        },
                        new
                        {
                            UserId = new Guid("1bd14a32-2288-4210-b065-9cdbacfbfcfe"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "daniel@klingons.com",
                            IsLeader = false,
                            Name = "Daniel",
                            TeamId = new Guid("35fdf055-cca3-4708-bdb3-f1ab98b61f8e")
                        },
                        new
                        {
                            UserId = new Guid("b50b0bd1-6519-4ba4-b0ef-7f5bc85c6212"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "julia@red.com",
                            IsLeader = false,
                            Name = "Julia",
                            TeamId = new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6")
                        },
                        new
                        {
                            UserId = new Guid("8f529db0-90e1-424d-8e5c-48bf7fa9f5ec"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alex@red.com",
                            IsLeader = false,
                            Name = "Alex",
                            TeamId = new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6")
                        },
                        new
                        {
                            UserId = new Guid("1c9c1e07-824f-4ab1-9899-2ed9d6d7cff6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "sophia@red.com",
                            IsLeader = false,
                            Name = "Sophia",
                            TeamId = new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6")
                        },
                        new
                        {
                            UserId = new Guid("781159fd-f06a-4e69-be3f-1e79740ea063"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "david@red.com",
                            IsLeader = false,
                            Name = "David",
                            TeamId = new Guid("a776aed4-36c7-41ae-987e-b5422993b8f6")
                        });
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.Vote", b =>
                {
                    b.Property<Guid>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoffeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VotingSessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VoteId");

                    b.HasIndex("CoffeeId");

                    b.HasIndex("UserId");

                    b.HasIndex("VotingSessionId");

                    b.ToTable("Votes");

                    b.HasData(
                        new
                        {
                            VoteId = new Guid("b9b203a4-b522-4fe5-a49d-6ed60983253c"),
                            CoffeeId = new Guid("c510d21f-39f2-4a48-926e-7a9b2130fd2c"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("6d053564-d24d-4e2e-aa56-916a06a158c2"),
                            VotingSessionId = new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22")
                        },
                        new
                        {
                            VoteId = new Guid("3de3afe4-1b83-400c-a203-663e76cd47ae"),
                            CoffeeId = new Guid("a07e3f88-57b8-4d26-889d-48b1cd2fdc08"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("ea7b094e-e934-4321-a2af-019e47fe30c3"),
                            VotingSessionId = new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22")
                        },
                        new
                        {
                            VoteId = new Guid("2a6dd843-d678-4c83-b43f-967c68ce0b45"),
                            CoffeeId = new Guid("0668d9a2-c2d3-40ca-ab86-c41e897b1f51"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = new Guid("b5924414-d4f6-46c9-b7c1-4cc4c7dce5cc"),
                            VotingSessionId = new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22")
                        });
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.VotingSession", b =>
                {
                    b.Property<Guid>("VotingSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CoffeeGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VotingSessionId");

                    b.HasIndex("CoffeeGroupId");

                    b.HasIndex("TeamId");

                    b.ToTable("VoteSessions");

                    b.HasData(
                        new
                        {
                            VotingSessionId = new Guid("7a1c571a-1b44-45d0-8ff9-44613ea93f22"),
                            CoffeeGroupId = new Guid("9e342baf-5e4d-43a4-8a3e-e657b598cb98"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EndDate = new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TeamId = new Guid("e2c60c79-94b0-4d96-964a-954d773b8a4a")
                        });
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.Announcement", b =>
                {
                    b.HasOne("CoffeeClub.Domain.Entities.Team", "Team")
                        .WithMany("Announcements")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.CoffeeSelection", b =>
                {
                    b.HasOne("CoffeeClub.Domain.Entities.CoffeeGroup", "CoffeeGroup")
                        .WithMany("CoffeeSelections")
                        .HasForeignKey("CoffeeGroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CoffeeClub.Domain.Entities.Coffee", "Coffee")
                        .WithMany()
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coffee");

                    b.Navigation("CoffeeGroup");
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.User", b =>
                {
                    b.HasOne("CoffeeClub.Domain.Entities.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.Vote", b =>
                {
                    b.HasOne("CoffeeClub.Domain.Entities.Coffee", "Coffee")
                        .WithMany()
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CoffeeClub.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeClub.Domain.Entities.VotingSession", "VotingSession")
                        .WithMany("Votes")
                        .HasForeignKey("VotingSessionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Coffee");

                    b.Navigation("User");

                    b.Navigation("VotingSession");
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.VotingSession", b =>
                {
                    b.HasOne("CoffeeClub.Domain.Entities.CoffeeGroup", "CoffeeGroup")
                        .WithMany()
                        .HasForeignKey("CoffeeGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeClub.Domain.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoffeeGroup");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.CoffeeGroup", b =>
                {
                    b.Navigation("CoffeeSelections");
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.Team", b =>
                {
                    b.Navigation("Announcements");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("CoffeeClub.Domain.Entities.VotingSession", b =>
                {
                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
