using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class HistoryView
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Task { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
    }
}
