using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

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
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@buildingID";
            param.Value = buildingID;
            
            // Bind the data to grdMeters
            DataTable dataTable = DataAccessLayer.getMeters(param);
            grdMeters.DataSource = dataTable;
            grdMeters.DataBind();
        }

        /// <summary>
        /// Populates the label indicating the currently selected building.
        /// </summary>
        protected void populateBuildingLabel()
        {
            int buildingID = getBuildingIDFromSession();
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@buildingID";
            param.Value = buildingID;

            DataTable resultTable = DataAccessLayer.getBuildingName(param);
            if (resultTable.Rows.Count > 0)
            {
                lblBuilding.Text = resultTable.Rows[0].ItemArray[0].ToString();
            }
            else
            {
                lblBuilding.Text = "No building is currently selected";
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