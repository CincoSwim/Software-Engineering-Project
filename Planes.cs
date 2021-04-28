using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//EECS 3550 - Software Engineering
//Written By: Group 18 - Christopher Pucko, Cole Beddies, Bradley Austin
//Submitted: 4/28/2021

namespace Software_Engineering_Project
{
    public class Planes
    {
        public string planeModel;
        public int numOfSeats;

        internal int getNumOfSeats() { //could this be done with a switch? - p


            if (planeModel == "737") //using the 737-100 variant
            {
                return 85;
            }
            else if (planeModel == "747") //using the 747-100 variant
            {
                return 330;
            }
            else if (planeModel == "757") //using the 757-200 variant
            {
                return 200;
            }
            else return 1;
        }
    }
}
