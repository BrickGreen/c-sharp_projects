// Program 0
// CIS 200-01
// Due: 2/16/2015
// By: Brick Green

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LibraryMusic : LibraryMediaItem
{
    private const decimal DAYFEE = .5m;

    private string _artist;         //The music's director
    private MediaType _medium;      //The music's medium
    private int _numtracks;            //The music's number of tracks
    private decimal lateFee;        //The music's late fee
    private bool _checkedOut;       //The music's checked out status
    private LibraryPatron _patron;  //The person that has the music checked out (null otherwise)

    // Precondition:  None
    // Postcondition: The library periodical has been initialized with the specified
    //                values for title, publisher, copyright year, loan period, call number,
    //                duration, artist, medium, and number of tracks. The book is not checked out.
    public LibraryMusic(string title, string publisher, int copyrightYear, int loanPeriod,
        string callNumber, double duration, string artist, MediaType medium, int tracks)
        : base(title, publisher, copyrightYear, loanPeriod, callNumber, duration)
    {
        Artist = artist;
        MusicMedium = medium; 
        NumTracks = tracks;       
    }

    public string Artist
    { 
        //Precondition: none
        //Postcondition: the artist is returned
        get 
        {
            return _artist;
        }

        //Precondition: none
        //Postcondition: The artist has been set to the specified value
        set 
        {
            _artist = value;
        }
    }

    public MediaType MusicMedium
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
            if (_medium == MediaType.CD || _medium == MediaType.SACD || _medium == MediaType.VINYL)
                _medium = value;
            else
                throw new ArgumentException("Unacceptable media type.");

        }
    }

    public int NumTracks
    { 
        //Precondition: none
        //Postcondition: the number of tracks has been returned
        get 
        {
            return _numtracks;
        }
        //Precondition: value > 0
        //Postcondition: the number of tracks has been set to the specified value
        set
        {
            if (value > 0)
                _numtracks = value;
            else
                throw new ArgumentException("Negative number not accepted.");
        }
    }

    //Precondition: daysLate >= 0
    //Postcondition: The late fee has been returned
    public virtual decimal CalcLateFee(int daysLate)
    {
        lateFee = (decimal)daysLate * DAYFEE;
        if (lateFee > 20)
            lateFee = 20;
        return lateFee;
    }

    // Precondition:  None
    // Postcondition: A string is returned presenting the libary book's data on
    //                separate lines
    public override string ToString()
    {
        String result; // Holds for formatted results as being built

        result = String.Format("Title: {0}{8} Publisher: {1}{8}" +
            "Copyright: {2}{8} Loan Period: {3}{8} Call Number: {4}{8}" + 
            "Duration: {5}{8} Artist: {6}{8} Medium: {7}{8} Number of Tracks: {8}{8}",
            Title, Publisher, CopyrightYear, LoanPeriod, CallNumber, Duration, Artist, Medium, NumTracks, System.Environment.NewLine);

        if (IsCheckedOut())
            result += String.Format("Checked Out By: {0}{1}", Patron, System.Environment.NewLine);
        else
            result += "Not Checked Out";

        return result;
    }
}