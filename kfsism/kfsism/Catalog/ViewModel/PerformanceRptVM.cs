using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalog.ViewModel
{
    public class PerformanceRptVM
    {
        public vessel_head vesselhead { get; set; }
        public ptwinspection ptwinspection { get; set; }
        public pob pob { get; set; }
        public monthly_rob monthly_rob { get; set; }
        public monthly_activity monthly_activity { get; set; }
        public hselaggingwaste hselaggingwaste { get; set; }
        public hseleadingindent hseleadingindent { get; set; }
    }
}