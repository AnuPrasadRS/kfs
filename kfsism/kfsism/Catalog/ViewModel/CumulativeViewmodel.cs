using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalog.ViewModel
{
    public class CumulativeViewmodel
    {

    }
    public class CategoriesVM
    {
        public int  CategID { get; set; }
        public string CatgName { get; set; }
    }
    public partial class vessel_headVM
    {
        public int id { get; set; }
        public int ShipsId { get; set; }
        public string vessel { get; set; }
        public string type { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string navigation { get; set; }
        public string imono { get; set; }
        public string manhours { get; set; }
        public string master { get; set; }
        public string chiefofficer { get; set; }
        public string chiefengineer { get; set; }
        public string location { get; set; }
        public Nullable<int> EnteredBY { get; set; }
    }
    public class Monthly_ActivityVM
    {
        public int id { get; set; }
        public int head_id { get; set; }
        public string steamingtime { get; set; }
        public string steamingconsumption { get; set; }
        public string steamingmcr { get; set; }
        public string anchoragetime { get; set; }
        public string anchorageconsumption { get; set; }
        public string anchoragemcr { get; set; }
        public string berthtime { get; set; }
        public string berthconsumption { get; set; }
        public string berthmcr { get; set; }
        public string towingtime { get; set; }
        public string towingconsumption { get; set; }
        public string towingmcr { get; set; }
        public string downtime { get; set; }
        public string downconsumption { get; set; }
        public string downmcr { get; set; }
        public string meneauveringtime { get; set; }
        public string meneauveringconsumption { get; set; }
        public string meneauveringmcr { get; set; }
        public string otherstime { get; set; }
        public string othersconsumption { get; set; }
        public string othersmcr { get; set; }
        public string remarkstime { get; set; }
        public string remarksconsumption { get; set; }
        public string remarksmcr { get; set; }
    }
}