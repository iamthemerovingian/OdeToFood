﻿using OdeToFood.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    //[Authorize]
    [Log]
    public class CusineController : Controller
    {
        // GET: Cusine
        //[Authorize]
        public ActionResult Search(string name = "French")
        {

            throw new Exception("Something Terrible Has happened!!!");

            var message = Server.HtmlEncode(name);
            return Content($"Hello, you have reached the Cusine/{name} page");

            //return RedirectToAction("Index", "Home", new { name = name });

            //return File(Server.MapPath("~/Content/site.css"), "text/css");

            //return Json(new { Message = message, name = "Milinda" }, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult Search()
        //{
        //    //var message = Server.HtmlEncode(name);

        //    return Content($"Search!!");

        //    //return RedirectToAction("Index", "Home", new { name = name });

        //    //return File(Server.MapPath("~/Content/site.css"), "text/css");

        //    //return Json(new { Message = message, name = "Milinda" }, JsonRequestBehavior.AllowGet);
        //}
    }
}