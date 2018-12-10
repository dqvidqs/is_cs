using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_CS.Models;

namespace IS_CS.Controllers
{
    public class IrenginysController : Controller
    {
        private is_kpEntities1 db = new is_kpEntities1();
        // GET: Irenginys
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult irenginys_list()
        {

            int i = 0;
            var irenginiai = db.Remontuojamas_irenginys.ToList();

            foreach (var irenginys in irenginiai)
            {
                foreach (var busena in db.Irenginio_busena)
                {
                    if (irenginys.busena == busena.id_Irenginio_busena)
                      
                    {
                        irenginiai.ElementAt(i).busenaString = busena.name;
                    }
                }
                i++;
            }

            return View(irenginiai);         
        }

        public ActionResult irenginys_Edit(int id) {
         
                Remontuojamas_irenginys irenginys = db.Remontuojamas_irenginys.Find(id);
                if (irenginys == null)
                {
                    return HttpNotFound();
                }
                return View(irenginys);
           
        }

        [HttpPost]
        public ActionResult irenginys_Edit(Remontuojamas_irenginys irenginys)
        {
            if (ModelState.IsValid)
            {
                db.Entry(irenginys).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("irenginys_list");
            }
            return View(irenginys);
        }


    }
}