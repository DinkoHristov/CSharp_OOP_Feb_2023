using NUnit.Framework;
using System;
using System.Runtime.ConstrainedExecution;

namespace RepairShop.Tests
{
    [TestFixture]
    public class Tests
    {
        public class RepairsShopTests
        {
            private Garage garage;

            [SetUp]
            public void SetUp() 
            {
                garage = new Garage("Home", 10);
            }

            [TearDown]
            public void TearDown()
            {
                garage = null;
            }

            [Test]
            public void Test_ConstructorCorrect()
            {
                Assert.AreEqual("Home", garage.Name);
                Assert.AreEqual(10, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void Test_NameSetterThrowsExceptionWhenNullOrEmpty()
            {
                Assert.Throws<ArgumentNullException>(
                    () => garage = new Garage(null, 10)
                    );

                Assert.Throws<ArgumentNullException>(
                    () => garage = new Garage(string.Empty, 10)
                    );
            }

            [Test]
            public void Test_MechanicsAvailableSetterThrowsExceptionWhenZero()
            {
                Assert.Throws<ArgumentException>(
                    () => garage = new Garage("Home", 0)
                    );
            }

            [Test]
            public void Test_AddCarCorrect()
            {
                garage.AddCar(new Car("Ferrari", 10));

                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void Test_AddCarThrowsException()
            {
                garage = new Garage("Home", 1);
                garage.AddCar(new Car("Ferrari", 10));

                Assert.Throws<InvalidOperationException>(
                    () => garage.AddCar(new Car("Volvo", 5))
                    );
            }

            [Test]
            public void Test_FixCarCorrect()
            {
                Car car = new Car("Ferrari", 10);
                garage.AddCar(car);
                garage.FixCar("Ferrari");

                Assert.AreEqual(0, car.NumberOfIssues);
            }

            [Test]
            public void Test_FixCarThrwosException()
            {
                Car car = new Car("Ferrari", 10);
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(
                    () => garage.FixCar("Lambo")
                    );
            }

            [Test]
            public void Test_RemoveFixedCarCorrect()
            {
                Car car = new Car("Ferrari", 10);
                Car car2 = new Car("Lambo", 20);

                garage.AddCar(car);
                garage.AddCar(car2);

                garage.FixCar("Ferrari");
                garage.FixCar("Lambo");
                garage.RemoveFixedCar();

                Assert.AreEqual(true, car.IsFixed);
                Assert.AreEqual(true, car2.IsFixed);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void Test_RemoveFixedCarThrowsException()
            {
                Car car = new Car("Lambo", 20);
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(
                    () => garage.RemoveFixedCar()
                    );
            }

            [Test]
            public void Test_ReportCorrect()
            {
                Car car = new Car("Lambo", 20);
                Car car2 = new Car("Ferrari", 20);

                garage.AddCar(car);
                garage.AddCar(car2);

                garage.FixCar("Lambo");
                garage.FixCar("Ferrari");

                string result = garage.Report();

                Assert.That(result, Is.EquivalentTo(garage.Report()));
            }
        }
    }
}