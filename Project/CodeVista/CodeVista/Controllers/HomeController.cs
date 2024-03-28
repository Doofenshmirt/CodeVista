using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeVista.Models;

namespace CodeVista.Controllers
{
    public class HomeController : Controller
    {
        private CodeVistaEntities db = new CodeVistaEntities();

        // GET: Home/Index
        public ActionResult Index()
        {
            var sektorlerListesi = db.Sektorler.ToList();
            return View(sektorlerListesi);
        }
        public ActionResult DillerPartialView()
        {  // Burada gerekli model verisini alınıyor
            var dillerListesi = db.Diller.ToList();
            return PartialView(dillerListesi);
        }
        public ActionResult KaynaklarPartialView()
        {  // Burada gerekli model verisini alınıyor
            var kaynaklarListesi = db.Kaynaklar.ToList();
            return PartialView(kaynaklarListesi);
        }
    }
}