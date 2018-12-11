using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_CS.Models;
using System.Net;

namespace IS_CS.Controllers
{
    public class PirktiController : Controller
    {
        // GET: Pirkti
        private is_kpEntities1 db = new is_kpEntities1();

        public ActionResult apmokejimo_budai()
        {
            return View(db.Mokejimo_budas.ToList());
        }
        public ActionResult krepselio_perziura()
        {
            return View(db.Mokejimo_budas.ToList());
        }
        public ActionResult pristatymo_budai()
        {
            return View(db.Pristatymo_budai.ToList());
        }
        public ActionResult pirkimo_uzsakymas()
        {
            var list = db.Mokejimo_budas.ToList();
            var list1 = db.Pristatymo_budai.ToList();
            var Mokejimai = GetMokejimaiList(list);
            var Pristatymai = GetPristatymaiList(list1);
            Uzsakyma uzsakymas = new Uzsakyma();
            uzsakymas.mokejimai = Mokejimai;
            uzsakymas.pristatymai = Pristatymai;
            return View(uzsakymas); ;
        }
        [HttpPost]
        public ActionResult pirkimo_uzsakyma(Uzsakyma newUzsakymas)
        {
            if (ModelState.IsValid)
            {
                db.Uzsakymas.Add(newUzsakymas);
                db.SaveChanges();
            }
            return RedirectToAction("krepselio_perziura");
        }
        private IEnumerable<SelectListItem> GetMokejimaiList(List<Mokejimo_budas> list)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            foreach (var element in list)
            {
                selectList.Add(new SelectListItem
                {
                    Value = Convert.ToString(element.id_Mokejimo_budas),
                    Text = element.name
                });
            }

            return selectList;
        }
        private IEnumerable<SelectListItem> GetPristatymaiList(List<Pristatymo_budai> list)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            foreach (var element in list)
            {
                selectList.Add(new SelectListItem
                {
                    Value = Convert.ToString(element.pristatymo_id),
                    Text = element.pavadinimas
                });
            }

            return selectList;
        }
    }
}