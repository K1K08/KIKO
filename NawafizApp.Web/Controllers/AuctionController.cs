using NawafizApp.Services.Dtos;

using NawafizApp.Services.Identity;
using NawafizApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NawafizApp.Common;
using Microsoft.AspNet.Identity;

namespace NawafizApp.Web.Controllers
{
    public class AuctionController : BaseAuthorizeController
    {
        IAuctionService _IAuctionService;
        public AuctionController(ApplicationUserManager userManager, ApplicationSignInManager signInManager,IAuctionService ias) : base(userManager, signInManager)
        {
            this._IAuctionService = ias;
        }

        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="Admin")]
        public ActionResult AddLocation()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLocation(LocationDto dto)
        {
            _IAuctionService.addLocation(dto);
            return RedirectToAction("AddLocation");
        }
        public ActionResult getAllLocations()
        {
            return View(_IAuctionService.getAllLocations());
        }
        [Authorize(Roles = "Admin")]
        public ActionResult EditLocation(int id)
        {

            return View(_IAuctionService.getLocationById(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLocation(int id,LocationDto dto)
        {
            var x = _IAuctionService.EditLocation(id, dto);

            return RedirectToAction("AddLocation");
        }
        [Authorize(Roles ="Admin")]
        public ActionResult DeleteLocation (int id)
        {
            _IAuctionService.deleteLocation(id);
            return RedirectToAction("AddLocation");

        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddDecoration()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDecoration(DecorationDto dto)
        {
            _IAuctionService.addDecoration(dto);
            return RedirectToAction("AddDecoration");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllDecorations()
        {
            return View(_IAuctionService.getAllDecorations());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditDecoration(int id)
        {

            return View(_IAuctionService.getDecorationById(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDecoration(int id, DecorationDto dto)
        {
            var x = _IAuctionService.EditDecoration(id, dto);

            return RedirectToAction("AddDecoration");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDecoration(int id)
        {
            _IAuctionService.deleteDecoration(id);
            return RedirectToAction("AddDecoration");

        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddFloor()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFloor(FloorDto dto)
        {
            _IAuctionService.addFloor(dto);
            return RedirectToAction("AddFloor");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllFloors()
        {
            return View(_IAuctionService.getAllFloors());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditFloor(int id)
        {

            return View(_IAuctionService.getFloorById(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFloor(int id, FloorDto dto)
        {
            var x = _IAuctionService.EditFloor(id, dto);

            return RedirectToAction("AddFloor");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteFloor(int id)
        {
            _IAuctionService.deleteFloor(id);
            return RedirectToAction("AddFloor");

        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddDirection()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDirection(DirectionDto dto)
        {
            _IAuctionService.addDirection(dto);
            return RedirectToAction("AddDirection");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllDirections()
        {
            return View(_IAuctionService.getAllDirections());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditDirection(int id)
        {

            return View(_IAuctionService.getDirectionById(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDirection(int id, DirectionDto dto)
        {
            var x = _IAuctionService.EditDirection(id, dto);

            return RedirectToAction("AddDirection");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDirection(int id)
        {
            _IAuctionService.deleteDirection(id);
            return RedirectToAction("AddDirection");

        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddH_View()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddH_View(H_ViewDto dto)
        {
            _IAuctionService.addH_View(dto);
            return RedirectToAction("AddH_View");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult getAllH_Views()
        {
            return View(_IAuctionService.getAllH_Views());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditH_View(int id)
        {

            return View(_IAuctionService.getH_ViewById(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditH_View(int id, H_ViewDto dto)
        {
            var x = _IAuctionService.EditH_View(id, dto);

            return RedirectToAction("AddH_View");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteH_View(int id)
        {
            _IAuctionService.deleteH_View(id);
            return RedirectToAction("AddH_View");

        }
        [Authorize]
        public ActionResult getActiveAuctions()
        {
            return View(_IAuctionService.getActiveAuctions());
        }

        [Authorize]
        public ActionResult getAuction(int id)
        {
            bool t = _IAuctionService.checkIfAuctionStillAvailable(id);
            ViewBag.check = t;
            if (!t)
            {
                ViewBag.w = _IAuctionService.getCurrentBidAndBider(id).currentBider;
                ViewBag.b = _IAuctionService.getCurrentBidAndBider(id).currentBid;
            }
            
            return View(_IAuctionService.getAuctionById(id));
           // return RedirectToAction("expired" ,new { id = id});
        }

        [Authorize]
        public ActionResult expired(int id)
        {
            if(!_IAuctionService.checkIfAuctionStillAvailable(id))
                return View();
            return RedirectToAction("getAuction", new { id = id });
       
        }
        [Authorize]
        public ActionResult getCurrent(int id)
        {
            if (Request.IsAjaxRequest())
            {
             //   if(_IAuctionService.checkIfAuctionStillAvailable(id))
                return PartialView(_IAuctionService.getCurrentBidAndBider(id));
                

            }
            return PartialView(_IAuctionService.getCurrentBidAndBider(id));
        }
        [Authorize]
        public ActionResult myAuctions()
        {
            var id = getGuid(User.Identity.GetUserId());
            return View(_IAuctionService.getMyAuctions(id));
        }
        [Authorize]
        public ActionResult myActions()
        {
            var id = getGuid(User.Identity.GetUserId());
            return View(_IAuctionService.getMyActions(id));
        }
        [Authorize]
        public ActionResult Bid (int auId,int val)
        {
            if(Request.IsAjaxRequest())
            {
                if (!_IAuctionService.checkIfAuctionStillAvailable(auId))
                {
                    ViewBag.mess = "انتهى المزاد";
                    return PartialView();
                }
                    var id = getGuid(User.Identity.GetUserId());
                ViewBag.mess = _IAuctionService.bid(auId, val, id);
                return PartialView();
            }
            return PartialView();
        }
        [Authorize]
        public ActionResult addAuction()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addAuction(AddAuctionDto dto,IEnumerable<HttpPostedFileBase> files)
        {
            int hID = _IAuctionService.addHouse(dto);
            ImageDto Imdto = new ImageDto();
            foreach (var file in files)
            {

                if (file.ContentLength > (4 * 1024 * 1024))
                {
                    ModelState.AddModelError("CustomError", "file size must be less than 4MB");
                    return View();
                }
                if (!(file.ContentType == "image/jpeg" || file.ContentType == "image/png" || file.ContentType == "image/gif"))
                {
                    ModelState.AddModelError("CustomError", "الأنماط المسموحة :jpeg , png , gif");
                    return View();
                }
                Imdto.source = new byte[file.ContentLength];
                file.InputStream.Read(Imdto.source, 0, file.ContentLength);
                Imdto.HouseId = hID;
                _IAuctionService.addImage(Imdto);
                Imdto = new ImageDto();
            }
            dto.OwnerId = getGuid(User.Identity.GetUserId());
           // string s1 = _IAuctionService.getAllDecorations().Where(x => x.Id == dto.decorationId).Single().type;

            dto.startBid = 0;
            dto.HouseId = hID;
            dto.startBid = 0;
            dto.CurrentBid = 0;

            int direction1 = 5;
            if (!String.IsNullOrEmpty(dto.Direction1))
            {
                direction1 = _IAuctionService.getAllDirections().Where(y => y.name == dto.Direction1).SingleOrDefault().Id;
            }
            int direction2 = 5;
            if (!String.IsNullOrEmpty(dto.Direction2))
            {
                direction2 = _IAuctionService.getAllDirections().Where(y => y.name == dto.Direction2).SingleOrDefault().Id;
            }
            int direction3 = 5;
            if (!String.IsNullOrEmpty(dto.Direction3))
            {
                direction3 = _IAuctionService.getAllDirections().Where(y => y.name == dto.Direction3).SingleOrDefault().Id;
            }
            int direction4 = 5;
            if (!String.IsNullOrEmpty(dto.Direction4))
            {
                direction4 = _IAuctionService.getAllDirections().Where(y => y.name == dto.Direction4).SingleOrDefault().Id;
            }

            int location = decodeLocation(dto.locationId);
            int floor = decodeFloor(dto.floorId);
            int decoration = decodeDecoration(dto.decorationId);
            int hView = decodeView(dto.h_ViewId);

            int direction = decodeDirection(direction1, direction2, direction3, direction4);
            int size = dto.size;
            //////////////////////
            auctionWebService1.auctionWebService1 aws = new auctionWebService1.auctionWebService1();
            int startBid = Convert.ToInt32(aws.calc(location, floor, decoration, hView, direction) * size) * 1000;
            dto.startBid = dto.CurrentBid = startBid;
            var u = _IAuctionService.addAuction(dto);
            return RedirectToAction("predict", new { Aid = u });
        }


        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult calcPrice(AddAuctionDto dto)
        //{
        //    auctionWebService1.auctionWebService1 aws = new auctionWebService1.auctionWebService1();
        //    dto.startBid = Convert.ToInt32(aws.calc(dto.locationId, dto.floorId, dto.decorationId, dto.h_ViewId , dto.decorationId));
        //    return RedirectToAction("addAuction");
        //}

        int decodeLocation(int x)
        {
            return x;
        }

        int decodeFloor(int x)
        {
            if (x <= 7)
                return x - 4;
            return x - 5;
        }

        int decodeDecoration(int x)
        {
            return x - 1;
        }

        int decodeView(int x)
        {
            return x;
        }

        int decodeDirection(int x1 , int x2 , int x3 , int x4)
        {
            return Math.Min(x1, Math.Min(x2, Math.Min(x3, x4)));
        }

        [Authorize]
        public ActionResult predict(int Aid)
        {
            var x = _IAuctionService.getAuctionById(Aid);
        
            int direction1 = 5;
            if (!String.IsNullOrEmpty(x.Direction1))
            {
                direction1 = _IAuctionService.getAllDirections().Where(y => y.name == x.Direction1).SingleOrDefault().Id;
            }
            int direction2 = 5;
            if (!String.IsNullOrEmpty(x.Direction2))
            {
                direction2 = _IAuctionService.getAllDirections().Where(y => y.name == x.Direction2).SingleOrDefault().Id;
            }
            int direction3 = 5;
            if (!String.IsNullOrEmpty(x.Direction3))
            {
                direction3 = _IAuctionService.getAllDirections().Where(y => y.name == x.Direction3).SingleOrDefault().Id;
            }
            int direction4 = 5;
            if (!String.IsNullOrEmpty(x.Direction4))
            {
                direction4 = _IAuctionService.getAllDirections().Where(y => y.name == x.Direction4).SingleOrDefault().Id;
            }
            int location = decodeLocation(x.LocationId);
            int floor = decodeFloor(x.floorId);
            int decoration = decodeDecoration(x.DecorationId);
            int hView = decodeView(x.hviewId);
            
            int direction = decodeDirection(direction1, direction2, direction3, direction4);
            int size = x.size;
            //////////////////////
            auctionWebService1.auctionWebService1 aws = new auctionWebService1.auctionWebService1();
            int startBid = Convert.ToInt32(aws.calc(location , floor , decoration , hView , direction) * size) * 1000;
            //int startBid = Convert.ToInt32(aws.calc(2, 2, 2, 2, 2)); 
            ///////////////////
            ViewBag.sb = startBid;
            ViewBag.id = Aid;
            return View();

        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult predict(int Aid, int sbid)
        {
            _IAuctionService.updateStartbid(Aid, sbid);
            return RedirectToAction("myAuctions");
        }

    }
}