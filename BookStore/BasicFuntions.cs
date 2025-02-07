using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BookStore
{
    internal class BasicFuntions
    {
        public static Book? GetBookByTitle(string title)
        {
            using (var context = new Se407BookStoreContext())
            {
                return context.Books
                    .FirstOrDefault(b => b.BookTitle == title);
            }
        }
        public static List<Book> GetAllBooks()
        {
            using (var context = new Se407BookStoreContext())
            {
                return context.Books.ToList();
            }
        }
        public static List<Book> GetBooksByAuthorLastName(string lastName)
        {
            using (var context = new Se407BookStoreContext())
            {
                return context.Authors
                    .Where(a => a.AuthorLast == lastName)
                    .Join(
                        context.Books,
                        author => author.AuthorId,
                        book => book.AuthorId,
                        (author, book) => book
                    )
                    .ToList();
            }
        }

    }

}
