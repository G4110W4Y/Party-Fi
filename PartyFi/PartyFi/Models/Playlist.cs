using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpotifyAPI;
using SpotifyAPI.Local.Enums;
using SpotifyAPI.Local.Models;
using Newtonsoft.Json;
using SpotifyAPI.Local;

namespace PartyFi.Models
{
    public class Playlist
    {
        /*  String clientID = null;
          string clientSecret = null;
              try
              {
                  System.IO.StreamReader file = new System.IO.StreamReader(@"api.txt"); //This is your specific file path to api.txt
                  clientID = file.ReadLine();
                  clientSecret = file.ReadLine();

                  file.Close();
              }
              catch (Exception e) { }   */

        private string clientId = "ba75619adcea46109349a260a683d184";
        private string clientSecret = "e1cb33530db7428590f0526ac184c62e";

        private static SpotifyLocalAPI spotify;

        public static void Main(String[] args)
        {
            spotify = new SpotifyLocalAPI();

            if (!SpotifyLocalAPI.IsSpotifyRunning())
                return; //Make sure the spotify client is running
            if (!SpotifyLocalAPI.IsSpotifyWebHelperRunning())
                return; //Make sure the WebHelper is running

            if (!spotify.Connect())
                return; //We need to call Connect before fetching infos, this will handle Auth stuff

            StatusResponse status = spotify.GetStatus(); //status contains infos

            spotify.PlayURL("5rLwnbPExWwiPbScCNlvxC", "");
            SpotifyResource name = status.Track.TrackResource;
        }

        public static int randomID()
        {
            Random rand = new Random();
            int ID = rand.Next(10000, 99999);
            return ID;
        }



    }
}