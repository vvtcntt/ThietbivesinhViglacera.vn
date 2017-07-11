using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblOrderDetail
    {
        public int id { get; set; }
        public Nullable<int> idOrder { get; set; }
        public Nullable<int> idProduct { get; set; }
        public string Name { get; set; }
        public Nullable<int> Quantily { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> SumPrice { get; set; }
    }
}
