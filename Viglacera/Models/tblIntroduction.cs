using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblIntroduction
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> iView { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<int> idUser { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
    }
}
