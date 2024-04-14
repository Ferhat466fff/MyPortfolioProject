using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;//tanımlaman gerek

namespace MyportfolioProject.Controllers
{
    public class ProjectController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        //listeleme
        public ActionResult Index()
        {
            var values = db.Tbl_Projects.ToList();
            return View(values);
        }

        //kategori ekleme ve kategori seçtirme (İLİŞKİLİ TABLOLARDA)
        [HttpGet]
        public ActionResult AddProject()
        {//categoriyi sectirme
            var categoryies = db.Tbl_Categories.ToList();//kategorilerilisteledik
            List<SelectListItem> categoryList = (from x in categoryies select new SelectListItem//kategoriler içerisinde seçimler yapacağız
            {
                Text = x.CategoryName,//displaymember(gözükecek deger)
                Value = x.CategoryId.ToString() //valuemember gibi düşün(arkada dönen deger)
            }).ToList();
            ViewBag.dgr = categoryList;//ViewBag-->controller ifadeleri ındexlere taşımada kullanılır(addproject kategori kısmına bakabilirsin)
            return View();

        }
        [HttpPost]
        public ActionResult AddProject(Tbl_Projects project)
        {  //kategori ekleme
            db.Tbl_Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.Tbl_Projects.Find(id);
            db.Tbl_Projects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");//sil denildikten sonra bizi tekrar ındex yollasın
            //ındex html butonun yolunu verdik
        }




        //kategori verilerini getirme ve güncelleme
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            //categoriyi sectirme(verileri alma)
            var categoryies = db.Tbl_Categories.ToList();//kategorilerilisteledik
           
                List<SelectListItem> categoryList = (from x in categoryies
                                                     select new SelectListItem//kategoriler içerisinde seçimler yapacağız
                                                     {
                                                         Text = x.CategoryName,//displaymember(gözükecek deger)
                                                         Value = x.CategoryId.ToString() //valuemember gibi düşün(arkada dönen deger)
                                                     }).ToList();
                ViewBag.dgr = categoryList;//ViewBag-->controller ifadeleri ındexlere taşımada kullanılır(addproject kategori kısmına bakabilirsin)
                var value = db.Tbl_Projects.Find(id);
                return View(value);
            
        }
            [HttpPost]
            public ActionResult UpdateProject(Tbl_Projects p)
            {//güncelleme
                var value = db.Tbl_Projects.Find(p.ProjectId);
                value.ProjectName = p.ProjectName;
                value.ImageUrl = p.ImageUrl;
                value.GithubUrl = p.GithubUrl;
                value.CategoryId = p.CategoryId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }



}   } 