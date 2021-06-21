using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class fmMaintainBooks : Form
    {
        ManageBook mn = new ManageBook();
        DataTable dt;
        BindingSource bs = new BindingSource();

        public fmMaintainBooks()
        {
            InitializeComponent();
            this.FormClosing += FmMaintainBooks_FormClosing;
        }

        private void FmMaintainBooks_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void fmMaintainBooks_Load(object sender, EventArgs e)
        {
            getAllBooks();
        }

        public void getAllBooks()
        {
            dt = mn.getBooks();
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            bs.DataSource = dt;
            dgvBooks.DataSource = bs;

            bindingNav.BindingSource = bs;
            txtID.DataBindings.Add("Text", bs, "BookID");
            txtName.DataBindings.Add("Text", bs, "BookName");
            txtPrice.DataBindings.Add("Text", bs, "BookPrice");
            
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Book b = new Book
            {
                BookID = Int32.Parse(txtID.Text),
                BookName = txtName.Text,
                BookPrice = double.Parse(txtPrice.Text)
            };
            if (mn.addNewBook(b))
            {
                MessageBox.Show("Add success");
            }
            else
            {
                MessageBox.Show("Add Fail");
            }
        }

        private void btRefesh_Click(object sender, EventArgs e)
        {
            getAllBooks();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            Book b = new Book
            {
                BookID = Int32.Parse(txtID.Text),
                BookName = txtName.Text,
                BookPrice = double.Parse(txtPrice.Text)
            };
            if (mn.updateBook(b))
            {
                MessageBox.Show("Update success");
            }
            else
            {
                MessageBox.Show("Update Fail");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(txtID.Text);
            if (mn.deleteBook(id))
            {
                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Delete Fail");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            string filter = "BookName like '%" + txtSearch.Text + "%'";
            dv.RowFilter = filter;
            lbsum.Text = "SumBookPrice: " + dt.Compute("SUM(BookPrice)",filter);
        }

        private void btReport_Click(object sender, EventArgs e)
        {
            fmReport rp = new fmReport();
            rp.Show();
        }
    }
}
