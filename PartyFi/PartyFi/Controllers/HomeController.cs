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
        keys activeParties = new keys();

        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Create(string plName) {
            return RedirectToAction("Create", "Playlist", new { playlistName = plName });
        }

        //public ActionResult Join(string codeInput) {
            
        //}
    }
}