namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;

        [SetUp]
        public void Setup()
        {
            robot = new Robot("Optimus", 100);
            manager = new RobotManager(2);
        }

        [Test]
        public void Test_ChargeMethodCorrect()
        {
            manager.Add(robot);

            manager.Work(robot.Name, "Fighting", 20);

            manager.Charge(robot.Name);

            Assert.AreEqual(100, robot.Battery);
        }

        [Test]
        public void Test_ChargeMethodThrowExceptionWhenRobotDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => manager.Charge(robot.Name)
                );
        }

        [Test]
        public void Test_WorkMethodCorrect()
        {
            manager.Add(robot);

            manager.Work(robot.Name, "Fighting", 20);

            Assert.AreEqual(80, robot.Battery);
        }

        [Test]
        public void Test_WorkMethodThrowExceptioWhenRobotDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => manager.Work(robot.Name, "Fighting", 50)
                );
        }

        [Test]
        public void Test_WorkMethodThrowExceptioWhenRobotBaterryIsNotEnough()
        {
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => manager.Work(robot.Name, "Fighting", 150)
                );
        }

        [Test]
        public void Test_RemoveRobotCorrect()
        {
            manager.Add(robot);

            manager.Remove(robot.Name);

            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void Test_RemoveRobotThrowExceptionWhenRobotDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(
                () => manager.Remove(robot.Name)
                );
        }

        [Test]
        public void Test_AddRobotCorrect()
        {
            manager.Add(robot);

            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void Test_AddRobotThrowExceptionWhenRobotAlreadyExists()
        {
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => manager.Add(robot)
                );
        }

        [Test]
        public void Test_AddRobotThrowExceptionWhenRobotCountEqualsCapacity()
        {
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => manager.Add(robot)
                );
        }

        [Test]
        public void Test_RobotManagerCapacityThrowExceptionWhenNegative()
        {
            Assert.Throws<ArgumentException>(
                () => manager = new RobotManager(-2)
                );
        }

        [Test]
        public void Test_RobotManagerCapacity()
        {
            Assert.AreEqual(2, manager.Capacity);
        }

        [Test]
        public void Test_RobotManagerNotNull()
        {
            Assert.NotNull(manager);
        }

        [Test]
        public void Test_RobotManagerPrivateListNotNull()
        {
            Type type = typeof(RobotManager);

            FieldInfo filedInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "robots");

            List<Robot> value = filedInfo.GetValue(manager) as List<Robot>;

            Assert.NotNull(value);
        }

        [Test]
        public void Test_RobotNotNull()
        {
            Assert.NotNull(robot);
        }

        [Test]
        public void Test_RobotName()
        {
            Assert.AreEqual("Optimus", robot.Name);
        }

        [Test]
        public void Test_RobotMaximumBattery()
        {
            Assert.AreEqual(100, robot.MaximumBattery);
        }

        [Test]
        public void Test_RobotBattery()
        {
            Assert.AreEqual(100, robot.Battery);
        }
    }
}
