// Program 2
// CIS 200-01
// Spring 2014
// Due: 3/11/2015
// By: Andrew L. Wright

// File: BookForm.cs
// This class creates the Book dialog box form GUI. It performs validation
// and provides String properties for each field.
// BookForm IS-A ItemFormBase

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibraryItems
{
    public partial class BookForm : ItemFormBase
    {
        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display.
        public BookForm()
        {
            InitializeComponent();
        }

        public String BookAuthor
        {
            // Precondition:  None
            // Postcondition: The text of form's author field has been returned
            get
            {
                return bookAuthorTxt.Text;
            }

            // Precondition:  None
            // Postcondition: The text of form's author field has been set to the specified value
            set
            {
                bookAuthorTxt.Text = value;
            }
        }

        // Precondition:  Focus is shifting from bookAuthorTxt
        // Postcondition: If text is invalid, focus remains and error provider
        //                highlights the field
        private void bookAuthorTxt_Validating(object sender, CancelEventArgs e)
        {
            if (bookAuthorTxt.TextLength == 0) // Empty field
            {
                e.Cancel = true;
                errorProvider.SetError(bookAuthorTxt, "Must provide Author");
            }
        }

        // Precondition:  Validating of bookAuthorTxt not cancelled, so data OK
        // Postcondition: Error provider cleared and focus allowed to change
        private void bookAuthorTxt_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(bookAuthorTxt, "");
        }

        // Precondition:  User clicked on okBtn
        // Postcondition: If invalid field on dialog, keep form open and give first invalid
        //                field the focus. Else return OK and close form.
        private void okBtn_Click(object sender, EventArgs e)
        {
            if (ValidateChildren()) // If all controls validate
                this.DialogResult = DialogResult.OK; // Causes form to close and return OK result
        }
    }
}
