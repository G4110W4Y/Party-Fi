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
        public static Playlist PL = null;
        public static bool host = false;

        // GET: Playlist
        public ActionResult Create(string playlistName = "Party-Fi")
        {
            if (PL == null)
            {
                PL = new Playlist();
                PL.codeGen();
                PL.PLName = playlistName;
                host = true;
            }
            return View(PL);
        }

        public ActionResult Join()
        {
            host = false;
            return View("Join", PL);
        }

        [HttpGet]
        public ActionResult Search(string search)
        {
            PL.searchTracks.Clear();
            PL.searchSong(search);
            return Json(PL.searchTracks, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CurrentSong()
        {
            return PartialView(PL);
        }
        //renders playlist table
        [HttpGet]
        public ActionResult PlaylistTableCreate()
        {
                return PartialView(PL);
        }
        [HttpGet]
        public ActionResult PlaylistTableJoin()
        {
            return PartialView(PL);
        }


        //add song selected from search
        [HttpPost]
        public ActionResult AddSong(string song)
        {
            PL.addSong(song);
            return RedirectToAction("Create");
        }
        //up vote a song
        public ActionResult Up(int? id)
        {
            PL.playlist[(int)id].rank++;
            PL.sort();
            return RedirectToAction("Create");
        }
        //down vote a song
        public ActionResult Down(int? id)
        {
            PL.playlist[(int)id].rank--;
            PL.sort();
            return RedirectToAction("Create");
        }
        //remove a song
        public ActionResult Remove(int? id)
        {
            PL.playlist[(int)id].hasPlayed = true;
            PL.sort();
            return RedirectToAction("Create");
        }
    }
}