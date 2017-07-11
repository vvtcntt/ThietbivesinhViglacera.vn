using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblInfoCriteria
    {
        public int id { get; set; }
        public Nullable<int> idCri { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Nullable<int> type { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
