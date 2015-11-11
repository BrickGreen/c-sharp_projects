// Program 0
// CIS 200-01
// Due: 2/16/2015
// By: Brick Green

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LibraryJournal : LibraryPeriodical
{
    private const decimal DAYFEE = .75m;

    private string _discipline;
    private string _editor;
    private decimal lateFee;

    // Precondition:  None
    // Postcondition: The library journal has been initialized with the specified
    //                values for title, publisher, copyright year, loan period,
    //                call number, volume, number, discipline, and editor. 
    //                The book is not checked out.
    public LibraryJournal(string title, string publisher, int copyrightYear, int loanPeriod,
        string callNumber, int volume, int number, string discipline, string editor)
        : base(title, publisher, copyrightYear, loanPeriod, callNumber, volume, number)
    {
        Discipline = discipline;
        Editor = editor;
    }

    public string Discipline
    {
        //Precondition: none
        //Postcondtion: the discipline is returned
        get
        {
            return _discipline;
        }

        //Precondition: none
        //Postcondition: the discipline is set to the 
        set
        {
            _discipline = value;
        }
    }
    public string Editor
    {
        //Precondition: none
        //Postcondtion: the editor is returned
        get
        {
            return _editor;
        }

        //Precondition: none
        //Postcondition: the editor is set to the 
        set
        {
            _editor = value;
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
    // Postcondition: A string is returned presenting the libary journal's data on
    //                separate lines
    public override string ToString()
    {
        String result; // Holds for formatted results as being built

        result = String.Format("Title: {0}{9} Publisher: {1}{9}" +
            "Copyright: {2}{9} Loan Period: {3}{9} Call Number: {4}{9} Volume: {5}{9}" +
            "Number: {6}{9} Discipline: {7}{9} Editor: {8}{9}",
            Title, Publisher, CopyrightYear, LoanPeriod, CallNumber, Volume, Number, Discipline, Editor, System.Environment.NewLine);

        if (IsCheckedOut())
            result += String.Format("Checked Out By: {0}{1}", Patron, System.Environment.NewLine);
        else
            result += "Not Checked Out";

        return result;
    }
}
