using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblVideo
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<bool> AutoPlay { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<int> idUser { get; set; }
    }
}
