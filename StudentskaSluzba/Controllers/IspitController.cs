using StudentskaSluzba.DAL;
using StudentskaSluzba.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentskaSluzba.Controllers
{
    public class IspitController : Controller
    {
        private StudentskaSluzbaContext db = new StudentskaSluzbaContext();

        public ActionResult Index()
        {
            return View(db.Ispits.ToList());
        }

        public ActionResult Create()
        {
            var studenti = db.Students.ToList();
            var indeksi = new List<int>();

            foreach(var item in studenti)
            {
                indeksi.Add(item.BI);
            }

            ViewBag.indeksi = indeksi;

            var predmeti = db.Predmets.ToList();
            var sifre = new List<int>();

            foreach (var item in predmeti)
            {
                sifre.Add(item.PredmetId);
            }

            ViewBag.sifre = sifre;

            var ocene = new List<int>();
            for(int i = 6; i < 11; i++)
            {
                ocene.Add(i);
            }
            ViewBag.ocene = ocene;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BI, PredmetId, Ocena")] Ispit ispit)
        {
            var ispiti = db.Ispits.ToList();

            foreach (var item in ispiti)
            {
                if (item.BI == ispit.BI && item.PredmetId == ispit.PredmetId)
                {
                    ModelState.AddModelError("BI", "Promeni BI ili PredmetId");
                    ModelState.AddModelError("PredmetId", "Promeni BI ili PredmetId");
                }
            }

            if (ModelState.IsValid)
            {
                db.Ispits.Add(ispit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var studenti = db.Students.ToList();
            var indeksi = new List<int>();

            foreach (var item in studenti)
            {
                indeksi.Add(item.BI);
            }

            ViewBag.indeksi = indeksi;

            var predmeti = db.Predmets.ToList();
            var sifre = new List<int>();

            foreach (var item in predmeti)
            {
                sifre.Add(item.PredmetId);
            }

            ViewBag.sifre = sifre;

            var ocene = new List<int>();
            for (int i = 6; i < 11; i++)
            {
                ocene.Add(i);
            }
            ViewBag.ocene = ocene;

            return View(ispit);
        }

        public ActionResult Edit(int BI, int PredmetId)
        {
            Ispit ispit = db.Ispits.Where(x => x.PredmetId==PredmetId && x.BI==BI).FirstOrDefault();
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BI, PredmetId, Ocena")] Ispit ispit)
        {
            var studenti = db.Students.ToList();
            var indeksi = new List<int>();

            foreach (var item in studenti)
            {
                indeksi.Add(item.BI);
            }

            var predmeti = db.Predmets.ToList();
            var sifre = new List<int>();

            foreach (var item in predmeti)
            {
                sifre.Add(item.PredmetId);
            }

            if (!indeksi.Contains(ispit.BI))
            {
                ModelState.AddModelError("BI", "Ne postoji u bazi");

            }

            if (!sifre.Contains(ispit.PredmetId))
            {
                ModelState.AddModelError("PredmetId", "Ne postoji u bazi");

            }

            if (ModelState.IsValid)
            {
                db.Entry(ispit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ispit);
        }

        public ActionResult Details(int BI, int PredmetId)
        {
            Ispit ispit = db.Ispits.Where(x => x.PredmetId == PredmetId && x.BI == BI).FirstOrDefault();

            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        public ActionResult Delete(int BI, int PredmetId)
        {
            Ispit ispit = db.Ispits.Where(x => x.PredmetId == PredmetId && x.BI == BI).FirstOrDefault();
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int BI, int PredmetId)
        {
            Ispit ispit = db.Ispits.Where(x => x.PredmetId == PredmetId && x.BI == BI).FirstOrDefault();
            db.Ispits.Remove(ispit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}