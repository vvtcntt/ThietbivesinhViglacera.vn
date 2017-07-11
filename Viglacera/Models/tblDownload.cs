using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblDownload
    {
        public int id { get; set; }
        public Nullable<int> idMenu { get; set; }
        public string Name { get; set; }
        public string NameURL { get; set; }
        public string FileName { get; set; }
        public string HeadShort { get; set; }
        public string ImageName { get; set; }
        public string ImageLink { get; set; }
        public string ImageLinkRoot { get; set; }
        public Nullable<int> State { get; set; }
        public Nullable<int> idUser { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
    }
}
