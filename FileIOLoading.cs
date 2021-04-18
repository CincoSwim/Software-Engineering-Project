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

        internal static void ReadAlltoMem() 
        {
           /* using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(UserDictPath).ToArray()))
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                App.UserAccountDict = (Dictionary<string, UserAccountObj>)binFormatter.Deserialize(ms);
            }
            */

            
            if (File.Exists(UserDictPath))
            {
                Dictionary<string, UserAccountObj> ReadUserDict = JsonConvert.DeserializeObject<Dictionary<string, UserAccountObj>>(File.ReadAllText(UserDictPath));
                foreach(KeyValuePair<string, UserAccountObj> entry in ReadUserDict)
                {
                    Console.WriteLine("loaded entry - " + entry.Key + " - " + entry.Value.emailAddress);
                }
                App.UserAccountDict = ReadUserDict;
            }
            
            /*
            if (File.Exists(UserDictPath))
            {
                var ReadUserDict = new JavaScriptSerializer().Deserialize<Dictionary<string, UserAccountObj>>(File.ReadAllText(UserDictPath));
                App.UserAccountDict = ReadUserDict;
            }
            if (File.Exists(MMQueuePath))
            {
                var ReadMMQueue = new JavaScriptSerializer().Deserialize<List<FlightManifestObj>>(File.ReadAllText(MMQueuePath));
                App.MarketMangerQueue = ReadMMQueue;
            }
            if (File.Exists(TransactionHistPath))
            {   //SHOJEFABG:FJGH:ASDKJFGHA:SKLJGHDF
                var ReadTransactions = new JavaScriptSerializer().Deserialize<List<int>>(File.ReadAllText(TransactionHistPath)); //NEED TO MAKE TRANSACTION OBJ
                App.TransactionHist = ReadTransactions;
            }
            if (File.Exists(FlightHistDictPath))
            {
                var ReadFlightHist = new JavaScriptSerializer().Deserialize<Dictionary<string, FlightManifestObj>>(File.ReadAllText(FlightHistDictPath));
                App.FlightHistoryDictionary = ReadFlightHist;
            }
            if (File.Exists(FlightPlanDictPath))
            {
                var ReadFlightPlans = new JavaScriptSerializer().Deserialize<Dictionary<string, FlightManifestObj>>(File.ReadAllText(FlightPlanDictPath));
                App.FlightPlanDict = ReadFlightPlans;
            }
            */

        }

        internal static void WriteAlltoFile()
        {
           /* using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(ms, App.UserAccountDict);
                byte[] dicBytes = ms.ToArray();
                File.WriteAllBytes(UserDictPath, dicBytes);
            }
            */





            
            File.WriteAllText(UserDictPath, JsonConvert.SerializeObject(App.UserAccountDict, Formatting.Indented));

            /*
            File.WriteAllText(MMQueuePath, new JavaScriptSerializer().Serialize(App.MarketMangerQueue));
            File.WriteAllText(TransactionHistPath, new JavaScriptSerializer().Serialize(App.TransactionHist));
            File.WriteAllText(FlightHistDictPath, new JavaScriptSerializer().Serialize(App.FlightHistoryDictionary));
            File.WriteAllText(FlightPlanDictPath, new JavaScriptSerializer().Serialize(App.FlightPlanDict));
            */
        }
    }
}
