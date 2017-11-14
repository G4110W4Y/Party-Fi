using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyFi.Models;

namespace PartyFi.Controllers
{
    public class PlaylistController : Controller
    {
        public Playlist PL = null; //new Playlist();

        public void Authenticate(string playlistName = "Party-Fi")
        {
            PL = new Playlist();
            PL.codeGen();
            //return RedirectToAction("Create", "Playlist");
        }

        // GET: Playlist
        public ActionResult Create(/*string playlistName = "Party-Fi"*/)
        {
            //PL.codeGen();
            Authenticate();
            return View(PL);
        }

        //Possibly add a different view to look at playlist
        //public ActionResult ViewPL()
        //{

        //}

        //needs to be adjusted for guests
        public ActionResult Join() {
            return RedirectToAction("Create");
        }

    }
}