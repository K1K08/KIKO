using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
  public  class AddAuctionDto
    {
        public int auctionId { set; get; }
        public Guid OwnerId { set; get; }
        public string OwnerName { set; get; }
        public int startBid { set; get; }
        public Guid? CurrentBider { set; get; }
        public int CurrentBid { set; get; }
        public string CurrentBiderName { set; get; }
        public int HouseId { set; get; }
        public string startDate { set; get; }
        public string endDate { set; get; }
        public string strTime { set; get; }
        public string EndTimeTime { set; get; }
        public int price { set; get; }
        public int size { set; get; }
        public string Direction1 { set; get; }
        public string Direction2 { set; get; }
        public string Direction3 { set; get; }
        public string Direction4 { set; get; }
     
        public int locationId { set; get; }
      
        public int h_ViewId { set; get; }
     
        public int floorId { set; get; }
       
        public int decorationId { set; get; }

    }
}
