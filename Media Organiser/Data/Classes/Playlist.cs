using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Organiser
{
    public class Playlist
    {

        public Guid playlistID = Guid.NewGuid();
        public string playlistname { get; set; }
        public int playlistcount { get; set; }
        public List<Whizzyfile> whizzyfilelist { get; set; }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
}
