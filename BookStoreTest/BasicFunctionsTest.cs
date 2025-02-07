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

            Book? testBook = BasicFunctions.GetBookByTitle("The Travels of Marco Polo");

            Assert.Equal("The Travels of Marco Polo", testBook.BookTitle.Trim());
        }


        [Fact]
        public void TestGetAllBooks()
        {
            List<Book> books = BasicFunctions.GetAllBooks();
        }

        [Fact]
        public void TestGetBooksByAuthorLastName()
        {

            List<Book> booksByAuthor = BasicFunctions.GetBooksByAuthorLastName("Polo");

            Assert.All(booksByAuthor, book => Assert.Equal("Polo", book.Author.AuthorLast));
        }
    }
}
