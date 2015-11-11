// Program 0
// CIS 200-01
// Due: 2/16/2015
// By: Brick Green

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LibraryMovie : LibraryMediaItem
{
    private const decimal DVDVHSFEE = 1m;
    private const decimal BLURAYFEE = 1.5m;

    private string _director;       //The movie's director
    private MediaType _medium;      //The movie's medium
    private MPAARating _rating;     //The movie's rating
    private decimal lateFee;        //The movie's late fee
    private bool _checkedOut;       // The movie's checked out status
    private LibraryPatron _patron;  // The person that has the book checked out (null otherwise)

    // Precondition:  None
    // Postcondition: The library periodical has been initialized with the specified
    //                values for title, publisher, copyright year, loan period, call number,
    //                duration, director, medium, and rating. The book is not checked out.
    public LibraryMovie(string title, string publisher, int copyrightYear, int loanPeriod,
        string callNumber, double duration, string director, MediaType medium, MPAARating rating)
        : base(title, publisher, copyrightYear, loanPeriod, callNumber, duration)
    {
        Director = director;
        Medium = medium;
        Rating = rating;
    }

    private enum MPAARating { G, PG, PG13, R, NC17, U };

    public string Director
    {
        //Precondtion: none
        //Postcondtion: the director has been returned
        get
        {
            return _director;
        }
        //Precondtion: none
        //Postcondition: the director is set to the specified value
        set
        {
            _director = value;
        }
    }

    public MediaType Medium
    {
        //Precondition: none
        //Postcondition: the medium has been returned
        get
        {
            return _medium;
        }
        //Precondition: value equals one the MediaType elements
        //Postcondition: the medium has been set to the specified value
        set
        {
            if (_medium == MediaType.DVD || _medium == MediaType.VHS || _medium == MediaType.BLURAY)
                _medium = value;
            else
                throw new ArgumentException("Unacceptable media type.");
        }
    }

    public MPAARating Rating
    {
        //Precondition: none
        //Postcondition: the rating has been returned
        get
        {
            return _rating;
        }
        //Precondition: value equals one of the MPAARating elements
        //Postcondition: the rating has been set to the specified value
        set
        {
            switch (value)
                {
                    case MPAARating.G:
                    case MPAARating.NC17:
                    case MPAARating.PG:
                    case MPAARating.PG13:
                    case MPAARating.R:
                    case MPAARating.U:
                        _rating = value;
                        break;
                    default:
                        throw new ArgumentException("Unacceptable rating.");
                        break;
                }
        }
    }

    //Precondition: daysLate >= 0
    //Postcondition: The late fee has been returned
    public virtual decimal CalcLateFee(int daysLate)
    {
        if (_medium == MediaType.DVD || _medium == MediaType.VHS)
        {
            lateFee = (decimal)daysLate * DVDVHSFEE;
                if (lateFee > 25)
                    lateFee = 25;
                return lateFee;
        }
            else
            {
                lateFee = (decimal)daysLate * BLURAYFEE;
                if (lateFee > 25)
                    lateFee = 25;
                return lateFee;
            }


    }

    // Precondition:  None
    // Postcondition: A string is returned presenting the libary book's data on
    //                separate lines
    public override string ToString()
    {
        String result; // Holds for formatted results as being built

        result = String.Format("Title: {0}{8} Publisher: {1}{8}" +
            "Copyright: {2}{8} Loan Period: {3}{8} Call Number: {4}{8}" + 
            "Duration: {5}{8} Director: {6}{8} Medium: {7}{8} Rating: {8}{8}",
            Title, Publisher, CopyrightYear, LoanPeriod, CallNumber, Duration, Director, Medium, Rating, System.Environment.NewLine);

        if (IsCheckedOut())
            result += String.Format("Checked Out By: {1}{0}", Patron, System.Environment.NewLine);
        else
            result += "Not Checked Out";

        return result;
    }
}
