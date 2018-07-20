using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
  public  class ActiveAuctionDto
    {

        public int AuId { set; get; }
        public string ExpireDate { set; get; }
        public int CurrentBid { set; get; }
    }
}
