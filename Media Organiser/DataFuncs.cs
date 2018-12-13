using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Organiser
{
    public class DataFuncs
    {
        //private string datastore = @"../../Data/Playlists/";
        private string datastore = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + @"\Playlists\";

        public bool saveFile(Playlist playlist, string playlistname)
        {
            using (StreamWriter saveFile = File.CreateText(datastore + playlistname + ".json"))
            {
                try
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(saveFile, playlist);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public void createPlaylist(Playlist playlist, string playlistname)
        {
            if (playlist.playlistname == null || playlist.playlistcount == 0 || playlist.whizzyfilelist == null)
            {
                playlist.playlistname = playlistname;
                playlist.playlistcount = playlist.whizzyfilelist != null ? playlist.whizzyfilelist.Count : 0;         
            }
            using (StreamWriter saveFile = File.CreateText(datastore + playlistname + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(saveFile, playlist);
            }
        }

        public Playlist loadPlaylist(string fn)
        {
            Playlist item = new Playlist();
                    using (StreamReader r = new StreamReader(fn))
                    {
                        string json = r.ReadToEnd();
                        item = JsonConvert.DeserializeObject<Playlist>(json);
                    }

            return item;
        }

        public bool checkExists(string playlistName)
        { 
            string[] playlists = Directory.GetFiles(datastore, "*.json").Select(Path.GetFullPath).ToArray();
            bool containsPlaylist = false;

            for (int i = 0; i < playlists.Length; i++)
            {
                if (File.Exists(playlists[i]))
                {
                    containsPlaylist = true;
                }
            }

            return containsPlaylist;
        }
    }
}
