using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using TestServiceClient.ServiceReference1;

namespace TestServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client proxy = new Service1Client();

            Building building = proxy.GetBuildings();
            Console.WriteLine("ID: " + building.BuildingID);
            Console.WriteLine("Name: " + building.BuildingName);
            Console.WriteLine("Code: " + building.BuildingCode);
            Console.WriteLine("Memo: " + building.BuildingMemo);
            Console.ReadLine();
        }
    }
}
