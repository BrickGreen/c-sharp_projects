using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    class CopyrightYearOrder : IComparer<LibraryItem>
    {
        //Postcondition: two library items have been passed as parameters
        //Precondtion: the difference between the copyright years has been returned
        public int Compare(LibraryItem Item1, LibraryItem Item2)
        {
            int yearCompare = Item2.CopyrightYear - Item1.CopyrightYear; // Difference between copyright years

            return yearCompare;
        }
    }
}
