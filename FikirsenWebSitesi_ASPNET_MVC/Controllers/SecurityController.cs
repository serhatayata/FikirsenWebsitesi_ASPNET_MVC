using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FikirsenWebSitesi_ASPNET_MVC.Models.entities;
using FikirsenWebSitesi_ASPNET_MVC.Models;
namespace FikirsenWebSitesi_ASPNET_MVC.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        FikirsenWebDBEntities3 db = new FikirsenWebDBEntities3();
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(Tbl_Kullanicilar p1)
        {
                var userDB = db.Tbl_Kullanicilar.FirstOrDefault(x=> x.KullaniciGirisAd == p1.KullaniciGirisAd && x.KullaniciGirisSifre == p1.KullaniciGirisSifre);
                if (userDB != null)
                {
                    FormsAuthentication.SetAuthCookie(p1.KullaniciGirisAd, false);
                    GirisKayit.girisAd = p1.KullaniciGirisAd;
                    GirisKayit.KullaniciID = Convert.ToInt32(db.Tbl_Kullanicilar.Single(x=> x.KullaniciGirisAd == p1.KullaniciGirisAd).KullaniciID);
                    return RedirectToAction("AnaSayfa", "AnaSayfa");
                }
                else
                {
                    ViewBag.msg = "Geçersiz Kullanıcı Girişi...";
                    return View();
                }
        }
        public ActionResult CikisYap()
        {
            GirisKayit.girisAd = "";
            GirisKayit.KullaniciID = 0;
            return View("Giris");
        }
    }
}