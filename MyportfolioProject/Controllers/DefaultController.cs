using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;//tanımlaman gerek


namespace MyportfolioProject.Controllers
{

    [AllowAnonymous]//herkes buraya erişebilir
    public class DefaultController : Controller
    {
        //_UILLayout ilişkili indexleri felan
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            return View();
        }
        //Kişi Özelliklerini Listeleme
        public PartialViewResult DefaultFeaturePartial()
        {
            var values = db.Tbl_Features.ToList();
            return PartialView(values);
        }
        //Kişi Hakkımda Listeleme
        public PartialViewResult DefaultAboutPartial()
        {
            var values = db.Tbl_Abauts.ToList();
            return PartialView(values);
        }

        //Yeni Mesaj Ekleme
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(Tbl_Messages t)//post-->action demeliyiz
        {
            db.Tbl_Messages.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Servis Listeleme
        public PartialViewResult DefaultServicePartial()
        {
            var values = db.Tbl_Services.Where(x=>x.Status==true).ToList();//statüs(durum) dedik veri tabında true olanları göstersin
            return PartialView(values); 
        }

        //Yetnekler Listeleme
        public PartialViewResult DefaultSkillPartial()
        {
            var values = db.Tbl_Skills.ToList();
            return PartialView(values);
        }

        //Projelerim Listeleme
        public PartialViewResult DefaultProjectPartial()
        {
            var categories = db.Tbl_Categories.ToList();//kategorileri listeledik
            ViewBag.categories = categories;//viewbag içerisine attık defaultprojectpartialda ona göre çağırıyoruz

            var values = db.Tbl_Projects.ToList();
            return PartialView(values);
        }

        //Deneyimlerim Listeleme
        public PartialViewResult DefaultExperiences()
        {
            var Values = db.Tbl_Experiences.ToList();
            return PartialView(Values);
        }

        //Referanslarım Listeleme
        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = db.Tbl_Testimonials.ToList();
            return PartialView(values);
        }

        //Takım Arkadaşlarım Listeleme
        public PartialViewResult DefaultTeamPartial()
        {
            var values = db.Tbl_Teams.ToList();
            return PartialView(values);
        }


        //Sosyal Medya Listeleme
        public PartialViewResult DefaultSocialMediaPartial()
        {
            var values = db.Tbl_Contacts.ToList();
            return PartialView(values);
        }

    }
}