using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository repository;

    [SetUp]
    public void Setup()
    {
        hero = new Hero("Legolas", 100);
        repository = new HeroRepository();
    }

    [Test]
    public void Test_GetHeroCorrect()
    {
        repository.Create(hero);

        Hero expectedHero = repository.GetHero(hero.Name);

        Assert.AreEqual(expectedHero, hero);
        Assert.AreEqual(expectedHero.Name, hero.Name);
    }

    [Test]
    public void Test_GetHeroWithHighestLevelCorrect()
    {
        Hero newHero = new Hero("Aragorn", 200);

        repository.Create(hero);
        repository.Create(newHero);

        Hero expectedHero = repository.GetHeroWithHighestLevel();

        Assert.AreEqual(expectedHero, newHero);
        Assert.AreEqual(expectedHero.Name, newHero.Name);
        Assert.AreEqual(expectedHero.Level, newHero.Level);
    }

    [Test]
    public void Test_RemoveMethodCorrect()
    {
        repository.Create(hero);

        bool isRemoved = repository.Remove(hero.Name);

        Assert.AreEqual(0, repository.Heroes.Count);
        Assert.AreEqual(true, isRemoved);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("    ")]
    public void Test_RemoveMethodThrowsExceptionWhenNameIsNullOrWhitespace(string name)
    {
        repository.Create(hero);

        Assert.Throws<ArgumentNullException>(
            () => repository.Remove(name)
            );
        Assert.AreEqual(1, repository.Heroes.Count);
    }

    [Test]
    public void Test_CreateThrowExceptionWhenHeroIsNull()
    {
        hero = null;

        Assert.Throws<ArgumentNullException>(
            () => repository.Create(hero)
            );
        Assert.AreEqual(0, repository.Heroes.Count);
    }

    [Test]
    public void Test_CreateThrowExceptionWhenHeroExists()
    {
        repository.Create(hero);

        Assert.Throws<InvalidOperationException>(
            () => repository.Create(hero)
            );
        Assert.AreEqual(1, repository.Heroes.Count);
    }

    [Test]
    public void Test_CreateCorrect()
    {
        string realOutput = repository.Create(hero);

        string expectedOutput = $"Successfully added hero {hero.Name} with level {hero.Level}";

        Assert.AreEqual(1, repository.Heroes.Count);
        Assert.AreEqual(expectedOutput, realOutput);
    }

    [Test]
    public void Test_HeroRepositoryPrivateListNotNull()
    {
        Type type = typeof(HeroRepository);

        FieldInfo fieldInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(fi => fi.Name == "data");

        List<Hero> value = fieldInfo.GetValue(repository) as List<Hero>;

        Assert.NotNull(value);
    }

    [Test]
    public void Test_HeroNotNull()
    {
        Assert.NotNull(hero);
    }

    [Test]
    public void Test_HeroName()
    {
        Assert.AreEqual("Legolas", hero.Name);
    }

    [Test]
    public void Test_HeroLevel()
    {
        Assert.AreEqual(100, hero.Level);
    }
}