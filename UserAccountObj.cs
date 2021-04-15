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
        string uniqueID;
        int balance;
        List<string> upcomingFlights;
        List<string> takenFlights;
        List<string> canceledFlights;

        //Getters and setters in order-------------------------------------------------------------------------------------------
        string getFirstName()
        {
            return firstName;
        }
        void setFirstName(string fname)
        {
            firstName = fname;
        }
        string getLastName()
        {
            return lastName;
        }
        void setLastName(string lname)
        {
            lastName = lname;
        }
        string getEmailAddress()
        {
            return emailAddress;
        }
        void setEmailAddress(string email)
        {
            emailAddress = email;
        }
        string getPwdHash()
        {
            return passwordHash;
        }
        void setPwdHash(string pwdHash)
        {
            passwordHash = pwdHash;
        }
        string getAddress()
        {
            return address;
        }
        void setAddress(string adr)
        {
            address = adr;
        }
        string getCity()
        {
            return city;
        }
        void setCity(string cit)
        {
            city = cit;
        }
        string getState()
        {
            return state;
        }
        void setState(string st)
        {
            state = st;
        }
        long getPhoneNum()
        {
            return phoneNumber;
        }
        void setPhoneNum(long phNum)
        {
            phoneNumber = phNum;
        }
        int getAge()
        {
            return age;
        }
        void setAge(int anos)
        {
            age = anos;
        }
        long getCCNumber()
        {
            return creditCardNumber;
        }
        void setCCNumber(long ccNum)
        {
            creditCardNumber = ccNum;
        }
        string getUniqueID()
        {
            return uniqueID;
        }
        void setUniqueID(string UID)
        {
            uniqueID = UID;
        }
        int getBalance()
        {
            return balance;
        }
        void setBalance(int newBal)
        {
            balance = newBal;
        }
        //End Getters and Setters -----------------------------------------------------------------------------------------------------------------

        //Manipulate Bookings
        void addBooking(string FlightNum)
        {

        }
        
        void markFlightTaken(string FlightNum)
        {

        }
        void markFlightCanceled(string FlightNum)
        {

        }
        bool confirmPassword(string recievedPass)
        {
            return false;
        }
    }
}
