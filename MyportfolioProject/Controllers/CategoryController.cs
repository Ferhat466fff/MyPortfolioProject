using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;//tanımlaman gerek

namespace MyportfolioProject.Controllers
{
    public class CategoryController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        //kategori listeleme
        public ActionResult Index()
        {
            var values = db.Tbl_Categories.ToList();
            return View(values);
        }

        //kategori ekleme
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Tbl_Categories t)
        {
            db.Tbl_Categories.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");//ekle denildikten sonra bizi tekrar ındex yollasın
        }

        //kategori silme
        public ActionResult DeleteCategory(int id)
        {
            var value = db.Tbl_Categories.Find(id);//id'ye göre silecek
            db.Tbl_Categories.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");//sil denildikten sonra bizi tekrar ındex yollasın
            //ındex html butonun yolunu verdik
        }

        //kategori bilgilerini getirme ve güncelleme
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {//kategori getirme
            var category = db.Tbl_Categories.Find(id);//id'si varsa kısaca verileri al
            if (category!=null)
            {
                return View(category);
            }
            else
            {
                return RedirectToAction("Index");//yoksa indexe gonder
            }
        }
        [HttpPost]
        public ActionResult UpdateCategory(Tbl_Categories category)
        {//verileri güncelleme
            var value = db.Tbl_Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

     

    }
}