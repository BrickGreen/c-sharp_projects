// Program 1
// CIS 200-01
// Due: 2/17/2015
// By: Andrew L. Wright

// File: Program.cs
// This file creates a small application that tests the LibraryItem hierarchy

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryItems;


public class Program
{
    // Precondition:  None
    // Postcondition: The LibraryItem hierarchy has been tested using LINQ, demonstrating polymorphism
    public static void Main(string[] args)
    {
        const int DAYSLATE = 14; // Number of days late to test each object's CalcLateFee method

        List<LibraryItem> items = new List<LibraryItem>();       // List of library items
        List<LibraryPatron> patrons = new List<LibraryPatron>(); // List of patrons

        int p; // Patron index

        // Test data - Magic numbers allowed here
        items.Add(new LibraryBook("The Wright Guide to C#", "UofL Press", 2010, 14,
            "ZZ25 3G", "Andrew Wright"));
        items.Add(new LibraryBook("Harriet Pooter", "Stealer Books", 2000, 21,
            "AB73 ZF", "IP Thief"));
        items.Add(new LibraryMovie("Andrew's Super-Duper Movie", "UofL Movies", 2011, 7,
            "MM33 2D", 92.5, "Andrew L. Wright", LibraryMediaItem.MediaType.BLURAY,
            LibraryMovie.MPAARatings.PG));
        items.Add(new LibraryMovie("Pirates of the Carribean: The Curse of C#", "Disney Programming", 2011, 10,
            "MO93 4S", 122.5, "Steven Stealberg", LibraryMediaItem.MediaType.DVD, LibraryMovie.MPAARatings.G));
        items.Add(new LibraryMusic("C# - The Album", "UofL Music", 2011, 14,
            "CD44 4Z", 84.3, "Dr. A", LibraryMediaItem.MediaType.CD, 10));
        items.Add(new LibraryMusic("The Sounds of Programming", "Soundproof Music", 1996, 21,
            "VI64 1Z", 65.0, "Cee Sharpe", LibraryMediaItem.MediaType.VINYL, 12));
        items.Add(new LibraryJournal("Journal of C# Goodness", "UofL Journals", 2011, 14,
            "JJ12 7M", 1, 2, "Information Systems", "Andrew Wright"));
        items.Add(new LibraryJournal("Journal of VB Goodness", "UofL Journals", 2007, 14,
            "JJ34 3F", 8, 4, "Information Systems", "Alexander Williams"));
        items.Add(new LibraryMagazine("C# Monthly", "UofL Mags", 2010, 14,
            "MA53 9A", 16, 7));
        items.Add(new LibraryMagazine("C# Monthly", "UofL Mags", 2010, 14,
            "MA53 9B", 16, 8));
        items.Add(new LibraryMagazine("C# Monthly", "UofL Mags", 2010, 14,
            "MA53 9C", 16, 9));
        items.Add(new LibraryMagazine("VB Magazine", "UofL Mags", 2011, 14,
            "MA21 5V", 1, 1));



        // Add patrons
        patrons.Add(new LibraryPatron("Ima Reader", "12345"));
        patrons.Add(new LibraryPatron("Jane Doe", "11223"));
        patrons.Add(new LibraryPatron("John Smith", "54321"));
        patrons.Add(new LibraryPatron("James T. Kirk", "98765"));
        patrons.Add(new LibraryPatron("Jean-Luc Picard", "33456"));

        Console.WriteLine("List of items at start:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item);
        Pause();

        // Check out some items
        // Here, every other item will be checked out by patrons (in order)
        // This is tricky... pay attention!

        p = 0; // Start with 1st patron
        for (int i = 0; i < items.Count; i+=2) // +=2 does every other
            items[i].CheckOut(patrons[p++ % patrons.Count]); // % Count keeps within 0 - (Count-1)

        Console.WriteLine("List of items after checking some out:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item); //write the elements of the items list
        Pause();

        // linq statement to select elements of items that are currently checked out
        var currentCheckedOut =
            from item in items
            where item.IsCheckedOut()
            select item;

        //  write each element of currentCheckedOut
        foreach (var element in currentCheckedOut)
            Console.WriteLine("{0}\n", element);

        Console.WriteLine("Current number of items checked out:");
        Console.WriteLine(currentCheckedOut.Count());

        Pause();

        // linq statement to select any media item that is checked out
        var currMediaCheckedOut =
            from LibraryItem item in currentCheckedOut
            where item is LibraryMediaItem
            select item;

        foreach (var element in currMediaCheckedOut)
            Console.WriteLine("{0}\n", element);


        Pause();
        
        // linq statement to select any magazine that is checked out
        var uniqueMag =
            from LibraryItem item in currentCheckedOut
            where item is LibraryMagazine
            select item;

        foreach(var element in uniqueMag.Distinct())
                Console.WriteLine(element);

        Pause();

        Console.WriteLine("Calculated late fees after {0} days late:\n", DAYSLATE);
        Console.WriteLine("{0,42} {1,11} {2,8}", "Title", "Call Number", "Late Fee");
        Console.WriteLine("------------------------------------------ ----------- --------");

        // Caluclate and display late fees for each item
        foreach (LibraryItem item in items)
            Console.WriteLine("{0,42} {1,11} {2,8:C}", item.Title, item.CallNumber,
                item.CalcLateFee(DAYSLATE));
        Pause();

        // Return each item that is checked out
        foreach (LibraryItem item in items)
        {
            if (item.IsCheckedOut())
                item.ReturnToShelf();
        }

        Console.WriteLine("After returning all items:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine("{0}\n", item);
        Pause();

        // write current number of checked out items
        Console.WriteLine("Current number of items checked out:");
        Console.WriteLine(currentCheckedOut.Count());

        Pause();

        // write current loan periods
        Console.WriteLine("The loan periods:\n");
        foreach (LibraryItem item in items)
            Console.WriteLine(item.LoanPeriod);
        
        // linq statement to increase loan period for books by 7
        var increaseLoanPeriod =
            from LibraryItem item in items
            where item is LibraryBook
            let new_item = item.LoanPeriod += 7
            select new_item;

        // write the new loan periods
        Console.WriteLine("After changing the loan periods:\n");
        foreach (var element in increaseLoanPeriod)
            Console.WriteLine(element);

        Pause();
    }

    // Precondition:  None
    // Postcondition: Pauses program execution until user presses Enter and
    //                then clears the screen
    public static void Pause()
    {
        Console.WriteLine("Press Enter to Continue...");
        Console.ReadLine();

        Console.Clear(); // Clear screen
    }
}