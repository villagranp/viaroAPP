using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViaroAPP.Models;

namespace ViaroAPP.Controllers
{
    public class alumnsController : Controller
    {
        private ViaroAPPEntities db = new ViaroAPPEntities();

        // GET: alumns
        public ActionResult Index()
        {
            return View(db.alumns.ToList());
        }

        // GET: alumns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumn alumn = db.alumns.Find(id);
            if (alumn == null)
            {
                return HttpNotFound();
            }
            return View(alumn);
        }

        // GET: alumns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: alumns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_alumn,first_name,last_name,gender,bith_date")] alumn alumn)
        {
            if (ModelState.IsValid)
            {
                db.alumns.Add(alumn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alumn);
        }

        // GET: alumns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumn alumn = db.alumns.Find(id);
            if (alumn == null)
            {
                return HttpNotFound();
            }
            return View(alumn);
        }

        // POST: alumns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_alumn,first_name,last_name,gender,bith_date")] alumn alumn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumn);
        }

        // GET: alumns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumn alumn = db.alumns.Find(id);
            if (alumn == null)
            {
                return HttpNotFound();
            }
            return View(alumn);
        }

        // POST: alumns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            alumn alumn = db.alumns.Find(id);
            db.alumns.Remove(alumn);
            db.SaveChanges();
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
