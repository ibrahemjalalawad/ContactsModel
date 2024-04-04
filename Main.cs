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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void _RefreshContactsList()
        {
            dgvContactsList.DataSource = clsContacts.GetAllContact();

        }

        private void btnAddNewContact_Click_1(object sender, EventArgs e)
        {

            AddEditContact frm = new AddEditContact(-1);
            frm.ShowDialog();
            _RefreshContactsList();
        }

        private void dgvContactsList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddEditContact frm = new AddEditContact((int)dgvContactsList.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
            _RefreshContactsList();
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete contact [" + dgvContactsList.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsContacts._DeleteContact((int)dgvContactsList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully.");
                    _RefreshContactsList();
                }

                else
                    MessageBox.Show("Contact is not deleted.");

            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _RefreshContactsList();
        }
    }


    
}
