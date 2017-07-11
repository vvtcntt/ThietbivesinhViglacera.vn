using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblAgency
    {
        public int id { get; set; }
        public Nullable<int> idMenu { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string People { get; set; }
        public string Email { get; set; }
        public string Tag { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Ord { get; set; }
        public string Tabs { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<int> idUser { get; set; }
    }
}
