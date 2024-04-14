using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;

namespace MyportfolioProject.Controllers
{
    public class SkillController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();

        //Listeleme
        public ActionResult Index()
        {
            var values = db.Tbl_Skills.ToList();
            return View(values);
        }

        //Yetenek Ekleme
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Tbl_Skills id)
        {
            db.Tbl_Skills.Add(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Yetenek Silme
        public ActionResult DeleteSkill(int id)
        {
            var values=db.Tbl_Skills.Find(id);
            db.Tbl_Skills.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Yetenek Bilgilerini Getirme ve Güncelleme
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var values = db.Tbl_Skills.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateSkill(Tbl_Skills k)
        { 
        //güncelleme
            var values=db.Tbl_Skills.Find(k.SkillId);
            values.SkillName = k.SkillName;
            values.Value = k.Value;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}