using System;
using System.Collections.Generic;

namespace Viglacera.Models
{
    public partial class tblUser
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> idModule { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public Nullable<int> idUser { get; set; }
    }
}
