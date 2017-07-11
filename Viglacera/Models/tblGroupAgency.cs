using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblGroupAgency
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public Nullable<int> Ord { get; set; }
        public string Level { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> idUser { get; set; }
    }
}
