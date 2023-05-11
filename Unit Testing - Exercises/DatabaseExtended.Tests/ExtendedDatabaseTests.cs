namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [TearDown]
        public void TearDown() 
        {
            database = null;
        }

        [Test]
        public void Test_AddMethodCorrect()
        {
            database.Add(new Person(1, "Ivan"));
            Person first = database.FindById(1);

            Assert.AreEqual(1, database.Count);
            Assert.AreEqual(1, first.Id);
            Assert.AreEqual("Ivan", first.UserName);
        }

        [Test]
        public void Test_AddMethodThrowsExceptionWhenPersonsOver16()
        {
            Person[] persons = new Person[16];
            for (int i = 0; i < persons.Length; i++) 
            {
                persons[i] = new Person(i, $"{i}");
            }

            database = new Database(persons);

            Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person(20, "Ivaka"))
                );
        }

        [Test]
        public void Test_AddMethodThrowsExceptionWhenIdExists()
        {
            database = new Database(new Person(1, "Ivan"));

            Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person(1, "Johnny"))
                );
        }

        [Test]
        public void Test_AddMethodThrowsExceptionWhenUsernameExists()
        {
            database = new Database(new Person(1, "Ivan"));

            Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person(2, "Ivan"))
                );
        }

        [Test]
        public void Test_ConstructorCorrect()
        {
            database = new Database(new Person(1, "Ivan"), new Person(2, "Gosho"));
            Person first = database.FindById(1);
            Person second = database.FindById(2);

            Assert.AreEqual(2, database.Count);
            Assert.AreEqual("Ivan", first.UserName);
            Assert.AreEqual("Gosho", second.UserName);
        }

        [Test]
        public void Test_AddRangeThrowsExceptionWhenOver16()
        {
            Person[] persons = new Person[17];

            Assert.Throws<ArgumentException>(
                () => database = new Database(persons)
                );
        }

        [Test]
        public void Test_AddRangeMethodCorrect()
        {
            Person person = new Person(1, "Ivan");
            database = new Database(person);
            Person[] persons = new Person[1] { person };

            Assert.AreEqual(database.Count, persons.Length);
        }

        [Test]
        public void Test_RemoveMethodCorrect()
        {
            database = new Database(new Person(1, "Ivan"), new Person(2, "Gosho"));
            database.Remove();
            Person first = database.FindById(1);

            Assert.AreEqual(1, database.Count);
            Assert.AreEqual("Ivan", first.UserName);
            Assert.Throws<InvalidOperationException>(
                () => database.FindByUsername("Gosho")
                );
        }

        [Test]
        public void Test_RemoveMethodThrowsExceptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(
                () => database.Remove()
                );
        }

        [Test]
        public void Test_FindByUsernameCorrect()
        {
            database = new Database(new Person(1, "Ivan"));
            Person first = database.FindByUsername("Ivan");

            Assert.AreEqual("Ivan", first.UserName);
        }

        [Test]
        public void Test_FindByUsernameThrowsExceptionWhenNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => database.FindByUsername(null)
                );
        }

        [Test]
        public void Test_FindByUsernameThrowsExceptionWhenNameIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(
                () => database.FindByUsername(string.Empty)
                );
        }

        [Test]
        public void Test_FindByIdMethodCorrect()
        {
            database = new Database(new Person(1, "Ivan"));
            Person first = database.FindById(1);

            Assert.AreEqual(1, first.Id);
        }

        [Test]
        public void Test_FindByIdThrowsExceptionWhenIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => database.FindById(-10)
                );
        }

        [Test]
        public void Test_FindByIdThrowsExceptionWhenIdIsNotInDatabase()
        {
            Assert.Throws<InvalidOperationException>(
                () => database.FindById(1)
                );
        }
    }
}