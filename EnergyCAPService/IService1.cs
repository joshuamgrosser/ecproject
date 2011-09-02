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
    }

    [DataContract]
    public class Building
    {
        int buildingID = -1;
        string buildingCode = "123ABC";
        string buildingName = "YMCA";
        string buildingMemo = "The YMCA has the best facilities in the area.";

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
}
