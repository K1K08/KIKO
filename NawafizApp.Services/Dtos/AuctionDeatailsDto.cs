using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
    public class AuctionDeatailsDto
    {

        public string Direction1 { set; get; }
        public string Direction2 { set; get; }
        public string Direction3 { set; get; }
        public string Direction4 { set; get; }
        public string Decoration { set; get; }
        public int DecorationId { set; get; }

        public string floor { set; get; }
        public int floorId { set; get; }
        public string location { set; get; }
        public int LocationId { set; get; }
        public string hView { set; get; }
        public int hviewId { set; get; }
        public int size { set; get; }
        public List<ImageDto> Images { set; get; }
        public int auId { set; get; }
        public string Owner { set; get; }
        public string OwnerPhone { set; get; }
        public string Winner { set; get; }
        public string winnerPhone { set; get; }
        public string PayVal { set; get; }
        public string startDate { set; get; }
        public string endtDate { set; get; }

    }
}
