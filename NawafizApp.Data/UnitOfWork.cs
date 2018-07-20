using NawafizApp.Data.Repositories;
using NawafizApp.Domain;
using NawafizApp.Domain.Entities;
using NawafizApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private IRepository<Language> _languageRepository;
        private IRepository<Auction> _AuctionRepository;
        private IRepository<Direction> _DirectionRepository;
        private IRepository<Decoration> _DecorationRepository;
        private IRepository<Floor> _FloorRepository;
        private IRepository<House> _HouseRepository;
        private IRepository<Location> _LocationRepository;
        private IRepository<Image> _ImageRepository;
        private IRepository<H_View> _H_ViewRepository;



        #endregion

        #region Constructors
        public UnitOfWork(string nameOrConnectionString)
        {
            _context = new ApplicationDbContext(nameOrConnectionString);
        }
        #endregion

        #region IUnitOfWork Members
        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(_context)); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public IRepository<Language> LanguageRepository
        {
            get { return _languageRepository ?? (_languageRepository = new Repository<Language>(_context)); }
        }

        public IRepository<Auction> AuctionRepository
        {
            get
            {
                return _AuctionRepository ?? (_AuctionRepository = new Repository<Auction>(_context));
            }
        }

        public IRepository<Decoration> DecorationRepository
        {
            get
            {
                return _DecorationRepository ?? (_DecorationRepository = new Repository<Decoration>(_context));
            }
        }

        public IRepository<Direction> DirectionRepository
        {
            get
            {
                return _DirectionRepository ?? (_DirectionRepository = new Repository<Direction>(_context));
            }
        }

        public IRepository<Floor> FloorRepository
        {
            get
            {
                return _FloorRepository ?? (_FloorRepository = new Repository<Floor>(_context));
            }
        }

        public IRepository<House> HouseRepository
        {
            get
            {
                return _HouseRepository ?? (_HouseRepository = new Repository<House>(_context));
            }
        }

        public IRepository<Image> ImageRepository
        {
            get
            {
                return _ImageRepository ?? (_ImageRepository = new Repository<Image>(_context));
            }
        }

        public IRepository<Location> LocationRepository
        {
            get
            {
                return _LocationRepository ?? (_LocationRepository = new Repository<Location>(_context));
            }
        }

        public IRepository<H_View> H_ViewRepository
        {
            get
            {
                return _H_ViewRepository ?? (_H_ViewRepository = new Repository<H_View>(_context));
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _externalLoginRepository = null;
            _roleRepository = null;
            _userRepository = null;
            _context.Dispose();
        }
        #endregion
    }
}
