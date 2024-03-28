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
    public class KullanicilarsController : Controller
    {
        private CodeVistaEntities db = new CodeVistaEntities();

        // GET: Kullanicilars
        public async Task<ActionResult> Index()
        {
            var kullanicilar = db.Kullanicilar.Include(k => k.KullaniciSeviyeleri);
            return View(await kullanicilar.ToListAsync());
        }

        // GET: Kullanicilars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanicilar kullanicilar = await db.Kullanicilar.FindAsync(id);
            if (kullanicilar == null)
            {
                return HttpNotFound();
            }
            return View(kullanicilar);
        }

        // GET: Kullanicilars/Create
        public ActionResult Create()
        {
            ViewBag.SeviyeİD = new SelectList(db.KullaniciSeviyeleri, "SeviyeİD", "SeviyeAdi");
            return View();
        }

        // POST: Kullanicilars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "KullaniciİD,KullaniciAdi,HashlenmisSifre,SeviyeİD,Ad,Soyad,Email,KullaniciRolu")] Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                db.Kullanicilar.Add(kullanicilar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SeviyeİD = new SelectList(db.KullaniciSeviyeleri, "SeviyeİD", "SeviyeAdi", kullanicilar.SeviyeİD);
            return View(kullanicilar);
        }

        // GET: Kullanicilars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanicilar kullanicilar = await db.Kullanicilar.FindAsync(id);
            if (kullanicilar == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeviyeİD = new SelectList(db.KullaniciSeviyeleri, "SeviyeİD", "SeviyeAdi", kullanicilar.SeviyeİD);
            return View(kullanicilar);
        }

        // POST: Kullanicilars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "KullaniciİD,KullaniciAdi,HashlenmisSifre,SeviyeİD,Ad,Soyad,Email,KullaniciRolu")] Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanicilar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SeviyeİD = new SelectList(db.KullaniciSeviyeleri, "SeviyeİD", "SeviyeAdi", kullanicilar.SeviyeİD);
            return View(kullanicilar);
        }

        // GET: Kullanicilars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanicilar kullanicilar = await db.Kullanicilar.FindAsync(id);
            if (kullanicilar == null)
            {
                return HttpNotFound();
            }
            return View(kullanicilar);
        }

        // POST: Kullanicilars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kullanicilar kullanicilar = await db.Kullanicilar.FindAsync(id);
            db.Kullanicilar.Remove(kullanicilar);
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
