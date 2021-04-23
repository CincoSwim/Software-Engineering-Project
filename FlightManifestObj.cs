using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//import UserAcounnt Obj;

namespace Software_Engineering_Project
{   [Serializable]
    public class FlightManifestObj
    {
        public int flightID { get; set; }
        public string originCode { get; set; }
        public string layoverCodeA { get; set; }
        public string layoverCodeB { get; set; }
        public string destinationCode { get; set; }
        public DateTime departTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public Planes planeAssigned { get; set; }
        public double ticketPrice { get; set; }
        public int pointReward { get; set; }
        public List<UserAccountObj> bookedUsers { get; set; } //I think this may have to be ints with the unique ID of the users. 
        public List<int> userPaymentType { get; set; }

        //Recieve Departure Time for Each Plane. 
        //Uses departTime from Flight ManifestObj
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

        //Pays for flight and updates flight list
        //Uses bookedUsers and ticketPrice to accomplish this
        //Need userID. 
        void addBookingAndPay() {

        }


        int getTotalSales() {
            return ticketPrice * bookedUsers.Count;
        }

        void setPlane() { }
        int getCountFreeSeats() {
            return 0;
        }
    }
}
