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
        public List<string> keys = new List<string>();
        public HomeViewModel view = new HomeViewModel();

        [HttpGet]
        public ActionResult Index()
        {
            return View(view);
        }

        public ActionResult Create(string plName) {
            return RedirectToAction("Create", "Playlist", new { playlistName = plName });
        }

        public ActionResult Join()
        {
            return RedirectToAction("Join", "Playlist");
        }

        public ActionResult ValidateCode()
        {
            //asking to validate to create an instance of playlist
            //this.temp.stuff.Add("Popeyes89", new Playlist());
            keys.Add("Popeyes89");
            return Json(this.keys, JsonRequestBehavior.AllowGet);
        }
    }
}