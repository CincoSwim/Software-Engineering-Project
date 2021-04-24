using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_Project
{  [Serializable]
   public class UserAccountObj
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string passwordHash { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public long phoneNumber { get; set; }
        public long creditCardNumber { get; set; }
        public string uniqueID { get; set; }
        public int age { get; set; }
        public int balance { get; set; }
        public List<string> upcomingFlights { get; set; } = new List<string>();
        public List<string> takenFlights { get; set; } = new List<string>();
        public List<string> canceledFlights { get; set; } = new List<string>();

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
    }
}
