using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FikirsenWebSitesi_ASPNET_MVC.Models;
using FikirsenWebSitesi_ASPNET_MVC.Models.entities;
namespace FikirsenWebSitesi_ASPNET_MVC.Controllers
{
    public class BilgiController : Controller
    {
        // GET: Sifre
        FikirsenWebDBEntities3 db = new FikirsenWebDBEntities3();
        [HttpGet]
        public ActionResult BilgiDegistir()
        {
            var degerler = db.Tbl_Kullanicilar.FirstOrDefault(x => x.KullaniciGirisAd == GirisKayit.girisAd.ToString());
            return View(degerler);
        }
        [HttpPost]
        public ActionResult BilgiDegistir(Tbl_Kullanicilar p1)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.dgr = "İşlem Başarısız !";
                return View("BilgiDegistir");
            }
            var degerler = db.Tbl_Kullanicilar.FirstOrDefault(x => x.KullaniciID == p1.KullaniciID);
            degerler.KullaniciAd = p1.KullaniciAd;
            degerler.KullaniciSoyad = p1.KullaniciSoyad;
            degerler.KullaniciMail = p1.KullaniciMail;
            degerler.KullaniciGirisAd = p1.KullaniciGirisAd;
            degerler.KullaniciGirisSifre = p1.KullaniciGirisSifre;
            db.SaveChanges();
            ViewBag.dgr = "İşlem Başarılı";
            return View();
        }

        
    }
}