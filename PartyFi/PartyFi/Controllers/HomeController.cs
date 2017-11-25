using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyFi.Models;

namespace PartyFi.Controllers
{
    public class HomeController : Controller
    {
        public keys temp = new keys();
        public HomeViewModel view = new HomeViewModel();

        //NEEDS TO ACCOUNT FOR BAD CODES
        [HttpGet]
        public ActionResult Index()
        {
            //view.badCode = badCode;
            return View(view);
        }

        public ActionResult Create(string plName) {
            return RedirectToAction("Create", "Playlist", new { playlistName = plName });
        }

        public ActionResult Join()
        {
            temp.stuff.Add("Popeyes89", new Playlist());

            return RedirectToAction("Join", "Playlist");
        }

        public ActionResult ValidateCode()
        {
            return Json(new List<String>(temp.stuff.Keys), JsonRequestBehavior.AllowGet);
        }
    }
}