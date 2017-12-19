using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FloraAndFauna.Models;

namespace FloraAndFauna.Controllers
{
    public class PlantasManagerController : Controller
    {
        private PlantaDBContext db = new PlantaDBContext();

        // GET: PlantasManager
        public ActionResult Index()
        {
            return View(db.Plantas.ToList());
        }

        // GET: PlantasManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = db.Plantas.Find(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(planta);
        }

        // GET: PlantasManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlantasManager/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idplanta,NombrePlanta,Especie,Flor,Familia,NombreChileno,NombreIngles,Descripcion")] Planta planta)
        {
            if (ModelState.IsValid)
            {
                db.Plantas.Add(planta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planta);
        }

        // GET: PlantasManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = db.Plantas.Find(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(planta);
        }

        // POST: PlantasManager/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idplanta,NombrePlanta,Especie,Flor,Familia,NombreChileno,NombreIngles,Descripcion")] Planta planta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planta);
        }

        // GET: PlantasManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = db.Plantas.Find(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(planta);
        }

        // POST: PlantasManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planta planta = db.Plantas.Find(id);
            db.Plantas.Remove(planta);
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
