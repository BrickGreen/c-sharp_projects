// Program 0
// CIS 200-01
// Due: 2/16/2015
// By: Brick Green

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public abstract class LibraryMediaItem : LibraryItem
{
    private int _loanperiod;        // The media item's loan period
    private int _duration;          // The media item's duration
    private MediaType _medium;      // The media item's media type
    private bool _checkedOut;       // The movie's checked out status

    // Precondition:  None
    // Postcondition: The library periodical has been initialized with the specified
    //                values for title, publisher, copyright year, loan period, call number
    //                and duration. The book is not checked out.
    public LibraryMediaItem(string title, string publisher, int copyrightYear, int loanPeriod, string callNumber, double duration)
        : base(title, publisher, copyrightYear, loanPeriod, callNumber)
    {
        Duration = duration;
    }

    public enum MediaType { DVD, BLURAY, VHS, CD, SACD, VINYL };

    public double Duration
    {
        //Precondition: None
        //Postcondition: The duration has been returned
        get
        {
            return _duration;
        }

        //Precondition: The value must be greater than 0
        //Postconditon: The duration has been returned
        set 
        {
            
        }
    }

    public abstract MediaType Medium
    {
        //Precondition: none
        //Postcondition: The medium has been returned
        get
        {
            return _medium;        
        }
        //Precondition: none
        //Postcondition: the medium has been set to the specified value
        set 
        {
            _medium = value;
        }
    }

    // Precondition:  None
    // Postcondition: A string is returned presenting the libary book's data on
    //                separate lines
    public override string ToString()
    {
        String result; // Holds for formatted results as being built

        result = String.Format("Title: {0}{5}Author: {1}{5}Publisher: {2}{5}" +
            "Copyright: {3}{5} Loan Period: {4}{5} Call Number: {5}{5} Duration: {6}{5}",
            Title, Publisher, CopyrightYear, LoanPeriod, CallNumber,Duration, System.Environment.NewLine);

        return result;
    }
 }

