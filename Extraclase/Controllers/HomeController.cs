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
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Usuarios user)
        {
            if (ModelState.IsValid)
            {
                List<Usuarios> usuarios = db.Usuarios.ToList();

                //for (int i = 1; i <= usuarios; i++);
                foreach (var usuario in usuarios)
                {
                    if (usuario.Username == user.Username && usuario.Password == user.Password)
                    {
                        Session["data"] = usuario.Admin;
                        //TempData["data"] = usuario.Username;//solo hace una funcion y se desloguea
                        return RedirectToAction("Index", "Temas");
                        //return RedirectToAction("Seleccion", "Temas");
                        //return View(user);
                    }
                }             
            }
            ViewBag.Message = "Incorrect";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}