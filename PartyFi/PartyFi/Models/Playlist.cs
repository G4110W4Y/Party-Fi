using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Local.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyFi.Models
{
    public class Playlist
    {
        //public string holdThis = "";

        private static SpotifyWebAPI Spotify = new SpotifyWebAPI();
        public IList<Song> playlist; 
        private static PrivateProfile profile;
        public string code;

        public Playlist() {
            //Authentication();
        }

        public async void Authentication()
        {
            WebAPIFactory webApiFactory = new WebAPIFactory(
            "http://localhost/Home/Create",
            51107,
            "ba75619adcea46109349a260a683d184",   //Client ID
            Scope.UserReadPrivate,
            TimeSpan.FromSeconds(20)
            );
           
            try
            {
                //This will open the user's browser and returns once
                //the user is authorized.
                Spotify = await webApiFactory.GetWebApi();
                profile = Spotify.GetPrivateProfile();
            
            }
            catch (Exception ex)
            {
              }

            if (Spotify == null)
                return;
        }

        public static void createPlaylist(string name)
        {
            string profileID = profile.Id;
            FullPlaylist newPlaylist = Spotify.CreatePlaylist(profileID, name);
            string playlistID = newPlaylist.Id;
            ErrorResponse response = Spotify.AddPlaylistTracks(profileID, playlistID, new List<string> { "5WggjuxMubr94bo33Aan4K", "6ORDSA2FoPpoCZzqoDaX8E", "32zkKx35Et6A515oZKxDkD" });
        }

        public void addSong(string URI)
        {
            FullTrack track = Spotify.GetTrack(URI);
            FullArtist artisto = Spotify.GetArtist(URI);
            string artist = artisto.Name;
            string name = track.Name;
            playlist = new List<Song>() { new Song() { ID = URI, rank = 1, song = name, artist = artist, hasPlayed = false } };
        }

        public void codeGen()
        {
            List<string> aminuls = new List<String>
            {
                "SlipperyDick",
                "Cat",
                "Dog",
                "Horse",
                "Emu",
                "Alpaca",
                "Raven",
                "Ocelot",
                "Rhino",
                "Goat",
                "BlueFootedBooby",
                "Chinchilla",
                "Pupper",
                "Wombat",
                "Shark",
                "MantisShrimp",
                "Turtle",
                "Cuttlefish",
                "Octopus",
                "Hedgehog",
                "Dolphin",
                "Otter"
            };
            Random gen = new Random();
            code = aminuls[gen.Next(aminuls.Count())] + gen.Next(1000);
        }

    }
}