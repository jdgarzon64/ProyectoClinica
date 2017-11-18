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
    public class MedicamentosController : Controller
    {
        private readonly ProyectoFinalIngenieriaEntities db = new ProyectoFinalIngenieriaEntities();

        // GET: Medicamentos
        public ActionResult Index()
        {
            var medicamentos = db.Medicamentos.Include(m => m.Farmacia);
            return View(medicamentos.ToList());
        }

        // GET: Medicamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamentos medicamentos = db.Medicamentos.Find(id);
            if (medicamentos == null)
            {
                return HttpNotFound();
            }
            return View(medicamentos);
        }

        // GET: Medicamentos/Create
        public ActionResult Create()
        {
            ViewBag.idFarmacia = new SelectList(db.Farmacia, "idFarmacia", "nombre");
            return View();
        }

        // POST: Medicamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMedicamento,idInventario,nombre,descripcion,dosis,idFarmacia")] Medicamentos medicamentos)
        {
            if (ModelState.IsValid)
            {
                db.Medicamentos.Add(medicamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFarmacia = new SelectList(db.Farmacia, "idFarmacia", "nombre", medicamentos.idFarmacia);
            return View(medicamentos);
        }

        // GET: Medicamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamentos medicamentos = db.Medicamentos.Find(id);
            if (medicamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFarmacia = new SelectList(db.Farmacia, "idFarmacia", "nombre", medicamentos.idFarmacia);
            return View(medicamentos);
        }

        // POST: Medicamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMedicamento,idInventario,nombre,descripcion,dosis,idFarmacia")] Medicamentos medicamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFarmacia = new SelectList(db.Farmacia, "idFarmacia", "nombre", medicamentos.idFarmacia);
            return View(medicamentos);
        }

        // GET: Medicamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamentos medicamentos = db.Medicamentos.Find(id);
            if (medicamentos == null)
            {
                return HttpNotFound();
            }
            return View(medicamentos);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicamentos medicamentos = db.Medicamentos.Find(id);
            db.Medicamentos.Remove(medicamentos);
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
