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
    public class ProfilController : Controller
    {
        FikirsenWebDBEntities3 db = new FikirsenWebDBEntities3();
        [HttpGet]
        public ActionResult Profil()
        {
            var degerler = db.Tbl_Kullanicilar.Where(x => x.KullaniciGirisAd == GirisKayit.girisAd.ToString()).ToList();
            return View(degerler);
        }
    }
}