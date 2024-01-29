using CoffeeClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeClub.Persistence.Configurations
{
    public class CoffeeConfiguration : IEntityTypeConfiguration<Coffee>
    {
        public void Configure(EntityTypeBuilder<Coffee> builder)
        {
            builder.ToTable("Coffees"); // Set the table name

            builder.HasKey(c => c.CoffeeId); // Set the primary key

            builder.Property(c => c.CoffeeId)
                .ValueGeneratedNever(); // Set the CoffeeId property as non-generated

            // Configure other properties
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Price)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(c => c.PurchasingLink)
             .IsRequired()
             .HasAnnotation("RegularExpression", @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$")
             .HasMaxLength(2000);

            builder.Property(c => c.Size)
            .IsRequired()
            .HasAnnotation("RegularExpression", @"^\d+(\s+(oz|lb))$")
            .HasMaxLength(20);


            builder.Property(c => c.Origin)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.RoastType)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
