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
        //FileIOLoading
        //This class deals with FileIO operations to write and read persistent data to-and-from system storage
        //Files are written in a txt formatted in JavaScript Object Notation or JSON. All files stored by this program write to the C:\temp\ directory.
        //These files are read into memory when the program first starts, and written to memory when the program completely ends (usually by closing MainWindow)
        //If one of these files is missing, the program will instead start with the corresponding C# collection as a fresh collection.


        //Windows Filesystem paths for saving and reading files. Those in the \Printouts\ directory are made public so that other windows can use them to write that directory.
        static string tempDir = @"c:\temp\";
        public static string printoutDir = @"c:\temp\Printouts\";
        static string UserDictPath = @"c:\temp\UserDict.txt";
        static string MMQueuePath = @"c:\temp\MMQueueDict.txt";
        static string TransactionHistPath = @"c:\temp\TransHistList.txt";
        static string FlightHistDictPath = @"c:\temp\FlightHistDict.txt";
        static string FlightPlanDictPath = @"c:\temp\FlightPlanDict.txt";
        public static string AccountantSinglePath = @"c:\temp\Printouts\SingleSelection.txt";
        public static string AccountantMultiPath = @"c:\temp\Printouts\AllSelection.txt";
        public static string BoardingPassPath = @"c:\temp\Printouts\BoardingPass.txt";

        internal static void ReadAlltoMem() 
        {
            //Checks if a file with the correct name exists at a path. If it does, it deserializes the object into the proper Collection type, and loads it into the
            //static Collections in App.xaml.cs
            if (File.Exists(UserDictPath))//User Dictionary
            {
                Dictionary<string, UserAccountObj> ReadUserDict = JsonConvert.DeserializeObject<Dictionary<string, UserAccountObj>>(File.ReadAllText(UserDictPath));
                App.UserAccountDict = ReadUserDict;
            }
            
            if (File.Exists(MMQueuePath))//Marketing Manager Approval Queue
            {
                var ReadMMQueue = JsonConvert.DeserializeObject<List<FlightManifestObj>>(File.ReadAllText(MMQueuePath));
                App.MarketMangerQueue = ReadMMQueue;
            }
            if (File.Exists(TransactionHistPath))//Transaction Records
            {  
                var ReadTransactions = JsonConvert.DeserializeObject<List<TransactionObj>>(File.ReadAllText(TransactionHistPath)); //NEED TO MAKE TRANSACTION OBJ
                App.TransactionHist = ReadTransactions;
            }   
            if (File.Exists(FlightHistDictPath))//Past Flight Histories
            {
                var ReadFlightHist = JsonConvert.DeserializeObject<Dictionary<string, FlightManifestObj>>(File.ReadAllText(FlightHistDictPath));
                App.FlightHistoryDictionary = ReadFlightHist;
            }
            if (File.Exists(FlightPlanDictPath))//Flights available for booking
            {
                var ReadFlightPlans = JsonConvert.DeserializeObject<Dictionary<string, FlightManifestObj>>(File.ReadAllText(FlightPlanDictPath));
                App.FlightPlanDict = ReadFlightPlans;
            }
            

        }

        internal static void WriteAlltoFile()
        {
            //Writes all the relevant static collections from App.xaml.cs to their appropriate paths as a JSON-formatted .txt
            FileInfo pathing = new FileInfo(printoutDir);
            pathing.Directory.Create();
            File.WriteAllText(UserDictPath, JsonConvert.SerializeObject(App.UserAccountDict, Formatting.Indented));            
            File.WriteAllText(MMQueuePath, JsonConvert.SerializeObject(App.MarketMangerQueue, Formatting.Indented));
            File.WriteAllText(TransactionHistPath, JsonConvert.SerializeObject(App.TransactionHist, Formatting.Indented));
            File.WriteAllText(FlightHistDictPath, JsonConvert.SerializeObject(App.FlightHistoryDictionary, Formatting.Indented));
            File.WriteAllText(FlightPlanDictPath, JsonConvert.SerializeObject(App.FlightPlanDict, Formatting.Indented));
            
        }
    }
}
