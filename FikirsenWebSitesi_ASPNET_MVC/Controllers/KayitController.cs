using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FikirsenWebSitesi_ASPNET_MVC.Models;
using FikirsenWebSitesi_ASPNET_MVC.Models.entities;
namespace FikirsenWebSitesi_ASPNET_MVC.Controllers
{
    public class KayitController : Controller
    {
        // GET: Kayit
        FikirsenWebDBEntities3 db = new FikirsenWebDBEntities3();
        [HttpGet]
        public ActionResult KayitYap()
        {
            return View();
        }
        public ActionResult KayitKullanici(Tbl_Kullanicilar kullanici)
        {
            db.Tbl_Kullanicilar.Add(kullanici);
            db.SaveChanges();
            return RedirectToAction("Giris", "Security");
        }
    
    }
}