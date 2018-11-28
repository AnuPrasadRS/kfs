using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Catalog.Models;
using Catalog.ViewModel;
using Catalog.Controllers;
using System.Data.Entity;

namespace Catalog.Helpers
{
    public class ReportHelper
    {
        private CatalogEntities db = new CatalogEntities();
        public int Add_vessel_head(ReportViewModel report)
        {
            try
            {
                vessel_head head = new vessel_head
                {
                    ShipsId = report.ShipsId,
                    EnteredBY = Convert.ToInt32(HttpContext.Current.Session["UserID"]),
                    date = report.date,
                    vessel = report.vessel,
                    type = report.type,
                    navigation = report.navigation,
                    imono = report.imono,
                    manhours = report.manhours,
                    master = report.master,
                    chiefofficer = report.chiefofficer,
                    chiefengineer = report.chiefengineer,
                    location = report.location,
                };
                db.vessel_head.Add(head);
                db.SaveChanges();
                return head.id;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public bool Add_ptwinspection(int head_id, ReportViewModel report)
        {
            try
            {
                ptwinspection ptwins = new ptwinspection
                {
                    head_id = head_id,
                    hot_m = report.hot_m,
                    hot_y = report.hot_y,
                    cold_m = report.cold_m,
                    cold_y = report.cold_y,
                    aloft_m = report.aloft_m,
                    aloft_y = report.aloft_y,
                    confined_m = report.confined_m,
                    confined_y = report.confined_y,
                    diving_m = report.diving_m,
                    diving_y = report.diving_y,
                    electrical_m = report.electrical_m,
                    electrical_y = report.electrical_y,
                    firstaid = report.firstaid,
                    firefighting = report.firefighting,
                    mess = report.mess,
                    toilet = report.toilet,
                    pms = report.pms,
                    galley = report.galley,
                    lifesaving = report.lifesaving,
                    towing_inspect = report.towing_inspect,
                    radio_inspect = report.radio_inspect,
                    hull_inspect = report.hull_inspect,
                    remark = report.remark,

                };
                db.ptwinspections.Add(ptwins);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Add_Pob(int head_id, ReportViewModel report)
        {
            try
            {
                pob pob = new pob
                {
                    head_id = head_id,
                    pobcrew = report.pobcrew,
                    pobcharterers = report.pobcharterers,
                    pobkfc = report.pobkfc,
                    pobothers = report.pobothers,
                    pobtotal = report.pobtotal,
                    remarkscrew = report.remarkscrew,
                    remarkscharterers = report.remarkscharterers,
                    remarkskfc = report.remarkskfc,
                    remarksothers = report.remarksothers,

                };
                db.pobs.Add(pob);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Add_Monthly_Rob(int head_id, ReportViewModel report)
        {
            try
            {
                monthly_rob montrob = new monthly_rob
                {
                    head_id = head_id,
                    openingfuel = report.openingfuel,
                    openingfreshwater = report.openingfreshwater,
                    openingloil = report.openingloil,
                    openinghoil = report.openinghoil,
                    openinggoil = report.openinggoil,
                    receivedfuel = report.receivedfuel,
                    receivedfreshwater = report.receivedfreshwater,
                    receivedloil = report.receivedloil,
                    receivedhoil = report.receivedhoil,
                    receivedgoil = report.receivedgoil,
                    closingfuel = report.closingfuel,
                    closingfreshwater = report.closingfreshwater,
                    closingloil = report.closingloil,
                    closinghoil = report.closinghoil,
                    closinggoil = report.closinggoil,
                    consumedfuel = report.consumedfuel,
                    consumedfreshwater = report.consumedfreshwater,
                    consumedloil = report.consumedloil,
                    consumedhoil = report.consumedhoil,
                    consumedgoil = report.consumedgoil,
                    deliveredfuel = report.deliveredfuel,
                    deliveredfreshwater = report.deliveredfreshwater,
                    deliveredloil = report.deliveredloil,
                    deliveredhoil = report.deliveredhoil,
                    deliveredgoil = report.deliveredgoil,
                    deliveredkfcfuel = report.deliveredkfcfuel,
                    deliveredkfcfreshwater = report.deliveredkfcfreshwater,
                    deliveredkfcloil = report.deliveredkfcloil,
                    deliveredkfchoil = report.deliveredkfchoil,
                    deliveredkfcgoil = report.deliveredkfcgoil,
                    menginerunninghrsfuel = report.menginerunninghrsfuel,
                    menginerunninghrsfreshwater = report.menginerunninghrsfreshwater,
                    menginerunninghrsloil = report.menginerunninghrsloil,
                    menginerunninghrshoil = report.menginerunninghrshoil,
                    menginerunninghrsgoil = report.menginerunninghrsgoil,
                    menginefuelconsfuel = report.menginefuelconsfuel,
                    menginefuelconsfreshwater = report.menginefuelconsfreshwater,
                    menginefuelconsloil = report.menginefuelconsloil,
                    menginefuelconshoil = report.menginefuelconshoil,
                    menginefuelconsgoil = report.menginefuelconsgoil,
                    aenginerunninghrsfuel = report.aenginerunninghrsfuel,
                    aenginerunninghrsfreshwater = report.aenginerunninghrsfreshwater,
                    aenginerunninghrsloil = report.aenginerunninghrsloil,
                    aenginerunninghrshoil = report.aenginerunninghrshoil,
                    aenginerunninghrsgoil = report.aenginerunninghrsgoil,
                    aenginefuelconsfuel = report.aenginefuelconsfuel,
                    aenginefuelconsfreshwater = report.aenginefuelconsfreshwater,
                    aenginefuelconsloil = report.aenginefuelconsloil,
                    aenginefuelconshoil = report.aenginefuelconshoil,
                    aenginefuelconsgoil = report.aenginefuelconsgoil,

                };
                db.monthly_rob.Add(montrob);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Add_Monthly_Activity(int head_id, ReportViewModel report)
        {
            try
            {
                monthly_activity monthact = new Models.monthly_activity
                {
                    head_id = head_id,
                    steamingtime = report.steamingtime,
                    steamingconsumption = report.steamingconsumption,
                    steamingmcr = report.steamingmcr,
                    anchoragetime = report.anchoragetime,
                    anchorageconsumption = report.anchorageconsumption,
                    anchoragemcr = report.anchoragemcr,
                    berthtime = report.berthtime,
                    berthconsumption = report.berthconsumption,
                    berthmcr = report.berthmcr,
                    towingtime = report.towingtime,
                    towingconsumption = report.towingconsumption,
                    towingmcr = report.towingmcr,
                    downtime = report.downtime,
                    downconsumption = report.downconsumption,
                    downmcr = report.downmcr,
                    meneauveringtime = report.downtime,
                    meneauveringconsumption = report.downconsumption,
                    meneauveringmcr = report.downmcr,
                    otherstime = report.otherstime,
                    othersconsumption = report.othersconsumption,
                    othersmcr = report.othersmcr,
                    remarkstime = report.remarkstime,
                    remarksconsumption = report.remarksconsumption,
                    remarksmcr = report.remarksmcr,

                };
                db.monthly_activity.Add(monthact);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Add_HseleadingIndent(int head_id, ReportViewModel report)
        {
            try
            {
                hseleadingindent hseleading = new hseleadingindent
                {
                    head_id = head_id,
                    nomeeting_m = report.nomeeting_m,
                    nomeeting_y = report.nomeeting_y,
                    nosuggestion_m = report.nosuggestion_m,
                    nosuggestion_y = report.nosuggestion_y,
                    noemergency_m = report.noemergency_m,
                    noemergency_y = report.noemergency_y,
                    nopermit_m = report.nopermit_m,
                    nopermit_y = report.nopermit_y,
                    notbt_m = report.notbt_m,
                    notbt_y = report.notbt_y,
                    nosafetyflashes_m = report.nosafetyflashes_m,
                    nosafetyflashes_y = report.nosafetyflashes_y,
                    notraining_m = report.notraining_m,
                    notraining_y = report.notraining_y,
                    notraininghours_m = report.notraininghours_m,
                    notraininghours_y = report.notraininghours_y,
                    notrainingpersons_m = report.notrainingpersons_m,
                    notrainingpersons_y = report.notrainingpersons_y,
                    nosafetyflashed_m = report.nosafetyflashed_m,
                    nosafetyflashed_y = report.nosafetyflashed_y,
                    ltic_m = report.ltic_m,
                    ltic_y = report.ltic_y,
                    rwdc_m = report.rwdc_m,
                    rwdc_y = report.rwdc_y,
                    fac_m = report.fac_m,
                    fac_y = report.fac_y,
                    oi_m = report.oi_m,
                    oi_y = report.oi_y,
                    pdi_m = report.pdi_m,
                    pdi_y = report.pdi_y,
                    ei_m = report.ei_m,
                    ei_y = report.ei_y,
                    nmi_m = report.nmi_m,
                    nmi_y = report.nmi_y,
                    mtc_m = report.mtc_m,
                    mtc_y = report.mtc_y,
                };
                db.hseleadingindents.Add(hseleading);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Add_HseLaggingwaste(int head_id, ReportViewModel report)
        {
            try
            {
                hselaggingwaste hselagwste = new hselaggingwaste
                {
                    head_id = head_id,
                    warning_m = report.warning_m,
                    warning_y = report.warning_y,
                    complaints_m = report.complaints_m,
                    complaints_y = report.complaints_y,
                    fines_m = report.fines_m,
                    fines_y = report.fines_y,
                    observations_m = report.observations_m,
                    observations_y = report.observations_y,
                    injury_m = report.injury_m,
                    injury_y = report.injury_y,
                    plastic_m = report.plastic_m,
                    plastic_y = report.plastic_y,
                    food_m = report.food_m,
                    food_y = report.food_y,
                    cookingoil_m = report.cookingoil_m,
                    cookingoil_y = report.cookingoil_y,
                    metal_m = report.metal_m,
                    metal_y = report.metal_y,
                    seweragewater_m = report.seweragewater_m,
                    seweragewater_y = report.seweragewater_y,
                    hazardous_m = report.hazardous_m,
                    hazardous_y = report.hazardous_y,
                    others_m = report.others_m,
                    others_y = report.others_y,
                };
                db.hselaggingwastes.Add(hselagwste);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public int Update_vessel_head(ReportViewModel report)
        {
            try
            {
                vessel_head head = db.vessel_head.Where(a => a.id == report.id).Single();

                head.ShipsId = report.ShipsId;
                head.vessel = report.vessel;
                head.type = report.type;
                head.navigation = report.navigation;
                head.imono = report.imono;
                head.manhours = report.manhours;
                head.master = report.master;
                head.chiefofficer = report.chiefofficer;
                head.chiefengineer = report.chiefengineer;
                head.location = report.location;

                db.Entry(head).State = EntityState.Modified;
                db.SaveChanges();
                return head.id;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public bool Update_ptwinspection(int head_id, ReportViewModel report)
        {
            try
            {
                ptwinspection ptwins = db.ptwinspections.Where(a => a.head_id == head_id).Single();

                ptwins.hot_m = report.hot_m;
                ptwins.hot_y = report.hot_y;
                ptwins.cold_m = report.cold_m;
                ptwins.cold_y = report.cold_y;
                ptwins.aloft_m = report.aloft_m;
                ptwins.aloft_y = report.aloft_y;
                ptwins.confined_m = report.confined_m;
                ptwins.confined_y = report.confined_y;
                ptwins.diving_m = report.diving_m;
                ptwins.diving_y = report.diving_y;
                ptwins.electrical_m = report.electrical_m;
                ptwins.electrical_y = report.electrical_y;
                ptwins.firstaid = report.firstaid;
                ptwins.firefighting = report.firefighting;
                ptwins.mess = report.mess;
                ptwins.toilet = report.toilet;
                ptwins.pms = report.pms;
                ptwins.galley = report.galley;
                ptwins.lifesaving = report.lifesaving;
                ptwins.towing_inspect = report.towing_inspect;
                ptwins.radio_inspect = report.radio_inspect;
                ptwins.hull_inspect = report.hull_inspect;
                ptwins.remark = report.remark;

                db.Entry(ptwins).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Update_Pob(int head_id, ReportViewModel report)
        {
            try
            {
                pob pob = db.pobs.Where(a => a.head_id == head_id).Single();
                pob.pobcrew = report.pobcrew;
                pob.pobcharterers = report.pobcharterers;
                pob.pobkfc = report.pobkfc;
                pob.pobothers = report.pobothers;
                pob.pobtotal = report.pobtotal;
                pob.remarkscrew = report.remarkscrew;
                pob.remarkscharterers = report.remarkscharterers;
                pob.remarkskfc = report.remarkskfc;
                pob.remarksothers = report.remarksothers;
                db.Entry(pob).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Update_Monthly_Rob(int head_id, ReportViewModel report)
        {
            try
            {
                monthly_rob montrob = db.monthly_rob.Where(a => a.head_id == head_id).Single();
                montrob.openingfuel = report.openingfuel;
                montrob.openingfreshwater = report.openingfreshwater;
                montrob.openingloil = report.openingloil;
                montrob.openinghoil = report.openinghoil;
                montrob.openinggoil = report.openinggoil;
                montrob.receivedfuel = report.receivedfuel;
                montrob.receivedfreshwater = report.receivedfreshwater;
                montrob.receivedloil = report.receivedloil;
                montrob.receivedhoil = report.receivedhoil;
                montrob.receivedgoil = report.receivedgoil;
                montrob.closingfuel = report.closingfuel;
                montrob.closingfreshwater = report.closingfreshwater;
                montrob.closingloil = report.closingloil;
                montrob.closinghoil = report.closinghoil;
                montrob.closinggoil = report.closinggoil;
                montrob.consumedfuel = report.consumedfuel;
                montrob.consumedfreshwater = report.consumedfreshwater;
                montrob.consumedloil = report.consumedloil;
                montrob.consumedhoil = report.consumedhoil;
                montrob.consumedgoil = report.consumedgoil;
                montrob.deliveredfuel = report.deliveredfuel;
                montrob.deliveredfreshwater = report.deliveredfreshwater;
                montrob.deliveredloil = report.deliveredloil;
                montrob.deliveredhoil = report.deliveredhoil;
                montrob.deliveredgoil = report.deliveredgoil;
                montrob.deliveredkfcfuel = report.deliveredkfcfuel;
                montrob.deliveredkfcfreshwater = report.deliveredkfcfreshwater;
                montrob.deliveredkfcloil = report.deliveredkfcloil;
                montrob.deliveredkfchoil = report.deliveredkfchoil;
                montrob.deliveredkfcgoil = report.deliveredkfcgoil;
                montrob.menginerunninghrsfuel = report.menginerunninghrsfuel;
                montrob.menginerunninghrsfreshwater = report.menginerunninghrsfreshwater;
                montrob.menginerunninghrsloil = report.menginerunninghrsloil;
                montrob.menginerunninghrshoil = report.menginerunninghrshoil;
                montrob.menginerunninghrsgoil = report.menginerunninghrsgoil;
                montrob.menginefuelconsfuel = report.menginefuelconsfuel;
                montrob.menginefuelconsfreshwater = report.menginefuelconsfreshwater;
                montrob.menginefuelconsloil = report.menginefuelconsloil;
                montrob.menginefuelconshoil = report.menginefuelconshoil;
                montrob.menginefuelconsgoil = report.menginefuelconsgoil;
                montrob.aenginerunninghrsfuel = report.aenginerunninghrsfuel;
                montrob.aenginerunninghrsfreshwater = report.aenginerunninghrsfreshwater;
                montrob.aenginerunninghrsloil = report.aenginerunninghrsloil;
                montrob.aenginerunninghrshoil = report.aenginerunninghrshoil;
                montrob.aenginerunninghrsgoil = report.aenginerunninghrsgoil;
                montrob.aenginefuelconsfuel = report.aenginefuelconsfuel;
                montrob.aenginefuelconsfreshwater = report.aenginefuelconsfreshwater;
                montrob.aenginefuelconsloil = report.aenginefuelconsloil;
                montrob.aenginefuelconshoil = report.aenginefuelconshoil;
                montrob.aenginefuelconsgoil = report.aenginefuelconsgoil;

                db.Entry(montrob).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Update_Monthly_Activity(int head_id, ReportViewModel report)
        {
            try
            {
                monthly_activity monthact = db.monthly_activity.Where(a => a.head_id == head_id).Single();
                monthact.steamingtime = report.steamingtime;
                monthact.steamingconsumption = report.steamingconsumption;
                monthact.steamingmcr = report.steamingmcr;
                monthact.anchoragetime = report.anchoragetime;
                monthact.anchorageconsumption = report.anchorageconsumption;
                monthact.anchoragemcr = report.anchoragemcr;
                monthact.berthtime = report.berthtime;
                monthact.berthconsumption = report.berthconsumption;
                monthact.berthmcr = report.berthmcr;
                monthact.towingtime = report.towingtime;
                monthact.towingconsumption = report.towingconsumption;
                monthact.towingmcr = report.towingmcr;
                monthact.downtime = report.downtime;
                monthact.downconsumption = report.downconsumption;
                monthact.downmcr = report.downmcr;
                monthact.meneauveringtime = report.downtime;
                monthact.meneauveringconsumption = report.downconsumption;
                monthact.meneauveringmcr = report.downmcr;
                monthact.otherstime = report.otherstime;
                monthact.othersconsumption = report.othersconsumption;
                monthact.othersmcr = report.othersmcr;
                monthact.remarkstime = report.remarkstime;
                monthact.remarksconsumption = report.remarksconsumption;
                monthact.remarksmcr = report.remarksmcr;

                db.Entry(monthact).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Update_HseleadingIndent(int head_id, ReportViewModel report)
        {
            try
            {
                hseleadingindent hseleading = db.hseleadingindents.Where(a => a.head_id == head_id).Single();
                hseleading.nomeeting_m = report.nomeeting_m;
                hseleading.nomeeting_y = report.nomeeting_y;
                hseleading.nosuggestion_m = report.nosuggestion_m;
                hseleading.nosuggestion_y = report.nosuggestion_y;
                hseleading.noemergency_m = report.noemergency_m;
                hseleading.noemergency_y = report.noemergency_y;
                hseleading.nopermit_m = report.nopermit_m;
                hseleading.nopermit_y = report.nopermit_y;
                hseleading.notbt_m = report.notbt_m;
                hseleading.notbt_y = report.notbt_y;
                hseleading.nosafetyflashes_m = report.nosafetyflashes_m;
                hseleading.nosafetyflashes_y = report.nosafetyflashes_y;
                hseleading.notraining_m = report.notraining_m;
                hseleading.notraining_y = report.notraining_y;
                hseleading.notraininghours_m = report.notraininghours_m;
                hseleading.notraininghours_y = report.notraininghours_y;
                hseleading.notrainingpersons_m = report.notrainingpersons_m;
                hseleading.notrainingpersons_y = report.notrainingpersons_y;
                hseleading.nosafetyflashed_m = report.nosafetyflashed_m;
                hseleading.nosafetyflashed_y = report.nosafetyflashed_y;
                hseleading.ltic_m = report.ltic_m;
                hseleading.ltic_y = report.ltic_y;
                hseleading.rwdc_m = report.rwdc_m;
                hseleading.rwdc_y = report.rwdc_y;
                hseleading.fac_m = report.fac_m;
                hseleading.fac_y = report.fac_y;
                hseleading.oi_m = report.oi_m;
                hseleading.oi_y = report.oi_y;
                hseleading.pdi_m = report.pdi_m;
                hseleading.pdi_y = report.pdi_y;
                hseleading.ei_m = report.ei_m;
                hseleading.ei_y = report.ei_y;
                hseleading.nmi_m = report.nmi_m;
                hseleading.nmi_y = report.nmi_y;
                hseleading.mtc_m = report.mtc_m;
                hseleading.mtc_y = report.mtc_y;
                db.Entry(hseleading).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Update_HseLaggingwaste(int head_id, ReportViewModel report)
        {
            try
            {
                hselaggingwaste hselagwste = db.hselaggingwastes.Where(a => a.head_id == head_id).Single();
                hselagwste.warning_m = report.warning_m;
                hselagwste.warning_y = report.warning_y;
                hselagwste.complaints_m = report.complaints_m;
                hselagwste.complaints_y = report.complaints_y;
                hselagwste.fines_m = report.fines_m;
                hselagwste.fines_y = report.fines_y;
                hselagwste.observations_m = report.observations_m;
                hselagwste.observations_y = report.observations_y;
                hselagwste.injury_m = report.injury_m;
                hselagwste.injury_y = report.injury_y;
                hselagwste.plastic_m = report.plastic_m;
                hselagwste.plastic_y = report.plastic_y;
                hselagwste.food_m = report.food_m;
                hselagwste.food_y = report.food_y;
                hselagwste.cookingoil_m = report.cookingoil_m;
                hselagwste.cookingoil_y = report.cookingoil_y;
                hselagwste.metal_m = report.metal_m;
                hselagwste.metal_y = report.metal_y;
                hselagwste.seweragewater_m = report.seweragewater_m;
                hselagwste.seweragewater_y = report.seweragewater_y;
                hselagwste.hazardous_m = report.hazardous_m;
                hselagwste.hazardous_y = report.hazardous_y;
                hselagwste.others_m = report.others_m;
                hselagwste.others_y = report.others_y;
                db.Entry(hselagwste).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public ReportHeadViewmodel CalcSumForPerformance(List<ReportHeadViewmodel> reportvmlist)
        {
            ReportHeadViewmodel headModelSecc = new ReportHeadViewmodel();
            headModelSecc = reportvmlist.FirstOrDefault();
            headModelSecc.pob.pobcrew = reportvmlist.Sum(a => Convert.ToInt64(a.pob.pobcrew)).ToString();
            headModelSecc.vesselhead.manhours = reportvmlist.Sum(a => filtertoint(a.vesselhead.manhours)).ToString();
            headModelSecc.hseleadingindent.nomeeting_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.nomeeting_m)).ToString();
            headModelSecc.hseleadingindent.nosuggestion_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.nosuggestion_m)).ToString();
            headModelSecc.hseleadingindent.noemergency_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.noemergency_m)).ToString();
            headModelSecc.hseleadingindent.nopermit_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.nopermit_m)).ToString();
            headModelSecc.hseleadingindent.notbt_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.notbt_m)).ToString();
            headModelSecc.hseleadingindent.notraining_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.notraining_m)).ToString();

            headModelSecc.hseleadingindent.notraininghours_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.notraininghours_m)).ToString();
            headModelSecc.hseleadingindent.notrainingpersons_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.notrainingpersons_m)).ToString();
            headModelSecc.hseleadingindent.nosafetyflashed_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.nosafetyflashed_m)).ToString();
            headModelSecc.hseleadingindent.ltic_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.ltic_m)).ToString();
            headModelSecc.hseleadingindent.rwdc_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.rwdc_m)).ToString();
            headModelSecc.hseleadingindent.fac_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.fac_m)).ToString();
            headModelSecc.hseleadingindent.oi_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.oi_m)).ToString();
            headModelSecc.hseleadingindent.pdi_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.pdi_m)).ToString();
            headModelSecc.hseleadingindent.ei_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.ei_m)).ToString();
            headModelSecc.hseleadingindent.nmi_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.nmi_m)).ToString();
            headModelSecc.hseleadingindent.mtc_m = reportvmlist.Sum(a => filtertoint(a.hseleadingindent.mtc_m)).ToString();

            headModelSecc.hselaggingwaste.warning_m = reportvmlist.Sum(a => filtertoint(a.hselaggingwaste.warning_m)).ToString();
            headModelSecc.hselaggingwaste.complaints_m = reportvmlist.Sum(a => filtertoint(a.hselaggingwaste.complaints_m)).ToString();
            headModelSecc.hselaggingwaste.fines_m = reportvmlist.Sum(a => filtertoint(a.hselaggingwaste.fines_m)).ToString();
            headModelSecc.hselaggingwaste.observations_m = reportvmlist.Sum(a => filtertoint(a.hselaggingwaste.observations_m)).ToString();
            headModelSecc.hselaggingwaste.injury_m = reportvmlist.Sum(a => filtertoint(a.hselaggingwaste.injury_m)).ToString();

            headModelSecc.ptwinspection.hot_m = reportvmlist.Sum(a => filtertoint(a.ptwinspection.hot_m)).ToString();
            headModelSecc.ptwinspection.cold_m = reportvmlist.Sum(a => filtertoint(a.ptwinspection.cold_m)).ToString();
            headModelSecc.ptwinspection.aloft_m = reportvmlist.Sum(a => filtertoint(a.ptwinspection.aloft_m)).ToString();
            headModelSecc.ptwinspection.confined_m = reportvmlist.Sum(a => filtertoint(a.ptwinspection.confined_m)).ToString();
            headModelSecc.ptwinspection.diving_m = reportvmlist.Sum(a => filtertoint(a.ptwinspection.diving_m)).ToString();
            headModelSecc.ptwinspection.electrical_m = reportvmlist.Sum(a => filtertoint(a.ptwinspection.electrical_m)).ToString();

            headModelSecc.lifesaving_ptw_Sum = reportvmlist.Sum(a => filterBooltoint(a.ptwinspection.lifesaving)).ToString();
            headModelSecc.towing_inspect_ptw_Sum = reportvmlist.Sum(a => filterBooltoint(a.ptwinspection.towing_inspect)).ToString();
            headModelSecc.mess_ptw_Sum = reportvmlist.Sum(a => filterBooltoint(a.ptwinspection.mess)).ToString();
            headModelSecc.galley_ptw_Sum = reportvmlist.Sum(a => filterBooltoint(a.ptwinspection.galley)).ToString();
            headModelSecc.radio_inspect_ptw_Sum = reportvmlist.Sum(a => filterBooltoint(a.ptwinspection.radio_inspect)).ToString();
            headModelSecc.firefighting_ptw_Sum = reportvmlist.Sum(a => filterBooltoint(a.ptwinspection.firefighting)).ToString();
            headModelSecc.toilet_ptw_Sum = reportvmlist.Sum(a => filterBooltoint(a.ptwinspection.toilet)).ToString();
            headModelSecc.hull_inspect_ptw_Sum = reportvmlist.Sum(a => filterBooltoint(a.ptwinspection.hull_inspect)).ToString();
            headModelSecc.pms_ptw_Sum = reportvmlist.Sum(a => filterBooltoint(a.ptwinspection.pms)).ToString();

            headModelSecc.monthly_rob.consumedfuel = reportvmlist.Sum(a => filtertoint(a.monthly_rob.consumedfuel)).ToString();
            headModelSecc.monthly_rob.menginerunninghrsfuel = reportvmlist.Sum(a => filtertoint(a.monthly_rob.menginerunninghrsfuel)).ToString();
            //headModelSecc.monthly_rob.th = reportvmlist.Sum(a => filtertoint(a.monthly_rob.closingfuel)).ToString();
            //headModelSecc.monthly_rob.consumedfreshwater = reportvmlist.Sum(a => filtertoint(a.monthly_rob.consumedfreshwater)).ToString();

            headModelSecc.hselaggingwaste.plastic_m = reportvmlist.Sum(a => filtertoint(a.hselaggingwaste.plastic_m)).ToString();
            headModelSecc.hselaggingwaste.food_m = reportvmlist.Sum(a => filtertoint(a.hselaggingwaste.food_m)).ToString();
            headModelSecc.hselaggingwaste.cookingoil_m = reportvmlist.Sum(a => filtertoint(a.hselaggingwaste.cookingoil_m)).ToString();
            headModelSecc.hselaggingwaste.metal_m = reportvmlist.Sum(a => filtertoint(a.hselaggingwaste.metal_m)).ToString();
            headModelSecc.hselaggingwaste.seweragewater_m = reportvmlist.Sum(a => filtertoint(a.hselaggingwaste.seweragewater_m)).ToString();
            headModelSecc.hselaggingwaste.hazardous_m = reportvmlist.Sum(a => filtertoint(a.hselaggingwaste.hazardous_m)).ToString();

            return headModelSecc;
        }
        public Int64 filtertoint(string str)
        {
            int r = 0;
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (int.TryParse(str, out r))
                {
                    Convert.ToInt64(str);
                }
            }
            return 0;
        }
        public Int64 filterBooltoint(bool? str)
        {
            if (str == true)
            {
                return 1;
            }
            return 0;
        }
    }
}