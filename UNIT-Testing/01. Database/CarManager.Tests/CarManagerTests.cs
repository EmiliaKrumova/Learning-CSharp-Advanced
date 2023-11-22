namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;
    using System.Runtime.ConstrainedExecution;

    [TestFixture]
    public class CarManagerTests
    {
       
        [Test]
        public void WhenCreateCar_TheEmptyCTORShouldCreateCar_WithFuelAmount_0()
        {
            // public Car(string make, string model, double fuelConsumption, double fuelCapacity) : this()
            Car car = new Car("make", "model", 5, 5);
            double expectedFuelAmount = 0;
            double actualResultFuelAmount = car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualResultFuelAmount);

        }
        [Test]
        public void CtorShouldCreateCarCorrectly()
        {
            string make = "make";
            string model = "model";
            double fuelConsumption = 5.63;
            double fuelCapacity = 99.98;
            Car car = new Car("make","model",5.63,99.98);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        public void CtorShouldThrowException_WhenMakeIsEmpty()
        {
           
            
            Assert.Throws<ArgumentException>(() =>
            { Car car = new Car("", "model", 5.63, 99.98); }, "Make cannot be null or empty!");

        }
        [Test]
        public void CtorShouldThrowException_WhenMakeIsNull()
        {
          

            Assert.Throws<ArgumentException>(() =>
            { Car car = new Car(null, "model", 5.63, 99.98); }, "Make cannot be null or empty!");

        }
        [Test]
        public void CtorShouldThrowException_WhenModelIsEmpty()
        {


            Assert.Throws<ArgumentException>(() =>
            { Car car = new Car("make", "", 5.63, 99.98); }, "Model cannot be null or empty!");

        }
        [Test]
        public void CtorShouldThrowException_WhenModelIsNull()
        {


            Assert.Throws<ArgumentException>(() =>
            { Car car = new Car("make", null, 5.63, 99.98); }, "Model cannot be null or empty!");

        }
        [Test]
        public void CtorShouldThrowException_WhenConsumptionIs_0()
        {


            Assert.Throws<ArgumentException>(() =>
            { Car car = new Car("make", "model", 0, 99.98); }, "Fuel consumption cannot be zero or negative!");

        }
        [Test]
        public void CtorShouldThrowException_WhenConsumptionIs_Negative()
        {


            Assert.Throws<ArgumentException>(() =>
            { Car car = new Car("something", "else", -9.87, 99.98); }, "Fuel consumption cannot be zero or negative!");

        }
        [Test]
        public void CarFuelAmountShouldThrowExceptionIfIsNegative()
        {
            Car car = new Car("something", "else", 4, 99.98);
            Assert.Throws<InvalidOperationException>(()
                => car.Drive(12), "Fuel amount cannot be negative!");
        }
        [Test]
        public void DriveMethod_ShouldThrowException_WhenFuelAmountIs_NotEnogh()
        {
           
            Car car = new Car("something", "else", 4, 99.98);


           Assert.Throws<InvalidOperationException>(()
               => { car.Drive(12); ; }, "You don't have enough fuel to drive!");
           

        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CtorShouldThrowException_WhenFuelCapacityIs_0_OrNegative(double capacity)
        {


            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            { Car car = new Car("make", "model", 6.9, capacity); });


            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);

        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelMethod_ShouldThrowException_WhenFuel_0_OrNegative(double fuel)
        {
            Car car = new Car("make", "model", 2.9, 50.87);

            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {car.Refuel(fuel) ; });


            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);

        }
        [Test]
        [TestCase(24)]
        [TestCase(35.98)]
        public void RefuelMethod_ShouldIncreaseFuelAmount(double fuel)
        {
            double expectedFuelAmount = fuel;
            Car car = new Car("make", "model", 2.9, 50.87);
            car.Refuel(fuel);           


            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);

        }
        [Test]
        [TestCase(52.7)]
        [TestCase(365.98)]
        public void RefuelMethod_ShouldIncreaseFuelAmount_UntilIsEqualToCapacity(double fuel)
        {
            double expectedFuelAmount = 50.87;
            Car car = new Car("make", "model", 27.9, 50.87);
            car.Refuel(fuel);


            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);

        }
        [Test]
        [TestCase(1)]
        [TestCase(200)]
        public void DriveMethod_ShouldThrowException_When_NeededFuelIsBigger_ThanFuelAmount(double km)
        {
            Car car = new Car("make", "model", 2.9, 50.87);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            { car.Drive(km); });


            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);

        }
        [Test]
        [TestCase(10,15)]
        [TestCase(50,170)]
        [TestCase(100,800)]
        public void DriveMethod_ShouldDecreaseFuelAmount(double fuelToRefuel, double km)
        {
            
            Car car = new Car("make", "model", 10, 100);
            car.Refuel(fuelToRefuel);
            car.Drive(km);

            double expectedFuelAmount = fuelToRefuel -= km * 10 / 100;


            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);

        }




    }
}