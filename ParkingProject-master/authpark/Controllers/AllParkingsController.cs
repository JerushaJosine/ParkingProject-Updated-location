using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using authpark.Models;
using Microsoft.AspNet.Identity;

namespace authpark.Controllers
{
    public class AllParkingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AllParkings
        public ActionResult Index()
        {
            return View(db.Parkings.ToList());
        }

        // GET: AllParkings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parking parking = db.Parkings.Find(id);
            if (parking == null)
            {
                return HttpNotFound();
            }
            return View(parking);
        }

        // GET: AllParkings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllParkings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParkingId,UserId,LocationId,VehicalRegNo,CheckinTime,CheckoutTime,ParkingStatus")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                db.Parkings.Add(parking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parking);
        }

        // GET: AllParkings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parking parking = db.Parkings.Find(id);
            if (parking == null)
            {
                return HttpNotFound();
            }
            return View(parking);
        }

        // POST: AllParkings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkingId,UserId,LocationId,VehicalRegNo,CheckinTime,CheckoutTime,ParkingStatus")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parking);
        }

        // GET: AllParkings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parking parking = db.Parkings.Find(id);
            if (parking == null)
            {
                return HttpNotFound();
            }
            return View(parking);
        }

        // POST: AllParkings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parking parking = db.Parkings.Find(id);
            db.Parkings.Remove(parking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Reserve(int LocationId)
        {
                Parking parking = new Parking();
            try
            {
                var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                if (userId != null)
                {
                    int loc = LocationId;
                    //ApplicationUser user = (from u in db.Users where u.Id == userId select u).FirstOrDefault();
                    parking.UserId = userId;
                    parking.LocationId = LocationId;
                    parking.VehicalRegNo = "MN-1600";
                    parking.ParkingStatus = "Reserved";
                    //parking.VehicalRegNo=user.no
                    parking.CheckinTime = DateTime.Now;
                    db.Parkings.Add(parking);
                    db.SaveChanges();
                    ViewBag.msg = "Reserved Successfully!";
                }
                else {
                    ViewBag.msg = "Login First!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex;
                throw;
            }
           
            return ViewBag.msg;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
