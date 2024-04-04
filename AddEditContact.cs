using BussinessContacts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsModel
{
    public partial class AddEditContact : Form
    {
        public AddEditContact()
        {
            InitializeComponent();
        }
        public enum enMode { addnew = 0, updateContact = 1 }
        private enMode _Mode;
        int _ContactID;
        clsContacts _Contacts;
        public AddEditContact(int CountactID)
        {
            InitializeComponent();

            _ContactID = CountactID;
            if (CountactID == -1)
            {
                _Mode = enMode.addnew;

            }
            else
                _Mode = enMode.updateContact;

        }
     
        private void _Load()
        {
           

            if (_Mode == enMode.addnew)
            {
                label1.Text = "Add New Contact";
                _Contacts = new clsContacts();
                return;

            }
            _Contacts = clsContacts.Find(_ContactID);
            if (_Contacts == null)
            {
                MessageBox.Show("This form will be closed because No Contact with ID = " + _ContactID);
                this.Close();

                return;
            }


            label1.Text = "Update Contact with ID = " + _Contacts.ID;
            lblContactID.Text = _Contacts.ID.ToString();
            tbFirstName.Text = _Contacts.FirstName;
            tbLastName.Text = _Contacts.LastName;
            tbEmail.Text = _Contacts.Email;
            tbPhone.Text = _Contacts.Phone;
          
        







        }

       

     

      
      

        private void AddEditContact_Load(object sender, EventArgs e)
        {
            _Load();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            _Contacts.FirstName = tbFirstName.Text;
            _Contacts.LastName = tbLastName.Text;
            _Contacts.Email = tbEmail.Text;
            _Contacts.Phone = tbPhone.Text;

            if (_Contacts.Save())
            {
                MessageBox.Show("Contact Save Successfully");
            }
            else
                MessageBox.Show("Could not save the contact");

            _Mode = enMode.updateContact;
            label1.Text = "Update Contact with ID = " + _Contacts.ID;
            lblContactID.Text = _Contacts.ID.ToString();
        }
    }
}
