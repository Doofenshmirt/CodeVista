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
    public class KurslarsController : Controller
    {
        private CodeVistaEntities db = new CodeVistaEntities();

        // GET: Kurslars
        public async Task<ActionResult> Index()
        {
            var kurslar = db.Kurslar.Include(k => k.Diller).Include(k => k.Konular).Include(k => k.Resimler);
            return View(await kurslar.ToListAsync());
        }

        // GET: Kurslars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurslar kurslar = await db.Kurslar.FindAsync(id);
            if (kurslar == null)
            {
                return HttpNotFound();
            }
            return View(kurslar);
        }

        // GET: Kurslars/Create
        public ActionResult Create()
        {
            ViewBag.DilİD = new SelectList(db.Diller, "DilİD", "DilAdi");
            ViewBag.KonuİD = new SelectList(db.Konular, "KonuİD", "KonuAdi");
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol");
            return View();
        }

        // POST: Kurslars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "KursİD,KursAdi,DilİD,KonuİD,KursSeviyesi,KursAciklama,ResimID,resim")] Kurslar kurslar)
        {
            if (ModelState.IsValid)
            {
                db.Kurslar.Add(kurslar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DilİD = new SelectList(db.Diller, "DilİD", "DilAdi", kurslar.DilİD);
            ViewBag.KonuİD = new SelectList(db.Konular, "KonuİD", "KonuAdi", kurslar.KonuİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", kurslar.ResimID);
            return View(kurslar);
        }

        // GET: Kurslars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurslar kurslar = await db.Kurslar.FindAsync(id);
            if (kurslar == null)
            {
                return HttpNotFound();
            }
            ViewBag.DilİD = new SelectList(db.Diller, "DilİD", "DilAdi", kurslar.DilİD);
            ViewBag.KonuİD = new SelectList(db.Konular, "KonuİD", "KonuAdi", kurslar.KonuİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", kurslar.ResimID);
            return View(kurslar);
        }

        // POST: Kurslars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "KursİD,KursAdi,DilİD,KonuİD,KursSeviyesi,KursAciklama,ResimID,resim")] Kurslar kurslar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kurslar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DilİD = new SelectList(db.Diller, "DilİD", "DilAdi", kurslar.DilİD);
            ViewBag.KonuİD = new SelectList(db.Konular, "KonuİD", "KonuAdi", kurslar.KonuİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", kurslar.ResimID);
            return View(kurslar);
        }

        // GET: Kurslars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurslar kurslar = await db.Kurslar.FindAsync(id);
            if (kurslar == null)
            {
                return HttpNotFound();
            }
            return View(kurslar);
        }

        // POST: Kurslars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kurslar kurslar = await db.Kurslar.FindAsync(id);
            db.Kurslar.Remove(kurslar);
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
