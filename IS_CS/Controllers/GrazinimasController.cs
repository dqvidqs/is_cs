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

        public ActionResult grazinimas_create()
        {
            Grazinima grazinima = new Grazinima();
            return View(grazinima); ;
        }
        [HttpPost]
        public ActionResult grazinimas_create(Grazinima newGrazinimas)
        {
            if (ModelState.IsValid)
            {
                _entities.Grazinimas.Add(newGrazinimas);
                _entities.SaveChanges();
            }
            return RedirectToAction("grazinimo_formos");
        }

        public ActionResult israsas_edit(int israsas)
        {
            Israsa israsa = _entities.Israsas.Find(israsas);
            if (israsa == null)
            {
                return HttpNotFound();
            }
            return View(israsa);
        }
        [HttpPost]
        public ActionResult israsas_edit(Israsa israsa)
        {
            if (ModelState.IsValid)
            {
                _entities.Entry(israsa).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();
                return RedirectToAction("grazinimo_formos");
            }
            return View(israsa);
        }
    }
}