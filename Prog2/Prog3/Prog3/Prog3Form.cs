// Program 3
// CIS 200-01
// Spring 2015
// Due: 3/31/2015
// By: Brick Green

// File: Prog2Form.cs
// This class creates the main GUI for Program 2. It provides a
// File menu with About and Exit items, an Insert menu with Patron and
// Book items, an Item menu with Check Out and Return items, and a
// Report menu with Patron List, Item List, and Checked Out Items items.
// Extra Credit - Check Out and Return only show relevant items

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryItems
{
    public partial class Prog3Form : Form
    {
        private Library lib; // The library
        private System.IO.FileStream output; //stream for writing to a file
        private FileStream input; //stream for reading from a file

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display. A few test items and patrons
        //                are added to the library
        public Prog3Form()
        {
            InitializeComponent();

        //    lib = new Library(); // Create the library

        //    // Insert test data - Magic numbers allowed here
        //    lib.AddLibraryBook("The Wright Guide to C#", "UofL Press", 2010, 14, "ZZ225 3G", "Andrew Wright");
        //    lib.AddLibraryBook("Harriet Pooter", "Stealer Books", 2000, 21, "AG773 ZF", "IP Thief");
        //    lib.AddLibraryMovie("Andrew's Super-Duper Movie", "UofL Movies", 2011, 7,
        //        "MM33 2D", 92.5, "Andrew L. Wright", LibraryMediaItem.MediaType.BLURAY,
        //        LibraryMovie.MPAARatings.PG);
        //    lib.AddLibraryMovie("Pirates of the Carribean: The Curse of C#", "Disney Programming", 2011, 10,
        //        "MO93 4S", 122.5, "Steven Stealberg", LibraryMediaItem.MediaType.DVD, LibraryMovie.MPAARatings.G);
        //    lib.AddLibraryMusic("C# - The Album", "UofL Music", 2011, 14,
        //        "CD44 4Z", 84.3, "Dr. A", LibraryMediaItem.MediaType.CD, 10);
        //    lib.AddLibraryMusic("The Sounds of Programming", "Soundproof Music", 1996, 21,
        //        "VI64 1Z", 65.0, "Cee Sharpe", LibraryMediaItem.MediaType.VINYL, 12);
        //    lib.AddLibraryJournal("Journal of C# Goodness", "UofL Journals", 2011, 14,
        //        "JJ12 7M", 1, 2, "Information Systems", "Andrew Wright");
        //    lib.AddLibraryJournal("Journal of VB Goodness", "UofL Journals", 2007, 14,
        //        "JJ34 3F", 8, 4, "Information Systems", "Alexander Williams");
        //    lib.AddLibraryMagazine("C# Monthly", "UofL Mags", 2010, 14,
        //        "MA53 9A", 16, 7);
        //    lib.AddLibraryMagazine("C# Monthly", "UofL Mags", 2010, 14,
        //        "MA53 9B", 16, 8);
        //    lib.AddLibraryMagazine("C# Monthly", "UofL Mags", 2010, 14,
        //        "MA53 9C", 16, 9);
        //    lib.AddLibraryMagazine("VB Magazine", "UofL Mags", 2011, 14,
        //        "MA21 5V", 1, 1);

        //    // Add 5 Patrons
        //    lib.AddPatron("Ima Reader", "12345");
        //    lib.AddPatron("Jane Doe", "11223");
        //    lib.AddPatron("John Smith", "54321");
        //    lib.AddPatron("James T. Kirk", "98765");
        //    lib.AddPatron("Jean-Luc Picard", "33456");
        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("Program 2 - Extra Credit{0}By: Andrew L. Wright{0}" +
                "CIS 200-01{0}Spring 2015", System.Environment.NewLine), "About Program 2");
        }

        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  Report, Patron List menu item activated
        // Postcondition: The list of patrons is displayed in the reportTxt
        //                text box
        private void patronListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            List<LibraryPatron> patrons; // List of patrons

            patrons = lib.GetPatronsList();
            result.Append(String.Format("Patron List - {0} patrons", lib.GetPatronCount()));
            result.Append(System.Environment.NewLine); // Remember, \n doesn't always work in GUIs
            result.Append(System.Environment.NewLine);

            foreach (LibraryPatron p in patrons)
            {
                result.Append(p.ToString());
                result.Append(System.Environment.NewLine);
                result.Append(System.Environment.NewLine);
            }

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.SelectionStart = 0;
        }

        // Precondition:  Report, Item List menu item activated
        // Postcondition: The list of items is displayed in the reportTxt
        //                text box
        private void itemListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            List<LibraryItem> items;     // List of library items

            items = lib.GetItemsList();

            result.Append(String.Format("Item List - {0} items", lib.GetItemCount()));
            result.Append(System.Environment.NewLine); // Remember, \n doesn't always work in GUIs
            result.Append(System.Environment.NewLine);

            foreach (LibraryItem item in items)
            {
                result.Append(item.ToString());
                result.Append(System.Environment.NewLine);
                result.Append(System.Environment.NewLine);
            }

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.SelectionStart = 0;
        }

        // Precondition:  Report, Checked Out Items menu item activated
        // Postcondition: The list of checked out items is displayed in the
        //                reportTxt text box
        private void checkedOutItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            List<LibraryItem> items;     // List of library items

            items = lib.GetItemsList();

            // LINQ: selects checked out items
            var checkedOutItems =
                from item in items
                where item.IsCheckedOut()
                select item;

            result.Append(String.Format("Checked Out Items - {0} items", checkedOutItems.Count()));
            result.Append(System.Environment.NewLine); // Remember, \n doesn't always work in GUIs
            result.Append(System.Environment.NewLine);

            foreach (LibraryItem item in checkedOutItems)
            {
                result.Append(item.ToString());
                result.Append(System.Environment.NewLine);
                result.Append(System.Environment.NewLine);
            }

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.SelectionStart = 0;
        }

        // Precondition:  Insert, Patron menu item activated
        // Postcondition: The Patron dialog box is displayed. If data entered
        //                are OK, a LibraryPatron is created and added to the library
        private void patronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatronForm patronForm = new PatronForm(); // The patron dialog box form

            DialogResult result = patronForm.ShowDialog(); // Show form as dialog and store result

            if (result == DialogResult.OK) // Only add if OK
            {
                // Use form's properties to get patron info to send to library
                lib.AddPatron(patronForm.PatronName, patronForm.PatronID);
            }

            patronForm.Dispose(); // Good .NET practice - will get garbage collected anyway
        }

        // Precondition:  Insert, Book menu item activated
        // Postcondition: The Book dialog box is displayed. If data entered
        //                are OK, a LibraryBook is created and added to the library
        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm(); // The book dialog box form

            DialogResult result = bookForm.ShowDialog(); // Show form as dialog and store result

            if (result == DialogResult.OK) // Only add if OK
            {
                try
                {
                    // Use form's properties to get book info to send to library
                    lib.AddLibraryBook(bookForm.ItemTitle, bookForm.ItemPublisher, int.Parse(bookForm.ItemCopyrightYear),
                        int.Parse(bookForm.ItemLoanPeriod), bookForm.ItemCallNumber, bookForm.BookAuthor);
                }

                catch (FormatException) // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Book Validation!", "Validation Error");
                }
            }

            bookForm.Dispose(); // Good .NET practice - will get garbage collected anyway
        }

        // Precondition:  Item, Check Out menu item activated
        // Postcondition: The Checkout dialog box is displayed. If data entered
        //                are OK, an item is checked out from the library by a patron
        private void checkOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Extra Credit - Only display items that aren't already checked out

            List<LibraryItem> notCheckedOutList; // List of items not checked out
            List<int> notCheckedOutIndices;      // List of index values of items not checked out
            List<LibraryItem> items;             // List of library items
            List<LibraryPatron> patrons;         // List of patrons

            items = lib.GetItemsList();
            patrons = lib.GetPatronsList();
            notCheckedOutList = new List<LibraryItem>();
            notCheckedOutIndices = new List<int>();

            for (int i = 0; i < items.Count(); ++i)
                if (!items[i].IsCheckedOut()) // Not checked out
                {
                    notCheckedOutList.Add(items[i]);
                    notCheckedOutIndices.Add(i);
                }

            if ((notCheckedOutList.Count() == 0) || (patrons.Count() == 0)) // Must have items and patrons
                MessageBox.Show("Must have items and patrons to check out!", "Check Out Error");
            else
            {
                CheckoutForm checkoutForm = new CheckoutForm(notCheckedOutList, patrons); // The check out dialog box form

                DialogResult result = checkoutForm.ShowDialog(); // Show form as dialog and store result

                if (result == DialogResult.OK) // Only add if OK
                {
                    try
                    {
                        int itemIndex; // Index of item from full list of items

                        itemIndex = notCheckedOutIndices[checkoutForm.ItemIndex]; // Look up index from full list
                        lib.CheckOut(itemIndex, checkoutForm.PatronIndex);
                    }
                    catch (ArgumentOutOfRangeException) // This should never happen
                    {
                        MessageBox.Show("Problem with Check Out Index!", "Check Out Error");
                    }
                }
                checkoutForm.Dispose(); // Good .NET practice - will get garbage collected anyway
            }
        }

        // Precondition:  Item, Return menu item activated
        // Postcondition: The Return dialog box is displayed. If data entered
        //                are OK, an item is returned to the library
        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Extra Credit - Only display items that are already checked out

            List<LibraryItem> checkedOutList; // List of items checked out
            List<int> checkedOutIndices;      // List of index values of items checked out
            List<LibraryItem> items;          // List of library items
            List<LibraryPatron> patrons;      // List of patrons

            items = lib.GetItemsList();
            patrons = lib.GetPatronsList();
            checkedOutList = new List<LibraryItem>();
            checkedOutIndices = new List<int>();

            for (int i = 0; i < items.Count(); ++i)
                if (items[i].IsCheckedOut()) // Checked out
                {
                    checkedOutList.Add(items[i]);
                    checkedOutIndices.Add(i);
                }

            if ((checkedOutList.Count() == 0)) // Must have checked out items
                MessageBox.Show("Must have checked out items to return!", "Return Error");
            else
            {
                ReturnForm returnForm = new ReturnForm(checkedOutList); // The return dialog box form

                DialogResult result = returnForm.ShowDialog(); // Show form as dialog and store result

                if (result == DialogResult.OK) // Only add if OK
                {
                    try
                    {
                        int itemIndex; // Index of item from full list of items

                        itemIndex = checkedOutIndices[returnForm.ItemIndex]; // Look up index from full list
                        lib.ReturnToShelf(itemIndex);
                    }
                    catch (ArgumentOutOfRangeException) // This should never happen
                    {
                        MessageBox.Show("Problem with Return Index!", "Return Error");
                    }
                }
                returnForm.Dispose(); // Good .NET practice - will get garbage collected anyway
            }
        }

        private void saveLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result; //dialog box to enable user to save file
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            string fileName; //file to save data

            using (SaveFileDialog filechooser = new SaveFileDialog())
            {
                filechooser.CheckFileExists = false; //user can create file to save
                result = filechooser.ShowDialog();
                fileName = filechooser.FileName; //user must specify file name
            }

            if (result == DialogResult.OK)
            {
                if (fileName == string.Empty) //error if no file name is specified
                    MessageBox.Show("Invalid File Name.");
                else
                {
                    try //if the specified name is valid, save file via filestream
                    {
                        //privide write access
                        output = new System.IO.FileStream(fileName, FileMode.Create, FileAccess.Write);
                        //write file to filestream
                        formatter.Serialize(output, lib);
                    }
                    catch (IOException) //
                    {
                        MessageBox.Show("Error opening file.");
                    }
                    catch (System.Runtime.Serialization.SerializationException)
                    {
                        MessageBox.Show("Error writing to file.");
                    }
                    finally
                    {
                        if (output != null)
                            output.Close();
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //object for deserializing in binary format
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter reader = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            DialogResult result; //result of OpenFileDialog
            string fileName; // name of file containing data

            using (OpenFileDialog filechooser = new OpenFileDialog())
            {
                result = filechooser.ShowDialog();
                fileName = filechooser.FileName; //get specified name
            }

            if (result == DialogResult.OK)
            {
                try
                {

                    if (fileName == string.Empty)
                        MessageBox.Show("Invalid File Name");
                    else
                    {
                        input = new FileStream(fileName, FileMode.Open, FileAccess.Read); //create file stream to allow read access from file
                        lib = (Library)reader.Deserialize(input); //store deserialized file in lib variable
                    }
                }
                catch (System.Runtime.Serialization.SerializationException)
                {
                    MessageBox.Show("No more records in file.");
                }
                finally 
                {
                    if (input != null)
                        input.Close();
                }
            }
        }

        private void patronToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<LibraryPatron> patrons = new List<LibraryPatron>(); // list to hold patrons

            patrons = lib.GetPatronsList(); //get list of current patrons

            PatronEdit patronEditForm = new PatronEdit(patrons); // The patron dialog box form

            DialogResult result = patronEditForm.ShowDialog(); // Show form as dialog and store result



            if (result == DialogResult.OK) // Only add if OK
            {               
                //hold patron selected to edit
                LibraryPatron selectedPatron = lib._patrons[patronEditForm.ItemIndex];

                PatronForm pform = new PatronForm(); //patron form to load current patron data into

                pform.PatronName = selectedPatron.PatronName;   //current patron name
                pform.PatronID = selectedPatron.PatronID;       //current patron ID

                result = pform.ShowDialog(); //show to the patron dialog with the current data

                if (result == DialogResult.OK) //only add if OK
                {
                    selectedPatron.PatronName = pform.PatronName;   //set new patron name
                    selectedPatron.PatronID = pform.PatronID;       //set new patron ID
                }
            }
        }

        private void bookToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<LibraryItem> items = new List<LibraryItem>();  //list for all library items
            List<LibraryItem> books = new List<LibraryItem>();  //list for library books
            List<int> bookIndices;      // List of index values of items checked out

            items = lib.GetItemsList(); //get current list of library items
            bookIndices = new List<int>(); //list for book indicies

            for (int i = 0; i < items.Count(); i++) //loop to end of list
            {
                if (items[i] is LibraryBook) //if the item type is LibraryBook
                {
                    books.Add(items[i]); //add book to list
                    bookIndices.Add(i); //add item index
                }
            }

            BookEdit bookEditForm = new BookEdit(books); //form to choose the book to edit

            DialogResult result = bookEditForm.ShowDialog(); //show form with selected book data

            if (result == DialogResult.OK) //continue if OK
            {
                LibraryItem selectedItem = lib._items[bookIndices[bookEditForm.ItemIndex]]; //hold book selected to edit

                LibraryBook selectedBook = selectedItem as LibraryBook; //cast item as library book

                BookForm bform = new BookForm(); //new book form to load selected items to

                bform.ItemTitle = selectedBook.Title;   //add book title
                bform.ItemPublisher = selectedBook.Publisher;   //add publisher book
                bform.ItemCopyrightYear = selectedBook.CopyrightYear.ToString();    //add sting of copyright year
                bform.ItemLoanPeriod = selectedBook.LoanPeriod.ToString();  //add string of loan period
                bform.ItemCallNumber = selectedBook.CallNumber; //add call number
                bform.BookAuthor = selectedBook.Author; //add author

                result = bform.ShowDialog(); //show form with the selected book's data

                if (result == DialogResult.OK) //continue if OK
                {
                    selectedBook.Title = bform.ItemTitle;   //set new book title
                    selectedBook.Publisher = bform.ItemPublisher; //set new book publisher
                    selectedBook.CopyrightYear = int.Parse(bform.ItemCopyrightYear); //set new copyright year as int
                    selectedBook.LoanPeriod = int.Parse(bform.ItemLoanPeriod); //set new loan period as int
                    selectedBook.CallNumber = bform.ItemCallNumber; //set new call number
                    selectedBook.Author = bform.BookAuthor; //set new author
                }
            }
        }
    }
}