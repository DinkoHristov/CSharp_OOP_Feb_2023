using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UniversityLibrary.Test
{
    [TestFixture]
    public class Tests
    {
        private TextBook textBook;
        private UniversityLibrary universityLibrary;

        [SetUp]
        public void Setup()
        {
            textBook = new TextBook("Hobbit", "Tolkin", "action");
            universityLibrary = new UniversityLibrary();
        }

        [Test]
        public void Test_ConstructorTextBookNotNull()
        {
            Assert.NotNull(textBook);
        }

        [Test]
        public void Test_TextBookConstructorPropertiesCorrect()
        {
            Assert.AreEqual("Hobbit", textBook.Title);
            Assert.AreEqual("Tolkin", textBook.Author);
            Assert.AreEqual("action", textBook.Category);
        }

        [Test]
        public void Test_UniversityConstructorAndCatalogCorrect()
        {
            Type type = universityLibrary.GetType();

            FieldInfo fieldInfo = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "textBooks");

            List<TextBook> value = fieldInfo.GetValue(universityLibrary) as List<TextBook>;

            CollectionAssert.AreEqual(universityLibrary.Catalogue, value);
        }

        [Test]
        public void Test_AddTextBookToLibraryCorrect()
        {
            universityLibrary.AddTextBookToLibrary(textBook);

            Assert.AreEqual(1, textBook.InventoryNumber);
            Assert.AreEqual(1, universityLibrary.Catalogue.Count);
        }

        [Test]
        public void Test_LoanTextBookCorrectWithoutHolderYet()
        {
            universityLibrary.AddTextBookToLibrary(textBook);

            string returned = universityLibrary.LoanTextBook(textBook.InventoryNumber, "Ivan");

            string result = $"{textBook.Title} loaned to Ivan.";

            Assert.AreEqual("Ivan", textBook.Holder);
            Assert.AreEqual(result, returned);
        }

        [Test]
        public void Test_LoanTextBookWithHolderAlready()
        {
            universityLibrary.AddTextBookToLibrary(textBook);

            universityLibrary.LoanTextBook(textBook.InventoryNumber, "Ivan");

            string returned = universityLibrary.LoanTextBook(textBook.InventoryNumber, "Ivan");

            string result = $"Ivan still hasn't returned {textBook.Title}!";

            Assert.AreEqual("Ivan", textBook.Holder);
            Assert.AreEqual(result, returned);
        }

        [Test]
        public void Test_ReturnedTextBookCorrect()
        {
            universityLibrary.AddTextBookToLibrary(textBook);

            string returned = universityLibrary.ReturnTextBook(textBook.InventoryNumber);

            string expectedHolder = string.Empty;

            string result = $"{textBook.Title} is returned to the library.";

            Assert.AreEqual(expectedHolder, textBook.Holder);
            Assert.AreEqual(result, returned);
        }

        [Test]
        public void Test_TextBookToStringMethodCorrect()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Book: Hobbit - 1");
            result.AppendLine("Category: action");
            result.AppendLine("Author: Tolkin");

            string expectedResult = result.ToString().TrimEnd();

            var actualResult = universityLibrary.AddTextBookToLibrary(textBook);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}