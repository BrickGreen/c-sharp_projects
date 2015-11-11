// Program 0
// CIS 200-01
// Due: 2/16/2015
// By: Brick Green

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

	public abstract class LibraryItem
	{
		private String _title;
		private String _publisher;
		private int _copyrightyear;
		private int _loanperiod;
		private String _callNumber;
		private bool _checkedOut;
		private LibraryPatron _patron;

        // Precondition:  None
        // Postcondition: The library item has been initialized with the specified
        //                values for title, publisher, copyright year, loan period, and
        //                call number. The item is not checked out.
		public LibraryItem(string title, string publisher, int copyrightYear, int loanPeriod, string callNumber) {

			Title = title;
			Publisher = publisher;
			CopyrightYear = copyrightYear;
            LoanPeriod = loanPeriod;
			CallNumber = callNumber;

			ReturnToShelf();
		}

		public String Title
		{
			//precondition: None
			//postcondition: The title has been returned
			get
			{
				return _title;
			}
			//precondition: None
			//postcondition: The title has been set to the specified value
			set
			{
				_title = value;
			}
		}


		public String Publisher
		{

			//precondition: None
			//postcondition: The publisher has been returned
			get
			{
				return _publisher;
			}
			//precondition: None
			//postcondition: The publisher has been set to the specified value
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
				return _copyrightyear;
			}

			// Precondition:  value >= 0
			// Postcondition: The copyright year has been set to the specified value
			set
			{
				if (value >= 0)
					_copyrightyear = value;
			}
		}

		public int LoanPeriod
		{
			//Precondition: None
			//Postcondition: The loan period has been returned
			get
			{
				return _loanperiod;
			}

			//Precondition: value >= 0
			//Postcondition: The loan period has been set to the specified value
			set
			{
                if (value >= 0)
                {
                    _copyrightyear = value;
                }
                else
                {
                    throw new ArgumentException("Unacceptable input.");
                }
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

		// Precondition:  None
		// Postcondition: The book is checked out by thePatron
		public void CheckOut(LibraryPatron thePatron)
		{
			_checkedOut = true;
			Patron = thePatron;
		}

		// Precondition:  None
		// Postcondition: The book is not checked out (by any patron)
		public void ReturnToShelf()
		{
			_checkedOut = false;
			Patron = null; // No longer associated with anyone
		}

		// Precondition:  None
		// Postcondition: true is returned if the book is checked out,
		//                otherwise false is returned
		public bool IsCheckedOut()
		{
			return _checkedOut;
		}

		public abstract decimal CalcLateFee(int daysLate);

		// Precondition:  None
		// Postcondition: A string is returned presenting the libary book's data on
		//                separate lines
		public override string ToString()
		{
			String result; // Holds for formatted results as being built

			result = String.Format("Title: {0}{5}Author: {1}{5}Publisher: {2}{5}" +
				"Copyright: {3}{5} Loan Period: {4}{5} Call Number: {5}{5}",
				Title, Publisher, CopyrightYear, LoanPeriod, CallNumber, System.Environment.NewLine);

			if (IsCheckedOut())
				result += String.Format("Checked Out By: {1}{0}", Patron, System.Environment.NewLine);
			else
				result += "Not Checked Out";

			return result;
		}
	}

