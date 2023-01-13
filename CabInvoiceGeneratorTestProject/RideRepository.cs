using CabInvoiceGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorTestProject
{
    public class RideRepository
    {
        public Dictionary<string, List<Ride>> rideRepository;
        public RideRepository()
        {
            rideRepository = new Dictionary<string, List<Ride>>();
        }
        public void AddRide(string userId, Ride ride)
        {
            if (rideRepository.ContainsKey(userId))
                rideRepository[userId].Add(ride);
            else
            {
                rideRepository.Add(userId, new List<Ride>());
                rideRepository[userId].Add(ride);
            }
        }
        public List<Ride> GetListOfRides(string userID)
        {
            if (rideRepository.ContainsKey(userID))
                return rideRepository[userID];
            else throw new CustomException(CustomException.Exceptions.INVLID_USER_ID, "Invalid User ID");
        }
    }
}
