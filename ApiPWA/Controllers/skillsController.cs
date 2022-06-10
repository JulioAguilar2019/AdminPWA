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
    public class skillsController : Controller
    {
        private Parcial3PWAEntities db = new Parcial3PWAEntities();

        // GET: skills
        public ActionResult Index()
        {
            var skills = db.skills.Include(s => s.users);
            return View(skills.ToList());
        }

        // GET: skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skills skills = db.skills.Find(id);
            if (skills == null)
            {
                return HttpNotFound();
            }
            return View(skills);
        }

        // GET: skills/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name");
            return View();
        }

        // POST: skills/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "skill_id,skill_description,user_id")] skills skills)
        {
            if (ModelState.IsValid)
            {
                db.skills.Add(skills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", skills.user_id);
            return View(skills);
        }

        // GET: skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skills skills = db.skills.Find(id);
            if (skills == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", skills.user_id);
            return View(skills);
        }

        // POST: skills/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "skill_id,skill_description,user_id")] skills skills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.users, "user_id", "user_name", skills.user_id);
            return View(skills);
        }

        // GET: skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            skills skills = db.skills.Find(id);
            if (skills == null)
            {
                return HttpNotFound();
            }
            return View(skills);
        }

        // POST: skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            skills skills = db.skills.Find(id);
            db.skills.Remove(skills);
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
