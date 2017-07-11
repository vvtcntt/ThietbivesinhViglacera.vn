using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblSupport
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Yahoo { get; set; }
        public string Skyper { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Mission { get; set; }
        public string Images { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> idUser { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
    }
}
