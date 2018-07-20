using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
  public  class ImageDto
    {
        public int Id { set; get; }
        public byte[] source { set; get; }
        public int HouseId { set; get; }
    }
}
