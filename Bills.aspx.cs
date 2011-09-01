using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

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
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@MeterInfoID";
            param.Value = meterID;

            // Bind the data to grdMeters
            DataTable dataTable = DataAccessLayer.getBills(param);
            grdBills.DataSource = dataTable;
            grdBills.DataBind();
        }

        /// <summary>
        /// Populates the label indicating the currently selected building.
        /// </summary>
        protected void populateMeterLabel()
        {
            int meterID = getMeterIDFromSession();
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@MeterInfoID";
            param.Value = meterID;

            string result = DataAccessLayer.getMeterName(param);

            if (result != null)
            {
                lblMeter.Text = "You are currently viewing bills for " + result + ".";
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