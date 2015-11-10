//Brick Green
//Program 3
//CIS 200-01
//Due: 3/31/15
//Description: The form produces a list box of the current patrons. Once selected, the patron's data is entered into a new box.

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
    public partial class PatronEdit : Form
    {
        private List<LibraryPatron> patrons; //list to hold current patrons

        //Precondition: there are patrons in list
        //Postcondition: The form has been created
        public PatronEdit(List<LibraryPatron> patronList)
        {
            InitializeComponent();

            patrons = patronList;
        }

        //Precondition: The library patron list has been loaded
        //Postcondition: Patrons have been added to the list box
        private void PatronEdit_Load(object sender, EventArgs e)
        {
            foreach (LibraryPatron p in patrons)
            {
                outputBox.Items.Add(p.PatronName + " - " + p.PatronID);
            }
        }

        public int ItemIndex
        {
            // Precondition:  None
            // Postcondition: The index of form's selected item list box has been returned
            get
            {
                return outputBox.SelectedIndex;
            }
        }

        // Precondition:  User clicked on okBtn
        // Postcondition: If invalid field on dialog, keep form open and give first invalid
        //                field the focus. Else return OK and close form.
        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (ValidateChildren()) // If all controls validate
                this.DialogResult = DialogResult.OK; // Causes form to close and return OK result
        }

        private void cancelBtn_MouseDown(object sender, MouseEventArgs e)
        {
            // This handler uses MouseDown instead of Click event because
            // Click won't be allowed if other field's validation fails

            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }

    }
}
