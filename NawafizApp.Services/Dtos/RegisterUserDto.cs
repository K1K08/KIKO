using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string UserName { set; get; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string phoneNum { set; get; }
        public string ConfirmPassword { get; set; }
    }
}
