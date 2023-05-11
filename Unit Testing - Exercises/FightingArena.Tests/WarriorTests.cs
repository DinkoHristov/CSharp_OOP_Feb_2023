namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Bolg", 10, 100);
        }

        [TearDown]
        public void TearDown() 
        {
            warrior = null;
        }

        [Test]
        public void Test_WarriorConstructorCorrect()
        {
            Assert.AreEqual("Bolg", warrior.Name);
            Assert.AreEqual(10, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        public void Test_WarriorNullOrEmptyNameThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => warrior = new Warrior(null, 10, 100)
                );

            Assert.Throws<ArgumentException>(
               () => warrior = new Warrior(string.Empty, 10, 100)
               );
        }

        [Test]
        public void Test_WarriorDamageThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => warrior = new Warrior("Bolg", 0, 100)
                );
        }

        [Test]
        public void Test_WarriorHpThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => warrior = new Warrior("Bolg", 10, -10)
                );
        }

        [Test]
        public void Test_WarriorAttackerAndDeffenderCorrect()
        {
            Warrior attacker = new Warrior("Hans", 10, 100);
            warrior.Attack(attacker);

            Assert.AreEqual(90, warrior.HP);
            Assert.AreEqual(90, attacker.HP);
        }

        [Test]
        public void Test_WarriorAttackWithBiggerDmgAndDefenderHpBecomes0()
        {
            warrior = new Warrior("Bolg", 100, 100);
            Warrior attacker = new Warrior("Hans", 10, 50);
            warrior.Attack(attacker);

            Assert.AreEqual(0, attacker.HP);
        }

        [Test]
        public void Test_WarriorAttackThrowsExceptionWhenHpBelow30()
        {
            warrior = new Warrior("Bolg", 10, 10);

            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(new Warrior("Hans", 20, 50))
                );
        }

        [Test]
        public void Test_WarriorAttackThrowsExceptionWhenAttackeHpBelow30()
        {
            Warrior attacker = new Warrior("Hans", 10, 10);

            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(attacker)
                );
        }

        [Test]
        public void Test_WarriorAttackThrowsExceptionWhenDefenderHpSnallerThanAttackeDamage()
        {
            Warrior attacker = new Warrior("Hans", 110, 100);

            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(attacker)
                );
        }
    }
}