using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblFunctionProduct
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Images { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
