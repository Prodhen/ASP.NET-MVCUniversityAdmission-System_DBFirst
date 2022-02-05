using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1262228_Arosh.ViewModels;
using _1262228_Arosh.Models;
namespace _1262228_Arosh.Controllers
{
    public class MyParentController : Controller
    {
        MyEntitiesDB db = new MyEntitiesDB();

        public ActionResult Index()
        {
            return View(db.Parents.ToList());
        }

        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(ParentVM pvm)
        {
            Parent p = new Parent();
            if (ModelState.IsValid)
            {
                p.Name = pvm.Name;
                p.NID = pvm.NID;
                p.Email = pvm.Email;
                p.Phone = pvm.Phone;
                p.Occupation = pvm.Occupation;
                p.Address = pvm.Address;             
                p.Income = pvm.Income;
                db.Parents.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
                

            }

            return PartialView("_ParentsDetails",db.Parents.ToList());
        }
        public ActionResult Edit (int id)
        {
            ParentVM pvm = new ParentVM();
            Parent p = db.Parents.Find(id);
            pvm.Name = p.Name;
            pvm.NID = p.NID;
            pvm.Email = p.Email;
            pvm.Phone = p.Phone;
            pvm.Occupation = p.Occupation;          
            pvm.Income = p.Income;
            pvm.Address = p.Address;

            if (p==null)
            {
                return HttpNotFound();

            }

            return PartialView(pvm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ParentVM pvm,int id)
        {
            Parent p = new Parent();
            p = db.Parents.Find(id);
            if (ModelState.IsValid)
            {
                p.Name = pvm.Name;
                p.NID = pvm.NID;
                p.Email = pvm.Email;
                p.Phone = pvm.Phone;
                p.Occupation = pvm.Occupation;
                p.Address = pvm.Address;
                p.Income = pvm.Income;
                db.Parents.Add(p);
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }




            return PartialView("_ParentsDetails", db.Parents.ToList());


        }

        public ActionResult Delete(int id)
        {
            Parent p = db.Parents.Find(id);
            ParentVM pvm = new ParentVM();

            pvm.Name = p.Name;
            pvm.NID = p.NID;
            pvm.Email = p.Email;
            pvm.Phone = p.Phone;
            pvm.Occupation = p.Occupation;
            pvm.Income = p.Income;
            pvm.Address = p.Address;



            return PartialView(pvm);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteParent(int id)
        {
            Parent p = db.Parents.Find(id);
            if (p != null)
            {
                db.Parents.Remove(p);
                db.SaveChanges();

            }




            return RedirectToAction("Index");

        }
        public ActionResult Details( int id)
        {

            Parent p = db.Parents.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);

        }

    }
}