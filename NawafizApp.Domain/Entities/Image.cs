using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
  public  class Image:IEntityBase
    {
        public int Id { set; get; }
        public byte[] source { set; get; }
        public virtual House House { set; get; }
        public int HouseId { set; get; }


    }
}
