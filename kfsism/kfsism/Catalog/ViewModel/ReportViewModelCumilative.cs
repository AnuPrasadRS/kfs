using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Catalog.ViewModel
{
    public class ReportViewModelCumilative
    {
        /*------------------vessel_head--------------------------------*/
        public int id { get; set; }
        public int ShipsId { get; set; }
        public Nullable<int> EnteredBY { get; set; }
        public string EnteredBYNm { get; set; }
        public string ShipsName { get; set; }
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
        /*------------------hselaggingwaste--------------------------------*/
        public string warning_m { get; set; }
        public string warning_y { get; set; }
        public string complaints_m { get; set; }
        public string complaints_y { get; set; }
        public string fines_m { get; set; }
        public string fines_y { get; set; }
        public string observations_m { get; set; }
        public string observations_y { get; set; }
        public string injury_m { get; set; }
        public string injury_y { get; set; }
        public string plastic_m { get; set; }
        public string plastic_y { get; set; }
        public string food_m { get; set; }
        public string food_y { get; set; }
        public string cookingoil_m { get; set; }
        public string cookingoil_y { get; set; }
        public string metal_m { get; set; }
        public string metal_y { get; set; }
        public string seweragewater_m { get; set; }
        public string seweragewater_y { get; set; }
        public string hazardous_m { get; set; }
        public string hazardous_y { get; set; }
        public string others_m { get; set; }
        public string others_y { get; set; }
        /*------------------hseleadingindent--------------------------------*/
        public string nomeeting_m { get; set; }
        public string nomeeting_y { get; set; }
        public string nosuggestion_m { get; set; }
        public string nosuggestion_y { get; set; }
        public string noemergency_m { get; set; }
        public string noemergency_y { get; set; }
        public string nopermit_m { get; set; }
        public string nopermit_y { get; set; }
        public string notbt_m { get; set; }
        public string notbt_y { get; set; }
        public string nosafetyflashes_m { get; set; }
        public string nosafetyflashes_y { get; set; }
        public string notraining_m { get; set; }
        public string notraining_y { get; set; }
        public string notraininghours_m { get; set; }
        public string notraininghours_y { get; set; }
        public string notrainingpersons_m { get; set; }
        public string notrainingpersons_y { get; set; }
        public string nosafetyflashed_m { get; set; }
        public string nosafetyflashed_y { get; set; }
        public string ltic_m { get; set; }
        public string ltic_y { get; set; }
        public string rwdc_m { get; set; }
        public string rwdc_y { get; set; }
        public string fac_m { get; set; }
        public string fac_y { get; set; }
        public string oi_m { get; set; }
        public string oi_y { get; set; }
        public string pdi_m { get; set; }
        public string pdi_y { get; set; }
        public string ei_m { get; set; }
        public string ei_y { get; set; }
        public string nmi_m { get; set; }
        public string nmi_y { get; set; }
        public string mtc_m { get; set; }
        public string mtc_y { get; set; }
        /*------------------monthly_activity--------------------------------*/
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
        /*------------------monthly_rob--------------------------------*/
        public string openingfuel { get; set; }
        public string openingfreshwater { get; set; }
        public string openingloil { get; set; }
        public string openinghoil { get; set; }
        public string openinggoil { get; set; }
        public string receivedfuel { get; set; }
        public string receivedfreshwater { get; set; }
        public string receivedloil { get; set; }
        public string receivedhoil { get; set; }
        public string receivedgoil { get; set; }
        public string closingfuel { get; set; }
        public string closingfreshwater { get; set; }
        public string closingloil { get; set; }
        public string closinghoil { get; set; }
        public string closinggoil { get; set; }
        public string consumedfuel { get; set; }
        public string consumedfreshwater { get; set; }
        public string consumedloil { get; set; }
        public string consumedhoil { get; set; }
        public string consumedgoil { get; set; }
        public string deliveredfuel { get; set; }
        public string deliveredfreshwater { get; set; }
        public string deliveredloil { get; set; }
        public string deliveredhoil { get; set; }
        public string deliveredgoil { get; set; }
        public string deliveredkfcfuel { get; set; }
        public string deliveredkfcfreshwater { get; set; }
        public string deliveredkfcloil { get; set; }
        public string deliveredkfchoil { get; set; }
        public string deliveredkfcgoil { get; set; }
        public string menginerunninghrsfuel { get; set; }
        public string menginerunninghrsfreshwater { get; set; }
        public string menginerunninghrsloil { get; set; }
        public string menginerunninghrshoil { get; set; }
        public string menginerunninghrsgoil { get; set; }
        public string menginefuelconsfuel { get; set; }
        public string menginefuelconsfreshwater { get; set; }
        public string menginefuelconsloil { get; set; }
        public string menginefuelconshoil { get; set; }
        public string menginefuelconsgoil { get; set; }
        public string aenginerunninghrsfuel { get; set; }
        public string aenginerunninghrsfreshwater { get; set; }
        public string aenginerunninghrsloil { get; set; }
        public string aenginerunninghrshoil { get; set; }
        public string aenginerunninghrsgoil { get; set; }
        public string aenginefuelconsfuel { get; set; }
        public string aenginefuelconsfreshwater { get; set; }
        public string aenginefuelconsloil { get; set; }
        public string aenginefuelconshoil { get; set; }
        public string aenginefuelconsgoil { get; set; }
        /*------------------pob--------------------------------*/
        public string pobcrew { get; set; }
        public string pobcharterers { get; set; }
        public string pobkfc { get; set; }
        public string pobothers { get; set; }
        public string pobtotal { get; set; }
        public string remarkscrew { get; set; }
        public string remarkscharterers { get; set; }
        public string remarkskfc { get; set; }
        public string remarksothers { get; set; }
        /*------------------ptwinspection--------------------------------*/
        public string hot_m { get; set; }
        public string hot_y { get; set; }
        public string cold_m { get; set; }
        public string cold_y { get; set; }
        public string aloft_m { get; set; }
        public string aloft_y { get; set; }
        public string confined_m { get; set; }
        public string confined_y { get; set; }
        public string diving_m { get; set; }
        public string diving_y { get; set; }
        public string electrical_m { get; set; }
        public string electrical_y { get; set; }
        public bool firstaid { get; set; }
        public bool firefighting { get; set; }
        public bool mess { get; set; }
        public bool toilet { get; set; }
        public bool pms { get; set; }
        public bool galley { get; set; }
        public bool lifesaving { get; set; }
        public bool towing_inspect { get; set; }
        public bool radio_inspect { get; set; }
        public bool hull_inspect { get; set; }
        public string remark { get; set; }
        /*------------------Cumulative total fields--------------------------------*/
        public double lost_time_freqrate
        {
            get
            {
                try
                {
                    Double val = Math.Round((Convert.ToDouble(ltic_m) / Convert.ToDouble(manhours)) * 1000000, 2);
                    if (Double.IsNaN(val))
                    {
                        val = 0;
                    }
                    return val;
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }
        public double lost_time_severityrate
        {
            get
            {
                try
                {
                    Double val = Math.Round((Convert.ToDouble(injury_m) / Convert.ToDouble(manhours)) * 1000000, 2);
                    if (Double.IsNaN(val))
                    {
                        val = 0;
                    }
                    return val;
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }
        public double near_miss_incidentfreqrate
        {
            get
            {
                try
                {
                    Double val = Math.Round((Convert.ToDouble(nmi_m) / Convert.ToDouble(manhours)) * 1000000, 2);
                    if (Double.IsNaN(val))
                    {
                        val = 0;
                    }
                    return val;
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }
        public double total_rptd_case_freqrate
        {
            get
            {
                try
                {
                    Double val = Math.Round((((Convert.ToDouble(mtc_m) + Convert.ToDouble(rwdc_m) + Convert.ToDouble(fac_m) + Convert.ToDouble(oi_m))) / Convert.ToDouble(manhours)) * 1000000, 2);
                    if (Double.IsNaN(val))
                    {
                        val = 0;
                    }
                    return val;
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }
        public double hse_meeting_efficiency
        {
            get
            {
                try
                {
                    Double val = Math.Round((Convert.ToDouble(nomeeting_m) / 1) * 100, 2);
                    if (Double.IsNaN(val))
                    {
                        val = 0;
                    }
                    return val;
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }
        public double training_eff_month
        {
            get
            {
                try
                {
                    Double val = Math.Round((Convert.ToDouble(notraining_m) / 3) * 100, 2);
                    if (Double.IsNaN(val))
                    {
                        val = 0;
                    }
                    return val;
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }
        public double total_box_tax
        {
            get
            {
                try
                {
                    Double val = Math.Round((Convert.ToDouble(notbt_m) / 4) * 100, 2);
                    if (Double.IsNaN(val))
                    {
                        val = 0;
                    }
                    return val;
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }
        public double emergency_dril_eff
        {
            get
            {
                try
                {
                    Double val = Math.Round((Convert.ToDouble(noemergency_m) / 3) * 100, 2);
                    if (Double.IsNaN(val))
                    {
                        val = 0;
                    }
                    return val;
                }
                catch (Exception)
                {

                    return 0;
                }

            }
        }
    }
    public class ReportHeadViewmodelCumulative
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