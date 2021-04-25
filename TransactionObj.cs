using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_Project
{   [Serializable]
    class TransactionObj
    {   
        //Holds records of individual transactions for access by Accountant
        //Includes a reference to a user, a flight, and the amount in the transaction
        public string UserUID { get; set; }
        public FlightManifestObj FlightUID { get; set; }
        public double transactionAmt { get; set; }

    }
}
