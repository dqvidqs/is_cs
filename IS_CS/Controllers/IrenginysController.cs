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
        private is_kpEntities1 _entities = new is_kpEntities1();
        // GET: Irenginys
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult preke_List()
        {
            return View(_entities.Prekes.ToList());
        }

    }
}