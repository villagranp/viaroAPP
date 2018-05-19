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
    public class course_alumnController : Controller
    {
        private ViaroAPPEntities db = new ViaroAPPEntities();

        // GET: course_alumn
        public ActionResult Index()
        {
            var course_alumn = db.course_alumn.Include(c => c.alumn).Include(c => c.Course);
            return View(course_alumn.ToList());
        }

        // GET: course_alumn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course_alumn course_alumn = db.course_alumn.Find(id);
            if (course_alumn == null)
            {
                return HttpNotFound();
            }
            return View(course_alumn);
        }

        // GET: course_alumn/Create
        public ActionResult Create()
        {
            ViewBag.id_alumn = new SelectList(db.alumns, "id_alumn", "first_name");
            ViewBag.id_course = new SelectList(db.Courses, "id_course", "name");
            return View();
        }

        // POST: course_alumn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_course_alumn,id_alumn,id_course,section")] course_alumn course_alumn)
        {
            if (ModelState.IsValid)
            {
                db.course_alumn.Add(course_alumn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_alumn = new SelectList(db.alumns, "id_alumn", "first_name", course_alumn.id_alumn);
            ViewBag.id_course = new SelectList(db.Courses, "id_course", "name", course_alumn.id_course);
            return View(course_alumn);
        }

        // GET: course_alumn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course_alumn course_alumn = db.course_alumn.Find(id);
            if (course_alumn == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_alumn = new SelectList(db.alumns, "id_alumn", "first_name", course_alumn.id_alumn);
            ViewBag.id_course = new SelectList(db.Courses, "id_course", "name", course_alumn.id_course);
            return View(course_alumn);
        }

        // POST: course_alumn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_course_alumn,id_alumn,id_course,section")] course_alumn course_alumn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_alumn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_alumn = new SelectList(db.alumns, "id_alumn", "first_name", course_alumn.id_alumn);
            ViewBag.id_course = new SelectList(db.Courses, "id_course", "name", course_alumn.id_course);
            return View(course_alumn);
        }

        // GET: course_alumn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course_alumn course_alumn = db.course_alumn.Find(id);
            if (course_alumn == null)
            {
                return HttpNotFound();
            }
            return View(course_alumn);
        }

        // POST: course_alumn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            course_alumn course_alumn = db.course_alumn.Find(id);
            db.course_alumn.Remove(course_alumn);
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

        public static string  getTeacher(int idCourse) {
            string profesor = "";
            int idprof = 0;
                ViaroAPPEntities db = new ViaroAPPEntities();
                idprof = Int32.Parse(  db.Courses.Find(idCourse).id_teacher.ToString() );
                profesor = db.teachers.Find(idprof).first_name.ToString();
            return profesor;
        }

        public  PartialViewResult CourseDropDownlist()
        {
            ViaroAPPEntities db = new ViaroAPPEntities();
            var Courses = (from c in db.Courses
                                 join p in db.teachers on c.id_teacher equals p.id_teacher
                                 select new { name = c.name + " " + p.first_name, c.id_course } ).ToList();

            ViewBag.Courses = new SelectList(Courses, "id_course", "name");

            return PartialView("DropDownList", Courses);

        }

    }
}
