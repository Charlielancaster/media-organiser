﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Organiser
{
    public class Category
    {
        public Guid catID = Guid.NewGuid();
        public string catname { get; set; }
    }
}
