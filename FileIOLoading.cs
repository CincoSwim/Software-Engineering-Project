using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Software_Engineering_Project
{
    class FileIOLoading
    {

        static string UserDictPath = @"c:\temp\UserDict.txt";
        static string MMQueuePath = @"c:\temp\MMQueueDict.txt";
        static string TransactionHistPath = @"c:\temp\TransHistList.txt";
        static string FlightHistDictPath = @"c:\temp\FlightHistDict.txt";
        static string FlightPlanDictPath = @"c:\temp\FlightPlanDict.txt";
        public static string AccountantSinglePath = @"c:\temp\Printouts\SingleSelection.txt";
        public static string AccountantMultiPath = @"c:\temp\Printouts\AllSelection.txt";

        internal static void ReadAlltoMem() 
        {
           

            
            if (File.Exists(UserDictPath))
            {
                Dictionary<string, UserAccountObj> ReadUserDict = JsonConvert.DeserializeObject<Dictionary<string, UserAccountObj>>(File.ReadAllText(UserDictPath));
                App.UserAccountDict = ReadUserDict;
            }
            
            if (File.Exists(MMQueuePath))
            {
                var ReadMMQueue = JsonConvert.DeserializeObject<List<FlightManifestObj>>(File.ReadAllText(MMQueuePath));
                App.MarketMangerQueue = ReadMMQueue;
            }
            if (File.Exists(TransactionHistPath))
            {   //===========================================================
                var ReadTransactions = JsonConvert.DeserializeObject<List<TransactionObj>>(File.ReadAllText(TransactionHistPath)); //NEED TO MAKE TRANSACTION OBJ
                App.TransactionHist = ReadTransactions;
            }   //===========================================================
            if (File.Exists(FlightHistDictPath))
            {
                var ReadFlightHist = JsonConvert.DeserializeObject<Dictionary<string, FlightManifestObj>>(File.ReadAllText(FlightHistDictPath));
                App.FlightHistoryDictionary = ReadFlightHist;
            }
            if (File.Exists(FlightPlanDictPath))
            {
                var ReadFlightPlans = JsonConvert.DeserializeObject<Dictionary<string, FlightManifestObj>>(File.ReadAllText(FlightPlanDictPath));
                App.FlightPlanDict = ReadFlightPlans;
            }
            

        }

        internal static void WriteAlltoFile()
        {
                      
            File.WriteAllText(UserDictPath, JsonConvert.SerializeObject(App.UserAccountDict, Formatting.Indented));            
            File.WriteAllText(MMQueuePath, JsonConvert.SerializeObject(App.MarketMangerQueue, Formatting.Indented));
            File.WriteAllText(TransactionHistPath, JsonConvert.SerializeObject(App.TransactionHist, Formatting.Indented));
            File.WriteAllText(FlightHistDictPath, JsonConvert.SerializeObject(App.FlightHistoryDictionary, Formatting.Indented));
            File.WriteAllText(FlightPlanDictPath, JsonConvert.SerializeObject(App.FlightPlanDict));
            
        }
    }
}
