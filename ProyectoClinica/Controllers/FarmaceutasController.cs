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
    public class FarmaceutasController : Controller
    {
        private readonly ProyectoFinalIngenieriaEntities db = new ProyectoFinalIngenieriaEntities();

        // GET: Farmaceutas
        public ActionResult Index()
        {
            var farmaceutas = db.Farmaceutas.Include(f => f.Farmacia);
            return View(farmaceutas.ToList());
        }

        // GET: Farmaceutas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmaceutas farmaceutas = db.Farmaceutas.Find(id);
            if (farmaceutas == null)
            {
                return HttpNotFound();
            }
            return View(farmaceutas);
        }

        // GET: Farmaceutas/Create
        public ActionResult Create()
        {
            ViewBag.idFarmacia = new SelectList(db.Farmacia, "idFarmacia", "nombre");
            return View();
        }

        // POST: Farmaceutas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFarmaceuta,idFarmacia,nombre,apellido,identificacion")] Farmaceutas farmaceutas)
        {
            if (ModelState.IsValid)
            {
                db.Farmaceutas.Add(farmaceutas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFarmacia = new SelectList(db.Farmacia, "idFarmacia", "nombre", farmaceutas.idFarmacia);
            return View(farmaceutas);
        }

        // GET: Farmaceutas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmaceutas farmaceutas = db.Farmaceutas.Find(id);
            if (farmaceutas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFarmacia = new SelectList(db.Farmacia, "idFarmacia", "nombre", farmaceutas.idFarmacia);
            return View(farmaceutas);
        }

        // POST: Farmaceutas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFarmaceuta,idFarmacia,nombre,apellido,identificacion")] Farmaceutas farmaceutas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmaceutas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFarmacia = new SelectList(db.Farmacia, "idFarmacia", "nombre", farmaceutas.idFarmacia);
            return View(farmaceutas);
        }

        // GET: Farmaceutas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmaceutas farmaceutas = db.Farmaceutas.Find(id);
            if (farmaceutas == null)
            {
                return HttpNotFound();
            }
            return View(farmaceutas);
        }

        // POST: Farmaceutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Farmaceutas farmaceutas = db.Farmaceutas.Find(id);
            db.Farmaceutas.Remove(farmaceutas);
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
