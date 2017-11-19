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
        public static Playlist PL = new Playlist();

        // GET: Playlist
        public ActionResult Create(/*string playlistName = "Party-Fi"*/)
        {
            PL.codeGen();
            return View(PL);
        }

        //needs to be adjusted for guests
        public ActionResult Join() {
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Search(string search) {
            PL.searchTracks.Clear();
            PL.searchSong(search);
            return Json(PL.searchTracks, JsonRequestBehavior.AllowGet);
        }

    }
}