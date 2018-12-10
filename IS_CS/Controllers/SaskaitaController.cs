using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_CS.Models;
using System.Net;

namespace IS_CS.Controllers
{
    public class SaskaitaController : Controller
    {
        private is_kpEntities1 db = new is_kpEntities1();
        // GET: Saskaita
        public ActionResult Saskaita_List()
        {
            var saskaitas = db.Saskaitas.ToList();
            return View(saskaitas);
        }
        public ActionResult Saskaita_Detail(int id)
        {
            var saskaita = db.Saskaitas.Find(id);
            var perk_sar_list = db.Prekiu_sarasas.ToList();
            var prek_list = db.Prekes.ToList();
            foreach(var a in perk_sar_list)
            {
                if(saskaita.serija == a.fk_Saskaitaserija)
                {
                    saskaita.prek_sar_list.Add(a);
                } 
            }
            foreach (var a in perk_sar_list)
            {
                foreach (var b in prek_list)
                {
                    if (a.fk_Prekebar_kodas == b.bar_kodas)
                        saskaita.prek_list.Add(b);
                }
            }
            return View(saskaita);
        }
    }
}