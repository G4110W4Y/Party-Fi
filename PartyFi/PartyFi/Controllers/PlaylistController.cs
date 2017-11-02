using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyFi.Controllers
{
    public class PlaylistController : Controller
    {
        // GET: Playlist
           public ActionResult Index()
           {
               return View();
           }        
 

        /*What i am trying to do below is read from the file that contains the information we need about the api and store it in client secret and ID 
         * and using the playlist controller to test to see if it worked. But i dont know if its the try block but nothing gets written to. I tested by assigning "pencil"
         * to clientID but it still prints out null.

        public string Index()
        {
            String clientID = null;
            string clientSecret = null;
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"C:\\api.txt");
                clientID = "Pencil"; //file.ReadLine();
                clientSecret = file.ReadLine();

                file.Close();
            }
            catch (Exception e) { }

            return "Client ID: " + clientID +" Client Secret: " + clientSecret;
        }     */
    }
}