using NawafizApp.Services.Dtos.Validators.PropertyValidators;
using FluentValidation;
using FluentValidation.Results;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NawafizApp.Services.Dtos.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public readonly IUserService _userService;
        public RegisterUserValidator(IUserService userService)
        {
            _userService = userService;
            RuleSet("Register", () =>
            {
                CommonRules();
            });
            CommonRules();
        }
        private void CommonRules()
        {
            RuleFor(m => m.UserName).NotEmpty().WithMessage(" مطلوب").Length(1,256).WithMessage("مرفوض");
            RuleFor(m => m.Password).NotEmpty().WithMessage("مطلوب").Length(3, 25).WithMessage("كلمة المرور مرفوضة");
            RuleFor(m => m.ConfirmPassword).NotEmpty().WithMessage("مطلوب").Equal(x => x.Password).WithMessage("كلمة المرور وتأكيدها غير متطابقان");
            RuleFor(m => m.FullName).NotEmpty().WithMessage("مطلوب");
            RuleFor(m => m.phoneNum).NotEmpty().WithMessage("مطلوب");
            //     RuleFor(m => m.FullName).NotEmpty().WithMessage("الاسم مطلaaوب");

            RuleFor(m => m.Email).SetValidator(new IsEmailUniquePropertyValidator(_userService));
        }
    }
}
