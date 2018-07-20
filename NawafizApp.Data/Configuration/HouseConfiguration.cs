using NawafizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Data.Configuration
{
  internal  class HouseConfiguration: EntityTypeConfiguration<House>
    {
        internal HouseConfiguration()
        {
            ToTable("House");
            HasKey(x => x.Id)
            .Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("int")
            .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.price)
                .HasColumnName("price")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.size)
              .HasColumnName("size")
              .HasColumnType("int")
              .IsRequired();
            Property(x => x.Direction1)
            .HasColumnName("Direction1")
            .HasColumnType("nvarchar")
            .IsOptional();
            Property(x => x.Direction2)
          .HasColumnName("Direction2")
          .HasColumnType("nvarchar")
          .IsOptional();
            Property(x => x.Direction3)
          .HasColumnName("Direction3")
          .HasColumnType("nvarchar")
          .IsOptional();
            Property(x => x.Direction4)
          .HasColumnName("Direction4")
          .HasColumnType("nvarchar")
          .IsOptional();

            HasMany(x => x.Auctions)
                .WithRequired(x => x.House)
                .HasForeignKey(x => x.HouseId);

            HasRequired(x => x.Decoration)
                .WithMany(x => x.Houses)
                .HasForeignKey(x => x.decorationId);

            HasRequired(x => x.Floor)
               .WithMany(x => x.Houses)
               .HasForeignKey(x => x.floorId);

            HasRequired(x => x.Location)
               .WithMany(x => x.Houses)
               .HasForeignKey(x => x.locationId);

            HasMany(x => x.Images)
               .WithRequired(x => x.House)
               .HasForeignKey(x => x.HouseId);



        }
    }
}
