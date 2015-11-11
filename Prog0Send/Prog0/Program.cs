// Program 0
// CIS 200-01
// Due: 2/16/2015
// By: Brick Green

// File: Program.cs
// This file serves as a simple test program for the LibraryBook
// and LibraryPatron classes. It creates a list of books and
// tests their ability to be checked out by patrons and returned.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Program
{
    // Precondition:  None
    // Postcondition: The LibraryBook and LibaryPatron classes have been tested
    public static void Main(string[] args)
    {
        LibraryBook book1 = new LibraryBook("First Book", "Brick Green", "UofL Press",
            2010, "ZZ25 3G");  // 1st test book
        LibraryBook book2 = new LibraryBook("Second Book", "Lee Cole", "Stealer Books",
            2000, "AG773 ZF"); // 2nd test book
        LibraryBook book3 = new LibraryBook("White Fang", "Jack London", "Unsure Books Ltd.",
            1985, "JJ438 4T"); // 3rd test book
        LibraryBook book4 = new LibraryBook("The Old Man and the Sea", "Ernest Hemingway", "Charles Schribner Sons",
            -1, "ZZ24 4F");    // 5th test book
        LibraryBook book5 = new LibraryBook("The Big Book of Doughnuts", "Homer Simpson", "Doh Books",
            2001, "AE842 7A"); // 4th test book

        LibraryPatron patron1 = new LibraryPatron("Ima Reader", "12345"); // 1st test patron
        LibraryPatron patron2 = new LibraryPatron("Jane Doe", "112233");  // 2nd test patron
        LibraryPatron patron3 = new LibraryPatron("John Smith", "54321"); // 3rd test patron


        List<LibraryBook> theBooks = new List<LibraryBook>(); // Test list of books

        // Add books to the list
        theBooks.Add(book1);
        theBooks.Add(book2);
        theBooks.Add(book3);
        theBooks.Add(book4);
        theBooks.Add(book5);


        Console.WriteLine("Original list of books");
        PrintBooks(theBooks);

        // Make changes
        book1.CheckOut(patron1);
        book2.Publisher = "Borrowed Books";
        book3.CheckOut(patron2);
        book4.CallNumber = "AB123 4A";
        book5.CheckOut(patron3);

        Console.WriteLine("After changes");
        PrintBooks(theBooks);

        // Return all the books
        for (int i = 0; i < theBooks.Count; ++i)
            theBooks[i].ReturnToShelf();

        Console.WriteLine("After returning the books");
        PrintBooks(theBooks);
    }

    // Precondition:  None
    // Postcondition: The books have been printed to the console
    public static void PrintBooks(List<LibraryBook> books)
    {
        foreach (LibraryBook b in books)
        {
            Console.WriteLine(b);
            Console.WriteLine();
        }
    }
}
