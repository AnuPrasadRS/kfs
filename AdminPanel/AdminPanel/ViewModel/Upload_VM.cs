using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AdminPanel.ViewModel
{
    public class Upload_VM
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int NCtgID { get; set; }
        public int Id { get; set; }
        public int Order_O { get; set; }
        public long  NLinkId { get; set; }
        public string Nlink { get; set; }
        public string NCtgName { get; set; }

       // public string File { get; set; }

        [DisplayName("Select File to Upload")]
        public IEnumerable<HttpPostedFileBase> File { get; set; }

    }
    public class Entity_Forms
    {
        public int Id { get; set; }
        public int Order_O { get; set; }
    }
    public class Entity_Links
    {
        public int NLinkId { get; set; }
        public int Norder { get; set; }
    }
}