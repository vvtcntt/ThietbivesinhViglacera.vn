using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblRegister
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
