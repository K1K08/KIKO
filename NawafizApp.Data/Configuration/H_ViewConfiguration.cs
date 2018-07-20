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
  internal  class H_ViewConfiguration: EntityTypeConfiguration<H_View>
    {
        internal H_ViewConfiguration()
        {
            ToTable("H_View");
            HasKey(x => x.Id)
    .Property(x => x.Id)
    .HasColumnName("Id")
    .HasColumnType("int")
    .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(x => x.name)
            .HasColumnName("name")
            .HasColumnType("nvarchar")
            .IsRequired();

            HasMany(x => x.Houses)
                .WithRequired(x=>x.H_View)
                .HasForeignKey(x=>x.h_ViewId);
        }
    }
}
