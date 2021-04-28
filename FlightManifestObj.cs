using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//EECS 3550 - Software Engineering
//Written By: Group 18 - Christopher Pucko, Cole Beddies, Bradley Austin
//Submitted: 4/28/2021

namespace Software_Engineering_Project
{   [Serializable]
    public class FlightManifestObj
    {
        public string flightID { get; set; }
        public string originCode { get; set; }
        public string layoverCodeA { get; set; }
        public string layoverCodeB { get; set; }
        public string destinationCode { get; set; }
        public DateTime departTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public Planes planeAssigned { get; set; } = new Planes();
        public double ticketPrice { get; set; }
        public double pointReward { get; set; }
        public List<UserAccountObj> bookedUsers { get; set; } = new List<UserAccountObj>(); 
        
        DateTime getDeparture() {
            return departTime;
        }
        string getOriginCode(string originCode)
        {
            return originCode;
        }
        void setOriginCode()
        {
            originCode = originCode;
        }

         
        void addBookingAndPay() {

        }


        double getTotalSales() {
            return ticketPrice * bookedUsers.Count;
        }

        void setPlane() { }
        int getCountFreeSeats() {
            return 0;
        }
    }
}
