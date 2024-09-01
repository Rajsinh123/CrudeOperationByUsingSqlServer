using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using CrudeOperationByUsingSqlServer.Models;
using System.Data.Entity;

namespace CrudeOperationByUsingSqlServer.Content
{
    public class StudentController : Controller
    {
        // GET: Student
        RajEntities db = new RajEntities();
        public ActionResult Index()
        {
            List<Student> lst = db.Students.ToList();
           return View(lst);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student st = db.Students.Find(id);
            return View(st);

        }
        [HttpPost]
        public ActionResult Edit( Student st)
        {
            db.Entry<Student>(st).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Student st = db.Students.Find(id);
            db.Students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}