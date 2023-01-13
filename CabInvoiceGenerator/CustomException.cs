using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CustomException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            TIME_SMALLER_THAN_ONE_MIN,
            DISTANCE_SMALLER_THAN_FIVE,
            INVLID_USER_ID,
            INVAID_RIDE_TYPE
        }
        public CustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
