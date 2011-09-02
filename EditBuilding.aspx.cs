using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using EnergyCAP.EnergyCapSvcRef;

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
            // Initialize the web service proxy class instance
            EnergyCapSvcRef.EnergyCapServiceClient proxy = new EnergyCapServiceClient();
            int buildingID = getBuildingIDFromSession();

            Building building = proxy.GetBuildingDetails(buildingID);

            // Populdate the textbox fields
            txtBuildingName.Text = building.BuildingName;
            txtBuildingCode.Text = building.BuildingCode;
            txtBuildingMemo.Text = building.BuildingMemo;
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
            EnergyCapSvcRef.EnergyCapServiceClient proxy = new EnergyCapServiceClient();
            int buildingID = getBuildingIDFromSession();

            Building building = new Building();
            building.BuildingID = buildingID;
            building.BuildingCode = txtBuildingCode.Text;
            building.BuildingName = txtBuildingName.Text;
            building.BuildingMemo = txtBuildingMemo.Text;

            // Update the building information in the database
            proxy.UpdateBuildingDetails(building);

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