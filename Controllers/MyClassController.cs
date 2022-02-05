using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1262228_Arosh.Models;
using System.Data.Entity;

namespace _1262228_Arosh.Controllers
{
    public class MyClassController : Controller
    {
        MyEntitiesDB db = new MyEntitiesDB();
        public ActionResult Index()
        {
            return View(db.Classesses.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.TeacherID = new SelectList(db.Teachers,"TeacherID", "TeacherName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Classess c)
        {
            
            if(ModelState.IsValid)
            {

                db.Classesses.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
 
            return View(c);

        }
       [Authorize(Roles ="Admin,Teacher")]
        public ActionResult Edit(int id)
        {

            Classess c = db.Classesses.Find(id);
            if (c==null)
            {
                HttpNotFound();
                return RedirectToAction("Index");

            }
            ViewBag.TeacherID = new SelectList(db.Teachers,"TeacherID", "TeacherName");
            return View(c);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Classess c)
        {


            if (ModelState.IsValid)
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
               return RedirectToAction("Index");
            }



            ViewBag.TeacherID = new SelectList(db.Teachers,"TeacherID", "TeacherName");
           return View(c);
                       
        }

        public ActionResult Delete(int id)
        {
            Classess c = db.Classesses.Find(id);
            if (c==null)
            {
                HttpNotFound();
                return RedirectToAction("Index");

            }
            return View(c);

        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClass(int id)
        {
            Classess c = db.Classesses.Find(id);


            if (ModelState.IsValid) 
            {
                db.Classesses.Remove(c);
                db.SaveChanges();
               return RedirectToAction("Index");
            }
            return View(c);




        }



        public ActionResult Details(int id)
        {
            Classess c = db.Classesses.Find(id);
            if (c==null)
            {
                HttpNotFound();
                return RedirectToAction("Index");


            }
            return View(c);


        }

    }
}