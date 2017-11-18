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
    public class FarmaciasController : Controller
    {
        private readonly ProyectoFinalIngenieriaEntities db = new ProyectoFinalIngenieriaEntities();

        // GET: Farmacias
        public ActionResult Index()
        {
            return View(db.Farmacia.ToList());
        }

        // GET: Farmacias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmacia farmacia = db.Farmacia.Find(id);
            if (farmacia == null)
            {
                return HttpNotFound();
            }
            return View(farmacia);
        }

        // GET: Farmacias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Farmacias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFarmacia,nombre,telefono,direccion")] Farmacia farmacia)
        {
            if (ModelState.IsValid)
            {
                db.Farmacia.Add(farmacia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(farmacia);
        }

        // GET: Farmacias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmacia farmacia = db.Farmacia.Find(id);
            if (farmacia == null)
            {
                return HttpNotFound();
            }
            return View(farmacia);
        }

        // POST: Farmacias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFarmacia,nombre,telefono,direccion")] Farmacia farmacia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmacia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(farmacia);
        }

        // GET: Farmacias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmacia farmacia = db.Farmacia.Find(id);
            if (farmacia == null)
            {
                return HttpNotFound();
            }
            return View(farmacia);
        }

        // POST: Farmacias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Farmacia farmacia = db.Farmacia.Find(id);
            db.Farmacia.Remove(farmacia);
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
