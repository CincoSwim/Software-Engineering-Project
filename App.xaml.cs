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
       
        internal static Dictionary<int, UserAccountObj> UserAccountDict { get; set; }

        
        internal static Dictionary<int, FlightManifestObj> FlightPlanDict { get; set; }


        internal static UserAccountObj LoggedInUser;


    }
}
