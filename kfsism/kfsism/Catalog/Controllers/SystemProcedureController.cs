using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalog.Controllers
{
    [SessionAuthorize(Roles = "Users")]

    public class SystemProcedureController : Controller
    {

        // GET: SystemProcedure
        public ActionResult Landing_Craft_Operations_Procedure() { return View(); }
        public ActionResult Purchasing() { return View(); }
        public ActionResult New_External_Provider_Selection() { return View(); }
        public ActionResult Passage_Planning() { return View(); }
        public ActionResult External_Provider_Performance_Evaluation() { return View(); }
        public ActionResult General_Deck_Safety() { return View(); }
        public ActionResult Logistics_Management() { return View(); }
        public ActionResult Navigation_and_Communication_Equipment() { return View(); }
        public ActionResult Lifesaving_appliances_firefighting_equipment() { return View(); }
        public ActionResult General_Procedure_Routine_Standards() { return View(); }
        public ActionResult Personal_conduct_on_board() { return View(); }
        public ActionResult Anchoring_and_Mooring_procedure() { return View(); }
        public ActionResult Shipboard_Op_Maintenance_Bunkering_Procedure() { return View(); }
        public ActionResult Hydrogen_Sulfide() { return View(); }
        public ActionResult Work_aloft_and_shipside() { return View(); }
        public ActionResult Confined_Space_Entry() { return View(); }
        public ActionResult Navigation() { return View(); }
        public ActionResult Emergency_Preparednes_and_Response() { return View(); }
        public ActionResult Making_Fast_and_Casting_Off() { return View(); }
        public ActionResult Chemical_Handling() { return View(); }
        public ActionResult Accident_Incident_Investigation() { return View(); }
        public ActionResult Cargo_Handling_Stowage_and_Securing() { return View(); }
        public ActionResult Lockout_Tagouo_LOTO() { return View(); }
        public ActionResult Control_of_Nonconforming_Services() { return View(); }
        public ActionResult Towing_Procedure() { return View(); }
        public ActionResult Waste_Management() { return View(); }
        public ActionResult Corrective_Actio_Preventive_Action() { return View(); }
        public ActionResult Watch_Keeping() { return View(); }
        public ActionResult Documented_Information() { return View(); }
        public ActionResult Vessel_Documentation() { return View(); }
        public ActionResult Records_and_Control_Records() { return View(); }
        public ActionResult Ship_Familiarization_procedure() { return View(); }
        public ActionResult Performance_Measuremen_and_Monitoring() { return View(); }
        public ActionResult Anchor_Handling_Tug() { return View(); }
        public ActionResult Internal_IMS_Audit() { return View(); }
        public ActionResult Passenger_Ship_Safety() { return View(); }
        public ActionResult Management_Review() { return View(); }
        public ActionResult Control_Monitoring_Measuring_Services() { return View(); }
        public ActionResult Monitoring_Measurement_Analysis() { return View(); }
        public ActionResult Maintenance_Vessels_Equipment_Damage() { return View(); }
        public ActionResult Evaluation_of_Compliance() { return View(); }
        public ActionResult Repair_and_Dry_docking() { return View(); }
        public ActionResult Purchase() { return View(); }
        public ActionResult Ship_Survey_Certificate() { return View(); }
        public ActionResult Store_Management() { return View(); }
        public ActionResult Bunker_Operations() { return View(); }
        public ActionResult Chartering_and_Tendering() { return View(); }
        public ActionResult Customer_Relations() { return View(); }
        public ActionResult International_Maritime_Dangerous_Cargo() { return View(); }
        public ActionResult Information_Technology() { return View(); }
        public ActionResult Vessel_Lay_Procedure() { return View(); }
        public ActionResult Occupational_Health_Management() { return View(); }
        public ActionResult Crew_Transfer() { return View(); }
        public ActionResult Identification_and_Traceability() { return View(); }
        public ActionResult Crew_Boat_Operations() { return View(); }
        public ActionResult Vendor_Subcontractor_Management() { return View(); }
        public ActionResult Asset_Management() { return View(); }

    }
}