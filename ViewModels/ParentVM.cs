using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1262228_Arosh.ViewModels
{
    public class ParentVM
    {
        public int ParentID { get; set; }
        public string Name { get; set; }
        public Nullable<int> NID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public Nullable<int> Income { get; set; }
        public string Address { get; set; }
    }
}