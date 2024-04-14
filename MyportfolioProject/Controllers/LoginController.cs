using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyportfolioProject.Models;
using System.Web.Security;//tanımladık güvenlik oluşturmak için

namespace MyportfolioProject.Controllers
{[AllowAnonymous]//herkes erişebilir
    public class LoginController : Controller
    {
        
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Admins admin)
        {
            var value = db.Tbl_Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);//kullancının girdiği bilgileri admin tablosuyla karşılaştırıyor
            if(value!=null)//boş değilse
            {
                FormsAuthentication.SetAuthCookie(value.UserName,false);//kullacının oturumu
                Session["username"] = value.UserName;//kullancıı otrum boyunca isim ve soy ismi gorebilir
                return RedirectToAction("Index", "About");//kullancıcı giriş yapınca indexden about girsin 
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");//hata mesajı
                   return View();
            }
            
        }


        //Profilden Çıkış Yapma(kullanıcının girmiş olduğu profilden sağ üstte)
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Default");//Çıkış yap tıklandığında default indexine gönderecek
        }








    }
}