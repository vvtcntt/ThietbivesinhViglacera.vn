using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblGroupProduct
    {
        public int id { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string Content { get; set; }
        public Nullable<int> Ord { get; set; }
        public string Tag { get; set; }
        public Nullable<bool> Priority { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Note { get; set; }
        public string Images { get; set; }
        public string Background { get; set; }
        public string iCon { get; set; }
        public string Color { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<int> idUser { get; set; }
    }
}
