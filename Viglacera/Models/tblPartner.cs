using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblPartner
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Hotline { get; set; }
        public string Email { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<int> idUser { get; set; }
    }
}
