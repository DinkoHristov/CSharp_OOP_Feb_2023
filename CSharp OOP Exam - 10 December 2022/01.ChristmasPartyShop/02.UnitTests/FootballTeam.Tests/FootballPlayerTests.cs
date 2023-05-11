using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace FootballTeam.Tests
{
    [TestFixture]
    public class Tests
    {
        private FootballPlayer player;
        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("Messi", 10, "Forward");
            team = new FootballTeam("Barcelona", 30);
        }

        [Test]
        public void Test_FootballTeamConstructorCorrect()
        {
            Assert.NotNull(team);
        }

        [Test]
        public void Test_FootballTeamConstructorCorrectPrivateList()
        {
            Type type = typeof(FootballTeam);

            FieldInfo info = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "players");

            List<FootballPlayer> value = info.GetValue(team) as List<FootballPlayer>;

            Assert.IsNotNull(value);
        }

        [Test]
        public void Test_FootballTeamNameCorrect()
        {
            Assert.AreEqual("Barcelona", team.Name);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_FootballTeamNameThrowExceptionWhenNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(
                () => team = new FootballTeam(name, 30)
                );
        }

        [Test]
        public void Test_FootballTeamCapacityCorrect()
        {
            Assert.AreEqual(30, team.Capacity);
        }

        [Test]
        public void Test_FootballTeamCapacityThrowException()
        {
            Assert.Throws<ArgumentException>(
                () => team = new FootballTeam("Barcelona", 10)
                );
        }

        [Test]
        public void Test_AddNewPlayerCorrect()
        {
            FootballPlayer newPlayer = new FootballPlayer("Ronaldo", 7, "Forward");

            string expected = $"Added player {newPlayer.Name} in position {newPlayer.Position} with number {newPlayer.PlayerNumber}";

            string result = team.AddNewPlayer(newPlayer);

            Assert.AreEqual(1, team.Players.Count);
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Test_AddNewPlayerNotAdding()
        {
            FootballTeam newTeam = new FootballTeam("Real", 16);

            for (int i = 0; i < 16; i++)
            {
                newTeam.AddNewPlayer(player);
            }

            string expected = "No more positions available!";

            string result = newTeam.AddNewPlayer(player);

            Assert.AreEqual(16, newTeam.Players.Count);
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Test_PickPlayer()
        {
            team.AddNewPlayer(player);

            FootballPlayer expected = team.PickPlayer("Messi");

            Assert.AreEqual(expected, player);
        }

        [Test]
        public void Test_PlayerScore()
        {
            team.AddNewPlayer(player);

            string result = team.PlayerScore(10);

            string expected = $"{player.Name} scored and now has {player.ScoredGoals} for this season!";

            Assert.AreEqual(1, player.ScoredGoals);
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Test_FootballPlayerConstructorCorrect()
        {
            Assert.NotNull(player);
        }

        [Test]
        public void Test_FootballPlayerName()
        {
            Assert.AreEqual("Messi", player.Name);
        }

        [Test]
        public void Test_FootballPlayerPosition()
        {
            Assert.AreEqual("Forward", player.Position);
        }

        [Test]
        public void Test_FootballPlayerNumber()
        {
            Assert.AreEqual(10, player.PlayerNumber);
        }

        [Test]
        public void Test_FootballPlayerScoredGoals()
        {
            Assert.AreEqual(0, player.ScoredGoals);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_FootballPlayerNameThrowExceptionWhenNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(
                () => player = new FootballPlayer(name, 10, "Forward")
                );
        }

        [TestCase(0)]
        [TestCase(22)]
        public void Test_FootballPlayerNumberThrowException(int number)
        {
            Assert.Throws<ArgumentException>(
                () => player = new FootballPlayer("Messi", number, "Forward")
                );
        }

        [TestCase("Forward")]
        [TestCase("Goalkeeper")]
        [TestCase("Midfielder")]
        public void Test_FootballPlayerPositionCorrect(string position)
        {
            player = new FootballPlayer("Messi", 10, position);

            Assert.AreEqual(position, player.Position);
        }

        [TestCase("attack")]
        [TestCase("defend")]
        [TestCase("kick")]
        public void Test_FootballPlayerPositionThrowException(string position)
        {
            Assert.Throws<ArgumentException>(
                () => player = new FootballPlayer("Messi", 10, position)
                );
        }

        [Test]
        public void Test_FootballPlayerScoreMethod()
        {
            player.Score();

            Assert.AreEqual(1, player.ScoredGoals);
        }


    }
}