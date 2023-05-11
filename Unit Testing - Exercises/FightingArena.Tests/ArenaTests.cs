namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private List<Warrior> warriros;
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            warriros = new List<Warrior>();
            arena = new Arena();
        }

        [TearDown]
        public void TearDown() 
        {
            arena = null;
        }

        [Test]
        public void Test_ArenaConstructor()
        {
            List<Warrior> emptyWarriors = new List<Warrior>();

            Assert.That(emptyWarriors, Is.EquivalentTo(warriros));
        }


        [Test]
        public void Test_WarriorsListCorrect()
        {
            List<Warrior> arenaWarriors = arena.Warriors.ToList();

            Assert.That(arenaWarriors, Is.EquivalentTo(warriros));
        }

        [Test]
        public void Test_WarriorsListCountCorrect()
        {
            Assert.AreEqual(0, warriros.Count);
        }

        [Test]
        public void Test_EnrollCorrect()
        {
            arena.Enroll(new Warrior("Bolg", 10, 100));

            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void Test_EnrollThrowsExceptionWhenHaveWarriorWithGivenName()
        {
            arena.Enroll(new Warrior("Bolg", 10, 100));

            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(new Warrior("Bolg", 20, 110))
                );
        }

        [Test]
        public void Test_FightCorrect()
        {
            arena.Enroll(new Warrior("Bolg", 10, 100));
            arena.Enroll(new Warrior("Hans", 20, 120));

            Warrior attacker = arena.Warriors.FirstOrDefault(n => n.Name == "Bolg");
            Warrior defender = arena.Warriors.FirstOrDefault(n => n.Name == "Hans");

            arena.Fight("Bolg", "Hans");

            Assert.AreEqual(80, attacker.HP);
            Assert.AreEqual(110, defender.HP);
        }

        [Test]
        public void Test_FightAttackerThrowsExceptionWhenNotFound()
        {
            arena.Enroll(new Warrior("Hans", 20, 120));

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Bolg", "Hans")
                );
        }

        [Test]
        public void Test_FightDefenderThrowsExceptionWhenNotFound()
        {
            arena.Enroll(new Warrior("Bolg", 20, 120));

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Bolg", "Hans")
                );
        }
    }
}
