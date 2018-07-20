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
   internal class FloorConfiguration : EntityTypeConfiguration<Floor>
    {
        internal FloorConfiguration()
        {
            ToTable("Floor");

            HasKey(x => x.Id)
    .Property(x => x.Id)
    .HasColumnName("Id")
    .HasColumnType("int")
    .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.number)
                .HasColumnName("number")
                .HasColumnType("int")
                .IsRequired();

            HasMany(x => x.Houses)
                 .WithRequired(x => x.Floor)
                 .HasForeignKey(x => x.floorId);

        }
    }
}
