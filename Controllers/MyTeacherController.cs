using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1262228_Arosh.Models;
using _1262228_Arosh.ViewModels;
using System.Data.Entity;
using System.IO;

namespace _1262228_Arosh.Controllers
{
    public class MyTeacherController : Controller
    {
        MyEntitiesDB db = new MyEntitiesDB();
        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }

        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Teacher t)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(t.UploadImage.FileName);
                string extension = Path.GetExtension(t.UploadImage.FileName);
                HttpPostedFileBase postedFile = t.UploadImage;

                fileName = fileName + extension;
                t.Picture = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                t.UploadImage.SaveAs(fileName);

                db.Teachers.Add(t);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(t);
        }
        public ActionResult Edit(int id = 0)
        {
            Teacher t = db.Teachers.Find(id);



            Session["Image"] = t.Picture;

            if (t == null)
            {
                return HttpNotFound();
            }

            return View(t);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher t)
        {
            if (ModelState.IsValid)
            {
                if (t.UploadImage != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(t.UploadImage.FileName);
                    string extension = Path.GetExtension(t.UploadImage.FileName);
                    HttpPostedFileBase postedFile = t.UploadImage;



                    fileName = fileName + extension;
                    t.Picture = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    t.UploadImage.SaveAs(fileName);

                }



                t.Picture = Session["Image"].ToString();
                db.Entry(t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentsID = new SelectList(db.Parents, "ParentID", "Name");
            ViewBag.ClassID = new SelectList(db.Classesses, "ClassID", "Name");
            return View(t);
        }
        public ActionResult Delete(int id = 0)
        {
            Teacher t = db.Teachers.Find(id);
            if (t == null)
            {
                return HttpNotFound();
            }
            return View(t);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            Teacher t = db.Teachers.Find(id);
            db.Teachers.Remove(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id = 0)
        {
            Teacher t = db.Teachers.Find(id);
            if (t == null)
            {
                return HttpNotFound();
            }
            return View(t);
        }
    }
}