using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyFi.Models
{
    public class Song
    {
        public string ID { get; set; }
        public int rank { get; set; }
        public string song { get; set; }
        public string artist { get; set; }
        public bool hasPlayed { get; set; }


    }
}