using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblMap
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<int> UserID { get; set; }
    }
}
