// Program 1
// CIS 200-01
// Due: 2/17/2015
// By: Andrew L. Wright

// File: LibraryJournal.cs
// This file creates a concrete LibraryJournal class that adds
// discipline and editor.
// LibraryJournal IS-A LibraryPeriodical

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    public class LibraryJournal : LibraryPeriodical
    {
        public const decimal DAILYLATEFEE = 0.75m; // Journal's daily late fee

        private string _discipline; // The journal's discipline
        private string _editor;     // The journal's editor

        // Precondition:  None
        // Postcondition: The journal has been initialized with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, volume, number, discipline, and editor. The
        //                item is not checked out.
        public LibraryJournal(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, int theVolume, int theNumber,
            String theDiscipline, String theEditor) :
            base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber, theVolume, theNumber)
        {
            Discipline = theDiscipline;
            Editor = theEditor;
        }

        public string Discipline
        {
            // Precondition:  None
            // Postcondition: The discipline has been returned
            get
            {
                return _discipline;
            }

            // Precondition:  None
            // Postcondition: The discipline has been set to the specified value
            set
            {
                _discipline = value;
            }
        }

        public string Editor
        {
            // Precondition:  None
            // Postcondition: The editor has been returned
            get
            {
                return _editor;
            }

            // Precondition:  None
            // Postcondition: The editor has been set to the specified value
            set
            {
                _editor = value;
            }
        }

        // Precondition:  daysLate >= 0
        // Postcondition: The fee for returning the item the specified days late
        //                has been returned
        public override decimal CalcLateFee(int daysLate)
        {
            ValidateDaysLate(daysLate);

            return daysLate * DAILYLATEFEE;
        }

        // Precondition:  None
        // Postcondition: A string is returned presenting the libary item's data on
        //                separate lines
        public override string ToString()
        {
            String result; // Holds for formatted results as being built

            result = String.Format("LibraryJournal{3}Discipline: {0}{3}Editor: {1}{3}{2}",
                Discipline, Editor, base.ToString(), System.Environment.NewLine);

            return result;
        }
    }
}
