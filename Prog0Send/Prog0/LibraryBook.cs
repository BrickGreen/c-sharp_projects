// Program 0
// CIS 200-01
// Due: 2/16/2015
// By: Brick Green

// This file creates a LibraryBook class capable of tracking
// the book's title, author, publisher, copyright year, call number,
// and checked out status. In addition, when a book is checked out
// by a LibraryPatron, the patron is noted.
// LibraryBook HAS-A LibraryPatron (when the book is checked out)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class LibraryBook : LibraryItem
{
    public const int DEFAULT_YEAR = 2015; // Default copyright year
    public const decimal LATE_FEE = 0.25M;

    private String _author;         // The book's author
    private decimal lateFee;        // The late fee for the book

    private bool _checkedOut;       // The book's checked out status
    private LibraryPatron _patron;  // The person that has the book checked out (null otherwise)

    // Precondition:  None
    // Postcondition: The library book has been initialized with the specified
    //                values for title, author, publisher, copyright year, loan period, and
    //                call number. The book is not checked out.
    public LibraryBook(String title, String author, String publisher,
        int copyrightYear, int loanPeriod, String callNumber)
        : base(title, publisher, copyrightYear, loanPeriod, callNumber)
    {
        Author = author;

        ReturnToShelf(); // Make sure book is not checked out
    }

    public String Author
    {
        // Precondition:  None
        // Postcondition: The author has been returned
        get
        {
            return _author;
        }

        // Precondition:  None
        // Postcondition: The author has been set to the specified value
        set
        {
            _author = value;
        }
    }

    //Precondition: The number of days late is a positive integer
    //Postcondition: the late fee has been returned 
    public virtual decimal CalcLateFee(int daysLate)
    {
        lateFee = (decimal)daysLate * LATE_FEE;
        return lateFee;
    }

    // Precondition:  None
    // Postcondition: A string is returned presenting the libary book's data on
    //                separate lines
    public override string ToString()
    {
        String result; // Holds for formatted results as being built

        result = String.Format("Title: {0}{5}Author: {1}{5}Publisher: {2}{5}" +
            "Copyright: {3}{5}Call Number: {4}{5}",
            Title, Author, Publisher, CopyrightYear, CallNumber, System.Environment.NewLine);

        if (IsCheckedOut())
            result += String.Format("Checked Out By: {1}{0}", Patron, System.Environment.NewLine);
        else
            result += "Not Checked Out";

        return result;
    }
}