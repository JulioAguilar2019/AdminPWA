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
    public class workExperienceController : Controller
    {
        private Parcial3PWAEntities db = new Parcial3PWAEntities();

        // GET: workExperience
        public ActionResult Index()
        {
            var work_experience = db.work_experience.Include(w => w.users);
            return View(work_experience.ToList());
        }

        // GET: workExperience/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            work_experience work_experience = db.work_experience.Find(id);
            if (work_experience == null)
            {
                return HttpNotFound();
            }
            return View(work_experience);
        }

        // GET: workExperience/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name");
            return View();
        }

        // POST: workExperience/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "work_exp_id,work_exp_description,date_init,date_fin,user_id")] work_experience work_experience)
        {
            if (ModelState.IsValid)
            {
                db.work_experience.Add(work_experience);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", work_experience.user_id);
            return View(work_experience);
        }

        // GET: workExperience/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            work_experience work_experience = db.work_experience.Find(id);
            if (work_experience == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", work_experience.user_id);
            return View(work_experience);
        }

        // POST: workExperience/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "work_exp_id,work_exp_description,date_init,date_fin,user_id")] work_experience work_experience)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_experience).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", work_experience.user_id);
            return View(work_experience);
        }

        // GET: workExperience/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            work_experience work_experience = db.work_experience.Find(id);
            if (work_experience == null)
            {
                return HttpNotFound();
            }
            return View(work_experience);
        }

        // POST: workExperience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            work_experience work_experience = db.work_experience.Find(id);
            db.work_experience.Remove(work_experience);
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
