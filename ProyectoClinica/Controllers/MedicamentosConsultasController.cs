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
    public class MedicamentosConsultasController : Controller
    {
        private readonly ProyectoFinalIngenieriaEntities db = new ProyectoFinalIngenieriaEntities();

        // GET: MedicamentosConsultas
        public ActionResult Index()
        {
            var medicamentosConsultas = db.MedicamentosConsultas.Include(m => m.Medicamentos).Include(m => m.Ordenes);
            return View(medicamentosConsultas.ToList());
        }

        // GET: MedicamentosConsultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentosConsultas medicamentosConsultas = db.MedicamentosConsultas.Find(id);
            if (medicamentosConsultas == null)
            {
                return HttpNotFound();
            }
            return View(medicamentosConsultas);
        }

        // GET: MedicamentosConsultas/Create
        public ActionResult Create()
        {
            ViewBag.idMedicamento = new SelectList(db.Medicamentos, "idMedicamento", "nombre");
            ViewBag.idConsulta = new SelectList(db.Ordenes, "idConsulta", "valoracion");
            return View();
        }

        // POST: MedicamentosConsultas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMConsulta,idMedicamento,idConsulta")] MedicamentosConsultas medicamentosConsultas)
        {
            if (ModelState.IsValid)
            {
                db.MedicamentosConsultas.Add(medicamentosConsultas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMedicamento = new SelectList(db.Medicamentos, "idMedicamento", "nombre", medicamentosConsultas.idMedicamento);
            ViewBag.idConsulta = new SelectList(db.Ordenes, "idConsulta", "valoracion", medicamentosConsultas.idConsulta);
            return View(medicamentosConsultas);
        }

        // GET: MedicamentosConsultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentosConsultas medicamentosConsultas = db.MedicamentosConsultas.Find(id);
            if (medicamentosConsultas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMedicamento = new SelectList(db.Medicamentos, "idMedicamento", "nombre", medicamentosConsultas.idMedicamento);
            ViewBag.idConsulta = new SelectList(db.Ordenes, "idConsulta", "valoracion", medicamentosConsultas.idConsulta);
            return View(medicamentosConsultas);
        }

        // POST: MedicamentosConsultas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMConsulta,idMedicamento,idConsulta")] MedicamentosConsultas medicamentosConsultas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamentosConsultas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMedicamento = new SelectList(db.Medicamentos, "idMedicamento", "nombre", medicamentosConsultas.idMedicamento);
            ViewBag.idConsulta = new SelectList(db.Ordenes, "idConsulta", "valoracion", medicamentosConsultas.idConsulta);
            return View(medicamentosConsultas);
        }

        // GET: MedicamentosConsultas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentosConsultas medicamentosConsultas = db.MedicamentosConsultas.Find(id);
            if (medicamentosConsultas == null)
            {
                return HttpNotFound();
            }
            return View(medicamentosConsultas);
        }

        // POST: MedicamentosConsultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicamentosConsultas medicamentosConsultas = db.MedicamentosConsultas.Find(id);
            db.MedicamentosConsultas.Remove(medicamentosConsultas);
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
