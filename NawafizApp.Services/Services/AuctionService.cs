using AutoMapper;

using NawafizApp.Common;
using NawafizApp.Domain;
using NawafizApp.Domain.Entities;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuctionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public bool checkIfAuctionStillAvailable(int AuId)
        {

            var item = _unitOfWork.AuctionRepository.FindById(AuId);

            DateTime date1 = new DateTime(item.startDate.Year, item.startDate.Month, item.startDate.Day
                    , item.starttime.Hours, item.starttime.Minutes, item.starttime.Seconds);
            DateTime date2 = new DateTime(item.endDate.Year, item.endDate.Month, item.endDate.Day
               , item.endtime.Hours, item.endtime.Minutes, item.endtime.Seconds);
            DateTime currentDate = DateTime.Now;
            if (!(currentDate >= date1 && currentDate <= date2))
            {
                return false;
            }
            return true;

        }
        public List<AuctionDeatailsDto> getMyActions(Guid id)
        {
            List<AuctionDeatailsDto> res = new List<AuctionDeatailsDto>();
            var lis = _unitOfWork.AuctionRepository.FindBy(x => x.CurrentBider == id);
            AuctionDeatailsDto dto = new AuctionDeatailsDto();
            foreach (var item in lis)
            {
                if (!checkIfAuctionStillAvailable(item.Id))
                {
                    dto.Owner = item.Owner.FullName;
                    dto.PayVal = item.CurrentBid + "";
                    dto.OwnerPhone = item.Owner.PhoneNumber;
                    dto.Winner = _unitOfWork.UserRepository.FindById(item.CurrentBider.GetValueOrDefault()).FullName;
                    dto.startDate = DateTimeHelper.ConvertDateToString(item.startDate, DateFormats.DD_MM_YYYY) + " - " +
                DateTimeHelper.ConvertTimeToString(item.starttime, TimeFormats.HH_MM_AM);
                    dto.endtDate = DateTimeHelper.ConvertDateToString(item.endDate, DateFormats.DD_MM_YYYY) + " - " +
                      DateTimeHelper.ConvertTimeToString(item.endtime, TimeFormats.HH_MM_AM);
                    dto.auId = item.Id;
                    res.Add(dto);
                    dto = new AuctionDeatailsDto();

                }

            }
            return res;
        }
        public List<AuctionDeatailsDto> getMyAuctions(Guid id)
        {
            List<AuctionDeatailsDto> res = new List<AuctionDeatailsDto>();
            var lis = _unitOfWork.AuctionRepository.FindBy(x => x.OwnerId == id);
            AuctionDeatailsDto dto = new AuctionDeatailsDto();
            foreach (var item in lis)
            {
                dto.Owner = _unitOfWork.UserRepository.FindById(id).FullName;
                if (checkIfAuctionStillAvailable(item.Id))
                {
                    dto.Winner = "لا يزال المزاد نشط";
                    dto.winnerPhone = "لا يزال المزاد نشط";
                    dto.PayVal = item.CurrentBid + " (حاليا) ";
                }
                else
                {
                    if (item.CurrentBider != null)
                    {
                        dto.Winner = _unitOfWork.UserRepository.FindById(item.CurrentBider).FullName;
                        dto.winnerPhone = _unitOfWork.UserRepository.FindById(item.CurrentBider).PhoneNumber;
                        dto.PayVal = item.CurrentBid + "";
                    }
                }
                dto.auId = item.Id;
                dto.startDate = DateTimeHelper.ConvertDateToString(item.startDate, DateFormats.DD_MM_YYYY) + " - " +
                    DateTimeHelper.ConvertTimeToString(item.starttime, TimeFormats.HH_MM_AM);
                dto.endtDate = DateTimeHelper.ConvertDateToString(item.endDate, DateFormats.DD_MM_YYYY) + " - " +
                  DateTimeHelper.ConvertTimeToString(item.endtime, TimeFormats.HH_MM_AM);

                res.Add(dto);
                dto = new AuctionDeatailsDto();
            }
            return res;
        }
        public string bid(int auId, int val, Guid uid)
        {
            string res = "";
            var x = _unitOfWork.AuctionRepository.FindById(auId);
            if (val > x.CurrentBid)
            {
                x.CurrentBid = val;
                x.CurrentBider = uid;
                _unitOfWork.AuctionRepository.Update(x);
                _unitOfWork.SaveChanges();
                res = "تم الأمر بنجاح";
                return res;
            }
            res = "القيمة المدخلة مرفوضة";
            return res;

        }
        public AuctionCurrentBidAndBider getCurrentBidAndBider(int id)
        {
            AuctionCurrentBidAndBider dto = new AuctionCurrentBidAndBider();
            dto.currentBid = _unitOfWork.AuctionRepository.FindById(id).CurrentBid.GetValueOrDefault();
            var x = _unitOfWork.AuctionRepository.FindById(id).CurrentBider;
            if (x == null)
            {
                dto.currentBider = "الافتتاح";
                dto.currentBid = _unitOfWork.AuctionRepository.FindById(id).startBid;
            }
            else
            {
                dto.currentBider = _unitOfWork.UserRepository.FindById(x.GetValueOrDefault()).FullName;
            }
            return dto;
        }
        public AuctionDeatailsDto getAuctionById(int AuId)
        {
            var item = _unitOfWork.AuctionRepository.FindById(AuId);
            var list = _unitOfWork.ImageRepository.GetAll().Where(x => x.HouseId == item.HouseId);
            List<ImageDto> imas = new List<ImageDto>();
            ImageDto im = new ImageDto();
            foreach (var x in list)
            {
                im.HouseId = x.HouseId;
                im.Id = x.Id;
                im.source = x.source;
                imas.Add(im);
                im = new ImageDto();
            }
            return new AuctionDeatailsDto
            {
                auId = item.Id,
                Decoration = item.House.Decoration.type,
                DecorationId = item.House.decorationId,
                floorId = item.House.floorId,
                hviewId = item.House.h_ViewId,
                LocationId = item.House.locationId,

                Direction1 = item.House.Direction1,
                Direction2 = item.House.Direction2,
                Direction3 = item.House.Direction3,
                Direction4 = item.House.Direction4,
                floor = item.House.Floor.number + "",
                hView = item.House.H_View.name,
                location = item.House.Location.name,
                Images = imas,
                size = item.House.size

            };
        }
        public bool updateStartbid(int Auid, int sbid)
        {
            var x = _unitOfWork.AuctionRepository.FindById(Auid);
            if (x == null) return false;
            x.startBid = sbid;
            x.CurrentBid = sbid;
            _unitOfWork.AuctionRepository.Update(x);
            _unitOfWork.SaveChanges();
            return true;

        }
        public int addHouse(AddAuctionDto dto)
        {
            House hou = new House();
            hou.decorationId = dto.decorationId;
            hou.floorId = dto.floorId;
            hou.h_ViewId = dto.h_ViewId;
            hou.locationId = dto.locationId;
            hou.price = dto.price;
            hou.size = dto.size;
            hou.Direction1 = dto.Direction1;
            hou.Direction2 = dto.Direction2;
            hou.Direction3 = dto.Direction3;
            hou.Direction4 = dto.Direction4;
            _unitOfWork.HouseRepository.Add(hou);
            _unitOfWork.SaveChanges();
            return hou.Id;
        }
        public List<ActiveAuctionDto> getActiveAuctions()
        {
            DateTime currentDate = DateTime.Now;
            var list = _unitOfWork.AuctionRepository.GetAll();
            ActiveAuctionDto dto = new ActiveAuctionDto();
            List<ActiveAuctionDto> result = new List<ActiveAuctionDto>();
            DateTime date1;
            DateTime date2;

            foreach (var item in list)
            {
                date1 = new DateTime(item.startDate.Year, item.startDate.Month, item.startDate.Day
                    , item.starttime.Hours, item.starttime.Minutes, item.starttime.Seconds);
                date2 = new DateTime(item.endDate.Year, item.endDate.Month, item.endDate.Day
                    , item.endtime.Hours, item.endtime.Minutes, item.endtime.Seconds);
                if (currentDate >= date1 && currentDate <= date2)
                {
                    dto.AuId = item.Id;
                    dto.CurrentBid = item.CurrentBid.GetValueOrDefault();
                    dto.ExpireDate = DateTimeHelper.ConvertDateToString(item.endDate, DateFormats.DD_MM_YYYY) + " "
                        + DateTimeHelper.ConvertTimeToString(item.endtime, TimeFormats.HH_MM_AM);
                    result.Add(dto);
                    dto = new ActiveAuctionDto();
                }

            }
            return result;
        }
        public int addImage(ImageDto dto)
        {
            Image im = new Image();
            im.HouseId = dto.HouseId;
            im.source = dto.source;
            _unitOfWork.ImageRepository.Add(im);
            _unitOfWork.SaveChanges();
            return im.Id;
        }
        public int addAuction(AddAuctionDto dto)
        {
            Auction au = new Auction();
            au.HouseId = dto.HouseId;
            au.OwnerId = dto.OwnerId;
            DateTime date1 = new DateTime();
            date1 = DateTimeHelper.ConvertStringToDate(dto.startDate, DateFormats.DD_MM_YYYY);

            au.startDate = date1;
            DateTime date2 = new DateTime();
            date2 = DateTimeHelper.ConvertStringToDate(dto.endDate, DateFormats.DD_MM_YYYY);

            au.endDate = date2;
            au.starttime = DateTimeHelper.ConvertStringToTime(dto.strTime, TimeFormats.HH_MM_AM);
            au.endtime = DateTimeHelper.ConvertStringToTime(dto.EndTimeTime, TimeFormats.HH_MM_AM);
            au.startBid = dto.startBid;
            au.CurrentBid = dto.CurrentBid;
            _unitOfWork.AuctionRepository.Add(au);
            _unitOfWork.SaveChanges();
            return au.Id;

        }
        public int addDecoration(DecorationDto dto)
        {
            Decoration d = new Decoration();
            d.type = dto.type;
            _unitOfWork.DecorationRepository.Add(d);
            _unitOfWork.SaveChanges();
            return d.Id;
        }

        public int addDirection(DirectionDto dto)
        {
            Direction d = new Direction();
            d.name = dto.name;
            _unitOfWork.DirectionRepository.Add(d);
            _unitOfWork.SaveChanges();
            return d.Id;
        }

        public int addFloor(FloorDto dto)
        {
            Floor f = new Floor();
            f.number = dto.number;
            _unitOfWork.FloorRepository.Add(f);
            _unitOfWork.SaveChanges();
            return f.Id;
        }

        public int addH_View(H_ViewDto dto)
        {
            H_View f = new H_View();
            f.name = dto.name;
            _unitOfWork.H_ViewRepository.Add(f);
            _unitOfWork.SaveChanges();
            return f.Id;
        }

        public int addLocation(LocationDto dto)
        {
            Location l = new Location();
            l.name = dto.name;
            _unitOfWork.LocationRepository.Add(l);
            _unitOfWork.SaveChanges();
            return l.Id;
        }

        public bool deleteDecoration(int id)
        {
            var l = _unitOfWork.DecorationRepository.FindById(id);
            if (l == null) return false;
            _unitOfWork.DecorationRepository.Remove(l);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool deleteDirection(int id)
        {
            var l = _unitOfWork.DirectionRepository.FindById(id);
            if (l == null) return false;
            _unitOfWork.DirectionRepository.Remove(l);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool deleteFloor(int id)
        {
            var l = _unitOfWork.FloorRepository.FindById(id);
            if (l == null) return false;
            _unitOfWork.FloorRepository.Remove(l);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool deleteH_View(int id)
        {
            var l = _unitOfWork.H_ViewRepository.FindById(id);
            if (l == null) return false;
            _unitOfWork.H_ViewRepository.Remove(l);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool deleteLocation(int id)
        {
            var l = _unitOfWork.LocationRepository.FindById(id);
            if (l == null) return false;
            _unitOfWork.LocationRepository.Remove(l);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool EditDecoration(int id, DecorationDto dto)
        {
            var d = _unitOfWork.DecorationRepository.FindById(id);
            if (d == null) return false;
            d.type = dto.type;
            _unitOfWork.DecorationRepository.Update(d);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool EditDirection(int id, DirectionDto dto)
        {
            var d = _unitOfWork.DirectionRepository.FindById(id);
            if (d == null) return false;
            d.name = dto.name;
            _unitOfWork.DirectionRepository.Update(d);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool EditFloor(int id, FloorDto dto)
        {
            var d = _unitOfWork.FloorRepository.FindById(id);
            if (d == null) return false;
            d.number = dto.number;
            _unitOfWork.FloorRepository.Update(d);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool EditH_View(int id, H_ViewDto dto)
        {
            var d = _unitOfWork.H_ViewRepository.FindById(id);
            if (d == null) return false;
            d.name = dto.name;
            _unitOfWork.H_ViewRepository.Update(d);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool EditLocation(int id, LocationDto dto)
        {
            var l = _unitOfWork.LocationRepository.FindById(id);
            if (l == null) return false;
            l.name = dto.name;
            _unitOfWork.LocationRepository.Update(l);
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<DecorationDto> getAllDecorations()
        {
            List<DecorationDto> res = new List<DecorationDto>();
            DecorationDto dto = new DecorationDto();
            foreach (var item in _unitOfWork.DecorationRepository.GetAll())
            {
                dto.Id = item.Id;
                dto.type = item.type;
                res.Add(dto);
                dto = new DecorationDto();

            }
            return res;
        }

        public List<DirectionDto> getAllDirections()
        {
            List<DirectionDto> res = new List<DirectionDto>();
            DirectionDto dto = new DirectionDto();
            foreach (var item in _unitOfWork.DirectionRepository.GetAll())
            {
                dto.Id = item.Id;
                dto.name = item.name;
                res.Add(dto);
                dto = new DirectionDto();

            }
            return res;
        }

        public List<FloorDto> getAllFloors()
        {
            List<FloorDto> res = new List<FloorDto>();
            FloorDto dto = new FloorDto();
            foreach (var item in _unitOfWork.FloorRepository.GetAll())
            {
                dto.Id = item.Id;
                dto.number = item.number;
                res.Add(dto);
                dto = new FloorDto();

            }
            return res;
        }

        public List<H_ViewDto> getAllH_Views()
        {
            List<H_ViewDto> res = new List<H_ViewDto>();
            H_ViewDto dto = new H_ViewDto();
            foreach (var item in _unitOfWork.H_ViewRepository.GetAll())
            {
                dto.Id = item.Id;
                dto.name = item.name;
                res.Add(dto);
                dto = new H_ViewDto();

            }
            return res;
        }

        public List<LocationDto> getAllLocations()
        {
            List<LocationDto> res = new List<LocationDto>();
            LocationDto dto = new LocationDto();
            foreach (var item in _unitOfWork.LocationRepository.GetAll())
            {
                dto.Id = item.Id;
                dto.name = item.name;
                res.Add(dto);
                dto = new LocationDto();

            }
            return res;
        }

        public DecorationDto getDecorationById(int id)
        {
            DecorationDto dto = new DecorationDto();
            var x = _unitOfWork.DecorationRepository.FindById(id);
            dto.Id = x.Id;
            dto.type = x.type;
            return dto;
        }

        public DirectionDto getDirectionById(int id)
        {
            DirectionDto dto = new DirectionDto();
            var x = _unitOfWork.DirectionRepository.FindById(id);
            dto.Id = x.Id;
            dto.name = x.name;
            return dto;
        }

        public FloorDto getFloorById(int id)
        {
            FloorDto dto = new FloorDto();
            var x = _unitOfWork.FloorRepository.FindById(id);
            dto.Id = x.Id;
            dto.number = x.number;
            return dto;
        }

        public H_ViewDto getH_ViewById(int id)
        {
            H_ViewDto dto = new H_ViewDto();
            var x = _unitOfWork.H_ViewRepository.FindById(id);
            dto.Id = x.Id;
            dto.name = x.name;
            return dto;
        }

        public LocationDto getLocationById(int id)
        {
            LocationDto dto = new LocationDto();
            var x = _unitOfWork.LocationRepository.FindById(id);
            dto.Id = x.Id;
            dto.name = x.name;
            return dto;

        }
    }
}
