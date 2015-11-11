// Program 0
// CIS 200-01
// Due: 2/16/2015
// By: Brick Green

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LibraryMagazine : LibraryPeriodical
{
    private const decimal DAYFEE = .25m;

    private decimal lateFee;

    // Precondition:  None
    // Postcondition: The library periodical has been initialized with the specified
    //                values for title, publisher, copyright year, loan period, call number,
    //                volume, and number. The book is not checked out.
    public LibraryMagazine(string title, string publisher, int copyrightYear, int loanPeriod, string callNumber, int volume, int number)
        : base(title, publisher, copyrightYear, loanPeriod, callNumber, volume, number) { }

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
    // Postcondition: A string is returned presenting the libary magazine's data on
    //                separate lines
    public override string ToString()
    {
        String result; // Holds for formatted results as being built

        result = String.Format("Title: {0}{7} Publisher: {1}{7}" +
            "Copyright: {2}{7} Loan Period: {3}{7} Call Number: {4}{7} Volume: {5}{7} Number: {6}{7}",
            Title, Publisher, CopyrightYear, LoanPeriod, CallNumber, Volume, Number, System.Environment.NewLine);

        if (IsCheckedOut())
            result += String.Format("Checked Out By: {0}{1}", Patron, System.Environment.NewLine);
        else
            result += "Not Checked Out";

        return result;
    }
}