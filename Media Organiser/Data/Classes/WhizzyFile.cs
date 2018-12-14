using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Organiser
{
    public class Whizzyfile
    {
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public string Filetype { get; set; }
        public string Filecomment { get; set; }
        public List<Category> FileGenres = new List<Category>();
        public string imagepath { get; set; }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
}
