using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_Project
{
    public class UserAccountObj
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
        public string getFirstName()
        {
            return firstName;
        }
        public void setFirstName(string fname)
        {
            firstName = fname;
        }
        public string getLastName()
        {
            return lastName;
        }
        public void setLastName(string lname)
        {
            lastName = lname;
        }
        public string getEmailAddress()
        {
            return emailAddress;
        }
        public void setEmailAddress(string email)
        {
            emailAddress = email;
        }
        public string getPwdHash()
        {
            return passwordHash;
        }
        public void setPwdHash(string pwdHash)
        {
            passwordHash = pwdHash;
        }
        public string getAddress()
        {
            return address;
        }
        public void setAddress(string adr)
        {
            address = adr;
        }
        public string getCity()
        {
            return city;
        }
        public void setCity(string cit)
        {
            city = cit;
        }
        public string getState()
        {
            return state;
        }
        public void setState(string st)
        {
            state = st;
        }
        public long getPhoneNum()
        {
            return phoneNumber;
        }
        public void setPhoneNum(long phNum)
        {
            phoneNumber = phNum;
        }
        public int getAge()
        {
            return age;
        }
        public void setAge(int anos)
        {
            age = anos;
        }
        public long getCCNumber()
        {
            return creditCardNumber;
        }
        public void setCCNumber(long ccNum)
        {
            creditCardNumber = ccNum;
        }
        public string getUniqueID()
        {
            return uniqueID;
        }
        public void setUniqueID(string UID)
        {
            uniqueID = UID;
        }
        public int getBalance()
        {
            return balance;
        }
        public void setBalance(int newBal)
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
