using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.ServiceModel;
using EnergyCAP.ServiceReference1;

namespace EnergyCAP
{
    public partial class Main : System.Web.UI.Page
    {
        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            populateBuildings();
        }

        /// <summary>
        /// Populates grdBuildings with the list of buildings from the database.
        /// </summary>
        protected void populateBuildings()
        {
            // Initialize the web service proxy class instance
            ServiceReference1.Service1Client proxy = new Service1Client();

            // Make the service call
            Building[] buildings = proxy.GetBuildings();

            // Construct a DataTable to store the results
            DataTable results = new DataTable();
            DataColumn col1 = new DataColumn("BuildingID");
            DataColumn col2 = new DataColumn("BuildingCode");
            DataColumn col3 = new DataColumn("BuildingName");

            results.Columns.Add(col1);
            results.Columns.Add(col2);
            results.Columns.Add(col3);

            // Add each building to the DataTable
            for (int i = 0; i < buildings.Length; i++)
            {
                Console.WriteLine("ID: " + buildings[i].BuildingID);
                Console.WriteLine("Code: " + buildings[i].BuildingCode);
                Console.WriteLine("Name: " + buildings[i].BuildingName);

                ArrayList valArrayList = new ArrayList();
                valArrayList.Add(buildings[i].BuildingID);
                valArrayList.Add(buildings[i].BuildingCode);
                valArrayList.Add(buildings[i].BuildingName);

                DataRow row = results.Rows.Add(valArrayList.ToArray());
            }

            // Bind the data to grdBuildings
            grdBuildings.DataSource = results;
            grdBuildings.DataBind();
        }

        /// <summary>
        /// Loads the Meters page using the building ID.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the session objects
            Session[SessionConstants.BUILDING_ID] = int.Parse(grdBuildings.SelectedDataKey.Value.ToString());
            Session[SessionConstants.METER_ID] = null;

            // Redirect
            Response.Redirect("Meters.aspx");
        }

        /// <summary>
        /// Event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdBuildings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            editBuilding(sender, e);
        }

        /// <summary>
        /// Redirects the user to the building editor page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void editBuilding(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditBuilding")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button clicked 
                // by the user from the Rows collection.
                GridViewRow row = grdBuildings.Rows[index];
                int buildingID = int.Parse(row.Cells[0].Text);

                // Set the session objects
                Session[SessionConstants.BUILDING_ID] = buildingID;
                Session[SessionConstants.METER_ID] = null;

                // Redirect to building editor page
                Response.Redirect("EditBuilding.aspx?buildingID=" + buildingID);
            }

        }
    }
}