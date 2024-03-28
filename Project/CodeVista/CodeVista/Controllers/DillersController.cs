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
    public class DillersController : Controller
    {
        private CodeVistaEntities db = new CodeVistaEntities();

        // GET: Dillers
        public async Task<ActionResult> Index()
        {
            var diller = db.Diller.Include(d => d.DilKonulari).Include(d => d.Resimler).Include(d => d.Resimler1).Include(d => d.Sektorler);
            return View(await diller.ToListAsync());
        }

        // GET: Dillers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diller diller = await db.Diller.FindAsync(id);
            if (diller == null)
            {
                return HttpNotFound();
            }
            return View(diller);
        }

        // GET: Dillers/Create
        public ActionResult Create()
        {
            ViewBag.DilİD = new SelectList(db.DilKonulari, "DilİD", "DilAdi");
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol");
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol");
            ViewBag.SektorİD = new SelectList(db.Sektorler, "SektorİD", "SektorAdi");
            return View();
        }

        // POST: Dillers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DilİD,DilAdi,DilTipi,SektorİD,ResimID,resim")] Diller diller)
        {
            if (ModelState.IsValid)
            {
                db.Diller.Add(diller);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DilİD = new SelectList(db.DilKonulari, "DilİD", "DilAdi", diller.DilİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", diller.ResimID);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", diller.ResimID);
            ViewBag.SektorİD = new SelectList(db.Sektorler, "SektorİD", "SektorAdi", diller.SektorİD);
            return View(diller);
        }

        // GET: Dillers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diller diller = await db.Diller.FindAsync(id);
            if (diller == null)
            {
                return HttpNotFound();
            }
            ViewBag.DilİD = new SelectList(db.DilKonulari, "DilİD", "DilAdi", diller.DilİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", diller.ResimID);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", diller.ResimID);
            ViewBag.SektorİD = new SelectList(db.Sektorler, "SektorİD", "SektorAdi", diller.SektorİD);
            return View(diller);
        }

        // POST: Dillers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DilİD,DilAdi,DilTipi,SektorİD,ResimID,resim")] Diller diller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diller).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DilİD = new SelectList(db.DilKonulari, "DilİD", "DilAdi", diller.DilİD);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", diller.ResimID);
            ViewBag.ResimID = new SelectList(db.Resimler, "ResimID", "Yol", diller.ResimID);
            ViewBag.SektorİD = new SelectList(db.Sektorler, "SektorİD", "SektorAdi", diller.SektorİD);
            return View(diller);
        }

        // GET: Dillers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diller diller = await db.Diller.FindAsync(id);
            if (diller == null)
            {
                return HttpNotFound();
            }
            return View(diller);
        }

        // POST: Dillers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Diller diller = await db.Diller.FindAsync(id);
            db.Diller.Remove(diller);
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
