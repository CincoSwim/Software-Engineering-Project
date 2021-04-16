using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Software_Engineering_Project
{
   
    public partial class App : Application
    {

        internal static Dictionary<string, UserAccountObj> UserAccountDict { get; set; } = new Dictionary<string, UserAccountObj>();


        internal static Dictionary<string, FlightManifestObj> FlightPlanDict { get; set; } = new Dictionary<string, FlightManifestObj>();


        internal static UserAccountObj LoggedInUser = new UserAccountObj();


    }
}
