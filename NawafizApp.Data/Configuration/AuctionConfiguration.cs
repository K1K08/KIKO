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
    internal class AuctionConfiguration: EntityTypeConfiguration<Auction>
    {
        internal AuctionConfiguration()
        {
            ToTable("Auction");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.startBid)
        .HasColumnName("startBid")
        .HasColumnType("int")
             .IsRequired();

            Property(x => x.CurrentBid)
      .HasColumnName("CurrentBid")
      .HasColumnType("int")
       .IsOptional();

            Property(x => x.CurrentBider)
            .HasColumnName("CurrentBider")
           .HasColumnType("uniqueidentifier")
          .IsOptional();

            Property(x => x.startDate)
            .HasColumnName("startDate")
             .HasColumnType("datetime")
                .HasPrecision(23)
               .IsRequired();


            Property(x => x.starttime)
            .HasColumnName("starttime")
             .HasColumnType("time")
             
               .IsRequired();
            Property(x => x.endtime)
          .HasColumnName("endtime")
           .HasColumnType("time")

             .IsRequired();
            Property(x => x.endDate)
         .HasColumnName("endDate")
          .HasColumnType("datetime")
             .HasPrecision(23)
            .IsRequired();

            HasRequired(x => x.House)
                .WithMany(x => x.Auctions)
                .HasForeignKey(x => x.HouseId);

            HasRequired(x => x.Owner)
              .WithMany(x => x.Auctions)
              .HasForeignKey(x => x.OwnerId);
        }
    }
}
