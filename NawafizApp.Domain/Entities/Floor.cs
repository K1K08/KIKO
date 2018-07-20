using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Domain.Entities
{
  public  class Floor:IEntityBase
    {
        public int Id { set; get; }
        public int number { set; get; }
        private ICollection<House> _Houses;
        public virtual ICollection<House> Houses
        {
            get { return _Houses ?? (_Houses = new List<House>()); }
            set { _Houses = value; }
        }
    }
}
