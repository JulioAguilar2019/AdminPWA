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
    public class certificationsController : Controller
    {
        private Parcial3PWAEntities db = new Parcial3PWAEntities();

        // GET: certifications
        public ActionResult Index()
        {
            var certifications = db.certifications.Include(c => c.users);
            return View(certifications.ToList());
        }

        // GET: certifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            certifications certifications = db.certifications.Find(id);
            if (certifications == null)
            {
                return HttpNotFound();
            }
            return View(certifications);
        }

        // GET: certifications/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name");
            return View();
        }

        // POST: certifications/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cert_id,cert_name,cert_institution,cert_description,cert_link,user_id")] certifications certifications)
        {
            if (ModelState.IsValid)
            {
                db.certifications.Add(certifications);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", certifications.user_id);
            return View(certifications);
        }

        // GET: certifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            certifications certifications = db.certifications.Find(id);
            if (certifications == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", certifications.user_id);
            return View(certifications);
        }

        // POST: certifications/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cert_id,cert_name,cert_institution,cert_description,cert_link,user_id")] certifications certifications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certifications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", certifications.user_id);
            return View(certifications);
        }

        // GET: certifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            certifications certifications = db.certifications.Find(id);
            if (certifications == null)
            {
                return HttpNotFound();
            }
            return View(certifications);
        }

        // POST: certifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            certifications certifications = db.certifications.Find(id);
            db.certifications.Remove(certifications);
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
