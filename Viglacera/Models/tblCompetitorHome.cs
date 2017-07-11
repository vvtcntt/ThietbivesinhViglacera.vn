using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblCompetitorHome
    {
        public int id { get; set; }
        public string CodeProduct { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> idUser { get; set; }
    }
}
