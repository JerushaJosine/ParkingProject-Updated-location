using authpark.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace authpark.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var data = db.Parkings.ToList();
            return View(data);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Vaccancies()
        {
            List<VaccanciesVM> vaccancies = new List<VaccanciesVM>() ;
            var data = db.Locations.ToList();
            foreach (var item in data)
            {
                int reserved = (from s in db.Parkings where s.ParkingStatus != "Done" && s.LocationId == item.LocationId select s).Count();
                //int total = item.TotalVacancies;
                var vac = new VaccanciesVM();
                vac.LocationId=item.LocationId;
                vac.Name= item.Name;
                vac.TotalVacancies=item.TotalVacancies;
                vac.Reserved=reserved;
                vaccancies.Add(vac);

            }
            return View(vaccancies.ToList());
        }
        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ParkingList()
        {
            return View(db.Parkings.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditParking(int? id)
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
        public ActionResult EditParking([Bind(Include = "ParkingId,UserId,LocationId,VehicalRegNo,CheckinTime,CheckoutTime,ParkingStatus")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ParkingList");
            }
            return View(parking);
        }

        public ActionResult ParkingDetails(int? id)
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
        public ActionResult AddParking()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddParking([Bind(Include = "LocationId,VehicalRegNo,CheckinTime,ParkingStatus")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                parking.LocationId = 1;
                parking.CheckinTime = DateTime.Now;
                parking.ParkingStatus = "Reserved";
                db.Parkings.Add(parking);
                db.SaveChanges();
                return RedirectToAction("ParkingList");
            }

            return View(parking);
        }

        public ActionResult DeleteParking(int? id)
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

        // POST: Parkings/Delete/5
        [HttpPost, ActionName("DeleteParking")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteParkingConfirmed(int id)
        {
            Parking parking = db.Parkings.Find(id);
            db.Parkings.Remove(parking);
            db.SaveChanges();
            return RedirectToAction("ParkingList");
        }

        public ActionResult LocationList()
        {
            return View(db.Locations.ToList());
        }
        public ActionResult LocationDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }
        public ActionResult AddLocation()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLocation([Bind(Include = "LocationId,Name,TotalVacancies,Langitude,Longitute,Price,IsActive")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("LocationList");
            }

            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult EditLocation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLocation([Bind(Include = "LocationId,Name,TotalVacancies,Langitude,Longitute,Price,IsActive")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("LocationList");
            }
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult DeleteLocation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("DeleteLocation")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLocationConfirmed(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
            db.SaveChanges();
            return RedirectToAction("LocationList");
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
