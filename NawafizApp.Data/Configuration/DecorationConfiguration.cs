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
  internal  class DecorationConfiguration : EntityTypeConfiguration<Decoration>
    {
        internal DecorationConfiguration()
        {
            ToTable("Decoration");

            HasKey(x => x.Id)
          .Property(x => x.Id)
          .HasColumnName("Id")
          .HasColumnType("int")
          .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(x => x.type)
                .HasColumnName("type")
                .HasColumnType("nvarchar")
                .IsRequired();

            HasMany(x => x.Houses)
               .WithRequired(x => x.Decoration)
               .HasForeignKey(x => x.decorationId);
        }
    }
}
