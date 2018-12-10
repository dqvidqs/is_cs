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
            return View(_entities.Grazinimo_priezastis.ToList());
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
    }
}