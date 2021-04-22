using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//import UserAcounnt Obj;

namespace Software_Engineering_Project
{
    public class FlightManifestObj
    {
        int flightID { get; set; }
        public string originCode { get; set; }
        public string layoverCodeA { get; set; }
        public string layoverCodeB { get; set; }
        public string destinationCode { get; set; }
        public DateTime departTime { get; set; }
        public DateTime arrivalTime { get; set; }
        Planes planeAssigned { get; set; }
        int ticketPrice { get; set; }
        int pointReward { get; set; }
        List<UserAccountObj> bookedUsers; //I think this may have to be ints with the unique ID of the users. 
        List<int> userPaymentType;

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
