using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblGroupNew
    {
        public int id { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string Tag { get; set; }
        public Nullable<bool> Index { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Images { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<int> idUser { get; set; }
    }
}
