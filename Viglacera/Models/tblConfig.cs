using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblConfig
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Logo { get; set; }
        public string Favicon { get; set; }
        public Nullable<bool> Popup { get; set; }
        public Nullable<bool> PopupSupport { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileIN { get; set; }
        public string HotlineIN { get; set; }
        public string MobileOUT { get; set; }
        public string HotlineOUT { get; set; }
        public string Email { get; set; }
        public string Slogan { get; set; }
        public string Authorship { get; set; }
        public string FanpageFacebook { get; set; }
        public string FanpageGoogle { get; set; }
        public string FanpageYoutube { get; set; }
        public string AppFacebook { get; set; }
        public string Analytics { get; set; }
        public string GoogleMaster { get; set; }
        public string GeoMeta { get; set; }
        public string DMCA { get; set; }
        public string CodeChat { get; set; }
        public string BCT { get; set; }
        public string BNI { get; set; }
        public string SKH { get; set; }
        public Nullable<bool> Coppy { get; set; }
        public Nullable<bool> Social { get; set; }
        public string UserEmail { get; set; }
        public string PassEmail { get; set; }
        public string Host { get; set; }
        public Nullable<int> Port { get; set; }
        public string Color { get; set; }
        public Nullable<int> Timeout { get; set; }
        public Nullable<int> Language { get; set; }
    }
}
