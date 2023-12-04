using NUnit.Framework;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private CoffeeMat coffeeMat;
        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(100, 10);
        }

        [Test]
        public void CtorShouldCreateObjectNotNull()
        {
            CoffeeMat coffee = new CoffeeMat(100, 10);
            Assert.IsNotNull(coffee);
            Assert.AreEqual(100, coffee.WaterCapacity);
            Assert.AreEqual(10, coffee.ButtonsCount);
        }
        [Test]
        public void CtorShouldCreate_ButtonsCorrectly()
        {
            CoffeeMat coffee = new CoffeeMat(500, 100);
            int expectedCountOfButtons = 100;
            int result = coffee.ButtonsCount;
            Assert.AreEqual(expectedCountOfButtons, result);          
        }
        [Test]
        public void CtorShouldCreate_CapacityCorrectly()
        {
            CoffeeMat coffee = new CoffeeMat(500, 100);
            int expectedWaterCapacity = 500;
            int result = coffee.WaterCapacity;
            Assert.AreEqual(expectedWaterCapacity, result);
        }
        [Test]
        public void CtorShouldSet_Income_Correctly()
        {
            CoffeeMat coffee = new CoffeeMat(500, 100);
            double expectedIncome = 0;
            double result = coffee.Income;
            Assert.AreEqual(expectedIncome, result);
        }
        [Test]
        public void CtorShouldSet_WaterTankLevel_Correctly()
        {
            CoffeeMat coffee = new CoffeeMat(500, 100);
            string expectedWaterLevel = $"Water tank is filled with 500ml";
            string result = coffee.FillWaterTank();
            Assert.AreEqual(expectedWaterLevel, result);
        }
        [Test]
        public void FillWaterTankMethod_ShouldRetutnMessage_WhenTankIsFull()
        {
            coffeeMat.FillWaterTank();

            string expectedMSG = $"Water tank is already full!";
            string result = coffeeMat.FillWaterTank();
            Assert.AreEqual(expectedMSG, result);
        }
        [Test]
        public void AddDrinkMethod_ShouldRetutnTrue_IfCoffeeAddedSuccesfully()
        {
            Assert.IsTrue(coffeeMat.AddDrink("kafe",1));
            
        }
       
        [Test]
        public void AddDrinkMethod_ShouldRetutnFalse_IfCoffeeHaveBeenAlreadyAdded()
        {
            coffeeMat.AddDrink("kafe", 1);
            Assert.IsFalse(coffeeMat.AddDrink("kafe", 19));

        }
        [Test]
        public void AddDrinkMethod_ShouldRetutnFalse_IfButtonsCountIsEqualToCountOfAddedDrinks()
        {
            CoffeeMat coffee = new CoffeeMat(500, 1);
            coffee.AddDrink("kafe", 6);
            coffee.AddDrink("dsd", 3);
            coffee.AddDrink("dff", 9);
            Assert.IsFalse(coffee.AddDrink("otherDrink", 19));

        }
        
        [Test]
        public void BuyDrinkMethod_ShouldRetutnErrorMSG_IfWaterTank_IsBelow80()
        {
            CoffeeMat coffee = new CoffeeMat(79, 1);
            coffee.AddDrink("kafe", 6);
            coffee.FillWaterTank();
            string expected = $"CoffeeMat is out of water!";
            Assert.AreEqual(expected,coffee.BuyDrink("kafe"));

        }
        [Test]
        public void BuyDrinkMethod_ShouldRetutnErrorMSG_IfWaterTank_IsEmpty()
        {
            CoffeeMat coffee = new CoffeeMat(2000, 1);
            coffee.AddDrink("kafe", 6);
            //coffee.FillWaterTank();
            string expected = $"CoffeeMat is out of water!";
            Assert.AreEqual(expected, coffee.BuyDrink("kafe"));

        }
        [Test]
        [TestCase("otherDrink")]
        [TestCase("7677")]
        public void BuyDrinkMethod_ShouldRetutnErrorMSG_IfDrinkIsNotAdded(string drinkToBuy)
        {
            CoffeeMat coffee = new CoffeeMat(80, 1);
            coffee.FillWaterTank();
            coffee.AddDrink("kafe", 6);
            string expected = $"{drinkToBuy} is not available!";
            Assert.AreEqual(expected, coffee.BuyDrink(drinkToBuy));
           
        }
        [Test]
        [TestCase(7.98)]
        [TestCase(16.00)]
        [TestCase(0.01)]
        public void BuyDrinkMethod_ShouldRetutnCorrectPriceMsg_WhenBuyingDrinkIsSuccesfull(double price)
        {
            CoffeeMat coffee = new CoffeeMat(80, 5);
            coffee.FillWaterTank();
            coffee.AddDrink("kafe", price);
            coffee.AddDrink("ooo", price);
            coffee.AddDrink("usus", price);
            string expected = $"Your bill is {price:f2}$";
            Assert.AreEqual(expected, coffee.BuyDrink("kafe"));

        }
        [Test]
        [TestCase(7.98)]
        [TestCase(16.00)]
        [TestCase(0.01)]
        public void BuyDrinkMethod_ShouldIncreaseIncome_WhenBuyingDrinkIsSuccesfull(double price)
        {
            CoffeeMat coffee = new CoffeeMat(80, 5);
            coffee.FillWaterTank();
            coffee.AddDrink("kafe", price);
            coffee.BuyDrink("kafe");
            double expected = price;
            Assert.AreEqual(expected, coffee.Income);

        }
        [Test]
        [TestCase(7.98)]
        [TestCase(16.00)]
        [TestCase(0.01)]
        public void CollectIncomeMethod_ReturnIncome_Correctly(double price)
        {
            CoffeeMat coffee = new CoffeeMat(800, 50);
            coffee.FillWaterTank();
            coffee.AddDrink("kafe", price);
            coffee.BuyDrink("kafe");
            coffee.AddDrink("other", price);
            coffee.AddDrink("tea", price);
            coffee.BuyDrink("other");
            coffee.BuyDrink("tea");
            double expected = price*3;
            Assert.AreEqual(expected, coffee.CollectIncome());
            

        }
        [Test]
        [TestCase(150.98)]
        [TestCase(16.00)]
        [TestCase(0.01)]
        public void CollectIncomeMethod_ReturnIncome_CorrectlyWhenIncomeIsCollected(double price)
        {
            CoffeeMat coffee = new CoffeeMat(800, 50);
            coffee.FillWaterTank();
            coffee.AddDrink("kafe", price);
            coffee.BuyDrink("kafe");
            coffee.AddDrink("other", price);
            coffee.AddDrink("tea", price);
            coffee.BuyDrink("other");
            coffee.BuyDrink("tea");            
            coffee.CollectIncome();
            Assert.AreEqual(0, coffee.Income);

        }
        
        [Test]
        public void CheckWaterConsuming()
        {
            CoffeeMat coffeeMat = new CoffeeMat(240, 6);

            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);
            coffeeMat.AddDrink("Milk", 0.90);
            coffeeMat.AddDrink("Tea", 0.60);
            coffeeMat.AddDrink("Hot Water", 0.30);

            coffeeMat.BuyDrink("Coffee");
            coffeeMat.BuyDrink("Macciato");
            coffeeMat.BuyDrink("Capuccino");
            coffeeMat.BuyDrink("Latte");
            coffeeMat.BuyDrink("Milk");
            coffeeMat.BuyDrink("Hot Chocolate");
            //coffeeMat.BuyDrink("Milk");
            
            
            string actualResult = coffeeMat.BuyDrink("Coffee");

            string expectedResult = "CoffeeMat is out of water!";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}