using NUnit.Framework;
using System;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database data;
        private readonly int[] initialArray = new int[] { 1, 2};

        [SetUp]
        public void SetUp()
        {
            data = new Database(initialArray);
        }

        [Test]
        public void Test_ArrayLength()
        {
            int expectedLength = 2;

            Assert.AreEqual(expectedLength, data.Count);
        }

        [Test]
        public void Test_ArrayCorrectAddsElement()
        {
            int expectedLength = 3;

            data.Add(1);

            Assert.AreEqual(expectedLength, data.Count);
        }

        [Test]
        public void Test_ArrayAddMethodThrowsException()
        {
            int expectedLength = 16;

            for (int i = data.Count; i < expectedLength; i++)
            {
                data.Add(1);
            }

            Assert.Throws<InvalidOperationException>(
                () => data.Add(1),
                "Add doesn't throw and exception!"
                );
        }

        [Test]
        public void Test_ArrayCorrectRemovesElement()
        {
            int expectedLenth = 1;

            data.Remove();

            Assert.AreEqual(expectedLenth, data.Count);
        }

        [Test]
        public void Test_ArrayRemoveMethodThrowsException()
        {
            data.Remove();
            data.Remove();

            Assert.Throws<InvalidOperationException>(
                () => data.Remove(),
                "Array is not empty!"
                );
        }

        [Test]
        public void Test_ArrayCorrectFetch()
        {
            int[] fetchedArray = data.Fetch();

            CollectionAssert.AreEqual(initialArray, fetchedArray);
        }
    }
}
