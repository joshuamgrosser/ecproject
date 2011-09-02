using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using TestServiceClient.ServiceReference1;
using System.Data;

namespace TestServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client proxy = new Service1Client();

            Building[] buildings = proxy.GetBuildings();

            for (int i = 0; i < buildings.Length; i++)
            {
                Console.WriteLine("ID: " + buildings[i].BuildingID);
                Console.WriteLine("Name: " + buildings[i].BuildingName);
                Console.WriteLine("Code: " + buildings[i].BuildingCode);
                Console.WriteLine("Memo: " + buildings[i].BuildingMemo + "\n\n");
            }
           
            Console.ReadLine();
        }
    }
}
