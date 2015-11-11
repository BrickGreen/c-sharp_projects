// Program 1
// CIS 200-01
// Due: 2/17/2015
// By: Andrew L. Wright

// File: LibraryItem.cs
// This file creates an abstract LibraryItem class that will serve
// as the base class of a hierarchy of library items that keep
// track of common information and can be checked out by
// LibraryPatrons.
// LibraryItem HAS-A LibraryPatron (when the item is checked out)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    public abstract class LibraryItem
    {
        public const int DEFAULT_YEAR = 2015; // Default copyright year

        private String _title;          // The item's title
        private String _publisher;      // The item's publisher
        private int _copyrightYear;     // The item's year of copyright
        private String _callNumber;     // The item's call number in the library
        private bool _checkedOut;       // The item's checked out status
        private int _loanPeriod;        // The item's loan period
        private LibraryPatron _patron;  // The person that has the item checked out (null otherwise)

        // Precondition:  None
        // Postcondition: The library item has been initialized with the specified
        //                values for title, publisher, copyright year, loan period and
        //                call number. The item is not checked out.
        public LibraryItem(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber)
        {
            // Establish default first in case invalid
            CopyrightYear = DEFAULT_YEAR;

            Title = theTitle;
            Publisher = thePublisher;
            CopyrightYear = theCopyrightYear;
            LoanPeriod = theLoanPeriod;
            CallNumber = theCallNumber;

            ReturnToShelf(); // Make sure item is not checked out
        }

        public String Title
        {
            // Precondition:  None
            // Postcondition: The title has been returned
            get
            {
                return _title;
            }

            // Precondition:  None
            // Postcondition: The title has been set to the specified value
            set
            {
                _title = value;
            }
        }

        public String Publisher
        {
            // Precondition:  None
            // Postcondition: The publisher has been returned
            get
            {
                return _publisher;
            }

            // Precondition:  None
            // Postcondition: The publisher has been set to the specified value
            set
            {
                _publisher = value;
            }
        }

        public int CopyrightYear
        {
            // Precondition:  None
            // Postcondition: The copyright year has been returned
            get
            {
                return _copyrightYear;
            }

            // Precondition:  value >= 0
            // Postcondition: The copyright year has been set to the specified value
            set
            {
                if (value >= 0)
                    _copyrightYear = value;
                else
                    throw new ArgumentOutOfRangeException("CopyrightYear",
                        value, "CopyrightYear must be >= 0");
            }
        }

        public String CallNumber
        {
            // Precondition:  None
            // Postcondition: The call number has been returned
            get
            {
                return _callNumber;
            }

            // Precondition:  None
            // Postcondition: The call number has been set to the specified value
            set
            {
                _callNumber = value;
            }
        }

        public LibraryPatron Patron
        {
            // Precondition:  IsCheckedOut() == true
            // Postcondition: The patron that has the book checked out is returned
            //                (otherwise null)
            get
            {
                return _patron;
            }

            // HELPER - not public
            // Precondition:  None
            // Postcondition: The associated patron value is stored
            private set
            {
                _patron = value;
            }
        }

        public int LoanPeriod
        {
            // Precondition:  None
            // Postcondition: The loan period has been returned
            get
            {
                return _loanPeriod;
            }

            // Precondition:  value >= 0
            // Postcondition: The loan period has been set to the specified value
            set
            {
                if (value >= 0)
                    _loanPeriod = value;
                else
                    throw new ArgumentOutOfRangeException("LoanPeriod",
                        value, "LoanPeriod must be >= 0");
            }
        }

        // Abstract method header
        // Precondition:  daysLate >= 0
        // Postcondition: The fee for returning the item the specified days late
        //                has been returned
        public abstract decimal CalcLateFee(int daysLate);

        // Precondition:  None
        // Postcondition: The item is checked out by thePatron
        public void CheckOut(LibraryPatron thePatron)
        {
            _checkedOut = true;
            Patron = thePatron;
        }

        // Precondition:  None
        // Postcondition: The item is not checked out (by any patron)
        public void ReturnToShelf()
        {
            _checkedOut = false;
            Patron = null; // No longer associated with anyone
        }

        // Precondition:  None
        // Postcondition: true is returned if the item is checked out,
        //                otherwise false is returned
        public bool IsCheckedOut()
        {
            return _checkedOut;
        }

        // Precondition:  None
        // Postcondition: A string is returned presenting the libary item's data on
        //                separate lines
        public override string ToString()
        {
            String result; // Holds for formatted results as being built

            result = String.Format("Title: {0}{5}Publisher: {1}{5}" +
                "Copyright: {2}{5}Loan Period: {3}{5}Call Number: {4}{5}",
                Title, Publisher, CopyrightYear, LoanPeriod, CallNumber,
                System.Environment.NewLine);

            if (IsCheckedOut())
                result += String.Format("Checked Out By:{1}{0}", Patron,
                    System.Environment.NewLine);
            else
                result += "Not Checked Out";

            return result;
        }

        // HELPER METHOD - for derived classes
        // Precondition:  daysLate >= 0
        // Postcondition: If daysLate invalid, throw exception
        protected void ValidateDaysLate(int daysLate)
        {
            if (daysLate < 0)
                throw new ArgumentOutOfRangeException("daysLate",
                    daysLate, "daysLate must be >= 0");
        }
    }
}
