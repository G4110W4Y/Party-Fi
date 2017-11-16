using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Local.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;


namespace PartyFi.Models
{
    public class Playlist
    {
        //public string holdThis = "";

        private static SpotifyWebAPI Spotify = new SpotifyWebAPI();
        public IList<Song> playlist = new List<Song>();
        private static PrivateProfile profile;
        public string code;
        public Timer timer;

        public Playlist()
        {
            Task.Run(() => Authentication());
            timer = new Timer(Advance);
            timer.Change(0, 500);
        }
     
        public void Advance(Object sender)
        {
            // i wanted t oqueue songs when the current is close to ending but you can't actually see the user's position in the currently playing song
            // What if we poll the size of the playlist list we have? if count !=0, add the first song in the list to the queue  and remove it from the list?
        }

        public async void Trest()
        {
            ErrorResponse error = Spotify.ResumePlayback(uris: new List<string> { "spotify:track:5o4yGlG0PfeVUa6ClIyOxq", "spotify:track:7ccI9cStQbQdystvc6TvxD" });
            System.Threading.Thread.Sleep(10000);
            error = Spotify.SkipPlaybackToNext();
        }
        public async void Authentication()
        {
            WebAPIFactory webApiFactory = new WebAPIFactory(
            "http://localhost",
            8000,
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
            Trest();
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
            Song newsong = new Song() { ID = URI, rank = 1, song = name, artist = artist, hasPlayed = false };
            // if a rank goes below 1, we need to be sure to insert the new song before that spot in the list
            for (int i = 0; i < playlist.Count; i++)
            {
                if (newsong.rank < playlist[i].rank)
                {
                    continue;
                }
                else if (i == playlist.Count - 1)
                {
                    playlist.Add(newsong);
                }
                else
                {
                    playlist.Insert(i, newsong);
                }
            }
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