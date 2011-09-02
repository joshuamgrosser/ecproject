using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

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

        public Meter[] GetMetersForBuilding(int buildingID)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@buildingID";
            parameter.Value = buildingID;

            DataTable results = DataAccessLayer.getMeters(parameter);
            Meter[] meters = new Meter[results.Rows.Count];

            int counter = 0;

            // Create a meter from each row
            foreach (DataRow row in results.Rows)
            {
                meters[counter] = new Meter();
                meters[counter].MeterInfoID = int.Parse(row[results.Columns["MeterInfoID"]].ToString());
                meters[counter].MeterCode = row[results.Columns["MeterCode"]].ToString();
                meters[counter].MeterName = row[results.Columns["MeterName"]].ToString();
                meters[counter].MeterSerial = row[results.Columns["MeterSerial"]].ToString();
                counter++;
            }

            return meters;
        }

        public Bill[] GetBillsForMeter(int meterInfoID)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@MeterInfoID";
            parameter.Value = meterInfoID;

            DataTable results = DataAccessLayer.getBills(parameter);
            Bill[] bills = new Bill[results.Rows.Count];

            int counter = 0;

            // Create a meter from each row
            foreach (DataRow row in results.Rows)
            {
                bills[counter] = new Bill();
                bills[counter].BillMtrID = int.Parse(row[results.Columns["BillMtrID"]].ToString());
                bills[counter].MeterCost = row[results.Columns["MtrCost"]].ToString();
                bills[counter].MeterUse = row[results.Columns["MtrUse"]].ToString();
                bills[counter].MeterBDem = row[results.Columns["MtrBDem"]].ToString();
                bills[counter].MeterADem = row[results.Columns["MtrADem"]].ToString();
                bills[counter].MeterStartDate = row[results.Columns["MtrStartDate"]].ToString();
                bills[counter].MeterEndDate = row[results.Columns["MtrEndDate"]].ToString();
                bills[counter].ReportYear = row[results.Columns["ReportYear"]].ToString();
                bills[counter].ReportMonth = row[results.Columns["ReportMonth"]].ToString();
                counter++;
            }

            return bills;
        }
    }
}
