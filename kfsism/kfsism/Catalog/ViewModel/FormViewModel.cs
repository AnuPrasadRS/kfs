
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalog.ViewModel
{
    public class FormViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Action { get; set; }
        public Nullable<int> Order_O { get; set; }
        public Nullable<int> Category { get; set; }
    }

}