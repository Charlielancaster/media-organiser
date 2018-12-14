using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Organiser
{
    public class Funcs
    {
        static DataFuncs datafuncs = new DataFuncs();
        static private string playlists = DataFuncs.datastore;
        static private string categories = DataFuncs.datastore2;
        protected List<Category> allcategories = new List<Category>();

        public Playlist addListToExistingPlaylist(Playlist playlist, List<Whizzyfile> wfiles)
        {
            playlist.whizzyfilelist.AddRange(wfiles);
            playlist.playlistcount = playlist.whizzyfilelist.Count;

            return playlist;
        }

        public List<Playlist> loadPlaylists(ListView listView, List<Playlist> playlist)
        {
            List<Playlist> retlist = new List<Playlist>();
            listView.Items.Clear();
            playlist.Clear();
            if (Directory.Exists(playlists))
            {
                DirectoryInfo d = new DirectoryInfo(playlists);
                foreach (FileInfo f in d.GetFiles())
                {
                    retlist.Add(datafuncs.loadPlaylist(f.FullName));
                }
            }
            else
            {
                Directory.CreateDirectory(playlists);
            }
            foreach (Playlist p in retlist)
            {
                listView.Items.Add(p.playlistname).SubItems.Add(p.playlistID.ToString());
            };

            return retlist;
        }

        public void populateListView (ListView listview, Playlist playlist)
        {
            listview.Items.Clear();
            if (playlist != null && playlist.whizzyfilelist != null)
            {
                foreach (Whizzyfile wfl in playlist.whizzyfilelist)
                {
                    string listcategories = "";
                    if (wfl.Filecomment == null) { wfl.Filecomment = " "; }
                    if (wfl.FileGenres != null)
                    {
                        int count = 1;
                        foreach (Category c in wfl.FileGenres)
                        {
                            listcategories += count < wfl.FileGenres.Count ? c.catname + ", " : c.catname;
                            count++;
                        }
                    }
                    string[] row = { wfl.Filepath, wfl.Filetype, wfl.Filecomment, wfl.imagepath, listcategories };
                    listview.Items.Add(wfl.Filename).SubItems.AddRange(row);
                }
            }
        }
    }
}
