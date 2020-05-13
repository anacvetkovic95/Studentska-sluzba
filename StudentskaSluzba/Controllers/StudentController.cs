using MVCNestedWebgrid.ViewModel;
using StudentskaSluzba.DAL;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace StudentskaSluzba.Controllers
{
    public class StudentController : Controller
    {
        private StudentskaSluzbaContext db = new StudentskaSluzbaContext();

        public static Student student;

        public bool StudentValidacija(Student student)
        {
            bool rezultat = true;
            if (student.Ime == null || student.Ime =="")
            {
                ModelState.AddModelError("Ime", "Unesite ime");
                rezultat = false;
                
            }
            if (student.Prezime == null || student.Prezime =="")
            {
                ModelState.AddModelError("Prezime", "Unesite prezime");
                rezultat = false;

            }
            if (student.Adresa == null || student.Adresa == "")
            {
                ModelState.AddModelError("Adresa", "Unesite adresu");
                rezultat = false;
            }
            if (student.Grad == null || student.Grad =="")
            {
                ModelState.AddModelError("Grad", "Unesite Grad");
                rezultat = false;
            }
            foreach (char item in student.Ime)
            {
                if (Char.IsDigit(item) || Char.IsPunctuation(item))
                {
                    ModelState.AddModelError("Ime", "Ime ne može da sadrži broj ili znak.");
                    rezultat = false;
                }
            }
            foreach (char item in student.Prezime)
            {
                if (Char.IsDigit(item) || Char.IsPunctuation(item))
                {
                    ModelState.AddModelError("Prezime", "Prezime ne može da sadrži broj ili znak.");
                    rezultat = false;
                }
            }
            foreach (char item in student.Adresa)
            {
                if (Char.IsPunctuation(item))
                {
                    ModelState.AddModelError("Adresa", "Adresa ne može da sadrži znak.");
                    rezultat = false;
                }
            }
            foreach (char item in student.Grad)
            {
                if (Char.IsDigit(item) || Char.IsPunctuation(item))
                {
                    ModelState.AddModelError("Grad", "Grad ne može da sadrži broj ili znak.");
                    rezultat = false;
                }
            }
            if (student.Ime == student.Prezime)
            {
                ModelState.AddModelError("Prezime", "Prezime studenta ne može biti isto kao i ime studenta.");
                rezultat = false;
            }

            return rezultat;
        }

        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }        

        public ActionResult Create()
        {
            return View();
        }       
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BI,Ime,Prezime,Adresa,Grad")] Student student)
        {
            StudentValidacija(student);
                     
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BI,Ime,Prezime,Adresa,Grad")] Student student)
        {
            StudentValidacija(student);

            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Student student = db.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            if (student.Ispiti.Count() > 0)
            {
                ModelState.AddModelError("BI", "Student ima ispitei nije pozeljno obrisati ga");
                return View(student);
            }
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}