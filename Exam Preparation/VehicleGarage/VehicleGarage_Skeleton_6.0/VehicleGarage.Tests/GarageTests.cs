using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleGarage.Tests
{
    public class GarageTests
    {
        Garage garage;
        private List<Vehicle> vehicles;
        [SetUp]
        public void Setup()
        {
            vehicles = new List<Vehicle>();
            garage = new Garage(25);
        }
        [Test]
        public void CtorShouldSetGarageNotNull()
        {
            garage = new Garage(20);
            Assert.IsNotNull(garage);

        }
        [Test]
        public void CtorShouldSetvehiclesListeNotNull()
        {
            garage = new Garage(20);
            Assert.IsNotNull(garage.Vehicles);

        }
        [Test]
        public void CapacityShouldSetCorrectly()
        {
            int expectedCapacity = 25;
            Assert.AreEqual(expectedCapacity, garage.Capacity);

        }
        [Test]
        [TestCase(1)]
        [TestCase(21)]
        [TestCase(25)]
        [TestCase(0)]
        public void AddVehiclesMethodShouldAddVehicleCorrectly(int countOfAddedVehicles)
        {
            int expectedCount = countOfAddedVehicles;
            for(int i = 0; i < countOfAddedVehicles; i++)
            {
                Vehicle vehicle = new Vehicle($"brand{i}",$"model{i}",$"plateNumber{i}");
                garage.AddVehicle(vehicle);
            }
            Assert.AreEqual(expectedCount, garage.Vehicles.Count);

        }
        [Test]
        public void AddVehiclesMethodShouldReturn_True_WhenVehicleAddedSuccesfully()
        {            
            Vehicle vehicle = new Vehicle($"brand", $"model", $"plateNumber");
            Assert.IsTrue(garage.AddVehicle(vehicle));
        }
        [Test]
        public void AddVehiclesMethodShouldReturn_False_WhenCapacityIsFull()
        {
            Garage garage = new Garage(2);
            Vehicle vehicle1 = new Vehicle($"brand", $"model", $"plateNumber");
            garage.AddVehicle(vehicle1 );
            Vehicle vehicle2 = new Vehicle($"brand2", $"model2", $"plateNumber2");
            garage.AddVehicle(vehicle2);
            Vehicle vehicle3 = new Vehicle($"brand3", $"model3", $"plateNumber3");
            Assert.IsFalse(garage.AddVehicle(vehicle3));
        }
        [Test]
        public void AddVehiclesMethodShouldReturn_False_WhenIsAddedVehicle_WithSame_PlateNumber()
        {
            Garage garage = new Garage(5);
            Vehicle vehicle1 = new Vehicle($"brand", $"model", $"plateNumber");
            garage.AddVehicle(vehicle1);
            Vehicle vehicle2 = new Vehicle($"brand2", $"model2", $"plateNumber2");
            garage.AddVehicle(vehicle2);
            Vehicle vehicle3 = new Vehicle($"brand3", $"model3", $"plateNumber2");
            Assert.IsFalse(garage.AddVehicle(vehicle3));
        }
        [Test]
        [TestCase(5,92)]
        [TestCase(8,53)]
       public void ChargeVehiclesMethodShouldChargeBatteriesCorectly(int countOfAddedVehicles, int batteryLevel)
        {
            int expectedBatteryLevel = 100;
            for (int i = 0; i < countOfAddedVehicles; i++)
            {
                Vehicle vehicle = new Vehicle($"brand{i}", $"model{i}", $"plateNumber{i}");
                garage.AddVehicle(vehicle);
                garage.DriveVehicle($"plateNumber{i}",i+58,false);
                garage.ChargeVehicles(batteryLevel);
                Assert.AreEqual(expectedBatteryLevel, garage.Vehicles[i].BatteryLevel);
            }
        }
        [Test]

        public void ChargeVehiclesMethodShouldReturnCount_ofChargedVehicles()
        {

            Vehicle vehicle = new Vehicle("brand", "model", "plate1Number");
            Vehicle vehicle1 = new Vehicle("brand", "model", "plate2Number");
            Vehicle vehicle2 = new Vehicle("brand", "model", "plate3Number");
            Vehicle vehicle3 = new Vehicle("brand", "model", "plate4Number");
            Vehicle vehicle4 = new Vehicle("brand", "model", "plate5Number");
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.AddVehicle(vehicle4);
            garage.DriveVehicle("plate1Number", 50, false);
            garage.DriveVehicle("plate5Number",50,false);
            garage.DriveVehicle("plate5Number", 49, false);
            Assert.AreEqual(2,garage.ChargeVehicles(50));


        }
       
        [Test]
        [TestCase(22)]
        [TestCase(0)]
        [TestCase(99)]
        [TestCase(100)]

        public void DriveVehicleMethod_ShouldDrainBattery(int drainage)
        {
            Vehicle vehicle1 = new Vehicle("brand", "model", "plateNumber");
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle("plateNumber", drainage, false);
            int expected = 100 - drainage;
           Assert.AreEqual(expected, vehicle1.BatteryLevel);
           
        }
        [Test]
        [TestCase(22)]
        [TestCase(0)]
        [TestCase(99)]
        [TestCase(100)]

        public void DriveVehicleMethod_ShouldNotDrainBattery_WhenVehicle_IsDamaged(int drainage)
        {
            Vehicle vehicle1 = new Vehicle("brand", "model", "plateNumber");
            vehicle1.IsDamaged = true;
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle("plateNumber", drainage, false);
            int expected = 100 ;
            Assert.AreEqual(expected, vehicle1.BatteryLevel);
            Assert.AreEqual(expected, garage.Vehicles.First(v => v.LicensePlateNumber == "plateNumber").BatteryLevel);
        }
        [Test]
        [TestCase(101)]
        [TestCase(1008)]        

        public void DriveVehicleMethod_ShouldNotDrainBattery_WhenDrainageIsOver100(int drainage)
        {
            Vehicle vehicle1 = new Vehicle("brand", "model", "plateNumber");
            
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle("plateNumber", drainage, false);
            int expected = 100;
            Assert.AreEqual(expected, vehicle1.BatteryLevel);
            
        }
        [Test]
        [TestCase(65)]
        [TestCase(58)]

        public void DriveVehicleMethod_ShouldNotDrainBattery_WhenBatteryLevel_IsSmaller_ThanDrainage(int drainage)
        {
            Vehicle vehicle1 = new Vehicle("brand", "model", "plateNumber");            
            garage.AddVehicle(vehicle1);
            garage.DriveVehicle("plateNumber", 46, false);
            garage.DriveVehicle("plateNumber", drainage, false);
            int expected = 54;
            Assert.AreEqual(expected, vehicle1.BatteryLevel);

        }
        [Test]
        [TestCase(65)]
        [TestCase(58)]

        public void DriveVehicleMethod_ShouldSet_IsDamaged_True_WhenIsInvokedWithIsDamaged_True(int drainage)
        {
            Vehicle vehicle1 = new Vehicle("brand", "model", "plateNumber");
            
            garage.AddVehicle(vehicle1);           
            garage.DriveVehicle("plateNumber", drainage, true);
            
            Assert.IsTrue( vehicle1.IsDamaged);

        }
       
        [Test]
        
        public void RepairMethodShouldReturnCountOfRepairedVehicles()
        {
            Vehicle vehicle = new Vehicle("brand", "model", "plate1Number");
            Vehicle vehicle1 = new Vehicle("brand", "model", "plate2Number");
            Vehicle vehicle2 = new Vehicle("brand", "model", "plate3Number");
            Vehicle vehicle3 = new Vehicle("brand", "model", "plate4Number");
            Vehicle vehicle4 = new Vehicle("brand", "model", "plate5Number");
            Vehicle scooter = new Vehicle("Yamaha", "Aerox", "PB6006PA");
            vehicle.IsDamaged = true;
            vehicle3.IsDamaged = true;
            vehicle4.IsDamaged = true;

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.AddVehicle(vehicle4);
            garage.AddVehicle(scooter);

            string expectedCountOfRepairs = $"Vehicles repaired: 3";
            Assert.AreEqual(expectedCountOfRepairs, garage.RepairVehicles());
           

            Assert.IsFalse(vehicle.IsDamaged);
            Assert.IsFalse(vehicle3.IsDamaged);
            Assert.IsFalse(vehicle4.IsDamaged);

        }
        [Test]

        public void RepairMethodShouldReturnCountOfRepairedVehiclesCorrect()
        {
            Vehicle vehicle = new Vehicle("brand", "model", "plate1Number");
            Vehicle vehicle1 = new Vehicle("brand", "model", "plate2Number");
            Vehicle vehicle2 = new Vehicle("brand", "model", "plate3Number");
            Vehicle vehicle3 = new Vehicle("brand", "model", "plate4Number");
            Vehicle vehicle4 = new Vehicle("brand", "model", "plate5Number");
            Vehicle scooter = new Vehicle("Yamaha", "Aerox", "PB6006PA");
            

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.AddVehicle(vehicle4);
            garage.AddVehicle(scooter);
            garage.DriveVehicle("plate1Number", 55, true);
            garage.DriveVehicle("plate3Number", 55, true);
            garage.DriveVehicle("plate4Number", 55, true);
            garage.DriveVehicle("plate5Number", 55, false);

            string expectedCountOfRepairs = $"Vehicles repaired: 3";
            Assert.AreEqual(expectedCountOfRepairs, garage.RepairVehicles());


            Assert.IsFalse(vehicle.IsDamaged);
            Assert.IsFalse(vehicle3.IsDamaged);
            Assert.IsFalse(vehicle4.IsDamaged);

        }

    }
}
