using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class ProductConnect
    {
        public int id { get; set; }
        public Nullable<int> idSyn { get; set; }
        public string idpd { get; set; }
        public string Content { get; set; }
        public string Parameter { get; set; }
    }
}
