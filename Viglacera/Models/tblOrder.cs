using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblOrder
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Mobiles { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Name1 { get; set; }
        public string Address1 { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile1s { get; set; }
        public string Email1 { get; set; }
        public string NameCP { get; set; }
        public string AddressCP { get; set; }
        public string MST { get; set; }
        public Nullable<int> TypePay { get; set; }
        public Nullable<int> TypeTransport { get; set; }
        public Nullable<double> Tolar { get; set; }
        public Nullable<System.DateTime> DateByy { get; set; }
        public Nullable<int> idUser { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
