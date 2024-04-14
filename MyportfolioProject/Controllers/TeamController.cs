using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;

namespace MyportfolioProject.Controllers
{
    public class TeamController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();

        //listeleme
        public ActionResult Index()
        {
            var values = db.Tbl_Teams.ToList();
            return View(values);
        }

        //Takım Arkadaşı Ekleme
        [HttpGet]
        public ActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeam(Tbl_Teams id)
        {
            var values = db.Tbl_Teams.Add(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Takım Arkadaşı Silme
        public ActionResult DeleteTeam(int id)
        {
            var values = db.Tbl_Teams.Find(id);
            db.Tbl_Teams.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Takım Arkadaşı Bilgilerini Getirme ve Güncelleme
        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            //verileri getirme
            var values = db.Tbl_Teams.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateTeam(Tbl_Teams k)
        {   //verileri güncelleme
            var value = db.Tbl_Teams.Find(k.TeamId);
            value.ImageUrl = k.ImageUrl;
            value.NameSurname = k.NameSurname;
            value.Title = k.Title;
            value.Description = k.Description;
            value.TwitterUrl = k.TwitterUrl;
            value.FacebookUrl = k.FacebookUrl;
            value.LinkedinUrl = k.LinkedinUrl;
            value.InstagramUrl = k.InstagramUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}