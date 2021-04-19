using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Web.Script.Serialization;
using System.IO;

namespace Software_Engineering_Project
{
   
    public partial class App : Application

        
    {
        
        internal static bool hasFirstLoaded = false;
        internal static Dictionary<string, UserAccountObj> UserAccountDict { get; set; } = new Dictionary<string, UserAccountObj>();
        internal static List<FlightManifestObj> MarketMangerQueue { get; set; } = new List<FlightManifestObj>();
        internal static List<int> TransactionHist { get; set; } = new List<int>(); //NEED TO MAKE THIS FROM INT TO TRANSACTIONOBJ

        internal static Dictionary<string, FlightManifestObj> FlightHistoryDictionary = new Dictionary<string, FlightManifestObj>();
        internal static Dictionary<string, FlightManifestObj> FlightPlanDict { get; set; } = new Dictionary<string, FlightManifestObj>();


        internal static UserAccountObj LoggedInUser = new UserAccountObj();

        void Application_Exit(object sender, ExitEventArgs e)
        {
            Console.WriteLine("App closing, saving to file");
            FileIOLoading.WriteAlltoFile();
            hasFirstLoaded = false;

        }


    }
   
}
