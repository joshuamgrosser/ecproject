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

        public Building[] GetBuildings()
        {
            DataTable results = DataAccessLayer.getBuildings();
            Building[] buildings = new Building[results.Rows.Count];

            int counter = 0;

            // Create a building from each row
            foreach (DataRow row in results.Rows)
            {
                buildings[counter] = new Building();
                buildings[counter].BuildingID = int.Parse(row[results.Columns["BuildingID"]].ToString());
                buildings[counter].BuildingCode = row[results.Columns["BuildingCode"]].ToString();
                buildings[counter].BuildingName = row[results.Columns["BuildingName"]].ToString();
                buildings[counter].BuildingMemo = row[results.Columns["BuildingMemo"]].ToString();
                counter++;
            }
            
            return buildings;
        }
    }
}
