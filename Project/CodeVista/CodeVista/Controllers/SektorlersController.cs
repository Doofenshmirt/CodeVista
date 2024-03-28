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
    public class SektorlersController : Controller
    {
        private CodeVistaEntities db = new CodeVistaEntities();

        // GET: Sektorlers
        public async Task<ActionResult> Index()
        {
            var sektorler = db.Sektorler.Include(s => s.Diller1).Include(s => s.Resimler);
            return View(await sektorler.ToListAsync());
        }

        // GET: Sektorlers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sektorler sektorler = await db.Sektorler.FindAsync(id);
            if (sektorler == null)
            {
                return HttpNotFound();
            }
            return View(sektorler);
        }

        // GET: Sektorlers/Create
        public ActionResult Create()
        {
            ViewBag.PopulerYazilimDiliİD = new SelectList(db.Diller, "DilİD", "DilAdi");
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol");
            return View();
        }

        // POST: Sektorlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SektorİD,SektorAdi,PopulerYazilimDiliİD,ResimID,resim")] Sektorler sektorler)
        {
            if (ModelState.IsValid)
            {
                db.Sektorler.Add(sektorler);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PopulerYazilimDiliİD = new SelectList(db.Diller, "DilİD", "DilAdi", sektorler.PopulerYazilimDiliİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", sektorler.ResimID);
            return View(sektorler);
        }

        // GET: Sektorlers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sektorler sektorler = await db.Sektorler.FindAsync(id);
            if (sektorler == null)
            {
                return HttpNotFound();
            }
            ViewBag.PopulerYazilimDiliİD = new SelectList(db.Diller, "DilİD", "DilAdi", sektorler.PopulerYazilimDiliİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", sektorler.ResimID);
            return View(sektorler);
        }

        // POST: Sektorlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SektorİD,SektorAdi,PopulerYazilimDiliİD,ResimID,resim")] Sektorler sektorler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sektorler).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PopulerYazilimDiliİD = new SelectList(db.Diller, "DilİD", "DilAdi", sektorler.PopulerYazilimDiliİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", sektorler.ResimID);
            return View(sektorler);
        }

        // GET: Sektorlers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sektorler sektorler = await db.Sektorler.FindAsync(id);
            if (sektorler == null)
            {
                return HttpNotFound();
            }
            return View(sektorler);
        }

        // POST: Sektorlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sektorler sektorler = await db.Sektorler.FindAsync(id);
            db.Sektorler.Remove(sektorler);
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
