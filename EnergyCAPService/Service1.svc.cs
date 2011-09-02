﻿using System;
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
    public class EnergyCapService : IEnergyCapService
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

        public Building GetBuildingDetails(int buildingID)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@buildingID";
            parameter.Value = buildingID;

            DataTable results = DataAccessLayer.getBuildingDetails(parameter);
            Building building = new Building();

            DataRow row = results.Rows[0];

            building.BuildingID = buildingID;
            building.BuildingCode = row[results.Columns["BuildingCode"]].ToString();
            building.BuildingName = row[results.Columns["BuildingName"]].ToString();
            building.BuildingMemo = row[results.Columns["BuildingMemo"]].ToString();

            return building;
        }

        public String GetBuildingName(int buildingID)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@buildingID";
            parameter.Value = buildingID;

            return DataAccessLayer.getBuildingName(parameter);
        }

        public String GetMeterName(int meterInfoID)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@MeterInfoID";
            parameter.Value = meterInfoID;

            return DataAccessLayer.getMeterName(parameter);
        }

        public int UpdateBuildingDetails(Building building)
        {
            // Compile the updated building information
            SqlParameter[] parameters = new SqlParameter[4];

            int buildingID = building.BuildingID;
            SqlParameter paramBuildingID = new SqlParameter();
            paramBuildingID.ParameterName = "@buildingID";
            paramBuildingID.Value = buildingID;
            parameters[0] = paramBuildingID;

            string buildingCode = building.BuildingCode;
            SqlParameter paramBuildingCode = new SqlParameter();
            paramBuildingCode.ParameterName = "@BuildingCode";
            paramBuildingCode.Value = buildingCode;
            parameters[1] = paramBuildingCode;

            string buildingName = building.BuildingName;
            SqlParameter paramBuildingName = new SqlParameter();
            paramBuildingName.ParameterName = "@BuildingName";
            paramBuildingName.Value = buildingName;
            parameters[2] = paramBuildingName;

            string buildingMemo = building.BuildingMemo;
            SqlParameter paramBuildingMemo = new SqlParameter();
            paramBuildingMemo.ParameterName = "@BuildingMemo";
            paramBuildingMemo.Value = buildingMemo;
            parameters[3] = paramBuildingMemo;

            // Update the building details
            return DataAccessLayer.updateBuildingDetails(parameters);
        }
    }
}