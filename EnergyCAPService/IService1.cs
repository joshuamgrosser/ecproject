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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Building[] GetBuildings();

        [OperationContract]
        Meter[] GetMetersForBuilding(int buildingID);

        [OperationContract]
        Bill[] GetBillsForMeter(int meterID);
    }

    [DataContract]
    public class Building
    {
        int buildingID = -1;
        string buildingCode = String.Empty;
        string buildingName = String.Empty;
        string buildingMemo = String.Empty;

        [DataMember]
        public int BuildingID
        {
            get { return buildingID; }
            set { buildingID = value; }
        }

        [DataMember]
        public string BuildingCode
        {
            get { return buildingCode; }
            set { buildingCode = value; }
        }

        [DataMember]
        public string BuildingName
        {
            get { return buildingName; }
            set { buildingName = value; }
        }

        [DataMember]
        public string BuildingMemo
        {
            get { return buildingMemo; }
            set { buildingMemo = value; }
        }
    }

    [DataContract]
    public class Meter
    {
        int meterInfoID = -1;
        string meterCode = String.Empty;
        string meterName = String.Empty;
        string meterSerial = String.Empty;

        [DataMember]
        public int MeterInfoID
        {
            get { return meterInfoID; }
            set { meterInfoID = value; }
        }

        [DataMember]
        public string MeterCode
        {
            get { return meterCode; }
            set { meterCode = value; }
        }

        [DataMember]
        public string MeterName
        {
            get { return meterName; }
            set { meterName = value; }
        }

        [DataMember]
        public string MeterSerial
        {
            get { return meterSerial; }
            set { meterSerial = value; }
        }
    }

    [DataContract]
    public class Bill
    {
        int billMtrID = -1;
        string meterCost = String.Empty;
        string meterUse = String.Empty;
        string meterBDem = String.Empty;
        string meterADem = String.Empty;
        string meterStartDate = String.Empty;
        string meterEndDate = String.Empty;
        string reportYear = String.Empty;
        string reportMonth = String.Empty;

        [DataMember]
        public int BillMtrID
        {
            get { return billMtrID; }
            set { billMtrID = value; }
        }

        [DataMember]
        public string MeterCost
        {
            get { return meterCost; }
            set { meterCost = value; }
        }

        [DataMember]
        public string MeterUse
        {
            get { return meterUse; }
            set { meterUse = value; }
        }

        [DataMember]
        public string MeterBDem
        {
            get { return meterBDem; }
            set { meterBDem = value; }
        }

        [DataMember]
        public string MeterADem
        {
            get { return meterADem; }
            set { meterADem = value; }
        }

        [DataMember]
        public string MeterStartDate
        {
            get { return meterStartDate; }
            set { meterStartDate = value; }
        }

        [DataMember]
        public string MeterEndDate
        {
            get { return meterEndDate; }
            set { meterEndDate = value; }
        }

        [DataMember]
        public string ReportYear
        {
            get { return reportYear; }
            set { reportYear = value; }
        }

        [DataMember]
        public string ReportMonth
        {
            get { return reportMonth; }
            set { reportMonth = value; }
        }
    }
}
