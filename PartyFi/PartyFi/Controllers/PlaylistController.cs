using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyFi.Controllers
{
    public class PlaylistController : Controller
    {
        /* // GET: Playlist
            public ActionResult Index()
            {
                return View();
            }        
  */

        public string Index()
        {
            String clientID = null;
            string clientSecret = null;
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"api.txt"); //This is your specific file path to api.txt
                clientID = file.ReadLine();
                clientSecret = file.ReadLine();

                file.Close();
            }
            catch (Exception e) { }

            return "Client ID: " + clientID + " Client Secret: " + clientSecret;
        }
    }
}