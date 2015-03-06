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
    public class TemasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Temas
        [HttpGet]
        [Route("temas/{name:alpha}")]
        public ActionResult Index()   
        {
            /*var usuario = Session["data"] as string;
            //var usuario = TempData["data"] as string;
            if (usuario == "x")*/

            if(validar_usuario() == true)
            {
                //Session.Remove("data"); 
                return View(db.Temas.ToList());              
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

        [HttpGet]
        public ActionResult Seleccion()
        {
            var usuario = Session["data"] as string;

            if (usuario != null)
            { 
                // @Html.DropDownList("Exemplo",new SelectList(listItems,"Value","Text"))
                //List<Usuario> gabrieles = contexto.Usuarios.Where(u => u.nombre == "Gabriel");
                //var grados = db.Temas.Select(u => u.Grado);
                var grados = new List<string>{"1","2","3","4","5","6"};

                //var materia = db.Temas.Select(u => u.Materia);
                //var materia = db.Temas.ToList();
                //ViewBag.list = materia; //db.Temas.ToList();
                ViewBag.grados = grados;
                return View(db.Temas.ToList());
            }
            else
            {
                return RedirectToAction("Denegado_permiso");
            }
        }

        [HttpPost]
        public ActionResult Seleccion(string grado)
        {
            grado = Request["Grado"];
            if (grado != null)
            {

            }
            ViewBag.Message = "Incorrect";
            return View();
        }

        /*[HttpPost]
        public ActionResult Seleccion(Models.Temas tema)
        {
            if (ModelState.IsValid)
            {
                
            }
            ViewBag.Message = "Incorrect";
            return View();
        }*/

        // GET: Temas/Details/5
        public ActionResult Details(int? id)
        {
            if (validar_usuario() == true)
            { 
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Temas temas = db.Temas.Find(id);
                if (temas == null)
                {
                    return HttpNotFound();
                }
                return View(temas);
            }
            else
            {
                return RedirectToAction("Denegado_permiso");
            }
        }

        // GET: Temas/Create
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

        // POST: Temas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Materia,Grado,Tema")] Temas temas)
        {
            if (ModelState.IsValid)
            {
                db.Temas.Add(temas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(temas);
        }

        // GET: Temas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (validar_usuario() == true)
            {     
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Temas temas = db.Temas.Find(id);
                if (temas == null)
                {
                    return HttpNotFound();
                }
                return View(temas);
            }
            else
            {
                return RedirectToAction("Denegado_permiso");
            }
        }

        // POST: Temas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Materia,Grado,Tema")] Temas temas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(temas);
        }

        // GET: Temas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (validar_usuario() == true)
            { 
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Temas temas = db.Temas.Find(id);
                if (temas == null)
                {
                    return HttpNotFound();
                }
                return View(temas);
            }
            else
            {
                return RedirectToAction("Denegado_permiso");
            }
        }

        // POST: Temas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Temas temas = db.Temas.Find(id);
            db.Temas.Remove(temas);
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
