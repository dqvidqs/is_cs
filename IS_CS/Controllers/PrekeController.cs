using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_CS.Models;
using System.Net;

namespace IS_CS.Controllers
{
    public class PrekeController : Controller
    {
        //-----------------------------------------------
        is_kpEntities1 db = new is_kpEntities1();
        // GET: preke
        public ActionResult preke_List()
        {
            
            int i = 0;
            var prekes = db.Prekes.ToList();
            foreach (var preke in prekes)
            {
                foreach (var tipas in db.Kiekio_tipas)
                {
                    if (preke.kiekio_tipas == tipas.id_Kiekio_tipas)
                    {
                        prekes.ElementAt(i).tipas = tipas.name;
                    }
                }
                i++;
            }
            return View(prekes);
        }
        
        public ActionResult preke_Edit(int id)
        {
            Preke preke = db.Prekes.Find(id);
            if (preke == null)
            {
                return HttpNotFound();
            }
            return View(preke);
        }
        [HttpPost]
        public ActionResult preke_Edit(Preke preke)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preke).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("preke_List");
            }
            return View(preke);
        }
        public ActionResult preke_Detail(int id)
        {
            Preke preke = db.Prekes.Find(id);
            if (preke == null)
            {
                return HttpNotFound();
            }
            return View(preke);
        }
        public ActionResult preke_Create()
        {
            var list = db.Kiekio_tipas.ToList();
            var Tipai = GetTipaiList(list);
            Preke preke = new Preke();
            preke.tipai = Tipai;
            return View(preke); ;
        }
        [HttpPost]
        public ActionResult preke_Create(Preke newPreke)
        {
            if (ModelState.IsValid)
            {
                db.Prekes.Add(newPreke);
                db.SaveChanges();
            }
            return RedirectToAction("preke_List");
        }

        private IEnumerable<SelectListItem> GetTipaiList(List<Kiekio_tipas> list)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in list)
            {
                selectList.Add(new SelectListItem
                {
                    Value = Convert.ToString(element.id_Kiekio_tipas),
                    Text = element.name
                });
            }

            return selectList;
        }

    }
}