using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FikirsenWebSitesi_ASPNET_MVC.Models.entities;
namespace FikirsenWebSitesi_ASPNET_MVC.Controllers
{
    public class AnaSayfaController : Controller
    {
        FikirsenWebDBEntities3 db = new FikirsenWebDBEntities3();
        // GET: AnaSayfa
        [Authorize]
        public ActionResult AnaSayfa(int? sayfa=1)
        {
            int _sayfa = sayfa ?? 1;
            var degerler = db.Tbl_Yazilar.ToList().ToPagedList<Tbl_Yazilar>(_sayfa,2);
            return View(degerler);
        }
    }
}