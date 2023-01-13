using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabInvoiceGeneratorTestProject
{
    [TestClass]
    public class UnitTest1
    {
        InvoiceGenerator invoice = new InvoiceGenerator();
        [TestMethod]
        [DataRow(6,4)]
        public void GiveDistanceAndTIme_CalcualteFare(int distance, int time)
        {
            Ride ride = new Ride(distance, time);
            int fare = invoice.CalculateFaresForSingleRide(ride);
            Assert.AreEqual(64, fare);
        }
        [TestMethod]
        [DataRow(3, 4)]
        public void WrongDistanceCalcualteFare(int distance, int time)
        {
            try
            {
                Ride ride = new Ride(distance, time);
                int fare = invoice.CalculateFaresForSingleRide(ride);
            }
            catch(CustomException ex)
            {
                Assert.AreEqual("Distance should be greater than or equal to Five Km", ex.Message);
            }
        }
        [TestMethod]
        [DataRow(6, 0)]
        public void InvalidTime_ThrowException(int distance, int time)
        {
            try
            {
                Ride ride = new Ride(distance, time);
                int fare = invoice.CalculateFaresForSingleRide(ride);
            }
            catch (CustomException ex)
            {
                Assert.AreEqual("Time should be greater than One Minutes", ex.Message);
            }
        }
        [TestMethod]
        public void GiveDistanceAndTIme_CalcualteFareMultipleRide()
        {
            Ride rideOne = new Ride(6, 4);
            Ride rideTwo = new Ride(5, 6);
            List<Ride> rides = new List<Ride>();
            rides.Add(rideOne);
            rides.Add(rideTwo);
            Assert.AreEqual(120, invoice.CalculateFareForMultipleRide(rides));
        }
        [TestMethod]
        public void GiveInvalidDistance_CalcualteFareMultipleRide()
        {
            Ride rideOne = new Ride(4, 4);
            Ride rideTwo = new Ride(3, 6);
            List<Ride> rides = new List<Ride>();
            rides.Add(rideOne);
            rides.Add(rideTwo);
            int calFare;
            try
            {
                calFare = invoice.CalculateFareForMultipleRide(rides);
            }
            catch (CustomException exception)
            {
                Assert.AreEqual("Distance should be greater than or equal to Five Km", exception.Message);
            }
        }
        [TestMethod]
        public void GiveInvalidTime_CalcualteFareMultipleRide()
        {
            Ride rideOne = new Ride(7, 0);
            Ride rideTwo = new Ride(8, 0);
            List<Ride> rides = new List<Ride>();
            rides.Add(rideOne);
            rides.Add(rideTwo);
            int calFare;
            try
            {
                calFare = invoice.CalculateFareForMultipleRide(rides);
            }
            catch (CustomException exception)
            {
                Assert.AreEqual("Time should be greater than One Minutes", exception.Message);
            }
        }
        [TestMethod]
        public void GiveDistanceAndTime_CalcualteAverage_FareFor_MultipleRide()
        {
            Ride rideOne = new Ride(6, 4);
            Ride rideTwo = new Ride(5, 6);
            Ride rideThree = new Ride(5, 6);
            List<Ride> rides = new List<Ride>();
            rides.Add(rideOne);
            rides.Add(rideTwo);
            rides.Add(rideThree);
            invoice.CalculateFareForMultipleRide(rides);
            int avergareFair = invoice.averageCostOfRide;
            Assert.AreEqual(58, avergareFair);
        }
        [TestMethod]
        public void GiveDistanceAndTime_CalcualteNumberOfRidesFor_MultipleRide()
        {
            Ride rideOne = new Ride(6, 4);
            Ride rideTwo = new Ride(5, 6);
            Ride rideThree = new Ride(5, 6);
            List<Ride> rides = new List<Ride>();
            rides.Add(rideOne);
            rides.Add(rideTwo);
            rides.Add(rideThree);
            invoice.CalculateFareForMultipleRide(rides);
            Assert.AreEqual(3, invoice.numberOfRides);
        }
    }
}