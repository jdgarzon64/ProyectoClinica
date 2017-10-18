using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoClinica;

namespace ProyectoClinica.Controllers
{
    public class EnfermedadesController : Controller
    {
        private ProyectoFinalIngenieriaEntities db = new ProyectoFinalIngenieriaEntities();

        // GET: Enfermedades
        public ActionResult Index()
        {
            return View(db.Enfermedades.ToList());
        }

        // GET: Enfermedades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enfermedades enfermedades = db.Enfermedades.Find(id);
            if (enfermedades == null)
            {
                return HttpNotFound();
            }
            return View(enfermedades);
        }

        // GET: Enfermedades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enfermedades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEnfermedad,nombre,descripcion")] Enfermedades enfermedades)
        {
            if (ModelState.IsValid)
            {
                db.Enfermedades.Add(enfermedades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enfermedades);
        }

        // GET: Enfermedades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enfermedades enfermedades = db.Enfermedades.Find(id);
            if (enfermedades == null)
            {
                return HttpNotFound();
            }
            return View(enfermedades);
        }

        // POST: Enfermedades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEnfermedad,nombre,descripcion")] Enfermedades enfermedades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enfermedades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enfermedades);
        }

        // GET: Enfermedades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enfermedades enfermedades = db.Enfermedades.Find(id);
            if (enfermedades == null)
            {
                return HttpNotFound();
            }
            return View(enfermedades);
        }

        // POST: Enfermedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enfermedades enfermedades = db.Enfermedades.Find(id);
            db.Enfermedades.Remove(enfermedades);
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
