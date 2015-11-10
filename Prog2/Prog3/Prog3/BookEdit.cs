//Brick Green
//CIS 200-01
//Program 3
//Due: 3/31/15

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
    public partial class BookEdit : Form
    {
        private List<LibraryItem> items;

        //Precondition: A list of Library Items has been entered
        //Postcondition: The form has been loaded
        public BookEdit(List<LibraryItem> itemList)
        {
            InitializeComponent();

            items = itemList;
        }

        //Precondition: The library item list has been loaded
        //Postcondition: Books have been added to the list box
        private void BookEdit_Load(object sender, EventArgs e)
        {
            foreach (LibraryItem b in items)
            {
                outputBookBox.Items.Add(b.Title + " - " + b.CallNumber);
            }
        }

        public int ItemIndex
        {
            // Precondition:  None
            // Postcondition: The index of form's selected item list box has been returned
            get
            {
                return outputBookBox.SelectedIndex;
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
