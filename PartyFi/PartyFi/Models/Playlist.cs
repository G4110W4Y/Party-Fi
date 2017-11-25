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
using System.Web.Script.Serialization;

namespace PartyFi.Models
{
    public class Playlist
    {
        
        public string PLName = "";
        private static SpotifyWebAPI Spotify = new SpotifyWebAPI();
        public IList<Song> playlist = new List<Song>();
        public IList<FullTrack> searchTracks = new List<FullTrack>();
        private static PrivateProfile profile;
        public string code;
        public string currentSong = "nothing";
        public Timer timer;
        public string json;

        public Playlist()
        {
            Task.Run(() => Authentication());
            timer = new Timer(Advance);
        }

        public void Advance(Object sender)
        {
            // i wanted t oqueue songs when the current is close to ending but you can't actually see the user's position in the currently playing song
            // What if we poll the size of the playlist list we have? if count !=0, add the first song in the list to the queue  and remove it from the list?
            timer.Dispose();
            timer = new Timer(Advance);
            if (playlist.Count > 0)
            {
                playSong(playlist[0].ID);
                current(playlist[0].ID);
                timer.Change(/*playlist[0].length*/ 30000, playlist[0].length);

                playlist.RemoveAt(0);
            }
        }

        public void current(string ID)
        {
            for (int x = 0; x < playlist.Count; x++)
                if (playlist[x].ID == ID)
                {
                    //currentSong = playlist[x].song + "  Artist: " + playlist[x].artist;
                    currentSong = playlist[x].artist + " - " + playlist[x].song;
                }

        }

        public async void Trest()
        {
            // Some ghostemane--nah fam
            addSong("3FtYbEfBqAlGO46NUDQSAt");
            // Some weeb shit
            addSong("2pxftVTI1ACfpvcryvebxd");
            // Some basic shit
            addSong("060X6dRG9lWF1sp8y1ssYe");
            // If i have to hear the first 10 seconds of "Boys" one more time i fucking swear i will delete the entire internet
            //       ErrorResponse error = Spotify.ResumePlayback(uris: new List<string> { "spotify:track:1gei6SEOLzPjMGY2TA95nq" });      //test play
            // Play the song for 30 seconds before going into the main queueing system
            timer.Change(30000, 30000);
        }

        public async void Authentication()
        {
            WebAPIFactory webApiFactory = new WebAPIFactory(
            "http://localhost",
            8000,
            "ba75619adcea46109349a260a683d184",   //Client ID
            Scope.UserReadPrivate | Scope.Streaming,
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

        //public static void createPlaylist(string name)
        //{
        //    string profileID = profile.Id;
        //    FullPlaylist newPlaylist = Spotify.CreatePlaylist(profileID, name);
        //    string playlistID = newPlaylist.Id;
        //    ErrorResponse response = Spotify.AddPlaylistTracks(profileID, playlistID, new List<string> { "5WggjuxMubr94bo33Aan4K", "6ORDSA2FoPpoCZzqoDaX8E", "32zkKx35Et6A515oZKxDkD" });
        //}

        public void searchSong(string search)
        {
            string query = search.Replace(' ', '+');
            SearchItem item = Spotify.SearchItems(query, SearchType.Track);

            foreach (FullTrack track in item.Tracks.Items)
            {
                searchTracks.Add(track);
            }
        }

        public void playSong(string uri)
        {
            string current = "spotify:track:" + uri;
            ErrorResponse error = Spotify.ResumePlayback(uris: new List<string> { current });
        }

        public void addSong(string URI)
        {
            FullTrack track = Spotify.GetTrack(URI);
            string laArtista = track.Artists[0].Name;
            string name = track.Name;
            Song newsong = new Song() { ID = URI, rank = 1, song = name, artist = laArtista, hasPlayed = false, length = track.DurationMs };
            // if a rank goes below 1, we need to be sure to insert the new song before that spot in the list
            // hahaha i lied. let's just make a sorting function to sort hte list everytime we add shit. (sort by rank, and preserve original order)
            playlist.Add(newsong);
            sort();

            //Json();

            //if(playlist.Count == 0)
            //{
            //    playlist.Add(newsong);
            //}
            //for (int i = 0; i < playlist.Count; i++)
            //{
            //    if (newsong.rank < playlist[i].rank)
            //    {
            //        continue;
            //    }
            //    else if (i == playlist.Count - 1)
            //    {
            //        playlist.Add(newsong);
            //    }
            //    else
            //    {
            //        playlist.Insert(i, newsong);
            //    }
            //}
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
            //code = aminuls[gen.Next(aminuls.Count())] + gen.Next(1000);
            code = "Popeyes89";
        }
        public void sort()
        {
            for (int x = 0; x < playlist.Count; x++)
            {
                if (playlist[x].hasPlayed == true)
                {
                    playlist.RemoveAt(x);
                }
            }
            playlist = playlist.OrderByDescending(x => x.rank).ToList();
            //for(int i = 0; i<playlist.Count-2; i++)
            //{
            //    if (playlist[i].rank > playlist[i +].rank)
            //    {
            //        playlist.
            //    }
            //}
        }

    }
}