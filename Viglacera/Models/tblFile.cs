using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblFile
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywork { get; set; }
        public string File { get; set; }
        public string Image { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<int> Cate { get; set; }
        public Nullable<int> idp { get; set; }
        public Nullable<int> idg { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<int> idUser { get; set; }
    }
}
