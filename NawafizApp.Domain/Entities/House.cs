using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
  public  class House :IEntityBase
    {
        public int Id { set; get; }
        public int price { set; get; }
        public int size { set; get; }
        public string Direction1 { set; get; }
        public string Direction2 { set; get; }
        public string Direction3 { set; get; }
        public string Direction4 { set; get; }
        public virtual Location Location { set; get; }
        public int locationId { set; get; }
        public virtual H_View H_View { set; get; }
        public int h_ViewId { set; get; }
        public virtual Floor Floor { set; get; }
        public int floorId { set; get; }
        public virtual Decoration Decoration { set; get; }
        public int decorationId { set; get; }
        private ICollection<Image> _Images;
        public virtual ICollection<Image> Images
        {
            get { return _Images ?? (_Images = new List<Image>()); }
            set { _Images = value; }
        }

        private ICollection<Auction> _Auctions;
        public virtual ICollection<Auction> Auctions
        {
            get { return _Auctions ?? (_Auctions = new List<Auction>()); }
            set { _Auctions = value; }
        }
    }
}
