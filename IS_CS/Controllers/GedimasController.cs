using IS_CS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_CS.Controllers
{
    public class GedimasController : Controller
    {
        private is_kpEntities1 db = new is_kpEntities1();
        // GET: Gedimas
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult gedimas_Create()
        {
            Gedima gedimas = new Gedima();


            var list = db.Gedimo_busena.ToList();
            var busenos = GetBusenosList(list);
            gedimas.busenos = busenos;

            return View(gedimas);
        }

        [HttpPost]
        public ActionResult gedimas_Create(Gedima gedimas)
        {
            Random rnd = new Random();
            int id = rnd.Next(15, 999999999);
            gedimas.id_Gedimas = id;
            if (ModelState.IsValid)
            {
                db.Gedimas.Add(gedimas);
                db.SaveChanges();
            }
            return RedirectToAction("gedimas_List");
        }


        public ActionResult gedimas_List()
        {

            int i = 0;
            var gedimai = db.Gedimas.ToList();
            Gedima g = new Gedima();
            foreach (var gedimas in gedimai)
            {
                foreach (var busena in db.Gedimo_busena)
                {
                    if (gedimas.busena == busena.id_Gedimo_busena)

                    {
                        gedimai.ElementAt(i).busenaString = busena.name;
                    }
                }
                i++;
            }

            return View(gedimai);


        }

        public ActionResult gedimas_Edit(int id)
        {

            Gedima gedimas = db.Gedimas.Find(id);
            if (gedimas == null)
            {
                return HttpNotFound();
            }

            var list = db.Gedimo_busena.ToList();
            var busenos = GetBusenosList(list);
            gedimas.busenos = busenos;

            return View(gedimas);

        }


        private IEnumerable<SelectListItem> GetBusenosList(List<Gedimo_busena> list)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in list)
            {
                selectList.Add(new SelectListItem
                {
                    Value = Convert.ToString(element.id_Gedimo_busena),
                    Text = element.name
                });
            }

            return selectList;
        }

    }
}