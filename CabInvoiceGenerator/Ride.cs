using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        public int distance;
        public int time;


        public Ride(int distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
