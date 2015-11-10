// Program 2
// CIS 200-01
// Spring 2014
// Due: 3/11/2015
// By: Andrew L. Wright

// File: ItemFormBase.cs
// This class creates the base class for the Item dialog box form GUIs. It performs validation
// and provides String properties for each field.

// Alternate Validation - Instead of writing separate event handlers to validate each text box,
//                        this solution uses just two. One for fields that should be non-empty,
//                        and one for fields that should be non-negative integers.

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
    public partial class ItemFormBase : Form
    {
        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display.
        public ItemFormBase()
        {
            InitializeComponent();
        }

        public String ItemTitle
        {
            // Precondition:  None
            // Postcondition: The text of form's title field has been returned
            get
            {
                return itemTitleTxt.Text;
            }

            // Precondition:  None
            // Postcondition: The text of form's title field has been set to the specified value
            set
            {
                itemTitleTxt.Text = value;
            }
        }

        public String ItemPublisher
        {
            // Precondition:  None
            // Postcondition: The text of form's publisher field has been returned
            get
            {
                return itemPublisherTxt.Text;
            }

            // Precondition:  None
            // Postcondition: The text of form's publisher field has been set to the specified value
            set
            {
                itemPublisherTxt.Text = value;
            }
        }

        public String ItemCopyrightYear
        {
            // Precondition:  None
            // Postcondition: The text of form's copyright field has been returned
            get
            {
                return itemCopyrightTxt.Text;
            }

            // Precondition:  None
            // Postcondition: The text of form's copyright field has been set to the specified value
            set
            {
                itemCopyrightTxt.Text = value;
            }
        }

        public String ItemLoanPeriod
        {
            // Precondition:  None
            // Postcondition: The text of form's loan period field has been returned
            get
            {
                return itemLoanPeriodTxt.Text;
            }

            // Precondition:  None
            // Postcondition: The text of form's loan period field has been set to the specified value
            set
            {
                itemLoanPeriodTxt.Text = value;
            }
        }

        public String ItemCallNumber
        {
            // Precondition:  None
            // Postcondition: The text of form's call number field has been returned
            get
            {
                return itemCallNumberTxt.Text;
            }

            // Precondition:  None
            // Postcondition: The text of form's call number field has been set to the specified value
            set
            {
                itemCallNumberTxt.Text = value;
            }
        }

        // Precondition:  None
        // Postcondition: If textbox is not empty, returns true, else false
        protected bool IsNonEmptyText(TextBox tb)
        {
            if (tb.TextLength == 0) // Empty field
                return false;
            //else
            return true;
        }

        // Precondition:  None
        // Postcondition: If textbox contains non-negative int, returns true
        //                else false
        protected bool IsNonNegativeInt(TextBox tb)
        {
            int number;        // Parsed number
            bool valid = true; // Is text valid?

            if (!int.TryParse(tb.Text, out number)) // Parse failed?
                valid = false;
            else if (number < 0)
                valid = false;

            return valid;
        }

        // Precondition:  Focus is shifting from sender, sender is TextBox
        // Postcondition: If text is invalid, focus remains and error provider
        //                highlights the field
        protected void itemTxtNonEmpty_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb; // sender as a textbox
            bool valid; // Is text valid?

            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                valid = IsNonEmptyText(tb);
                if (!valid)
                {
                    e.Cancel = true;
                    errorProvider.SetError(tb, "Must provide value");
                }
            }
            else
                throw new ArgumentException("sender must be a TextBox");
        }

        // Precondition:  Focus is shifting from sender, sender is TextBox
        // Postcondition: If text is invalid, focus remains and error provider
        //                highlights the field
        protected void itemTxtNonNegative_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb; // sender as a textbox
            bool valid; // Is text valid?

            if (sender is TextBox)
            {
                tb = (TextBox)sender;
                valid = IsNonNegativeInt(tb);
                if (!valid)
                {
                    e.Cancel = true;
                    errorProvider.SetError(tb, "Must provide non-negative int value");
                }
            }
            else
                throw new ArgumentException("sender must be a TextBox");
        }

        // Precondition:  Validating of sender not cancelled, so data OK
        // Postcondition: Error provider cleared and focus allowed to change
        protected void itemTxt_Validated(object sender, EventArgs e)
        {
            TextBox tb; // sender as a textbox

            if (sender is TextBox)
            {
                tb = (TextBox)sender;

                errorProvider.SetError(tb, "");
            }
            else
                throw new ArgumentException("sender must be a TextBox");
        }

        // Precondition:  User pressed on cancelBtn
        // Postcondition: Form closes and sends Cancel result
        private void cancelBtn_MouseDown(object sender, MouseEventArgs e)
        {
            // This handler uses MouseDown instead of Click event because
            // Click won't be allowed if other field's validation fails

            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
