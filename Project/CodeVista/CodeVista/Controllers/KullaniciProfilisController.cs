using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeVista.Models;

namespace CodeVista.Controllers
{
    public class KullaniciProfilisController : Controller
    {
        private CodeVistaEntities db = new CodeVistaEntities();

        // GET: KullaniciProfilis
        public async Task<ActionResult> Index()
        {
            var kullaniciProfili = db.KullaniciProfili.Include(k => k.Kullanicilar).Include(k => k.Resimler);
            return View(await kullaniciProfili.ToListAsync());
        }

        // GET: KullaniciProfilis/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciProfili kullaniciProfili = await db.KullaniciProfili.FindAsync(id);
            if (kullaniciProfili == null)
            {
                return HttpNotFound();
            }
            return View(kullaniciProfili);
        }

        // GET: KullaniciProfilis/Create
        public ActionResult Create()
        {
            ViewBag.KullaniciİD = new SelectList(db.Kullanicilar, "KullaniciİD", "KullaniciAdi");
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol");
            return View();
        }

        // POST: KullaniciProfilis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "KullaniciİD,KullaniciAdi,Email,TercihEdilenDil,ProfilResmiURL,Cinsiyet,DogumTarihi,Ulke,Sehir,İlgiAlanlari,KullaniciRolu,KayitTarihi,SonGirisTarihi,ProfilTamamlamaDurumu,SosyelMedyaHesaplari,İletisimBilgileri,OdemeBilgileri,SeviyeİD,ResimID")] KullaniciProfili kullaniciProfili)
        {
            if (ModelState.IsValid)
            {
                db.KullaniciProfili.Add(kullaniciProfili);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.KullaniciİD = new SelectList(db.Kullanicilar, "KullaniciİD", "KullaniciAdi", kullaniciProfili.KullaniciİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", kullaniciProfili.ResimID);
            return View(kullaniciProfili);
        }

        // GET: KullaniciProfilis/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciProfili kullaniciProfili = await db.KullaniciProfili.FindAsync(id);
            if (kullaniciProfili == null)
            {
                return HttpNotFound();
            }
            ViewBag.KullaniciİD = new SelectList(db.Kullanicilar, "KullaniciİD", "KullaniciAdi", kullaniciProfili.KullaniciİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", kullaniciProfili.ResimID);
            return View(kullaniciProfili);
        }

        // POST: KullaniciProfilis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "KullaniciİD,KullaniciAdi,Email,TercihEdilenDil,ProfilResmiURL,Cinsiyet,DogumTarihi,Ulke,Sehir,İlgiAlanlari,KullaniciRolu,KayitTarihi,SonGirisTarihi,ProfilTamamlamaDurumu,SosyelMedyaHesaplari,İletisimBilgileri,OdemeBilgileri,SeviyeİD,ResimID")] KullaniciProfili kullaniciProfili)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullaniciProfili).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.KullaniciİD = new SelectList(db.Kullanicilar, "KullaniciİD", "KullaniciAdi", kullaniciProfili.KullaniciİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", kullaniciProfili.ResimID);
            return View(kullaniciProfili);
        }

        // GET: KullaniciProfilis/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KullaniciProfili kullaniciProfili = await db.KullaniciProfili.FindAsync(id);
            if (kullaniciProfili == null)
            {
                return HttpNotFound();
            }
            return View(kullaniciProfili);
        }

        // POST: KullaniciProfilis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            KullaniciProfili kullaniciProfili = await db.KullaniciProfili.FindAsync(id);
            db.KullaniciProfili.Remove(kullaniciProfili);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
