using NawafizApp.Domain;
using NawafizApp.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NawafizApp.Services.Dtos.Validators.PropertyValidators;

namespace NawafizApp.Services.Dtos.Validators
{
   public class changePass: AbstractValidator<changepasswordDto>
    {
        public changePass()
        {
            RuleFor(x => x.oldPassword).NotEmpty().WithMessage("*");
            RuleFor(x => x.newPassword).NotEmpty().WithMessage("*");
            RuleFor(x => x.newPasswordConfirm).NotEmpty().WithMessage("*").Equal(o=>o.newPassword).WithMessage("غير متطابقتان");
        }
    }
}
