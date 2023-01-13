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
            TimeSmallerThaOneMin,
            DistanceSmallerThanFive,
            InvalidUserId
        }
        public CustomException(Exceptions type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
