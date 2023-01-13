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
    }
}