using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using EnergyCAP.ServiceReference1;
using System.Collections;

namespace EnergyCAP
{
    public partial class Meters : System.Web.UI.Page
    {
        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            populateMeters();
            populateBuildingLabel();
        }

        /// <summary>
        /// Populates grdMeters with meter information from the database, given a specific building ID.
        /// </summary>
        protected void populateMeters()
        {
            int buildingID = getBuildingIDFromSession();

            // Initialize the web service proxy class instance
            ServiceReference1.Service1Client proxy = new Service1Client();

            // Make the service call
            Meter[] meters = proxy.GetMetersForBuilding(buildingID);

            // Construct a DataTable to store the results
            DataTable results = new DataTable();
            DataColumn col1 = new DataColumn("MeterInfoID");
            DataColumn col2 = new DataColumn("MeterCode");
            DataColumn col3 = new DataColumn("MeterName");
            DataColumn col4 = new DataColumn("MeterSerial");

            results.Columns.Add(col1);
            results.Columns.Add(col2);
            results.Columns.Add(col3);
            results.Columns.Add(col4);

            // Add each building to the DataTable
            for (int i = 0; i < meters.Length; i++)
            {
                ArrayList valArrayList = new ArrayList();
                valArrayList.Add(meters[i].MeterInfoID);
                valArrayList.Add(meters[i].MeterCode);
                valArrayList.Add(meters[i].MeterName);
                valArrayList.Add(meters[i].MeterSerial);

                DataRow row = results.Rows.Add(valArrayList.ToArray());
            }

            // Bind the data to grdBuildings
            grdMeters.DataSource = results;
            grdMeters.DataBind();
        }

        /// <summary>
        /// Populates the label indicating the currently selected building.
        /// </summary>
        protected void populateBuildingLabel()
        {
            int buildingID = getBuildingIDFromSession();

            // Initialize the web service proxy class instance
            ServiceReference1.Service1Client proxy = new Service1Client();

            string buildingName = proxy.GetBuildingName(buildingID);

            if (buildingName != null)
            {
                lblBuilding.Text = "You are currently viewing meters for " + buildingName + ".";
            }
            else
            {
                lblBuilding.Text = "No building is selected.";
            }
        }

        /// <summary>
        /// Loads the Bills page using the meter ID.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdMeters_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionConstants.METER_ID] = int.Parse(grdMeters.SelectedDataKey.Value.ToString());
            Response.Redirect("Bills.aspx");
        }

        /// <summary>
        /// Gets the building ID from the session.
        /// </summary>
        /// <returns>The building ID stored in the session, or -1 if none exists.</returns>
        protected int getBuildingIDFromSession()
        {
            // Get the building ID from the query string
            String buildingIdStr = String.Empty;
            if (Session[SessionConstants.BUILDING_ID] != null)
            {
                buildingIdStr = Session[SessionConstants.BUILDING_ID].ToString();
            }

            int buildingID = -1;
            if (buildingIdStr != null && buildingIdStr != String.Empty) { buildingID = int.Parse(buildingIdStr); }
            return buildingID;
        }
    }
}