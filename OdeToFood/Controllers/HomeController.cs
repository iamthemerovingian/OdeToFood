using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;

namespace OdeToFood.Controllers
{
    [Authorize] //[Authorize("administrators, sales")]
    public class HomeController : Controller
    {
        IOdeToFoodDb _db;


        public HomeController()
        {
            _db = new OdeToFoodDb();
        }

        public HomeController(IOdeToFoodDb db)
        {
            _db = db;
        }
        public ActionResult AutoComplete (string term)
        {
            var model = _db.Query<Restaurant>()
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new
                {
                    label = r.Name
                });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //[ChildActionOnly]
        //[OutputCache(Duration = 60)]
        //[AllowAnonymous]
        //public ActionResult SayHello()
        //{
        //    return Content("Hello");
        //}

        [OutputCache(CacheProfile ="Long", VaryByHeader = "X-Requested-With;Accept-Language", Location = OutputCacheLocation.Server)]
        [AllowAnonymous]
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var id = RouteData.Values["id"];

            //var message = $" {controller}, {action}, {id}";

            //ViewBag.Message = message;

            //var model = _db.Restaurants.ToList();

            //var model = from r in _db.Restaurants
            //            orderby r.Reviews.Average(review => review.Rating) descending
            //            select new RestaurantListViewModel
            //            {
            //                Id = r.Id,
            //                Name = r.Name,
            //                City = r.City,
            //                Country = r.Country,
            //                CountOfReviews = r.Reviews.Count()
            //            };

            var model = _db.Query<Restaurant>()
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Select(r => new RestaurantListViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()
                }).ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel();

            model.Name = "Milinda";
            model.Location = "Bangkok, Thailand";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}