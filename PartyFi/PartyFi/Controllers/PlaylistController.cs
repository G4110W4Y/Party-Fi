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
        public static Playlist PL;

        // GET: Playlist
        public ActionResult Create(/*string playlistName = "Party-Fi"*/)
        {
            if(PL == null)
            {
                PL = new Playlist();
                PL.codeGen();
            }
            //PL.codeGen();
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
        [HttpPost]
        public ActionResult AddSong(string song)
        {
            PL.addSong(song);
            return RedirectToAction("Create");
        }
        public ActionResult Up(int? id)
        {
            PL.playlist[(int)id].rank++;
            PL.sort();
            return RedirectToAction("Create");
        }
        public ActionResult Down(int? id)
        {
            PL.playlist[(int)id].rank--;
            PL.sort();
            return RedirectToAction("Create");
        }
    }
}