﻿using System;
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
        internal static List<TransactionObj> TransactionHist { get; set; } = new List<TransactionObj>(); //NEED TO MAKE THIS FROM INT TO TRANSACTIONOBJ

        internal static Dictionary<string, FlightManifestObj> FlightHistoryDictionary = new Dictionary<string, FlightManifestObj>();
        internal static Dictionary<string, FlightManifestObj> FlightPlanDict { get; set; } = new Dictionary<string, FlightManifestObj>();
        internal static UserAccountObj LoggedInUser = new UserAccountObj();



        void Application_Exit(object sender, ExitEventArgs e)
        {

            Console.WriteLine("App closing, saving to file");
            FileIOLoading.WriteAlltoFile();
            hasFirstLoaded = false;

        }

        internal static void Update_Flights()
        {
            Console.WriteLine("Time hit, Running Update_Flights()");
            //MessageBox.Show("Timer Hit", "", MessageBoxButton.OK);
            foreach (var entry in App.FlightPlanDict.ToList())
            {
                if (entry.Value.departTime < DateTime.Now)
                {
                    //Add entry to App.FlightHistoryDict
                    Console.WriteLine("Found a Flight, moving it: " + entry.Value.flightID);
                    App.FlightHistoryDictionary.Add(entry.Key, entry.Value);
                    foreach (var user in App.UserAccountDict) //For each user acct
                    {
                        if (user.Value.upcomingFlights.Contains(entry.Key))
                        {
                            Console.WriteLine("This user has this flight, moving: " + user.Value.uniqueID);
                            user.Value.takenFlights.Add(entry.Key);//add to taken flights
                            user.Value.upcomingFlights.Remove(entry.Key);//remove from upcoming
                            user.Value.balance += entry.Value.pointReward;
                            //if the flight was canceled, it stays in canceled
                        }
                    }

                    App.FlightPlanDict.Remove(entry.Key);//remove flight from App.FlightPlanDict
                }
            }
        }

        internal static double[,] flightGraph = new double[15, 15]
        {//                 Nashville   Cleveland   New York    Seattle     Chicago     Austin      Orlando     Los Angeles     Denver      Minneapolis     Arlington   Atlanta     Toledo      Sacramento      Rapid City
        /*nashville*/       {0,         448.15,     764.13,     0,          409.17,     756.13,     616.11,     0,              1013.48,    695.07,         561.84,     213.87,     407.29,     0,              0},      //done
        /*cleveland*/       {448.15,    0,          418.59,     0,          315.47,     0,          895.46,     0,              0,          622.03,         309.97,     554.51,     102.30,     0,              0},      //done
        /*newYork*/         {764.13,    418.59,     0,          0,          733.25,     0,          949.91,     0,              0,          1020.28,        214.45,     761.52,     520.68,     0,              0},      //done
        /*seattle*/         {0,         0,          0,          0,          0,          0,          0,          0,              1024.03,    0,              0,          0,          0,          605.35,         957.36}, //done
        /*chicago*/         {409.17,    315.47,     733.25,     0,          0,          977.66,     0,          0,              888.27,     334.15,         611.82,     605.81,     213.33,     0,              779.54}, //done
        /*austin*/          {756.13,    0,          0,          0,          977.66,     0,          994.17,     1241.53,        775.12,     1041.53,        0,          812.84,     0,          0,              999.82}, //done
        /*orlando*/         {616.11,    895.46,     949.91,     0,          0,          994.17,     0,          0,              0,          0,              759.10,     403.59,     917.91,     0,              0},      //done
        /*losAngeles*/      {0,         0,          0,          0,          0,          1241.53,    0,          0,              861.86,     0,              0,          0,          0,          372.68,         0},      //done
        /*denver*/          {1013.48,   0,          0,          1024.03,    888.27,     775.12,     0,          861.86,         0,          679.90,         0,          0,          0,          909.26,         300.49}, //done
        /*minneapolis*/     {695.07,    622.03,     1020.28,    0,          334.15,     1041.53,    0,          0,              679.90,     0,              928.86,     906.58,     526.37,     0,              489.44}, //done
        /*arlington*/       {561.84,    309.97,     214.45,     0,          611.82,     0,          759.10,     0,              0,          928.86,         0,          547.08,     404.58,     0,              0},      //done
        /*atlanta*/         {213.87,    554.51,     761.52,     0,          605.81,     812.84,     403.59,     0,              0,          906.58,         547.08,     0,          549.34,     0,              0},      //done
        /*toledo*/          {407.29,    102.30,     520.68,     0,          213.33,     0,          917.91,     0,              0,          526.37,         404.58,     549.34,     0,          0,              0},      //done
        /*sacramento*/      {0,         0,          0,          605.35,     0,          0,          0,          372.68,         909.26,     0,              0,          0,          0,          0,              0},      //done
        /*rapidCity*/       {0,         0,          0,          957.36,     779.54,     999.82,     0,          0,              300.49,     489.44,         0,          0,          0,          0,              0},      //done
        };
        

        public static String intToCode(int value)
        {
            switch(value)
            {
                case 0:
                    return "Nashville, TN";
                case 1:
                    return "Cleveland, OH";
                case 2:
                    return "New York City, NY";
                case 3:
                    return "Seattle, WA";
                case 4:
                    return "Chicago, IL";
                case 5:
                    return "Austin, TX";
                case 6:
                    return "Orlando, FL";
                case 7:
                    return "Los Angeles, CA";
                case 8:
                    return "Denver, CO";
                case 9:
                    return "Minneapolis, MN";
                case 10:
                    return "Arlington, VA";
                case 11:
                    return "Atlanta, GA";
                case 12:
                    return "Toledo, OH";
                case 13:
                    return "Sacramento, CA";
                case 14:
                    return "Rapid City, SD";
                default:
                    return "Hell, MI";
            }
        }

        public static FlightManifestObj findShortestPath(FlightManifestObj flightPlan, int begin, int end)
        {
            if (begin > 14 || begin < 0) return flightPlan;
            if (end > 14 || end < 0) return flightPlan;

            double miles = 0;
            double minMiles = 0;

            //no layovers
            if (flightGraph[begin, end] != 0)
            {
                miles = flightGraph[begin, end];
                flightPlan.ticketPrice = Math.Round(50 + (0.12 * miles), 2);
                flightPlan.pointReward = Math.Round(10 * flightPlan.ticketPrice, 2);
                flightPlan.layoverCodeA = "N/A";
                flightPlan.layoverCodeB = "N/A";
                return flightPlan;
            } 
            //will go through every possible path and save the shortest one
            else
            {
                for (int i = 0; i < 15; i++)
                {
                    if (flightGraph[begin, i] != 0)
                    {   
                        //1 layover
                        if (flightGraph[i, end] != 0)
                        {
                            miles = (flightGraph[begin, i] + flightGraph[i, end]);
                            if (minMiles > miles || minMiles == 0) 
                            {
                                minMiles = miles;
                                flightPlan.ticketPrice = Math.Round((0.12 * miles) + 58, 2);
                                flightPlan.pointReward = Math.Round(10 * flightPlan.ticketPrice, 2);
                                flightPlan.layoverCodeA = intToCode(i);
                                flightPlan.layoverCodeB = "N/A";
                            }
                        }
                        //2 layovers
                        else
                        {
                            for (int j = 0; j < 15; j++)
                            {
                                if (flightGraph[i, j] != 0)
                                {
                                    if (flightGraph[j, end] != 0)
                                    {
                                        miles = (flightGraph[begin, i] + flightGraph[i, j] + flightGraph[j, end]);
                                        if (minMiles > miles || minMiles == 0) 
                                        {
                                            minMiles = miles;
                                            flightPlan.ticketPrice = Math.Round((0.12 * miles) + 66, 2);
                                            flightPlan.pointReward = Math.Round(10 * flightPlan.ticketPrice, 2);
                                            flightPlan.layoverCodeA = intToCode(i);
                                            flightPlan.layoverCodeB = intToCode(j);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return flightPlan;
        }

        public static FlightManifestObj applyDiscounts(FlightManifestObj flight)
        {
            TimeSpan redEyeStart = new TimeSpan(0, 0, 0);
            TimeSpan redEyeEnd = new TimeSpan(5, 0, 0);
            TimeSpan offPkStart = new TimeSpan(8, 0, 0);
            TimeSpan offPkEnd = new TimeSpan(19, 0, 0);

            if (flight.departTime.TimeOfDay > redEyeStart && flight.departTime.TimeOfDay < redEyeEnd)
            {
                flight.ticketPrice = Math.Round(0.8 * flight.ticketPrice, 2);
                flight.pointReward = Math.Round(0.8 * flight.pointReward, 2);
            }
            else if (flight.departTime.TimeOfDay < offPkStart || flight.arrivalTime.TimeOfDay > offPkEnd)
            {
                flight.ticketPrice = Math.Round(0.9 * flight.ticketPrice, 2);
                flight.pointReward = Math.Round(0.9 * flight.pointReward, 2);
            }

            return flight;
        }
    }
}
   

