using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using authpark.Models;

namespace authpark.Controllers
{
    public class ParkingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Parking
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var data = (from p in db.Parkings where p.UserId == user && p.ParkingStatus!= "Done" select p).ToList();
            return View(data);
        }

        // GET: Parking/Details/5
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

        // GET: Parking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParkingId,UserId,LocationId,VehicalRegNo,CheckinTime,CheckoutTime,ParkingStatus")] Parking parking)
        {
            parking.LocationId =1;
            parking.UserId = User.Identity.GetUserId();
            parking.CheckinTime = DateTime.Now;
            parking.ParkingStatus = "Reserved";
            if (ModelState.IsValid)
            {
                db.Parkings.Add(parking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parking);
        }

        // GET: Parking/Edit/5
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

        // POST: Parking/Edit/5
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

        // GET: Parking/Delete/5
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

        // POST: Parking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parking parking = db.Parkings.Find(id);
            db.Parkings.Remove(parking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Checkout(int id)
        {
            int ID = id;
            if (id!=0)
            {
            var parking = (from s in db.Parkings where s.ParkingId == id select s).FirstOrDefault();
            parking.ParkingStatus = "Done";
                parking.CheckoutTime = DateTime.Now;
            db.SaveChanges();
                return View();
            }
            return RedirectToAction("Home","Index");
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
