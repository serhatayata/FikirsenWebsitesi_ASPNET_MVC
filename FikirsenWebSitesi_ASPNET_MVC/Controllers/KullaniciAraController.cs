using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FikirsenWebSitesi_ASPNET_MVC.Models.entities;
namespace FikirsenWebSitesi_ASPNET_MVC.Controllers
{
    public class KullaniciAraController : Controller
    {
        // GET: KullaniciAra
        FikirsenWebDBEntities3 db = new FikirsenWebDBEntities3();
        [HttpGet]
        public ActionResult KullaniciAra()
        {
            var degerler = db.Tbl_Kullanicilar.ToList();
            return View(degerler);
        }
        [HttpPost]
        public ActionResult KullaniciAra(Tbl_Kullanicilar p1)
        {
            IEnumerable giden;
            var degerNot = db.Tbl_Kullanicilar.ToList();
            if (p1.KullaniciID != 0)
            {
                var degerler = db.Tbl_Kullanicilar.Where(x => x.KullaniciID == p1.KullaniciID);
                giden = degerler.ToList();
                return View(giden);
            }
            else if (p1.KullaniciAd != null)
            {
                var degerler = db.Tbl_Kullanicilar.Where(x => x.KullaniciAd == p1.KullaniciAd);
                giden = degerler.ToList();
                return View(giden);
            }
            else if (p1.KullaniciSoyad != null)
            {
                var degerler = db.Tbl_Kullanicilar.Where(x => x.KullaniciSoyad == p1.KullaniciSoyad);
                giden = degerler.ToList();
                return View(giden);
            }
            else if (p1.KullaniciMail != null)
            {
                var degerler = db.Tbl_Kullanicilar.Where(x => x.KullaniciMail == p1.KullaniciMail);
                giden = degerler.ToList();
                return View(giden);
            }
            else if (p1.KullaniciGirisAd != null)
            {
                var degerler = db.Tbl_Kullanicilar.Where(x => x.KullaniciGirisAd == p1.KullaniciGirisAd);
                giden = degerler.ToList();
                return View("KullaniciAra",giden);
        }
            return View(degerNot);
    }
        public ActionResult KullaniciAdiAra(string p1)
        {
            var degerler = db.Tbl_Kullanicilar.Where(x => x.KullaniciGirisAd == p1).ToList();
            return View("KullaniciAra",degerler);
            //return RedirectToAction("KullaniciAra",KullaniciAra, new { p1 = giden });
        }
    }
}