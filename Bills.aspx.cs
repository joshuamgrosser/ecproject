using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.ServiceModel;
using EnergyCAP.EnergyCapSvcRef;
using System.Collections;

namespace EnergyCAP
{
    public partial class Bills : System.Web.UI.Page
    {
        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            populateBills();
            populateMeterLabel();
        }

        /// <summary>
        /// Populates grdBills with information from the database, given a specific meter ID.
        /// </summary>
        protected void populateBills()
        {
            int meterID = getMeterIDFromSession();
            
            // Initialize the web service proxy class instance
            EnergyCapSvcRef.EnergyCapServiceClient proxy = new EnergyCapServiceClient();

            // Make the service call
            Bill[] bills = proxy.GetBillsForMeter(meterID);

            // Construct a DataTable to store the results
            DataTable results = new DataTable();
            DataColumn col1 = new DataColumn("BillMtrID");
            DataColumn col2 = new DataColumn("MtrCost");
            DataColumn col3 = new DataColumn("MtrUse");
            DataColumn col4 = new DataColumn("MtrBDem");
            DataColumn col5 = new DataColumn("MtrADem");
            DataColumn col6 = new DataColumn("MtrStartDate");
            DataColumn col7 = new DataColumn("MtrEndDate");
            DataColumn col8 = new DataColumn("ReportYear");
            DataColumn col9 = new DataColumn("ReportMonth");

            results.Columns.Add(col1);
            results.Columns.Add(col2);
            results.Columns.Add(col3);
            results.Columns.Add(col4);
            results.Columns.Add(col5);
            results.Columns.Add(col6);
            results.Columns.Add(col7);
            results.Columns.Add(col8);
            results.Columns.Add(col9);

            // Add each building to the DataTable
            for (int i = 0; i < bills.Length; i++)
            {
                ArrayList valArrayList = new ArrayList();
                valArrayList.Add(bills[i].BillMtrID);
                valArrayList.Add(bills[i].MeterCost);
                valArrayList.Add(bills[i].MeterUse);
                valArrayList.Add(bills[i].MeterBDem);

                valArrayList.Add(bills[i].MeterADem);
                valArrayList.Add(bills[i].MeterStartDate);
                valArrayList.Add(bills[i].MeterEndDate);
                valArrayList.Add(bills[i].ReportYear);
                valArrayList.Add(bills[i].ReportMonth);

                DataRow row = results.Rows.Add(valArrayList.ToArray());
            }

            // Bind the data to grdBuildings
            grdBills.DataSource = results;
            grdBills.DataBind();
        }

        /// <summary>
        /// Populates the label indicating the currently selected building.
        /// </summary>
        protected void populateMeterLabel()
        {
            int meterID = getMeterIDFromSession();
            //SqlParameter param = new SqlParameter();
            //param.ParameterName = "@MeterInfoID";
            //param.Value = meterID;

            //string result = DataAccessLayer.getMeterName(param);

            // Initialize the web service proxy class instance
            EnergyCapSvcRef.EnergyCapServiceClient proxy = new EnergyCapServiceClient();
            string meterName = proxy.GetMeterName(meterID);

            if (meterName != null)
            {
                lblMeter.Text = "You are currently viewing bills for " + meterName + ".";
            }
            else
            {
                lblMeter.Text = "No meter is selected.";
            }
        }

        /// <summary>
        /// Gets the meter ID from the session.
        /// </summary>
        /// <returns>The meter ID stored in the session, or -1 if none exists.</returns>
        protected int getMeterIDFromSession()
        {
            /// Get the meter ID from the query string
            String meterIDStr = String.Empty;
            if (Session[SessionConstants.METER_ID] != null)
            {
                meterIDStr = Session[SessionConstants.METER_ID].ToString();
            }

            int meterID = -1;
            if (meterIDStr != null && meterIDStr != String.Empty) { meterID = int.Parse(meterIDStr); }
            return meterID;
        }
    }
}