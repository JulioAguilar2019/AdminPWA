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
    public class usersController : Controller
    {
        private Parcial3PWAEntities db = new Parcial3PWAEntities();

        // GET: users
        public ActionResult Index()
        {
            try
            {
                return View(db.users.ToList());
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                users users = db.users.Find(id);
                if (users == null)
                {
                    return HttpNotFound();
                }
                return View(users);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: users/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: users/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,user_name,user_photo,first_name,last_name,email,social_net,introduction,grade,profession,university,grade_obj")] users users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.users.Add(users);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(users);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                users users = db.users.Find(id);
                if (users == null)
                {
                    return HttpNotFound();
                }
                return View(users);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,user_name,user_photo,first_name,last_name,email,social_net,introduction,grade,profession,university,grade_obj")] users users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(users).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(users);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                users users = db.users.Find(id);
                if (users == null)
                {
                    return HttpNotFound();
                }
                return View(users);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                users users = db.users.Find(id);
                db.users.Remove(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
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
