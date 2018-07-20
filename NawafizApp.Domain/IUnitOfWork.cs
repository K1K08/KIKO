using NawafizApp.Domain.Entities;
using NawafizApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NawafizApp.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties
        IExternalLoginRepository ExternalLoginRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }

        IRepository<Language> LanguageRepository { get; }
        IRepository<Auction> AuctionRepository { get; }
        IRepository<Decoration> DecorationRepository { get; }
        IRepository<Direction> DirectionRepository { get; }
        IRepository<Floor> FloorRepository { get; }
        IRepository<House> HouseRepository { get; }
        IRepository<Image> ImageRepository { get; }
        IRepository<Location> LocationRepository { get; }
        IRepository<H_View> H_ViewRepository { get; }


        #endregion

        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion
    }
}
