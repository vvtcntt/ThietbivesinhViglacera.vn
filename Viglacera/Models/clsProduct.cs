using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Viglacera.Models
{
    public class clsProduct
    {
        public int id
        {
            get;
            set;
        }
        public int idMenu
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Tag
        {
            get;
            set;
        }
        public int Ord
        {
            get;
            set;
        }
        public float Price
        {
            get;
            set;
        }
        public float SumPrice
        {
            get;
            set;
        }
    }
}