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
        public static string datastore = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + @"\Playlists\";
        public static string datastore2 = datastore + @"Categories\";

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

        public Category createCategory(string categoryname)
        {
            Category cat = new Category();
            cat.catname = categoryname;

            return cat;
        }

        public void updateCategories(List<Category> categories)
        {
            using (StreamWriter saveFile = File.CreateText(datastore2 + "Categories.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(saveFile, categories);
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

        public List<Category> loadCategories()
        {
            List<Category> item = new List<Category>();
            if (Directory.Exists(datastore2))
            {
                DirectoryInfo d = new DirectoryInfo(datastore2);
                FileInfo f = new FileInfo(d.FullName + "Categories.json");
                if (File.Exists(f.FullName))
                {
                    using (StreamReader r = new StreamReader(f.FullName))
                    {
                        string json = r.ReadToEnd();
                        item = JsonConvert.DeserializeObject<List<Category>>(json);
                    }
                }
                else
                {
                    Category cat = new Category();
                    cat.catname = "Jazz";
                    item.Add(cat);
                    updateCategories(item);
                }
            }
            else
            {
                Directory.CreateDirectory(datastore2);
            }

            return item;
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
