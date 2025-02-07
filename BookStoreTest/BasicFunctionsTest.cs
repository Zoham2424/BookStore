using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore;
using BookStore.Models;

namespace BookStoreTest
{
    public class BasicFunctionsTest
    {
        [Fact]
        public void TestGetBookByTitle()
        {

            Book? testBook = BasicFunctions.GetBookByTitle("");



            Assert.Equal("", testBook.BookTitle);
        }


        [Fact]
        public void TestGetAllBooks()
        {
            List<Book> books = BasicFunctions.GetAllBooks();

            // Assert
            Assert.NotEmpty(books);
        }

        [Fact]
        public void TestGetBooksByAuthorLastName()
        {
            // Act
            List<Book> booksByAuthor = BasicFunctions.GetBooksByAuthorLastName("Orwell");

            // Assert
            Assert.NotEmpty(booksByAuthor);
            Assert.All(booksByAuthor, book => Assert.Equal("Orwell", book.Author.AuthorLast));
        }
    }
}
