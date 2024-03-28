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
    public class DilKonularisController : Controller
    {
        private CodeVistaEntities db = new CodeVistaEntities();

        // GET: DilKonularis
        public async Task<ActionResult> Index(int? id)
        {
            if (id == null)
            {
                // id null ise, tüm dil konularını getir
                var dilKonular = await db.DilKonulari.Include(d => d.Diller).Include(d => d.Konular).Include(d => d.Sektorler).ToListAsync();
                return View(dilKonular);
            }
            // Dil ID'sine göre ilgili dilin konularını getir
            var konular = db.DilKonulari
                .Where(d => d.DilİD == id)
                .Include(d => d.Diller)
                .Include(d => d.Konular)
                .Include(d => d.Sektorler)
                .ToListAsync();

            return View(await konular);
        }

        // GET: DilKonularis/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DilKonulari dilKonulari = await db.DilKonulari.FindAsync(id);
            if (dilKonulari == null)
            {
                return HttpNotFound();
            }
            return View(dilKonulari);
        }

        // GET: DilKonularis/Create
        public ActionResult Create()
        {
            ViewBag.DilİD = new SelectList(db.Diller, "DilİD", "DilAdi");
            ViewBag.KonuİD = new SelectList(db.Konular, "KonuİD", "KonuAdi");
            ViewBag.SektorİD = new SelectList(db.Sektorler, "SektorİD", "SektorAdi");
            return View();
        }

        // POST: DilKonularis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DilİD,KonuİD,DilAdi,KullanimAlani,SektorİD,Amaç,PopulerlikDerecesi")] DilKonulari dilKonulari)
        {
            if (ModelState.IsValid)
            {
                db.DilKonulari.Add(dilKonulari);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DilİD = new SelectList(db.Diller, "DilİD", "DilAdi", dilKonulari.DilİD);
            ViewBag.KonuİD = new SelectList(db.Konular, "KonuİD", "KonuAdi", dilKonulari.KonuİD);
            ViewBag.SektorİD = new SelectList(db.Sektorler, "SektorİD", "SektorAdi", dilKonulari.SektorİD);
            return View(dilKonulari);
        }

        // GET: DilKonularis/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DilKonulari dilKonulari = await db.DilKonulari.FindAsync(id);
            if (dilKonulari == null)
            {
                return HttpNotFound();
            }
            ViewBag.DilİD = new SelectList(db.Diller, "DilİD", "DilAdi", dilKonulari.DilİD);
            ViewBag.KonuİD = new SelectList(db.Konular, "KonuİD", "KonuAdi", dilKonulari.KonuİD);
            ViewBag.SektorİD = new SelectList(db.Sektorler, "SektorİD", "SektorAdi", dilKonulari.SektorİD);
            return View(dilKonulari);
        }

        // POST: DilKonularis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DilİD,KonuİD,DilAdi,KullanimAlani,SektorİD,Amaç,PopulerlikDerecesi")] DilKonulari dilKonulari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dilKonulari).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DilİD = new SelectList(db.Diller, "DilİD", "DilAdi", dilKonulari.DilİD);
            ViewBag.KonuİD = new SelectList(db.Konular, "KonuİD", "KonuAdi", dilKonulari.KonuİD);
            ViewBag.SektorİD = new SelectList(db.Sektorler, "SektorİD", "SektorAdi", dilKonulari.SektorİD);
            return View(dilKonulari);
        }

        // GET: DilKonularis/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DilKonulari dilKonulari = await db.DilKonulari.FindAsync(id);
            if (dilKonulari == null)
            {
                return HttpNotFound();
            }
            return View(dilKonulari);
        }

        // POST: DilKonularis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DilKonulari dilKonulari = await db.DilKonulari.FindAsync(id);
            db.DilKonulari.Remove(dilKonulari);
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
