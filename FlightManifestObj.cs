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
        int flightID;
        public string originCode;
        string layoverCodeA;
        string layoverCodeB;
        public string destinationCode;
        public DateTime departTime;
        public DateTime arrivalTime;
        Planes planeAssigned;
        int ticketPrice;
        int pointReward;
        List<UserAccountObj> bookedUsers; //I think this may have to be ints with the unique ID of the users. 
        List<int> userPaymentType;

        //Recieve Departure Time for Each Plane. 
        //Uses departTime from Flight ManifestObj
        DateTime getDeparture() {
            return departTime;
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
