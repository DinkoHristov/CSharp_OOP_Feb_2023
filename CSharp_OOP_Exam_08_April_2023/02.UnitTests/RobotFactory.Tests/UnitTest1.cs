using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace RobotFactory.Tests
{
    [TestFixture]
    public class Tests
    {
        private Robot robot;
        private Supplement supplement;
        private Factory factory;

        [SetUp]
        public void Setup()
        {
            robot = new Robot("Ardu", 100, 10);
            supplement = new Supplement("Head", 20);
            factory = new Factory("Robots", 5);
        }

        [Test]
        public void Test_ProduceRobot()
        {
            string realString = factory.ProduceRobot("Ardu", 100, 10);

            string expectedString = $"Produced --> {robot.ToString()}";

            Assert.AreEqual(1, factory.Robots.Count);
            Assert.AreEqual(expectedString, realString);
        }

        [Test]
        public void Test_SellRobot()
        {
            Robot newRobot = new Robot("Henry", 70, 12);

            factory.ProduceRobot(robot.Model, robot.Price, robot.InterfaceStandard);

            factory.ProduceRobot(newRobot.Model, newRobot.Price, newRobot.InterfaceStandard);

            Robot realRobot = factory.SellRobot(70);

            Robot expectedRobot = newRobot;

            string realOuput = realRobot.ToString();

            string expectedOuput = newRobot.ToString();

            Assert.AreEqual(2, factory.Robots.Count);
            Assert.AreEqual(expectedOuput, realOuput);
        }

        [Test]
        public void Test_FactoryUpgradeRobotReturnFalseWhenRobotContainsSupplement()
        {
            Supplement newOne = new Supplement("Head", 10);

            factory.ProduceSupplement(newOne.Name, 10);

            robot.Supplements.Add(newOne);

            bool realOuput = factory.UpgradeRobot(robot, newOne);

            bool expectedOuput = false;

            Assert.AreEqual(0, factory.Robots.Count);
            Assert.AreEqual(1, factory.Supplements.Count);
            Assert.AreEqual(expectedOuput, realOuput);
        }

        [Test]
        public void Test_FactoryUpgradeRobotReturnFalseWhenRobotDoesntExist()
        {
            factory.ProduceSupplement(supplement.Name, supplement.InterfaceStandard);

            bool realOuput = factory.UpgradeRobot(robot, supplement);

            bool expectedOuput = false;

            Assert.AreEqual(0, factory.Robots.Count);
            Assert.AreEqual(1, factory.Supplements.Count);
            Assert.AreEqual(expectedOuput, realOuput);
        }

        [Test]
        public void Test_FactoryUpgradeRobotReturnFalseWhenSupplementDoesntExist()
        {
            factory.ProduceRobot(robot.Model, robot.Price, robot.InterfaceStandard);

            bool realOuput = factory.UpgradeRobot(robot, supplement);

            bool expectedOuput = false;

            Assert.AreEqual(1, factory.Robots.Count);
            Assert.AreEqual(0, factory.Supplements.Count);
            Assert.AreEqual(0, robot.Supplements.Count);
            Assert.AreEqual(expectedOuput, realOuput);
        }

        [Test]
        public void Test_FactoryUpgradeRobotReturnTrueWhenRobotAndSupplementExists()
        {
            factory.ProduceRobot("Ardu", 100, 10);

            supplement = new Supplement("Chest", 10);

            factory.ProduceSupplement(supplement.Name, supplement.InterfaceStandard);

            bool realOuput = factory.UpgradeRobot(robot, supplement);

            bool expectedOuput = true;

            Assert.AreEqual(1, factory.Robots.Count);
            Assert.AreEqual(1, factory.Supplements.Count);
            Assert.AreEqual(1, robot.Supplements.Count);
            Assert.AreEqual(expectedOuput, realOuput);
        }

        [Test]
        public void Test_FactoryProduceSupplement()
        {
            string realString = factory.ProduceSupplement(supplement.Name, supplement.InterfaceStandard);

            string expectedString = supplement.ToString();

            Assert.AreEqual(1, factory.Supplements.Count);
            Assert.AreEqual(expectedString, realString);
        }

        [Test]
        public void Test_FactoryProduceRobotWhenCountBiggerThanCapacity()
        {
            factory = new Factory("Robots", 1);

            factory.ProduceRobot("Art", 10, 4);

            string realString = factory.ProduceRobot(robot.Model, robot.Price, robot.InterfaceStandard);

            string expectedString = $"The factory is unable to produce more robots for this production day!";

            Assert.AreEqual(1, factory.Robots.Count);
            Assert.AreEqual(expectedString, realString);
        }

        [Test]
        public void Test_FactoryProduceRobotWhenCountSmallerThanCapacity()
        {
            string realString = factory.ProduceRobot(robot.Model, robot.Price, robot.InterfaceStandard);

            string expectedString = $"Produced --> {robot}";

            Assert.AreEqual(1, factory.Robots.Count);
            Assert.AreEqual(expectedString, realString);
        }

        [Test]
        public void Test_FactoryCapacity()
        {
            Assert.AreEqual(5, factory.Capacity);
        }

        [Test]
        public void Test_FactoryName()
        {
            Assert.AreEqual("Robots", factory.Name);
        }

        [Test]
        public void Test_FactorySupplementsNotNull()
        {
            Assert.NotNull(factory.Supplements);
        }

        [Test]
        public void Test_FactoryRobotsNotNull()
        {
            Assert.NotNull(factory.Robots);
        }

        [Test]
        public void Test_FactoryNotNull()
        {
            Assert.NotNull(factory);
        }

        [Test]
        public void Test_SupplementToStringMethod()
        {
            string realString = supplement.ToString();

            string expectedString = $"Supplement: Head IS: 20";

            Assert.AreEqual(expectedString, realString);
        }

        [Test]
        public void Test_SupplementInterfaceStandard()
        {
            Assert.AreEqual(20, supplement.InterfaceStandard);
        }

        [Test]
        public void Test_SupplementName()
        {
            Assert.AreEqual("Head", supplement.Name);
        }

        [Test]
        public void Test_SupplementNotNull()
        {
            Assert.NotNull(supplement);
        }

        [Test]
        public void Test_RobotToStringMethod()
        {
            string realString = robot.ToString();

            string expectedString = $"Robot model: Ardu IS: 10, Price: 100.00";

            Assert.AreEqual(expectedString, realString);
        }

        [Test]
        public void Test_RobotSuplementsNotNull()
        {
            Assert.NotNull(robot.Supplements);
        }

        [Test]
        public void Test_RobotInterfaceModel()
        {
            Assert.AreEqual(10, robot.InterfaceStandard);
        }

        [Test]
        public void Test_RobotPrice()
        {
            Assert.AreEqual(100, robot.Price);
        }

        [Test]
        public void Test_RobotModel()
        {
            Assert.AreEqual("Ardu", robot.Model);
        }

        [Test]
        public void Test_RobotNotNull()
        {
            Assert.NotNull(robot);
        }
    }
}