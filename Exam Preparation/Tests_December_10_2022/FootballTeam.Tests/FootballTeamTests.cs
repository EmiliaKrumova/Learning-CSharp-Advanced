using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeam.Tests
{
    public class FootballTeamTests
    {
        FootballTeam team = null;
        [SetUp]
        public void SetUp()
        {
            team = new FootballTeam("Arsenal", 28);
        }
        [Test]
        public void CtorShouldSetTeamNotNull()
        {
            FootballTeam newTeam = new FootballTeam("Chelsea", 15);
            Assert.IsNotNull(newTeam);
        }
        [Test]
        public void CtorShouldSetPlayersCollectionNotNull()
        {
            FootballTeam newTeam = new FootballTeam("Chelsea", 15);
            Assert.IsNotNull(newTeam.Players);
        }
        [Test]
        public void CtorShouldSetTeamNameCorrectly()
        {
            FootballTeam newTeam = new FootballTeam("Liverpool", 15);
            Assert.AreEqual("Liverpool", newTeam.Name);
        }
        [Test]
        public void NameOfTeamShould_ThrowArgumentException_WhenNameIsEmpty()
        {

            FootballTeam team;
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => team = new FootballTeam("", 20));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }
        [Test]
        public void NameOfTeamShould_ThrowArgumentException_WhenNameIsNull()
        {

            FootballTeam team;
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => team = new FootballTeam(null, 20));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(4)]
        [TestCase(14)]

        public void CapacityShould_ThrowArgumentException_WhenCountIsSmallerThan_15(int number)
        {
            FootballTeam football;

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => football = new FootballTeam("valid", number));
            Assert.AreEqual("Capacity min value = 15", exception.Message);
        }
        [Test]
        [TestCase(15)]
        [TestCase(100)]
        [TestCase(21)]


        public void CapacityShouldSet_Correctly_WhenPlayersAreOver_15(int number)
        {
            FootballTeam footballTeam = new FootballTeam("Something", number);
            int expectedNumber = number;
            Assert.AreEqual(expectedNumber, footballTeam.Capacity);


        }
        [Test]
        public void AddPlayerMethodShouldAddPlayerCorrectlyWhenPlayersCountIsSmallerThanCapacity()
        {
            FootballPlayer player = new FootballPlayer("Valid", 6, "Goalkeeper");
            FootballPlayer player1 = new FootballPlayer("Valid1", 7, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Valid2", 13, "Goalkeeper");
            team.AddNewPlayer(player);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);


            Assert.AreEqual(3, team.Players.Count);
            Assert.Contains(player, team.Players);
            Assert.Contains(player1, team.Players);
            Assert.Contains(player2, team.Players);
            


        }
        [Test]
        [TestCase(15)]
        public void AddPlayerMethodShouldThrowExceptionWhenPlayersCountIsBiggerThanCapacity(int count)
        {
            FootballTeam footballTeam = new FootballTeam("Something", 15);

            FootballPlayer player1 = new FootballPlayer("Valid23", 1, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Valid23", 2, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Valid23", 3, "Goalkeeper");
            FootballPlayer player4 = new FootballPlayer("Valid23", 4, "Goalkeeper");
            FootballPlayer player5 = new FootballPlayer("Valid23", 5, "Goalkeeper");
            FootballPlayer player6 = new FootballPlayer("Valid23", 6, "Goalkeeper");
            FootballPlayer player7 = new FootballPlayer("Valid23", 7, "Goalkeeper");
            FootballPlayer player8 = new FootballPlayer("Valid23", 8, "Goalkeeper");
            FootballPlayer player9 = new FootballPlayer("Valid23", 9, "Goalkeeper");
            FootballPlayer player10 = new FootballPlayer("Valid23", 10, "Goalkeeper");
            FootballPlayer player11 = new FootballPlayer("Valid23", 11, "Goalkeeper");
            FootballPlayer player12 = new FootballPlayer("Valid23", 12, "Goalkeeper");
            FootballPlayer player13 = new FootballPlayer("Valid23", 13, "Goalkeeper");
            FootballPlayer player14 = new FootballPlayer("Valid23", 14, "Goalkeeper");
            FootballPlayer player15 = new FootballPlayer("Valid23", 15, "Goalkeeper");
            footballTeam.AddNewPlayer(player1);
            footballTeam.AddNewPlayer(player2);
            footballTeam.AddNewPlayer(player3);
            footballTeam.AddNewPlayer(player4);
            footballTeam.AddNewPlayer(player5);
            footballTeam.AddNewPlayer(player6);
            footballTeam.AddNewPlayer(player7);
            footballTeam.AddNewPlayer(player8);
            footballTeam.AddNewPlayer(player9);
            footballTeam.AddNewPlayer(player10);
            footballTeam.AddNewPlayer(player11);
            footballTeam.AddNewPlayer(player12);
            footballTeam.AddNewPlayer(player13);
            footballTeam.AddNewPlayer(player14);
            footballTeam.AddNewPlayer(player15);


            FootballPlayer player16 = new FootballPlayer("Valid23", 16, "Goalkeeper");
            string expected = "No more positions available!";
            Assert.AreEqual(expected, footballTeam.AddNewPlayer(player16));
            


        }
        [Test]
        public void AddPlayerMethodShouldAddPlayerCorrectlyAndReturnStringMsg()
        {
            FootballPlayer player = new FootballPlayer("Valid", 6, "Goalkeeper");
            string expected = $"Added player Valid in position Goalkeeper with number 6";
            Assert.AreEqual(expected, team.AddNewPlayer(player));


        }
        [Test]
        public void PickPlayer_MethodShouldPickPlayerCorrectlyByGivenName()
        {
            FootballPlayer player = new FootballPlayer("Valid", 6, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Valid23", 2, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Valid33", 3, "Goalkeeper");
            team.AddNewPlayer(player);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            
            Assert.AreEqual(player3, team.PickPlayer("Valid33"));


        }
        [Test]
        public void PickPlayer_MethodShouldReturnNull_WhenNameOfPlayerDoesNotExist()
        {
            FootballPlayer player = new FootballPlayer("Valid", 6, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Valid23", 2, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Valid33", 3, "Goalkeeper");
            team.AddNewPlayer(player);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);

            Assert.IsNull(team.PickPlayer("Valid353"));


        }
        [Test]
        public void PlayerScore_MethodShouldCount_ScoredGoalsCorrect()
        {
            FootballPlayer player = new FootballPlayer("Valid", 6, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Valid23", 2, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Valid33", 3, "Goalkeeper");
            team.AddNewPlayer(player);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            player.Score();
            player.Score();
            player.Score();
            player2.Score();


            Assert.AreEqual($"Valid scored and now has 4 for this season!", team.PlayerScore(6));
            Assert.AreEqual($"Valid23 scored and now has 2 for this season!", team.PlayerScore(2));


        }
       

    }
}
