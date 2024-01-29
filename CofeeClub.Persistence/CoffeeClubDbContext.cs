using CofeeClub.Persistence.Configurations;
using CoffeeClub.Application.Contracts;
using CoffeeClub.Domain.Common;
using CoffeeClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CofeeClub.Persistence
{
    public class CoffeeClubDbContext : DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;

        public CoffeeClubDbContext(DbContextOptions<CoffeeClubDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;

        }

        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<VotingSession> VoteSessions { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CoffeeGroup> CoffeeGroups { get; set; }
        public DbSet<CoffeeSelection> CoffeeSelections { get; set; } // Add this line


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoffeeConfiguration).Assembly);

            // Configure decimal properties
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18, 2)");

            // Configure relationships
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.VotingSession)
                .WithMany(vs => vs.Votes)
                .HasForeignKey(v => v.VotingSessionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Coffee)
                .WithMany()
                .HasForeignKey(v => v.CoffeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Members)
                .WithOne(u => u.Team)
                .HasForeignKey(u => u.TeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Announcement>()
                .HasOne(a => a.Team)
                .WithMany(t => t.Announcements)
                .HasForeignKey(a => a.TeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CoffeeGroup>()
                .HasMany(cg => cg.CoffeeSelections)
                .WithOne(vs => vs.CoffeeGroup)
                .HasForeignKey(vs => vs.CoffeeGroupId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<CoffeeSelection>()
                .HasKey(cs => new { cs.CoffeeGroupId, cs.CoffeeId }); // Composite Key

            modelBuilder.Entity<CoffeeSelection>()
                .HasOne(cs => cs.CoffeeGroup)
                .WithMany(cg => cg.CoffeeSelections)
                .HasForeignKey(cs => cs.CoffeeGroupId);

            modelBuilder.Entity<CoffeeSelection>()
                .HasOne(cs => cs.Coffee)
                .WithMany()
                .HasForeignKey(cs => cs.CoffeeId);



            // seed data goes here
            var seedDate = new DateTime(2023, 5, 30); // Replace with the desired fixed date
            var seedDateThatsLater = seedDate.AddDays(1);
            //----------------------------------------------------------
            var coffee1 = new Coffee
            {
                CoffeeId = Guid.Parse("C510D21F-39F2-4A48-926E-7A9B2130FD2C"),
                Name = "Señor Juan",
                Description = "A smooth and silky blend of coffee guaranteed to wake you up in the morning. It offers a delightful balance of flavors and a rich aroma.",
                Price = 5.99m,
                PurchasingLink = "https://example.com",
                Size = "12 oz",
                Origin = "Colombia",
                RoastType = "Medium"
            };
            var coffee2 = new Coffee
            {
                CoffeeId = Guid.Parse("A07E3F88-57B8-4D26-889D-48B1CD2FDC08"),
                Name = "Trovão",
                Description = "Indulge in the richness of this dark coffee that promises a bold and intense flavor profile. Its robust taste will satisfy the most discerning coffee lovers.",
                Price = 6.99m,
                PurchasingLink = "https://fake.com",
                Size = "16 oz",
                Origin = "Brazil",
                RoastType = "Dark"
            };
            var coffee3 = new Coffee
            {
                CoffeeId = Guid.Parse("0668D9A2-C2D3-40CA-AB86-C41E897B1F51"),
                Name = "Glass Tank",
                Description = "Experience the unique characteristics of this coffee with its distinct flavor profile. It offers a smooth and light-bodied taste that will delight your senses.",
                Price = 7.99m,
                PurchasingLink = "https://bogus.com",
                Size = "8 oz",
                Origin = "Ethiopia",
                RoastType = "Light"
            };
            var coffee4 = new Coffee
            {
                CoffeeId = Guid.Parse("D32A4938-7DB8-40CC-9AC9-E3503EFC7507"),
                Name = "Morning Bliss",
                Description = "Start your day with this invigorating coffee that delivers a perfect balance of flavors and a hint of sweetness. Its smooth texture will awaken your senses.",
                Price = 8.99m,
                PurchasingLink = "https://morningblisscoffee.com",
                Size = "10 oz",
                Origin = "Costa Rica",
                RoastType = "Medium"
            };
            var coffee5 = new Coffee
            {
                CoffeeId = Guid.Parse("1BFA7E55-EE70-41DE-9049-1896D20D9DA3"),
                Name = "Sunrise Delight",
                Description = "Embrace the vibrant flavors of this coffee that captures the essence of a beautiful sunrise. Its bright acidity and delicate notes create a refreshing and uplifting experience.",
                Price = 9.99m,
                PurchasingLink = "https://sunrisedelightcoffee.com",
                Size = "14 oz",
                Origin = "Kenya",
                RoastType = "Light"
            };
            var coffee6 = new Coffee
            {
                CoffeeId = Guid.Parse("7A6B6F27-E187-40B6-99C9-EFFB683F8B42"),
                Name = "Midnight Symphony",
                Description = "Immerse yourself in the enchanting symphony of flavors in this dark and velvety coffee. Its deep richness and complex undertones will leave you craving for more.",
                Price = 10.99m,
                PurchasingLink = "https://midnightsymphonycoffee.com",
                Size = "16 oz",
                Origin = "Indonesia",
                RoastType = "Dark"
            };
            var coffee7 = new Coffee
            {
                CoffeeId = Guid.Parse("9EB35C63-8680-46C5-A91D-FE4E00DE6CE8"),
                Name = "Velvet Dream",
                Description = "Indulge in the smooth and velvety texture of this coffee that unveils layers of exquisite flavors. It offers a luxurious drinking experience that will satisfy even the most refined palates.",
                Price = 12.99m,
                PurchasingLink = "https://velvetdreamcoffee.com",
                Size = "8 oz",
                Origin = "Guatemala",
                RoastType = "Medium"
            };
            var coffee8 = new Coffee
            {
                CoffeeId = Guid.Parse("2E6C6636-291D-42CA-816E-A48C6210693C"),
                Name = "Harvest Euphoria",
                Description = "Celebrate the harvest season with this coffee that captures the essence of fall. It combines warm and comforting flavors with a hint of spice, creating a delightful cup of joy.",
                Price = 11.99m,
                PurchasingLink = "https://harvesteuphoriacoffee.com",
                Size = "12 oz",
                Origin = "Honduras",
                RoastType = "Medium"
            };
            var coffee9 = new Coffee
            {
                CoffeeId = Guid.Parse("E5ABD4E3-2C99-48C9-BF0A-EC4DFCEECF85"),
                Name = "Golden Fields",
                Description = "Immerse yourself in the golden hues and flavors of this coffee that brings to mind vast fields and sun-kissed mornings. Its smooth and balanced profile will transport you to a place of tranquility.",
                Price = 10.99m,
                PurchasingLink = "https://goldenfieldscoffee.com",
                Size = "16 oz",
                Origin = "Peru",
                RoastType = "Light"
            };
            var votingSessionId = Guid.Parse("7A1C571A-1B44-45D0-8FF9-44613EA93F22");
            var voteId1 = Guid.Parse("B9B203A4-B522-4FE5-A49D-6ED60983253C");
            var voteId2 = Guid.Parse("3DE3AFE4-1B83-400C-A203-663E76CD47AE");
            var voteId3 = Guid.Parse("2A6DD843-D678-4C83-B43F-967C68CE0B45");
            var AndroidsId = Guid.Parse("E2C60C79-94B0-4D96-964A-954D773B8A4A");
            var teamKlingonsId = Guid.Parse("35FDF055-CCA3-4708-BDB3-F1AB98B61F8E");
            var teamRedId = Guid.Parse("A776AED4-36C7-41AE-987E-B5422993B8F6");

            var marco = new User
            {
                UserId = Guid.Parse("6D053564-D24D-4E2E-AA56-916A06A158C2"),
                Name = "Marco",
                Email = "marco@androids.com",
                TeamId = AndroidsId
            };

            var joe = new User
            {
                UserId = Guid.Parse("2CAE5DD5-EE71-46A8-AED4-C97281E8C082"),
                Name = "Joe",
                Email = "Joe@klingons.com",
                TeamId = teamKlingonsId
            };

            var larry = new User
            {
                UserId = Guid.Parse("EC7F5960-7718-48AE-812B-FD22734F6A88"),
                Name = "Larry",
                Email = "Larry@red.com",
                TeamId = teamRedId
            };

            var sarah = new User
            {
                UserId = Guid.Parse("EA7B094E-E934-4321-A2AF-019E47FE30C3"),
                Name = "Sarah",
                Email = "sarah@androids.com",
                TeamId = AndroidsId
            };

            var mike = new User
            {
                UserId = Guid.Parse("B5924414-D4F6-46C9-B7C1-4CC4C7DCE5CC"),
                Name = "Mike",
                Email = "mike@androids.com",
                TeamId = AndroidsId
            };

            var emily = new User
            {
                UserId = Guid.Parse("D2C891CE-74CA-45C2-A931-1B20B937BF62"),
                Name = "Emily",
                Email = "emily@androids.com",
                TeamId = AndroidsId
            };

            var john = new User
            {
                UserId = Guid.Parse("772C00C1-55B5-48F0-8230-50415F631471"),
                Name = "John",
                Email = "john@androids.com",
                TeamId = AndroidsId
            };

            var robert = new User
            {
                UserId = Guid.Parse("5CF95F90-47F5-4D90-9ACF-4E3296635050"),
                Name = "Robert",
                Email = "robert@klingons.com",
                TeamId = teamKlingonsId
            };

            var amy = new User
            {
                UserId = Guid.Parse("B6E37974-17D7-4830-B469-511935A0B09A"),
                Name = "Amy",
                Email = "amy@klingons.com",
                TeamId = teamKlingonsId
            };

            var lisa = new User
            {
                UserId = Guid.Parse("E9E6D858-5DE5-44C6-A1E4-20A0056ECC51"),
                Name = "Lisa",
                Email = "lisa@klingons.com",
                TeamId = teamKlingonsId
            };

            var daniel = new User
            {
                UserId = Guid.Parse("1BD14A32-2288-4210-B065-9CDBACFBFCFE"),
                Name = "Daniel",
                Email = "daniel@klingons.com",
                TeamId = teamKlingonsId
            };

            var julia = new User
            {
                UserId = Guid.Parse("B50B0BD1-6519-4BA4-B0EF-7F5BC85C6212"),
                Name = "Julia",
                Email = "julia@red.com",
                TeamId = teamRedId
            };

            var alex = new User
            {
                UserId = Guid.Parse("8F529DB0-90E1-424D-8E5C-48BF7FA9F5EC"),
                Name = "Alex",
                Email = "alex@red.com",
                TeamId = teamRedId
            };

            var sophia = new User
            {
                UserId = Guid.Parse("1C9C1E07-824F-4AB1-9899-2ED9D6D7CFF6"),
                Name = "Sophia",
                Email = "sophia@red.com",
                TeamId = teamRedId
            };

            var david = new User
            {
                UserId = Guid.Parse("781159FD-F06A-4E69-BE3F-1E79740EA063"),
                Name = "David",
                Email = "david@red.com",
                TeamId = teamRedId
            };

            var votingSessionData = new VotingSession
            {
                VotingSessionId = votingSessionId,
                StartDate = seedDate,
                TeamId = AndroidsId,
                EndDate = seedDate.AddDays(5),
            };

            var coffeeGroupData = new CoffeeGroup
            {
                CoffeeGroupId = Guid.Parse("9E342BAF-5E4D-43A4-8A3E-E657B598CB98"),
            };

            votingSessionData.CoffeeGroupId = coffeeGroupData.CoffeeGroupId;



            var voteSessionCollection = new List<VotingSession> { votingSessionData };
            var coffeeCollection = new List<Coffee> { coffee1 };

            /*var groupCoffeeVotingData = new GroupCoffeeVoting
            {
                GroupCoffeeVotingId = Guid.Parse("829E15AE-A92D-48BA-8519-2FB437736A19"),
                CoffeeGroupId = Guid.Parse("9E342BAF-5E4D-43A4-8A3E-E657B598CB98"),
                CoffeeId = coffee1.CoffeeId,
                VotingSessionId = votingSessionId
            };*/

            //----------------------------------------------------------

            // Add other model configurations here
            // Configure seed data
            modelBuilder.Entity<Coffee>().HasData(
               coffee1, coffee2, coffee3, coffee4, coffee5, coffee6, coffee7, coffee8, coffee9
            );

            modelBuilder.Entity<CoffeeGroup>().HasData(coffeeGroupData);

            modelBuilder.Entity<VotingSession>().HasData(votingSessionData);

           // modelBuilder.Entity<GroupCoffeeVoting>().HasData(groupCoffeeVotingData);


            modelBuilder.Entity<Vote>().HasData(
                new Vote { VoteId = voteId1, UserId = marco.UserId, CoffeeId = coffee1.CoffeeId, VotingSessionId = votingSessionId },
                new Vote { VoteId = voteId2, UserId = sarah.UserId, CoffeeId = coffee2.CoffeeId, VotingSessionId = votingSessionId },
                new Vote { VoteId = voteId3, UserId = mike.UserId, CoffeeId = coffee3.CoffeeId, VotingSessionId = votingSessionId }
            );
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    TeamId = AndroidsId,
                    Name = "Androids",
                    CreatedDate = seedDate
                },
                new Team { TeamId = teamKlingonsId, Name = "Klingons", CreatedDate = seedDate },
                new Team { TeamId = teamRedId, Name = "Team Red", CreatedDate = seedDate }
            );

            modelBuilder.Entity<User>().HasData(
                marco, joe, larry, sarah, mike, emily, john, robert, amy, lisa, daniel, julia, alex, sophia, david
            );

            modelBuilder.Entity<Announcement>().HasData(
              new Announcement
              {
                  AnnouncementId = Guid.Parse("C065E164-3203-499F-A58A-C229653C26C2"),
                  Message = "Change in Management",
                  AnnouncementDate = seedDate,
                  TeamId = AndroidsId // TeamId foreign key
              },
                new Announcement
                {
                    AnnouncementId = Guid.Parse("DFA3408F-99F8-48FC-82CC-E4D8D5E8EA55"),
                    Message = "Coffee Leader will be going on holiday",
                    AnnouncementDate = seedDate,
                    TeamId = AndroidsId // TeamId foreign key
                },
                new Announcement
                {
                    AnnouncementId = Guid.Parse("06E5377F-5188-4C2E-8933-45B4109AAC63"),
                    Message = "Limited edition coffee will be offered for free today",
                    AnnouncementDate = seedDate,
                    TeamId = AndroidsId // TeamId foreign key
                }
            );

            modelBuilder.Entity<Payment>().HasData(
            new Payment { PaymentId = Guid.Parse("40C4591E-FF90-4CD3-8FF7-4582F2392883"), UserId = marco.UserId, Amount = 10.99m, PaymentDate = seedDate},
            new Payment { PaymentId = Guid.Parse("57200C32-3250-4C60-9090-720027577EF4"), UserId = sarah.UserId, Amount = 15.99m, PaymentDate = seedDate},
            new Payment { PaymentId = Guid.Parse("089F7464-800E-4A19-8254-E62A470183FD"), UserId = mike.UserId, Amount = 8.99m, PaymentDate = seedDate}
            );



            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditTableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
