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
    public class KaynaklarsController : Controller
    {
        private CodeVistaEntities db = new CodeVistaEntities();

        // GET: Kaynaklars
        /*public async Task<ActionResult> Index()
        {
            var kaynaklar = db.Kaynaklar.Include(k => k.KullaniciSeviyeleri).Include(k => k.Kurslar).Include(k => k.Resimler);
            return View(await kaynaklar.ToListAsync());
        }*/
        /* public async Task<ActionResult> IncrementCounter(int id)
       {
            // Kaynağın ID'sine göre veritabanından kaynağı bulun
            var kaynak = await db.Kaynaklar.FindAsync(id);
            if (kaynak == null)
            {
                return HttpNotFound();
            }

            // Ziyaret sayısını artırın
            kaynak.Sayac++;

            // Değişiklikleri veritabanına kaydet
            await db.SaveChangesAsync();

            // Yönlendirme yapın veya isteği işleyen başka bir şey ayarla
            return RedirectToAction("Index");
        }*/
        // GET: Kaynaklars
        public async Task<ActionResult> Index()
        {
            var kaynaklar = await db.Kaynaklar.ToListAsync();
            return View(kaynaklar);
        }

        // Action for incrementing visit count
        [HttpPost]
        public async Task<ActionResult> IncrementVisitCount(int id)
        {
            var kaynak = await db.Kaynaklar.FindAsync(id);
            if (kaynak != null)
            {
                kaynak.ZiyaretSayisi++;
                await db.SaveChangesAsync();
                return Json(new { success = true, ziyaretSayisi = kaynak.ZiyaretSayisi });
            }
            return Json(new { success = false });
        }
        // GET: Kaynaklars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaynaklar kaynaklar = await db.Kaynaklar.FindAsync(id);
            if (kaynaklar == null)
            {
                return HttpNotFound();
            }
            return View(kaynaklar);
        }

        // GET: Kaynaklars/Create
        public ActionResult Create()
        {
            ViewBag.SeviyeİD = new SelectList(db.KullaniciSeviyeleri, "SeviyeİD", "SeviyeAdi");
            ViewBag.KursİD = new SelectList(db.Kurslar, "KursİD", "KursAdi");
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol");
            return View();
        }

        // POST: Kaynaklars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "KaynakİD,KaynakAdi,KaynakTipi,KursİD,SeviyeİD,ResimID")] Kaynaklar kaynaklar)
        {
            if (ModelState.IsValid)
            {
                db.Kaynaklar.Add(kaynaklar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SeviyeİD = new SelectList(db.KullaniciSeviyeleri, "SeviyeİD", "SeviyeAdi", kaynaklar.SeviyeİD);
            ViewBag.KursİD = new SelectList(db.Kurslar, "KursİD", "KursAdi", kaynaklar.KursİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", kaynaklar.ResimID);
            return View(kaynaklar);
        }

        // GET: Kaynaklars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaynaklar kaynaklar = await db.Kaynaklar.FindAsync(id);
            if (kaynaklar == null)
            {
                return HttpNotFound();
            }
            ViewBag.SeviyeİD = new SelectList(db.KullaniciSeviyeleri, "SeviyeİD", "SeviyeAdi", kaynaklar.SeviyeİD);
            ViewBag.KursİD = new SelectList(db.Kurslar, "KursİD", "KursAdi", kaynaklar.KursİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", kaynaklar.ResimID);
            return View(kaynaklar);
        }

        // POST: Kaynaklars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "KaynakİD,KaynakAdi,KaynakTipi,KursİD,SeviyeİD,ResimID")] Kaynaklar kaynaklar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kaynaklar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SeviyeİD = new SelectList(db.KullaniciSeviyeleri, "SeviyeİD", "SeviyeAdi", kaynaklar.SeviyeİD);
            ViewBag.KursİD = new SelectList(db.Kurslar, "KursİD", "KursAdi", kaynaklar.KursİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", kaynaklar.ResimID);
            return View(kaynaklar);
        }

        // GET: Kaynaklars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kaynaklar kaynaklar = await db.Kaynaklar.FindAsync(id);
            if (kaynaklar == null)
            {
                return HttpNotFound();
            }
            return View(kaynaklar);
        }

        // POST: Kaynaklars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kaynaklar kaynaklar = await db.Kaynaklar.FindAsync(id);
            db.Kaynaklar.Remove(kaynaklar);
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
