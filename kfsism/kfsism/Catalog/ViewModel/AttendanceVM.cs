using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalog
{
    public class AttendanceVM
    {
        public int AttendanceId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }
        public string deletelink { get; set; }
        public Nullable<System.DateTime> EnteredOn { get; set; }
    }
}