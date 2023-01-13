using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CustomException : Exception
    {
        public Exceptions type;
        public enum Exceptions
        {
            TIME_SMALLER_THAN_ONE_MIN,
            DISTANCE_SMALLER_THAN_FIVE,
            INVLID_USER_ID
        }
        public CustomException(Exceptions type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
