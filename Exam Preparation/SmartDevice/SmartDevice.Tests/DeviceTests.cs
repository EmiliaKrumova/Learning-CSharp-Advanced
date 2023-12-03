namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device;
        [SetUp]
        public void Setup()
        {
            device = new Device(50);
        }

        [Test]
        public void CtorOfDeviceShouldWorkCorrectly()
        {      
            Device current = new Device(40);
            Assert.IsNotNull(current);
            Assert.IsNotNull(current.Applications);
            Assert.AreEqual(40, current.AvailableMemory);
            Assert.AreEqual(40, current.MemoryCapacity);
            Assert.AreEqual(0, current.Photos);
        }
        [Test]
        public void CtorShouldSetCapacityCorrectly()
        {
            int expectedResult = 50;
            int actualCapacity = device.MemoryCapacity;
            Assert.AreEqual(expectedResult, actualCapacity);
        }
        [Test]
        public void CtorShouldSetMemoryCorrectly()
        {
            int expectedResult = 50;
            int actualMemory = device.AvailableMemory;
            Assert.AreEqual(expectedResult, actualMemory);
        }
        [Test]
        public void CtorShouldSetStoragePhotosCorrectly() 
        {
            int expectedPhotos = 0;
            Assert.AreEqual(expectedPhotos, device.Photos);
        }
        [Test]
        [TestCase(51)]
        [TestCase(490)]
        public void TakePhotoMethodShouldReturnFalseWhenPhotoSizeIsBiggerThanAvailableMemory(int photoSize)
        {
             
            Assert.IsFalse(device.TakePhoto(photoSize));
        }
        [Test]
        [TestCase(50)]
        [TestCase(49)]
        [TestCase(0)]
        public void TakePhotoMethodShouldReturn_True_WhenPhotoSizeIsLess_OrEqual_ThanAvailableMemory(int photoSize)
        {
            
            Assert.IsTrue(device.TakePhoto(photoSize));
        }
        [Test]
        [TestCase(50)]
        [TestCase(49)]
        [TestCase(15)]
        [TestCase(0)]

        public void TakePhotoMethodShouldCalculateCorectlyAvailableMemory(int photoSize)
        {
            int expectedMemory = 50 - photoSize;
            device.TakePhoto(photoSize);
            Assert.AreEqual(expectedMemory, device.AvailableMemory);
        }
        [Test]
        [TestCase(20,2)]
        [TestCase(3,13)]
        [TestCase(15,3)]
        [TestCase(1,50)]

        public void TakePhotoMethodShouldCalculateCorectlyCountOfPhotos(int photoSize, int countOfPhotos)
        {
            
            for(int i = 0; i < countOfPhotos; i++)
            {
                device.TakePhoto(photoSize);
            }
            
            Assert.AreEqual(countOfPhotos, device.Photos);
        }
        [Test]
        [TestCase("app",51)]
        [TestCase("", 151)]
        public void InstallApp_ShouldThrowExceptionWhen_AppSizeIsBigger_ThanAvailableMemory(string appName,int appSize)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => device.InstallApp(appName, appSize));
            Assert.AreEqual("Not enough available memory to install the app.", exception.Message);

        }
        [Test]
        [TestCase("app", 50)]
        [TestCase("", 15)]
        [TestCase("something37_98", 0)]
        public void InstallApp_ShouldCaclulateMemory_When_AppSizeIsSmaller_ThanAvailableMemory(string appName, int appSize)
        {
            int expectedMemory = 50 - appSize;
            device.InstallApp(appName, appSize);
            Assert.AreEqual(expectedMemory, device.AvailableMemory);

        }
        [Test]
        [TestCase("app", 50)]
        [TestCase(")&^%$$", 15)]
        [TestCase("something37_98", 0)]
        public void InstallApp_AddAppInList_When_AppSizeIsSmaller_ThanAvailableMemory(string appName, int appSize)
        {
           
            device.InstallApp(appName, appSize);
            CollectionAssert.Contains(device.Applications, appName);

        }
        [Test]
        [TestCase("app", 50)]
        [TestCase(")&^%$$", 15)]
        [TestCase("something37_98", 0)]
        public void InstallAppMethod_ReturnString_WhenAddAppInList(string appName, int appSize)
        {
            string expected = $"{appName} is installed successfully. Run application?";
            string returned = device.InstallApp(appName, appSize);
            Assert.AreEqual(expected, returned);
           
            

        }
        [Test]
        public void FormatDeviceMethodShouldTurnDeviceToStartValues()
        {
            device.TakePhoto(6);
            device.InstallApp("jjj",3);
            device.FormatDevice();
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(50, device.AvailableMemory);
            Assert.IsNotNull(device.Applications);
            Assert.AreEqual(0,device.Applications.Count);
        }
        [Test]
        [TestCase(90,81,3)]
        public void GetDeviceStatusMethodShouldWorkCorrectly(int capacity,int memory,int photos)
            {
            Device current = new Device(capacity);
            current.TakePhoto(1);
            current.TakePhoto(1); 
            current.TakePhoto(1);
            current.InstallApp("ahs", 2);
            current.InstallApp("jsh77j", 2);
            current.InstallApp("shhdh", 2);
            string[] apps = new string[3]
            {
                "ahs",
                "jsh77j",
                "shhdh"
            };
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Memory Capacity: {capacity} MB, Available Memory: {memory} MB");
            sb.AppendLine($"Photos Count: {photos}");
            sb.AppendLine($"Applications Installed: {string.Join(", ", apps)}");
            string expected = sb.ToString().Trim();
            string result = current.GetDeviceStatus();
            Assert.AreEqual(expected, result);
        }
    }
}