using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Athlete athlete;
        private Gym gym;

        [SetUp]
        public void Setup()
        {
            athlete = new Athlete("Jordan");
            gym = new Gym("Monster", 30);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        public void Test_GymCapacityThrowExceptionWhenNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(
                () => gym = new Gym("Monster", capacity)
                );
        }

        [Test]
        public void Test_AddAthlete()
        {
            gym.AddAthlete(athlete);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void Test_AddAthleteThrowExceptionWhenCapacityIsEqualToGymCapacity()
        {
            gym = new Gym("Monster", 2);

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(
                () => gym.AddAthlete(athlete)
                );
            Assert.AreEqual(2, gym.Count);
        }

        [Test]
        public void Test_RemoveAthlete()
        {
            gym.AddAthlete(athlete);

            gym.RemoveAthlete(athlete.FullName);

            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void Test_RemoveAthleteThrowExceptionWhenAthleteDoesntExists()
        {
            Assert.Throws<InvalidOperationException>(
                () => gym.RemoveAthlete(athlete.FullName)
                );
        }

        [Test]
        public void Test_InjureAthlete()
        {
            gym.AddAthlete(athlete);

            Athlete expectedAthlete = gym.InjureAthlete(athlete.FullName);

            Assert.AreEqual(true, athlete.IsInjured);
            Assert.AreEqual(expectedAthlete, athlete);
        }

        [Test]
        public void Test_InjureAthleteThrowExceptionWhenAthleteDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => gym.InjureAthlete(athlete.FullName)
                );
        }

        [Test]
        public void Test_Report()
        {
            Athlete newAthlete = new Athlete("Kobe");

            gym.AddAthlete(athlete);
            gym.AddAthlete(newAthlete);

            string expectedOutput = $"Active athletes at Monster: Jordan, Kobe";

            Assert.AreEqual(expectedOutput, gym.Report());
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_GymNameThrowExceptionWhenNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(
                () => gym = new Gym(name, 30)
                );
        }

        [Test]
        public void Test_GymCapacityNotNull()
        {
            Assert.AreEqual(30, gym.Capacity);
        }

        [Test]
        public void Test_GymNameNotNull()
        {
            Assert.AreEqual("Monster", gym.Name);
        }

        [Test]
        public void Test_GymListOfAthletesNotNull()
        {
            Type type = typeof(Gym);

            FieldInfo gymInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "athletes");

            List<Athlete> value = gymInfo.GetValue(gym) as List<Athlete>;

            Assert.NotNull(value);
        }

        [Test]
        public void Test_GymNotNull()
        {
            Assert.NotNull(gym);
        }

        [Test]
        public void Test_AthleteNotNull()
        {
            Assert.NotNull(athlete);
        }

        [Test]
        public void Test_AthleteNameCorrect()
        {
            Assert.AreEqual("Jordan", athlete.FullName);
        }

        [Test]
        public void Test_AthleteIsInjuredCorrect()
        {
            Assert.AreEqual(false, athlete.IsInjured);
        }
    }
}
