﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_Project
{   [Serializable]
    class TransactionObj
    {
        public string UserUID { get; set; }
        public string FlightUID { get; set; }
        public double transactionAmt { get; set; }
    }
}
