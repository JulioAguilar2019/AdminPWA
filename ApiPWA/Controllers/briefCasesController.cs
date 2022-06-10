using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiPWA;

namespace ApiPWA.Controllers
{
    public class briefCasesController : Controller
    {
        private Parcial3PWAEntities db = new Parcial3PWAEntities();

        // GET: briefCases
        public ActionResult Index()
        {
            var briefcase = db.briefcase.Include(b => b.users);
            return View(briefcase.ToList());
        }

        // GET: briefCases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            briefcase briefcase = db.briefcase.Find(id);
            if (briefcase == null)
            {
                return HttpNotFound();
            }
            return View(briefcase);
        }

        // GET: briefCases/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name");
            return View();
        }

        // POST: briefCases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bc_id,proyect_name,proyect_rol,summary,responsabilities,used_tech,user_id")] briefcase briefcase)
        {
            if (ModelState.IsValid)
            {
                db.briefcase.Add(briefcase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", briefcase.user_id);
            return View(briefcase);
        }

        // GET: briefCases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            briefcase briefcase = db.briefcase.Find(id);
            if (briefcase == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", briefcase.user_id);
            return View(briefcase);
        }

        // POST: briefCases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bc_id,proyect_name,proyect_rol,summary,responsabilities,used_tech,user_id")] briefcase briefcase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(briefcase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", briefcase.user_id);
            return View(briefcase);
        }

        // GET: briefCases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            briefcase briefcase = db.briefcase.Find(id);
            if (briefcase == null)
            {
                return HttpNotFound();
            }
            return View(briefcase);
        }

        // POST: briefCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            briefcase briefcase = db.briefcase.Find(id);
            db.briefcase.Remove(briefcase);
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
    }
}
