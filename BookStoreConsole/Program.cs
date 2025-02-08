using BookStore;
using System;
using System.Collections.Generic;
using BookStore.Models;

namespace BookStoreConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();

            Console.WriteLine("How would you like the output? (CSV or Console)");
            string outputType = Console.ReadLine()?.ToUpper();

            if (outputType != "CSV" && outputType != "CONSOLE")
            {
                Console.WriteLine("Invalid choice. Please enter CSV or Console.");
                return;
            }

            Console.WriteLine("Which function do you want to run? (GetAllBooks, GetBookByTitle, GetBooksByAuthorLastName)");
            string function = Console.ReadLine();

            string parameter = "";
            if (function == "GetBookByTitle" || function == "GetBooksByAuthorLastName")
            {
                Console.WriteLine("Enter the parameter (e.g., Book Title or Author's Last Name):");
                parameter = Console.ReadLine();
                if (string.IsNullOrEmpty(parameter))
                {
                    Console.WriteLine("Parameter cannot be null or empty.");
                    return;
                }
            }

            switch (function)
            {
                case "GetAllBooks":
                    books = BasicFunctions.GetAllBooks();
                    break;
                case "GetBookByTitle":
                    Book? book = BasicFunctions.GetBookByTitle(parameter);
                    if (book != null) books.Add(book);
                    break;
                case "GetBooksByAuthorLastName":
                    books = BasicFunctions.GetBooksByAuthorLastName(parameter);
                    break;
                default:
                    Console.WriteLine("Invalid function name.");
                    return;
            }

            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            if (outputType == "CSV")
                ConsoleUtils.WriteBooksToCsv(books);
            else
                ConsoleUtils.ListBooks(books);
        }
    }
}
