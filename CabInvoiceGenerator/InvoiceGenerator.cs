using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        public int time;
        public int distance;
        readonly int rideChargePerKm;
        readonly int pricePrMinute;
        public int totalFare;
        public int averageCostOfRide;
        public int numberOfRides;
        readonly int minimumFare;
        public InvoiceGenerator()
        {
            rideChargePerKm = 10;
            pricePrMinute = 1;
            minimumFare = 5;
        }
        public int CalculateFaresForSingleRide(Ride ride)
        {
            if (ride.time < 1)
            {
                throw new CustomException(CustomException.Exceptions.TIME_SMALLER_THAN_ONE_MIN, "Time should be greater than One Minutes");
            }
            else if (ride.distance < 5)
            {
                throw new CustomException(CustomException.Exceptions.DISTANCE_SMALLER_THAN_FIVE, "Distance should be greater than or equal to Five Km");
            }
            return Math.Max(minimumFare, ride.distance * rideChargePerKm + ride.time * pricePrMinute);
        }
        public int CalculateFareForMultipleRide(List<Ride> rides)
        {
            foreach (var ride in rides)
            {
                totalFare += CalculateFaresForSingleRide(ride);
                numberOfRides++;
            }
            averageCostOfRide = totalFare / numberOfRides;
            return totalFare;
        }
    }
}
