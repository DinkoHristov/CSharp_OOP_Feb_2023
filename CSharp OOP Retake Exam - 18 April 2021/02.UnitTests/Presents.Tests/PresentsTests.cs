namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class PresentsTests
    {
        private Present present;
        private Bag bag;

        [SetUp]
        public void Setup()
        {
            present = new Present("Toy", 100);
            bag = new Bag();
        }

        [Test]
        public void Test_BagGetPresentMethod()
        {
            bag.Create(present);

            Present expectedPresent = present;

            Assert.AreEqual(1, bag.GetPresents().Count);
            Assert.AreEqual(expectedPresent, bag.GetPresent(present.Name));
        }

        [Test]
        public void Test_BagGetPresentWithLeastMagicMethod()
        {
            Present leastMagicPresent = new Present("Ball", 50);

            bag.Create(present);
            bag.Create(leastMagicPresent);

            Present expectedPresent = leastMagicPresent;

            Assert.AreEqual(2, bag.GetPresents().Count);
            Assert.AreEqual(expectedPresent, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void Test_BagRemoveMethodCorrect()
        {
            bag.Create(present);

            bag.Remove(present);

            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void Test_BagCreateThrowExceptionWhenPresentExists()
        {
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(
                () => bag.Create(present)
                );
        }

        [Test]
        public void Test_BagCreateThrowExceptionWhenPresentIsNull()
        {
            present = null;

            Assert.Throws<ArgumentNullException>(
                () => bag.Create(present)
                );
        }

        [Test]
        public void Test_BagCreateMethodCorrect()
        {
            string realOutput = bag.Create(present);

            string expectedOutput = $"Successfully added present {present.Name}.";

            Assert.AreEqual(1, bag.GetPresents().Count);
            Assert.AreEqual(expectedOutput, realOutput);
        }

        [Test]
        public void Test_BagPresentListNotNull()
        {
            Type type = typeof(Bag);

            FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "presents");

            List<Present> value = field.GetValue(bag) as List<Present>;

            Assert.NotNull(value);
        }

        [Test]
        public void Test_PresentNotNull()
        {
            Assert.NotNull(present);
        }

        [Test]
        public void Test_PresentName()
        {
            Assert.AreEqual("Toy", present.Name);
        }

        [Test]
        public void Test_PresentMagic()
        {
            Assert.AreEqual(100, present.Magic);
        }
    }
}
