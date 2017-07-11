using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblProductSale
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CodeOne { get; set; }
        public string CodeTrue { get; set; }
        public string CodeSale { get; set; }
        public string Content { get; set; }
        public string Slogan { get; set; }
        public string TextRun { get; set; }
        public Nullable<System.DateTime> StartSale { get; set; }
        public Nullable<System.DateTime> StopSale { get; set; }
        public string ImageBanner { get; set; }
        public string ImageSale { get; set; }
        public string ImageThumb { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Ord { get; set; }
        public string Tag { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<int> UserID { get; set; }
    }
}
