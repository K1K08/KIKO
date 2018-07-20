using NawafizApp.Data.Configuration;
using NawafizApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Data
{
    internal class ApplicationDbContext : DbContext
    {
        internal ApplicationDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString = "DefaultConnection")
        {
        }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            
        }



        public IDbSet<User> Users { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<ExternalLogin> Logins { get; set; }
        public IDbSet<Language> Languages { get; set; }
        public IDbSet<Direction> Directions { get; set; }
        public IDbSet<Decoration> Decorations { get; set; }
        public IDbSet<Floor> Floors { get; set; }
        public IDbSet<House> Houses { get; set; }
        public IDbSet<Image> Images { get; set; }
        public IDbSet<Location> Locations { get; set; }
        public IDbSet<Auction> Auctions { get; set; }
        public IDbSet<H_View> H_Views { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());
            modelBuilder.Configurations.Add(new LanguageConfiguration());
            modelBuilder.Configurations.Add(new DirectionConfiguration());
            modelBuilder.Configurations.Add(new DecorationConfiguration());
            modelBuilder.Configurations.Add(new AuctionConfiguration());
            modelBuilder.Configurations.Add(new FloorConfiguration());
            modelBuilder.Configurations.Add(new HouseConfiguration());
            modelBuilder.Configurations.Add(new ImageConfiguration());
            modelBuilder.Configurations.Add(new LocationConfiguration());
            modelBuilder.Configurations.Add(new H_ViewConfiguration());




        }
}

   

}
