using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryItems
{
    class Program4
    {
        // Precondition:  None
        // Postcondition: The LibraryItem sort has been tested
        static void Main(string[] args)
        {
            List<LibraryItem> items = new List<LibraryItem>();       // List of library items

            //fill library with library items
            items.Add(new LibraryBook("Orange", "Color Press", 2010, 14,
                "ZZ25 3G", "Brick Green"));
            items.Add(new LibraryBook("Beards Beards Beards", "Lumberjack Books", 2000, 21,
                "AB73 ZF", "Lee Cole"));
            items.Add(new LibraryMovie("If there's a will", "A Way Movies", 2007, 7,
                "MM33 2D", 92.5, "Aaron Williams", LibraryMediaItem.MediaType.BLURAY,
                LibraryMovie.MPAARatings.PG));
            items.Add(new LibraryMovie("Cheesy Cheddar", "Timbo Slice Programming", 2009, 10,
                "MO93 4S", 122.5, "Tim Cook", LibraryMediaItem.MediaType.DVD, LibraryMovie.MPAARatings.G));
            items.Add(new LibraryMusic("Jamal", "Jmill Music", 2011, 14,
                "CD44 4Z", 84.3, "Jon Miller", LibraryMediaItem.MediaType.CD, 10));
            items.Add(new LibraryMusic("The Sounds of Programming", "Soundproof Music", 1996, 21,
                "VI64 1Z", 65.0, "Cee Sharpe", LibraryMediaItem.MediaType.VINYL, 12));
            items.Add(new LibraryJournal("Journal of C# Goodness", "UofL Journals", 2010, 14,
                "JJ12 7M", 1, 2, "Information Systems", "Andrew Wright"));
            items.Add(new LibraryJournal("Cam Deezy", "Cam De Leon Journals", 2011, 14,
                "JK84 7M", 1, 2, "Dabildooya", "Camden Knight"));
            items.Add(new LibraryMagazine("Assspen", "Colorado Mags", 2010, 14,
                "MA53 9A", 16, 7));
            items.Add(new LibraryMagazine("VB Magazine", "UofL Mags", 2011, 14,
                "MA21 5V", 1, 1));

            //print list to console
            Console.Out.WriteLine("Orginal list:");
            foreach (LibraryItem Item in items)
            {
                Console.WriteLine(Item);
                Console.WriteLine();
            }
            Pause();


            items.Sort(); //sort items by title

            //print new sorted list to console
            Console.Out.WriteLine("Sorted list in natural order:");
            foreach (LibraryItem Item in items)
            {
                Console.WriteLine(Item);
                Console.WriteLine();
            }
            Pause();

            items.Sort(new CopyrightYearOrder()); // sort items by copyright year

            //print new list to console
            Console.WriteLine("Sorted by Copyright Year in descending order:");
            foreach (LibraryItem Item in items)
            {
                Console.WriteLine(Item);
                Console.WriteLine();
            }
            Pause();
        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }

    }


}
