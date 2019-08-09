using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoInventario.Models;

namespace ProyectoInventario.Controllers
{
    public class transaccionController : Controller
    {
        private InventarioContext db = new InventarioContext();

        // GET: transaccion
        public ActionResult Index()
        {
            var transacciones = db.Transacciones.Include(t => t.Articulo);
            return View(transacciones.ToList());
        }

        // GET: transaccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transacciones.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: transaccion/Create
        public ActionResult Create()
        {
            ViewBag.id_articulo = new SelectList(db.Articulos, "id_articulo", "descripcion_articulo");
            return View();
        }

        // POST: transaccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_transaccion,tipo_transaccion,id_articulo,cantidad,monto")] Transaccion transaccion)
        {
          
            transaccion.fecha = DateTime.Now; 
            if (ModelState.IsValid)
            {
                db.Transacciones.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_articulo = new SelectList(db.Articulos, "id_articulo", "descripcion_articulo", transaccion.id_articulo);
            return View(transaccion);
        }

        // GET: transaccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transacciones.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_articulo = new SelectList(db.Articulos, "id_articulo", "descripcion_articulo", transaccion.id_articulo);
            return View(transaccion);
        }

        // POST: transaccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_transaccion,tipo_transaccion,id_articulo,fecha,cantidad,monto")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_articulo = new SelectList(db.Articulos, "id_articulo", "descripcion_articulo", transaccion.id_articulo);
            return View(transaccion);
        }

        // GET: transaccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transacciones.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: transaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaccion transaccion = db.Transacciones.Find(id);
            db.Transacciones.Remove(transaccion);
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
