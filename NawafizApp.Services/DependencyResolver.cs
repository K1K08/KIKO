using NawafizApp.Data;
using NawafizApp.Domain;
using NawafizApp.Resolver;
using NawafizApp.Services.Dtos;
using NawafizApp.Services.Dtos.Validators;
using NawafizApp.Services.Identity;
using NawafizApp.Services.Interfaces;
using NawafizApp.Services.Services;
using FluentValidation;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NawafizApp.Services
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterTypeWithInjectedConstructor<IUnitOfWork, UnitOfWork>("NawafizApp");
            registerComponent.RegisterTypeWithTransientLifetimeManager<IUserStore<IdentityUser, Guid>, UserStore>();
            registerComponent.RegisterTypeWithTransientLifetimeManager<IRoleStore<IdentityRole,Guid>,RoleStore>();

            // Services
            registerComponent.RegisterType<ILanguageService, LanguageService>();
            registerComponent.RegisterType<IUserService,UserService>();
            registerComponent.RegisterType<IAuctionService, AuctionService>();


            // Validators
            registerComponent.RegisterType<IValidator<LanguageDto>, LanguageValidator>();
            registerComponent.RegisterType<IValidator<changepasswordDto>, changePass>();

            registerComponent.RegisterType<IValidator<RegisterUserDto>, RegisterUserValidator>();
            
        }
    }
}
