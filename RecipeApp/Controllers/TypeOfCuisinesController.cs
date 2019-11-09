using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeApp.Models;

namespace RecipeApp.Controllers
{
    public class TypeOfCuisinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TypeOfCuisines
        public ActionResult Index()
        {
            return View(db.Cuisines.ToList());
        }

        // GET: TypeOfCuisines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfCuisines typeOfCuisines = db.Cuisines.Find(id);
            if (typeOfCuisines == null)
            {
                return HttpNotFound();
            }
            return View(typeOfCuisines);
        }

        // GET: TypeOfCuisines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfCuisines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CuisineName,CuisineDescription")] TypeOfCuisines typeOfCuisines)
        {
            if (ModelState.IsValid)
            {
                db.Cuisines.Add(typeOfCuisines);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOfCuisines);
        }

        // GET: TypeOfCuisines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfCuisines typeOfCuisines = db.Cuisines.Find(id);
            if (typeOfCuisines == null)
            {
                return HttpNotFound();
            }
            return View(typeOfCuisines);
        }

        // POST: TypeOfCuisines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CuisineName,CuisineDescription")] TypeOfCuisines typeOfCuisines)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfCuisines).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfCuisines);
        }

        // GET: TypeOfCuisines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfCuisines typeOfCuisines = db.Cuisines.Find(id);
            if (typeOfCuisines == null)
            {
                return HttpNotFound();
            }
            return View(typeOfCuisines);
        }

        // POST: TypeOfCuisines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeOfCuisines typeOfCuisines = db.Cuisines.Find(id);
            db.Cuisines.Remove(typeOfCuisines);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public static List<SelectListItem> GetDropDownItems()
        {
            ApplicationDbContext thisdb = new ApplicationDbContext();
            List<SelectListItem> ls = new List<SelectListItem>();
            var data = thisdb.Cuisines.ToList();
            foreach (var temp in data)
            {
                ls.Add(new SelectListItem() { Text = temp.CuisineName, Value = temp.Id.ToString() });
            }
            return ls;
        }
    }
}
