using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        FootballPlayer player = null;
        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("Stoichkov",8, "Forward");
        }

        [Test]
        public void CtorShouldCreatePlayerNotNull()
        {
            FootballPlayer footballPlayer = new FootballPlayer("Berbatov", 11, "Goalkeeper");
            Assert.IsNotNull(footballPlayer);
        }
        [Test]
        public void CtorShouldCreatePlayerWith_0ScoredGoals()
        {
            FootballPlayer footballPlayer = new FootballPlayer("Berbatov", 11, "Goalkeeper");
            Assert.AreEqual(0, footballPlayer.ScoredGoals);
        }
        [Test]
        public void NameOfPlayerShouldSetCorrectly()
        {
            string expectedName = "Stoichkov";
            Assert.AreEqual(expectedName, player.Name);
        }
        [Test]
        public void NameOfPlayerShould_ThrowArgumentException_WhenNameIsNullOrEmpty()
        {
            FootballPlayer football; 
            
            ArgumentException exception = Assert.Throws<ArgumentException>(() => football = new FootballPlayer("", 7, "Goalkeeper"));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }
        [Test]
        public void NameOfPlayerShould_ThrowArgumentException_WhenNameIsNull()
        {
            FootballPlayer football;

            ArgumentException exception = Assert.Throws<ArgumentException>(() => football = new FootballPlayer(null, 7, "Goalkeeper"));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(22)]
        [TestCase(100)]

        public void NumberOfPlayerShould_ThrowArgumentException_WhenNumberIsSmallerThan1_OrBiggerThan21(int number)
        {
            FootballPlayer football;

            ArgumentException exception = Assert.Throws<ArgumentException>(() => football = new FootballPlayer("valid", number, "Goalkeeper"));
            Assert.AreEqual("Player number must be in range [1,21]", exception.Message);
        }
        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(21)]
        [TestCase(8)]

        public void NumberOfPlayerShould_SetCorrectly_WhenNumberIsInRange1_21(int number)
        {
            FootballPlayer footballPlayer = new FootballPlayer("Berbatov", number, "Goalkeeper");
            int expectedNumber = number;
            Assert.AreEqual(expectedNumber, footballPlayer.PlayerNumber);


        }
        [Test]
        [TestCase("Goalkeeper")]
        [TestCase("Midfielder")]
        [TestCase("Forward")]
        

        public void Position_OfPlayerShould_SetCorrectly_WhenDataIsValid(string position)
        {
            FootballPlayer footballPlayer = new FootballPlayer("Berbatov", 7, position);
            string expectedPosition = position;
            Assert.AreEqual(expectedPosition, footballPlayer.Position);


        }
        [Test]
        [TestCase("Invalid")]
        [TestCase("Midfie777lder")]
        [TestCase("")]


        public void Position_OfPlayerShould_ThrowException_WhenDataIsInValid(string position)
        {
            //FootballPlayer footballPlayer = new FootballPlayer("Berbatov", 7, position);
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => player = new FootballPlayer("valid", 6, position));
            Assert.AreEqual("Invalid Position", exception.Message);


        }
        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(21)]
        [TestCase(8)]

        public void ScoreMethod_Should_IncreaseGoals(int countOfGoals)
        {
            for(int i = 0; i < countOfGoals; i++)
            {
                player.Score();
            }
            int expectedNumber = countOfGoals;
            Assert.AreEqual(expectedNumber, player.ScoredGoals);


        }
    }
}