﻿using System;
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
    public class CitasController : Controller
    {
        private ProyectoFinalIngenieriaEntities db = new ProyectoFinalIngenieriaEntities();

        // GET: Citas
        public ActionResult Index()
        {
            var citas = db.Citas.Include(c => c.Ordenes).Include(c => c.Enfermedades).Include(c => c.Medicos).Include(c => c.Pacientes);
            return View(citas.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.idCita = new SelectList(db.Ordenes, "idConsulta", "valoracion");
            ViewBag.idEnfermedad = new SelectList(db.Enfermedades, "idEnfermedad", "nombre");
            ViewBag.idMedico = new SelectList(db.Medicos, "idMedico", "nombre");
            ViewBag.idPaciente = new SelectList(db.Pacientes, "idPacientes", "nombre");
            return View();
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCita,idMedico,idPaciente,idEnfermedad")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Citas.Add(citas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCita = new SelectList(db.Ordenes, "idConsulta", "valoracion", citas.idCita);
            ViewBag.idEnfermedad = new SelectList(db.Enfermedades, "idEnfermedad", "nombre", citas.idEnfermedad);
            ViewBag.idMedico = new SelectList(db.Medicos, "idMedico", "nombre", citas.idMedico);
            ViewBag.idPaciente = new SelectList(db.Pacientes, "idPacientes", "nombre", citas.idPaciente);
            return View(citas);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCita = new SelectList(db.Ordenes, "idConsulta", "valoracion", citas.idCita);
            ViewBag.idEnfermedad = new SelectList(db.Enfermedades, "idEnfermedad", "nombre", citas.idEnfermedad);
            ViewBag.idMedico = new SelectList(db.Medicos, "idMedico", "nombre", citas.idMedico);
            ViewBag.idPaciente = new SelectList(db.Pacientes, "idPacientes", "nombre", citas.idPaciente);
            return View(citas);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCita,idMedico,idPaciente,idEnfermedad")] Citas citas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCita = new SelectList(db.Ordenes, "idConsulta", "valoracion", citas.idCita);
            ViewBag.idEnfermedad = new SelectList(db.Enfermedades, "idEnfermedad", "nombre", citas.idEnfermedad);
            ViewBag.idMedico = new SelectList(db.Medicos, "idMedico", "nombre", citas.idMedico);
            ViewBag.idPaciente = new SelectList(db.Pacientes, "idPacientes", "nombre", citas.idPaciente);
            return View(citas);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citas citas = db.Citas.Find(id);
            if (citas == null)
            {
                return HttpNotFound();
            }
            return View(citas);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Citas citas = db.Citas.Find(id);
            db.Citas.Remove(citas);
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
