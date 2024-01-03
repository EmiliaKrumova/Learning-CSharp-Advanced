namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            RailwayStation station = new RailwayStation("name");
        }

        [Test]
        public void CtorNotNull()
        {
            RailwayStation station = new RailwayStation("name");
            Assert.IsNotNull(station);
            

        }
        [Test]
        public void CtorNotNullCollections()
        {
            RailwayStation station = new RailwayStation("name");
           
            Assert.IsNotNull(station.ArrivalTrains);
            Assert.IsNotNull(station.DepartureTrains);
            

        }
        [Test]
        public void CtorNotNullName()
        {
            RailwayStation station = new RailwayStation("name");
            
            Assert.IsNotNull(station.Name);

        }
        [Test]
        public void CtorCreatenameCorect()
        {
            RailwayStation station = new RailwayStation("name");
            Assert.AreEqual("name", station.Name);

        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void NameThrowExceptionNull(string name)
        {
            RailwayStation station;
            
            ArgumentException exception = Assert.Throws<ArgumentException>(()
             => station = new RailwayStation(name));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);

        }
        [Test]
        public void NewArrivalOnBoardShouldAddTraingToQueue()
        {
            RailwayStation station = new RailwayStation("name");
            station.NewArrivalOnBoard("train1");
            station.NewArrivalOnBoard("train2");
            Assert.AreEqual("train1", station.ArrivalTrains.Peek());
            Assert.AreEqual("train1", station.ArrivalTrains.Dequeue());

        }
        [Test]
        
        public void TrainHasArrivedThrowsIfTrainIsNotFirstInQueue()
        {
            RailwayStation station = new RailwayStation("name");
            station.NewArrivalOnBoard("train1");
            station.NewArrivalOnBoard("train2");
            string expected = $"There are other trains to arrive before train2.";
            Assert.AreEqual(expected, station.TrainHasArrived("train2"));

        }
        [Test]

        public void TrainHasArrivedSuccesIfTrainIsFirstInQueue()
        {
            RailwayStation station = new RailwayStation("name");
            station.NewArrivalOnBoard("train1");
            station.NewArrivalOnBoard("train2");
            string expected = $"train1 is on the platform and will leave in 5 minutes.";
            Assert.AreEqual(expected, station.TrainHasArrived("train1"));
            Assert.IsTrue(station.DepartureTrains.Contains("train1"));

        }
        [Test]

        public void TrainHasLeftSuccesIfTrainIsFirstInQueue()
        {
            RailwayStation station = new RailwayStation("name");
            station.NewArrivalOnBoard("train1");
            station.NewArrivalOnBoard("train2");
            station.TrainHasArrived("train1");
            station.TrainHasArrived("train2");

            Assert.IsTrue( station.TrainHasLeft("train1"));
            

        }
        [Test]

        public void TrainHasLeftFailIfTrainIsNotFirstInQueue()
        {
            RailwayStation station = new RailwayStation("name");
            station.NewArrivalOnBoard("train1");
            station.NewArrivalOnBoard("train2");
            station.TrainHasArrived("train1");
            station.TrainHasArrived("train2");

            Assert.IsFalse(station.TrainHasLeft("train2"));


        }
        [Test]

        public void TrainHasLeftCorrect()
        {
            RailwayStation station = new RailwayStation("name");
            station.NewArrivalOnBoard("train1");
            
            station.TrainHasArrived("train1");
            station.TrainHasLeft("train1");
            

            Assert.IsFalse(station.DepartureTrains.Contains("train1"));


        }
    }
}