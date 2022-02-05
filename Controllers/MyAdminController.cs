using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using _1262228_Arosh.Models;
using _1262228_Arosh.ViewModels;
using PagedList;
using System.IO;

namespace _1262228_Arosh.Controllers
{
    public class MyAdminController : Controller
    {
        MyEntitiesDB db = new MyEntitiesDB();
        [Authorize(Roles ="Admin")]
        public ActionResult Index(int? page)
        {
            int pageSize=5;
            int pageNumber = page ?? 1;
            return View(db.Students.ToList().ToPagedList(pageNumber,pageSize));
        }

        public ActionResult Create()

        {
            ViewBag.ParentsID = new SelectList(db.Parents, "ParentID", "Name");
            ViewBag.ClassID = new SelectList(db.Classesses, "ClassID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            //Student s = new Student();
            if (ModelState.IsValid)
            {
    
                string fileName = Path.GetFileNameWithoutExtension(s.UploadImage.FileName);
                string extension = Path.GetExtension(s.UploadImage.FileName);
                HttpPostedFileBase postedFile = s.UploadImage;
                int length = postedFile.ContentLength;



                fileName = fileName + extension;
                s.Picture = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                s.UploadImage.SaveAs(fileName);

                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.ParentsID = new SelectList(db.Parents, "ParentID", "Name");
            ViewBag.ClassID = new SelectList(db.Classesses, "ClassID", "Name");
            return View(db.Students.ToList());


        }
        public ActionResult Edit(int id = 0)
        {
            Student s = db.Students.Find(id);



            Session["Image"] = s.Picture;

            if (s == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentsID = new SelectList(db.Parents, "ParentID", "Name");
            ViewBag.ClassID = new SelectList(db.Classesses, "ClassID", "Name");
            return View(s);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid)
            {
                if(s.UploadImage!=null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(s.UploadImage.FileName);
                    string extension = Path.GetExtension(s.UploadImage.FileName);
                    HttpPostedFileBase postedFile = s.UploadImage;

                    fileName = fileName + extension;
                    s.Picture = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    s.UploadImage.SaveAs(fileName);

                }



                s.Picture = Session["Image"].ToString();
                db.Entry(s).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentsID = new SelectList(db.Parents, "ParentID", "Name");
            ViewBag.ClassID = new SelectList(db.Classesses, "ClassID", "Name");
            return View(s);
        }
        public ActionResult Delete(int id = 0)
        {
            Student s = db.Students.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            Student s = db.Students.Find(id);
            db.Students.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id = 0)
        {
            Student s = db.Students.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }
    }
}

