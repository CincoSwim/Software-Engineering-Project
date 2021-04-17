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

        int nashville = 0;
        int cleveland = 1;
        int newYork = 2;
        int seattle = 3;
        int chicago = 4;
        int austin = 5;
        int orlando = 6;
        int losAngeles = 7;
        int denver = 8;
        int minneapolis = 9;
        int arlington = 10;
        int atlanta = 11;
        int toledo = 12;
        int sacramento = 13;
        int rapidCity = 14;

        internal static double[15, 15] flightGraph = new double[15, 15] 
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
        }

        public findShortestPath(int begin, int end)
        {
            if (begin > 14 || begin < 0) return;
            if (end > 14 || end < 0) return;

            double miles = 0;
            double minMiles = 0;
            double price = 0;
            int layoverOne = 15;
            int layoverTwo = 15;
            
            //no layovers
            if (flightGraph[begin][end] != 0)
            {
                miles = flightGraph[begin][end];
                price = 0.15 * miles;
                return;
            } 
            //will go through every possible path and save the shortest one
            else
            {
                for (int i = 0; i < 15; i++)
                {
                    if (flightGraph[begin][i] != 0)
                    {   
                        //1 layover
                        if (flightGraph[i][end] != 0)
                        {
                            miles = (flightGraph[begin][i] + flightGraph[i][end]);
                            if (minMiles > miles || minMiles == 0) 
                            {
                                minMiles = miles;
                                double price = 0.15 * miles;
                                layoverOne = i;
                                layoverTwo = 15;
                            }
                        }
                        //2 layovers
                        else
                        {
                            for (int j = 0; j < 15; j++)
                            {
                                if (flightGraph[i][j] != 0)
                                {
                                    if (flightGraph[j][end] != 0)
                                    {
                                        miles = (flightGraph[begin][i] + flightGraph[i][j] + flightGraph[j][end]);
                                        if (minMiles > miles || minMiles == 0) 
                                        {
                                            minMiles = miles;
                                            double price = 0.15 * miles;
                                            layoverOne = i;
                                            layoverTwo = j;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            /*
            //if path still hasn't been found, we need 2 layovers
            //2 layovers
            //will go through every possible path and save the shortest one
            if (miles == 0)
            {
                for (int i = 0; i < 15; i++)
                {
                    if (flightGraph[begin][i] != 0)
                    {
                        for(int j = 0; j < 15; j++)
                        {
                            if (flightGraph[i][j] != 0)
                            {
                                if (flightGraph[j][end] != 0)
                                { 
                                    miles = (flightGraph[begin][i] + flightGraph[i][j] + flightGraph[j][end]);
                                    if (minMiles > miles || minMiles == 0) 
                                    {
                                        minMiles = miles;
                                        double price = 0.15 * miles;
                                        layoverOne = i;
                                        layoverTwo = j;
                                    }
                                }
                            }
                        }
                    }
                }
            */
            }
        }
    }
}
