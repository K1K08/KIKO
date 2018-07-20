using NawafizApp.Services.Dtos;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.IO;
using FluentValidation.Mvc;

namespace CoreApp.Web.Controllers
{
    public class HomeController : Controller
    {
        
        IUserService _iuserService;
        
        
        public HomeController(IUserService iuserService)
        {
            
            _iuserService = iuserService;
            
        }
        
       

        public ActionResult Index()
        {

           

            return View();
        }



        




        public ActionResult blank()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}