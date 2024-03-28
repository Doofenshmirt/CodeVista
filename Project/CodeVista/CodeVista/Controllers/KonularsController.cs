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
    public class KonularsController : Controller
    {
        private CodeVistaEntities db = new CodeVistaEntities();

        // GET: Konulars
        public async Task<ActionResult> Index(int? sektorId, string img)
        {
            if (sektorId == null)
            {
                // id null ise, tüm konuları getir
                return View(await db.Konular.ToListAsync());
            }
            // Sektorler ID'sine göre ilgili sektorler konularını getir
            var konular = db.Konular
                            .Include(k => k.Sektorler)
                            .Where(k => k.SektorID == sektorId);

            ViewBag.ImagePath = img; // Sektör resim yolunu ViewBag üzerinden view'a iletiyoruz

            return View(await konular.ToListAsync());
        }
        // GET: Konulars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konular konular = await db.Konular.FindAsync(id);
            if (konular == null)
            {
                return HttpNotFound();
            }
            return View(konular);
        }

        // GET: Konulars/Create
        public ActionResult Create()
        {
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol");
            return View();
        }

        // POST: Konulars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "KonuİD,KonuAdi,KonuAciklama,KonuTipi,ResimID")] Konular konular)
        {
            if (ModelState.IsValid)
            {
                db.Konular.Add(konular);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", konular.ResimID);
            return View(konular);
        }

        // GET: Konulars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konular konular = await db.Konular.FindAsync(id);
            if (konular == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", konular.ResimID);
            return View(konular);
        }

        // POST: Konulars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "KonuİD,KonuAdi,KonuAciklama,KonuTipi,ResimID")] Konular konular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(konular).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", konular.ResimID);
            return View(konular);
        }

        // GET: Konulars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konular konular = await db.Konular.FindAsync(id);
            if (konular == null)
            {
                return HttpNotFound();
            }
            return View(konular);
        }

        // POST: Konulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Konular konular = await db.Konular.FindAsync(id);
            db.Konular.Remove(konular);
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
