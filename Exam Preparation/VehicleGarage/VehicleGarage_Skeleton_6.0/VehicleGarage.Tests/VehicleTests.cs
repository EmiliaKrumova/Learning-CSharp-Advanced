using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        Vehicle vehicle = null;
        [SetUp]
        public void Setup()
        {
             vehicle = new Vehicle("Opel","Astra","EH6566HT");
        }

        [Test]
        public void CTorShouldCreateNewVehicleNotNull()
        {
            Vehicle vehicle = new Vehicle("Renault", "Megan", "EH0987PT");
            Assert.IsNotNull(vehicle);
        }
        [Test]
        public void CTorShouldCreateNewVehicleCorrectly()
        {
            string expectedBrand = "Renault";
            string expectedModel = "Megan";
            string expectedPlateNumber = "EH0987PT";
            int expectedBaterryLevel = 100;
            bool expectedIsDamaged = false;
            
            Vehicle vehicle = new Vehicle("Renault", "Megan", "EH0987PT");
            Assert.AreEqual(expectedBrand, vehicle.Brand);
            Assert.AreEqual(expectedModel, vehicle.Model);
            Assert.AreEqual(expectedPlateNumber, vehicle.LicensePlateNumber);
            Assert.AreEqual(expectedBaterryLevel, vehicle.BatteryLevel);
            Assert.AreEqual(expectedIsDamaged, vehicle.IsDamaged);
        }
        [Test]
        public void BrandPropertyShouldSetBranCorrectly()
        {
            string expectedBrand = "Opel";
            Assert.AreEqual(expectedBrand, vehicle.Brand);

        }
        [Test]
        public void ModelPropertyShouldSetBranCorrectly()
        {
            string expectedModel = "Astra";
            Assert.AreEqual(expectedModel, vehicle.Model);

        }
        [Test]
        public void PlatePropertyShouldSetDataCorrectly()
        {
            string expectedPlateNumber = "EH6566HT";
            Assert.AreEqual(expectedPlateNumber, vehicle.LicensePlateNumber);

        }
        [Test]
        public void BatteryPropertyShouldSetDataCorrectly()
        {
            int expectedBaterryLevel = 100;
            Assert.AreEqual(expectedBaterryLevel, vehicle.BatteryLevel);

        }
        [Test]
        public void IsDamagedPropertyShouldSetDataCorrectly()
        {
           
            Assert.IsFalse( vehicle.IsDamaged);

        }

    }
}