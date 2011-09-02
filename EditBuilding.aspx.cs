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
    public partial class EditBuilding : System.Web.UI.Page
    {
        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateBuildingDetails();
            }
        }

        /// <summary>
        /// Populates the form with the building details for the selected building.
        /// </summary>
        protected void populateBuildingDetails()
        {
            int buildingID = getBuildingIDFromSession();
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@buildingID";
            param.Value = buildingID;

            // Bind the data to grdBuildings
            DataTable results = DataAccessLayer.getBuildingDetails(param);
            DataRow row = results.Rows[0];

            // Populdate the textbox fields
            txtBuildingName.Text = row[results.Columns["BuildingName"]].ToString();
            txtBuildingCode.Text = row[results.Columns["BuildingCode"]].ToString();
            txtBuildingMemo.Text = row[results.Columns["BuildingMemo"]].ToString();
        }

        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Buildings.aspx");
        }

        /// <summary>
        /// Submits the changes to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Compile the information from the form
            SqlParameter[] parameters = new SqlParameter[4];

            int buildingID = getBuildingIDFromSession();
            SqlParameter paramBuildingID = new SqlParameter();
            paramBuildingID.ParameterName = "@buildingID";
            paramBuildingID.Value = buildingID;
            parameters[0] = paramBuildingID;

            string buildingCode = txtBuildingCode.Text;
            SqlParameter paramBuildingCode = new SqlParameter();
            paramBuildingCode.ParameterName = "@BuildingCode";
            paramBuildingCode.Value = buildingCode;
            parameters[1] = paramBuildingCode;

            string buildingName = txtBuildingName.Text;
            SqlParameter paramBuildingName = new SqlParameter();
            paramBuildingName.ParameterName = "@BuildingName";
            paramBuildingName.Value = buildingName;
            parameters[2] = paramBuildingName;

            string buildingMemo = txtBuildingMemo.Text;
            SqlParameter paramBuildingMemo = new SqlParameter();
            paramBuildingMemo.ParameterName = "@BuildingMemo";
            paramBuildingMemo.Value = buildingMemo;
            parameters[3] = paramBuildingMemo;

            // Update the selected building with the information from the form
            DataAccessLayer.updateBuildingDetails(parameters);

            // Redirect
            Response.Redirect("Buildings.aspx");
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