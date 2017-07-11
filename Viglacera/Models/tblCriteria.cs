using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblCriteria
    {
        public int id { get; set; }
        public Nullable<int> idCate { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Priority { get; set; }
        public Nullable<bool> Style { get; set; }
        public Nullable<int> Ord { get; set; }
    }
}
