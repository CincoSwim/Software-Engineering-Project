using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_Project
{
    class UserAccountObj
    {
        string firstName;
        string lastName;
        string emailAddress;
        string passwordHash;
        string address;
        string city;
        string state;
        long phoneNumber;
        int age;
        long creditCardNumber;
        int uniqueID;
        int balance;
        List<int> upcomingFlights;
        List<int> takenFlights;
        List<int> canceledFlights;

        bool confirmPassword() {
            return false;
        }

        int getUniqueID()
        {
            return uniqueID;
        }

        int checkBalance()
        {
            return balance;
        }

        void changeBalance()
        {

        }
        
        void addBooking()
        {

        }
        
        void markFlightTaken()
        {

        }
        void makeFlightCanceled()
        {

        }
    }
}
