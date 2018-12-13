using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Organiser
{
    public class Funcs
    {

        public Playlist addListToExistingPlaylist(Playlist playlist, List<Whizzyfile> wfiles)
        {
            playlist.whizzyfilelist.AddRange(wfiles);
            playlist.playlistcount = playlist.whizzyfilelist.Count;

            return playlist;
        }
    }
}
