// Program 1
// CIS 200-01
// Due: 2/17/2015
// By: Andrew L. Wright

// File: LibraryMediaItem.cs
// This file creates an abstract LibraryMediaItem class that adds
// media type and duration.
// LibraryMediaItem IS-A LibraryItem

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    public abstract class LibraryMediaItem : LibraryItem
    {
        public enum MediaType { DVD, BLURAY, VHS, CD, SACD, VINYL }; // Possible media types

        private double _duration; // The item's duration (in minutes)

        // Precondition:  None
        // Postcondition: The library media item has been initialized with the specified
        //                values for title, publisher, copyright year, loan period, 
        //                call number, and duration. The item is not checked out.
        public LibraryMediaItem(String theTitle, String thePublisher, int theCopyrightYear,
            int theLoanPeriod, String theCallNumber, double theDuration) :
            base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber)
        {
            Duration = theDuration;
        }

        // Abstract property header
        public abstract MediaType Medium
        {
            // Precondition:  None
            // Postcondition: The medium has been returned
            get;

            // Precondition:  Varies - See concrete implementation
            // Postcondition: The medium has been set to the specified value
            set;
        }

        public double Duration
        {
            // Precondition:  None
            // Postcondition: The duration has been returned
            get
            {
                return _duration;
            }

            // Precondition:  value >= 0
            // Postcondition: The duration has been set to the specified value
            set
            {
                if (value >= 0)
                    _duration = value;
                else
                    throw new ArgumentOutOfRangeException("ItemDuration",
                        value, "ItemDuration must be >= 0");
            }
        }

        // Precondition:  None
        // Postcondition: A string is returned presenting the libary item's data on
        //                separate lines
        public override string ToString()
        {
            String result; // Holds for formatted results as being built

            result = String.Format("Duration: {0:F1}{1}",
                Duration, System.Environment.NewLine);

            result += String.Format("Medium: {0}{2}{1}", 
                Medium, base.ToString(), System.Environment.NewLine);

            return result;
        }
    }
}
