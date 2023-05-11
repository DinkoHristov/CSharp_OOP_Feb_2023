using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Weapon weapon;
            private Planet planet;

            [SetUp]
            public void SetUp()
            {
                weapon = new Weapon("AK", 100, 9);
                planet = new Planet("Earth", 50);
            }

            [TearDown]
            public void TearDown()
            {
                weapon = null;
                planet = null;
            }

            [Test]
            public void Test_WeaponConstructorCorrect()
            {
                Assert.AreEqual("AK", weapon.Name);
                Assert.AreEqual(100, weapon.Price);
                Assert.AreEqual(9, weapon.DestructionLevel);
                Assert.AreEqual(false, weapon.IsNuclear);
            }

            [Test]
            public void Test_PriceThrowsExceptionWhenNegative()
            {
                Assert.Throws<ArgumentException>(
                    () => weapon = new Weapon("Ak", -100, 8)
                    );
            }

            [Test]
            public void Test_IncreacseDestructionLevelCoorect()
            {
                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(10, weapon.DestructionLevel);
            }

            [Test]
            public void Test_IsWeaponNuclearCorrect()
            {
                weapon.IncreaseDestructionLevel();

                Assert.AreEqual(true, weapon.IsNuclear);
            }

            [Test]
            public void Test_PlanetConstructorCorrect()
            {
                planet.AddWeapon(weapon);

                Assert.AreEqual("Earth", planet.Name);
                Assert.AreEqual(50, planet.Budget);
                Assert.AreEqual(1, planet.Weapons.Count);
                Assert.AreEqual(9, planet.MilitaryPowerRatio);
            }

            [Test]
            public void Test_NameSetterThrowsExceptionWhenNullOrEmty()
            {
                Assert.Throws<ArgumentException>(
                    () => planet = new Planet(null, 50)
                    );

                Assert.Throws<ArgumentException>(
                    () => planet = new Planet(string.Empty, 50)
                    );
            }

            [Test]
            public void Test_BudgetSetterThrowsExceptionWhenNegative()
            {
                Assert.Throws<ArgumentException>(
                    () => planet = new Planet("Earth", -50)
                    );
            }

            [Test]
            public void Test_ProfitCorrect()
            {
                planet.Profit(10);

                Assert.AreEqual(60, planet.Budget);
            }

            [Test]
            public void Test_SpendFunds()
            {
                planet.SpendFunds(10);

                Assert.AreEqual(40, planet.Budget);
            }

            [Test]
            public void Test_SpendFundsThrowsExceptionWhenAmountBiggerThanBudget()
            {
                Assert.Throws<InvalidOperationException>(
                    () => planet.SpendFunds(100)
                    );
            }

            [Test]
            public void Test_AddWeaponCorrect()
            {
                planet.AddWeapon(weapon);

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void Test_AddWeaponThrowsExceptionIfExists()
            {
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(
                    () => planet.AddWeapon(weapon)
                    );
            }

            [Test]
            public void Test_RemoveWeaponCorrect()
            {
                planet.AddWeapon(weapon);
                planet.AddWeapon(new Weapon("Gun", 50, 4));

                planet.RemoveWeapon(weapon.Name);

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void Test_UpgradeWeaponCorrect()
            {
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);

                Assert.AreEqual(10, weapon.DestructionLevel);
            }

            [Test]
            public void Test_UpragedWeaponThrowsExceptionIfDontExists()
            {
                Assert.Throws<InvalidOperationException>(
                    () => planet.UpgradeWeapon("AK")
                    );
            }

            [Test]
            public void Test_DestructOpponentCorrect()
            {
                planet.AddWeapon(weapon);

                Planet newPlanet = new Planet("Mars", 30);
                Weapon newWeapon = new Weapon("Gun", 10, 5);
                newPlanet.AddWeapon(newWeapon);

                planet.DestructOpponent(newPlanet);

                string result = planet.DestructOpponent(newPlanet);

                Assert.That(result, Is.EquivalentTo(planet.DestructOpponent(newPlanet)));
            }

            [Test]
            public void Test_DestructOpponentThrowsExceptionWhenOpponentHasBiggetDamage()
            {
                planet.AddWeapon(weapon);

                Planet newPlanet = new Planet("Mars", 30);
                Weapon newWeapon = new Weapon("Gun", 10, 15);
                newPlanet.AddWeapon(newWeapon);

                Assert.Throws<InvalidOperationException>(
                    () => planet.DestructOpponent(newPlanet)
                    );
            }
        }
    }
}
