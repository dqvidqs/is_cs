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
            var selectList = new List<SelectListItem>();

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
        public ActionResult preke_Delete(int id)
        {
            Preke preke = db.Prekes.Find(id);
            if (preke == null)
            {
                return HttpNotFound();
            }
            return View(preke);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult preke_Delete(int id, string confirmButton)
        {
            var preke = db.Prekes.Find(id);
            var prek_sar = db.Prekiu_sarasas.Where(i => i.fk_Prekebar_kodas == id);
            var a = prek_sar.Count();
            if (a == 0)
            {
                db.Prekes.Remove(preke);
                db.SaveChanges();
            }
            return RedirectToAction("preke_List");
        }
        [HttpPost]
        public ActionResult preke_List(string pavad, string model,
            decimal bar0, decimal bar1, decimal price0, decimal price1,
            string kt1, string kt2, string kt3)
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
            //PAVADINIMU
            if (pavad != "")
            {
                for (i = 0; i < prekes.Count; i++)
                {
                    if (prekes.ElementAt(i).pavadinimas.ToLower() != pavad.ToLower())
                    {
                        prekes.RemoveAt(i);
                        i--;
                    }
                }
            }
            //MODELIU
            if (model != "")
            {
                for (i = 0; i < prekes.Count; i++)
                {
                    if (prekes.ElementAt(i).modelis.ToLower() != model.ToLower())
                    {
                        prekes.RemoveAt(i);
                        i--;
                    }
                }
            }
            //BAR KODAI
            if (bar0 != 0 && bar1 != 0)
            {
                for (i = 0; i < prekes.Count; i++)
                {
                    var temp = prekes.ElementAt(i).bar_kodas;
                    if (bar0 > temp || temp > bar1)
                    {
                        prekes.RemoveAt(i);
                        i--;
                    }
                }
            }
            //Kaina       
            if (price0 != 0 && price1 != 0)
            {
                for (i = 0; i < prekes.Count; i++)
                {
                    var temp = Convert.ToDecimal(prekes.ElementAt(i).pardavimo_kaina);
                    if (price0 > temp || temp > price1)
                    {
                        prekes.RemoveAt(i);
                        i--;
                    }
                }
            }
            List<Preke> temp_list = new List<Preke>();
            if (kt1 == "true")
            {
                for (i = 0; i < prekes.Count; i++)
                {
                    if (prekes.ElementAt(i).kiekio_tipas == 1)
                    {
                        temp_list.Add(prekes.ElementAt(i));
                    }
                }
            }
            if (kt2 == "true")
            {
                for (i = 0; i < prekes.Count; i++)
                {
                    if (prekes.ElementAt(i).kiekio_tipas == 2)
                    {
                        temp_list.Add(prekes.ElementAt(i));
                    }
                }
            }
            if (kt3 == "true")
            {
                for (i = 0; i < prekes.Count; i++)
                {
                    if (prekes.ElementAt(i).kiekio_tipas == 3 )
                    {
                        temp_list.Add(prekes.ElementAt(i)); 
                    }
                }
            }
            prekes = temp_list;
            return View(prekes);
        }
    }
}