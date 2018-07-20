using NawafizApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Interfaces
{
    public interface IAuctionService
    {
        int addLocation(LocationDto dto);
        List<LocationDto> getAllLocations();
        bool EditLocation(int id, LocationDto dto);
        bool deleteLocation(int id);
        LocationDto getLocationById(int id);

        int addDecoration(DecorationDto dto);
        List<DecorationDto> getAllDecorations();
        bool EditDecoration(int id, DecorationDto dto);
        bool deleteDecoration(int id);
        DecorationDto getDecorationById(int id);

        int addFloor(FloorDto dto);
        List<FloorDto> getAllFloors();
        bool EditFloor(int id, FloorDto dto);
        bool deleteFloor(int id);
        FloorDto getFloorById(int id);

        int addDirection(DirectionDto dto);
        List<DirectionDto> getAllDirections();
        bool EditDirection(int id, DirectionDto dto);
        bool deleteDirection(int id);
        DirectionDto getDirectionById(int id);

        int addH_View(H_ViewDto dto);
        List<H_ViewDto> getAllH_Views();
        bool EditH_View(int id, H_ViewDto dto);
        bool deleteH_View(int id);
        H_ViewDto getH_ViewById(int id);
        int addHouse(AddAuctionDto dto);
        int addImage(ImageDto dto);
        int addAuction(AddAuctionDto dto);
        List<ActiveAuctionDto> getActiveAuctions();
        AuctionDeatailsDto getAuctionById(int AuId);
        bool checkIfAuctionStillAvailable(int AuId);
        AuctionCurrentBidAndBider getCurrentBidAndBider(int id);
        string bid(int auId, int val, Guid uid);
        List<AuctionDeatailsDto> getMyAuctions(Guid id);

        List<AuctionDeatailsDto> getMyActions(Guid id);
        bool updateStartbid(int Auid, int sbid);
    }
}
