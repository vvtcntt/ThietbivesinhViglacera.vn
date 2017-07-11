using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblCompetitorLink
    {
        public int id { get; set; }
        public Nullable<int> idHomes { get; set; }
        public Nullable<int> idCompetitor { get; set; }
        public string Url { get; set; }
        public Nullable<int> Ord { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<int> idUser { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
