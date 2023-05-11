namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void Setup()
        {
            fish = new Fish("Nemo");
            aquarium = new Aquarium("Fresh", 2);
        }

        [Test]
        public void Test_ReportCorrect()
        {
            Fish newFish = new Fish("Alfi");

            aquarium.Add(fish);

            aquarium.Add(newFish);

            string realOutput = aquarium.Report();

            string expectedOutput = $"Fish available at Fresh: Nemo, Alfi";

            Assert.AreEqual(expectedOutput, realOutput);
        }

        [Test]
        public void Test_SellFishCorrect()
        {
            aquarium.Add(fish);

            Fish requestedFish = aquarium.SellFish(fish.Name);

            Assert.AreEqual(1, aquarium.Count);
            Assert.AreEqual(false, requestedFish.Available);
            Assert.AreEqual(requestedFish, aquarium.SellFish(fish.Name));
        }

        [Test]
        public void Test_RemoveFishThrowExceptionWhenFishDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => aquarium.RemoveFish(fish.Name)
                );
        }

        [Test]
        public void Test_RemoveFishCorrect()
        {
            aquarium.Add(fish);

            aquarium.RemoveFish(fish.Name);

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void Test_AddMethodThrowExceptionWhenCountEqualsCapacity()
        {
            aquarium.Add(fish);
            aquarium.Add(fish);

            Assert.AreEqual(2, aquarium.Count);
            Assert.Throws<InvalidOperationException>(
                () => aquarium.Add(fish)
                );
        }

        [Test]
        public void Test_AddMethodCorrect()
        {
            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        public void Test_AquariumCapacityThrowExceptionWhenNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(
                () => aquarium = new Aquarium("Fresh", capacity)
                );
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_AquariumNameThrowExceptionWhenNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(
                () => aquarium = new Aquarium(name, 2)
                );
        }

        [Test]
        public void Test_AquariumCapacity()
        {
            Assert.AreEqual(2, aquarium.Capacity);
        }

        [Test]
        public void Test_AquariumName()
        {
            Assert.AreEqual("Fresh", aquarium.Name);
        }

        [Test]
        public void Test_AquariumNotNull()
        {
            Assert.NotNull(aquarium);
        }

        [Test]
        public void Test_AquariumFishListNotNull()
        {
            Type type = typeof(Aquarium);

            FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "fish");

            List<Fish> value = field.GetValue(aquarium) as List<Fish>;

            Assert.NotNull(value);
        }

        [Test]
        public void Test_FishName()
        {
            Assert.AreEqual("Nemo", fish.Name);
        }

        [Test]
        public void Test_FishAvailable()
        {
            Assert.AreEqual(true, fish.Available);
        }

        [Test]
        public void Test_FishNotNull()
        {
            Assert.NotNull(fish);
        }
    }
}
