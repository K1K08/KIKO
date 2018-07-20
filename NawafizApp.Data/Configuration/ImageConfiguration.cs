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
   internal class ImageConfiguration : EntityTypeConfiguration<Image>
    {
        internal ImageConfiguration()
        {
            ToTable("Image");

            HasKey(x => x.Id)
  .Property(x => x.Id)
  .HasColumnName("Id")
  .HasColumnType("int")
  .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.source)
.HasColumnName("source")
.HasColumnType("varbinary(MAX)").IsRequired();

            HasRequired(x => x.House)
                .WithMany(d => d.Images)
                .HasForeignKey(x => x.HouseId);
        }
    }
}
