using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
  public  class changepasswordDto
    {
        public string oldPassword { set; get; }
        public string newPassword { set; get; }
        public string newPasswordConfirm { set; get; }

    }
}
