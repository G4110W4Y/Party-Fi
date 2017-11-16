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
        public Playlist PL = new Playlist();

        // GET: Playlist
        public ActionResult Create(/*string playlistName = "Party-Fi"*/)
        {
            PL.codeGen();
            return View(PL);
            //return RedirectToAction("ViewPL", "Playlist");
        }

        public ActionResult Search(string search)
        {
            return View("~/Views/Playlist/Create.cshtml", search);
        }

        //public ActionResult ViewPL(/*string playlistName = "Party-Fi"*/)
        //{
        //    return View(PL);
        //}

        //needs to be adjusted for guests
        public ActionResult Join() {
            return RedirectToAction("Create");
        }

    }
}