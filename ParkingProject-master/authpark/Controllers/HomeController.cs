using authpark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace authpark.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.ListOfDropdown = db.Locations.ToList();
            return View();
        }
        public JsonResult GetAllLocation()
        {
            var data = db.Locations.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllLocationById(int id)
        {
            var data = db.Locations.Where(x => x.LocationId == id).SingleOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public JsonResult detailasjson()
        {
            return Json(db.Locations, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [WebMethod]
        public  static string GetDirection(string from, string to)
        {
            string returnVal = "";

            returnVal = "from:" + from + "to:" + to;
            return returnVal;

        }
    }
}