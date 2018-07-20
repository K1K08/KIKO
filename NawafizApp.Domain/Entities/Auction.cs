using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
  public  class Auction :IEntityBase
    {
        public int Id { set; get; }
        public DateTime startDate { set; get; }
        public DateTime endDate { set; get; }

        public TimeSpan starttime { set; get; }
        public TimeSpan  endtime { set; get; }

        public int startBid { set; get; }
        public int? CurrentBid { set; get; }
        public Guid? CurrentBider { set; get; }
        public virtual House House { set; get; }
        public int HouseId { set; get; }
        public virtual User Owner { set; get; }
        public Guid OwnerId { set; get; }

    }
}
