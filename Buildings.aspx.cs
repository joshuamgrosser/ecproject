using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

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
            // Bind the data to grdBuildings
            grdBuildings.DataSource = DataAccessLayer.getBuildings();
            grdBuildings.DataBind();
        }

        /// <summary>
        /// Loads the Meters page using the building ID.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[SessionConstants.BUILDING_ID] = int.Parse(grdBuildings.SelectedDataKey.Value.ToString());
            Session[SessionConstants.METER_ID] = null;
            Response.Redirect("Meters.aspx");
        }
    }
}