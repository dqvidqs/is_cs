using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_CS.Models;

namespace IS_CS.Controllers
{
    public class PrekeController : Controller
    {
        //-----------------------------------------------
        private is_kpEntities1 _entities = new is_kpEntities1();
        // GET: preke
        public ActionResult preke_List()
        {
            return View(_entities.Prekes.ToList());
        }
        
        public ActionResult preke_Edit(int id)
        {
            Preke preke = _entities.Prekes.Find(id);
            if (preke == null)
            {
                return HttpNotFound();
            }
            return View(preke);
        }
        public ActionResult preke_Detail(int id)
        {
            Preke preke = _entities.Prekes.Find(id);
            if (preke == null)
            {
                return HttpNotFound();
            }
            return View(preke);
        }
        public ActionResult preke_Create()
        {
            return View();
        }
    }
}