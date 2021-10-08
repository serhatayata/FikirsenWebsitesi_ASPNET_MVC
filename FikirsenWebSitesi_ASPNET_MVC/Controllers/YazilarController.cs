using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FikirsenWebSitesi_ASPNET_MVC.Models;
using FikirsenWebSitesi_ASPNET_MVC.Models.entities;

namespace FikirsenWebSitesi_ASPNET_MVC.Controllers
{
    public class YazilarController : Controller
    {
        // GET: Yazilar
        FikirsenWebDBEntities3 db = new FikirsenWebDBEntities3();
        public ActionResult YaziListesi(int? sayfa)
        {
            int _sayfa = sayfa ?? 1;
            var degerler = db.Tbl_Yazilar.Where(x=> x.Tbl_Kullanicilar.KullaniciGirisAd == GirisKayit.girisAd).ToList().ToPagedList<Tbl_Yazilar>(_sayfa, 2);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YaziEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YaziEkle(Tbl_Yazilar p1)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.dgr = "Ekleme Başarısız !";
                return View("YaziEkle");
            }
            Tbl_Yazilar yeni = new Tbl_Yazilar();
            yeni.YaziBaslik = p1.YaziBaslik;
            yeni.YaziIcerik = p1.YaziIcerik;
            yeni.YazarID = GirisKayit.KullaniciID;
            db.Tbl_Yazilar.Add(yeni);
            db.SaveChanges();
            ViewBag.dgr = "Ekleme Başarılı";
            return View();
        }
        public ActionResult YaziGetir(int id)
        {
            var yazi = db.Tbl_Yazilar.Find(id);
            return View(yazi);
        }
        public ActionResult YaziGuncelle(Tbl_Yazilar p1)
        {
            var yazi = db.Tbl_Yazilar.Find(p1.YaziID);
            yazi.YaziIcerik = p1.YaziIcerik;
            yazi.YaziBaslik = p1.YaziBaslik;
            db.SaveChanges();
            return RedirectToAction("YaziListesi");
        }
        public ActionResult YaziSil(int id)
        {
            var yazi = db.Tbl_Yazilar.Find(id);
            db.Tbl_Yazilar.Remove(yazi);
            db.SaveChanges();
            return RedirectToAction("YaziListesi");
        }
    }
}