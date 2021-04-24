using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//going off this list
// https://blog.thetravelinsider.info/airplane-types#Boeing
namespace Software_Engineering_Project
{
    public class Planes
    {
        public string planeModel, uniquePlaneRegister;
        public int numOfSeats;

        int getNumOfSeats() { //could this be done with a switch? - p


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
