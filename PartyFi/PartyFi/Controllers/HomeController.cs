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
        public ActionResult Index(bool badCode = false)
        {
            view.badCode = badCode;
            return View(view);
        }

        public ActionResult Create(string plName) {
            return RedirectToAction(/*"Authenticate"*/"Create", "Playlist", new { playlistName = plName });
        }

        public ActionResult Join(string codeInput)
        {
            temp.stuff.Add("Popeyes89", new Playlist());

            if (temp.stuff.ContainsKey(codeInput))
                return RedirectToAction("Join", "Playlist");
            else
                return RedirectToAction("Index", new {badCode = true});
        }
    }
}