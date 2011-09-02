using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace EnergyCAPService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Building GetBuildings()
        {
            Building building = new Building();
            //DataTable dataTable = DataAccessLayer.getBuildings();

            //// Bind the data to grdBuildings
            //foreach(DataRow row in 
            //DataRow row = results.Rows[0];

            //// Populdate the textbox fields
            //txtBuildingName.Text = row[results.Columns["BuildingName"]].ToString();
            //txtBuildingCode.Text = row[results.Columns["BuildingCode"]].ToString();
            //txtBuildingMemo.Text = row[results.Columns["BuildingMemo"]].ToString();

            return building;
        }
    }
}
