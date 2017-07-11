using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblHistoryLogin
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string Task { get; set; }
        public Nullable<int> idUser { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
