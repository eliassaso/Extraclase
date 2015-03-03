using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Extraclase.Models;

namespace Extraclase.Controllers
{
    public class UsuariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            if (validar_usuario() == true)
            {
                //Session.Remove("data"); 
                return View(db.Usuarios.ToList());
            }
            else
            {
                return RedirectToAction("Denegado_permiso");
            }
        }

        public ActionResult Denegado_permiso()
        {
            ViewBag.Message = "does not have permissions!!";
            return View();
        }


        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (validar_usuario() == true)
            { 
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuarios usuarios = db.Usuarios.Find(id);
                if (usuarios == null)
                {
                    return HttpNotFound();
                }
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("Denegado_permiso");
            }
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            if (validar_usuario() == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Denegado_permiso");
            }
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,Password,Admin")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (validar_usuario() == true)
            { 
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuarios usuarios = db.Usuarios.Find(id);
                if (usuarios == null)
                {
                    return HttpNotFound();
                }
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("Denegado_permiso");
            }
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,Password,Admin")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (validar_usuario() == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuarios usuarios = db.Usuarios.Find(id);
                if (usuarios == null)
                {
                    return HttpNotFound();
                }
                return View(usuarios);
            }
            else
            {
                return RedirectToAction("Denegado_permiso");
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuarios);
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

        public bool validar_usuario()
        {
            var usuario = Session["data"] as string;
            //var usuario = TempData["data"] as string;
            if (usuario == "s")
            {
                //Session.Remove("data"); 
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
