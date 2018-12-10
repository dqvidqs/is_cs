using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_CS.Models;

namespace IS_CS.Controllers
{
    public class GrazinimasController : Controller
    {
        private is_kpEntities1 _entities = new is_kpEntities1();

        public ActionResult prekiu_grazinimas()
        {
            return View(_entities.Uzsakymas.ToList());
        }

        public ActionResult grazinimo_formos()
        {
            return View(_entities.Uzsakymas.ToList());
        }

        public ActionResult israsas()
        {
            return View(_entities.Uzsakymas.ToList());
        }

        public ActionResult grazinimo_patvirtinimas()
        {
            return View(_entities.Patvirtinimas.ToList());
        }

        public ActionResult Grazinimas_Create()
        {
            Grazinima grazinima = new Grazinima();
            return View(grazinima); ;
        }
        [HttpPost]
        public ActionResult Grazinimas_Create(Grazinima newGrazinimas)
        {
            if (ModelState.IsValid)
            {
                _entities.Grazinimas.Add(newGrazinimas);
                _entities.SaveChanges();
            }
            return RedirectToAction("prekiu_grazinimas");
        }
    }
}