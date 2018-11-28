using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalog
{
    public class NcategoryVM
    {
        public int NCtgID { get; set; }
        public string NCtgName { get; set; }
        public bool? NCtgStatus { get; set; }
        public List<NForm> Nforms { get; set; }

    }
    public class NFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> NCategory { get; set; }
        public Nullable<int> Order_O { get; set; }
        public List<NLink> Nlinks { get; set; }


    }
    public class NLinksVM
    {
        public long NLinkId { get; set; }
        public Nullable<int> NformId { get; set; }
        public string Nlink1 { get; set; }
        public string FolderPath { get; set; }
        public int Norder { get; set; }


    }
}