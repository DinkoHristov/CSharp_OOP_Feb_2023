namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class Tests
    {
        private Book book;

        [SetUp]
        public void Setup()
        {
            book = new Book("Hobbit", "Tolkin");
        }

        [Test]
        public void Test_BookNotNull()
        {
            Assert.NotNull(book);
        }

        [Test]
        public void Test_BookPrivateDictionaryNotNull()
        {
            Type type = typeof(Book);

            FieldInfo bookInfo = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "footnote");

            Dictionary<int, string> value = bookInfo.GetValue(book) as Dictionary<int, string>;

            Assert.NotNull(value);
        }

        [Test]
        public void Test_BookNameCorrect()
        {
            Assert.AreEqual("Hobbit", book.BookName);
        }

        [Test]
        public void Test_BookAuthorNameCorrect()
        {
            Assert.AreEqual("Tolkin", book.Author);
        }

        [Test]
        public void Test_BookFootNoteCountCorrect()
        {
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_BookNameThrowExceptionWhenNullOrEmpty(string bookName)
        {
            Assert.Throws<ArgumentException>(
                () => book = new Book(bookName, "Tolkin")
                );
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_BookAuthorNameThrowExceptionWhenNullOrEmpty(string authorName)
        {
            Assert.Throws<ArgumentException>(
                () => book = new Book("Hobbit", authorName)
                );
        }

        [Test]
        public void Test_AddFootnoteCorrect()
        {
            book.AddFootnote(1, "Hobbit is the best");

            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void Test_AddFootnoteThrowExceptionWhenFootnoteNumberExists()
        {
            book.AddFootnote(1, "Hobbit is the best");

            Assert.Throws<InvalidOperationException>(
                () => book.AddFootnote(1,"Hobbit again!")
                );
            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void Test_FindFootnoteCorrect()
        {
            book.AddFootnote(1, "Hobbit is the best");

            string expectedText = "Footnote #1: Hobbit is the best";

            Assert.AreEqual(1, book.FootnoteCount);
            Assert.AreEqual(expectedText, book.FindFootnote(1));
        }

        [Test]
        public void Test_FindFootnoteThrowExceptionWhenDontExists()
        {
            Assert.Throws<InvalidOperationException>(
                () => book.FindFootnote(1)
                );
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        public void Test_AlterFootnoteCorrect()
        {
            book.AddFootnote(1, "Hobbit is the best");

            book.AlterFootnote(1, "Hobbit is the greatest");

            string expectedText = "Hobbit is the greatest";

            string[] outputTextSplitted = book.FindFootnote(1).Split(": ");
            string outputText = outputTextSplitted[1];

            Assert.AreEqual(expectedText, outputText);
            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void Test_AlterFootnoteThrowExceptionWhenDontHaveSuchKey()
        {
            Assert.Throws<InvalidOperationException>(
                () => book.AlterFootnote(1, "New text")
                );
            Assert.AreEqual(0, book.FootnoteCount);
        }
    }
}