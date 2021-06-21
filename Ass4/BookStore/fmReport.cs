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
    public partial class fmReport : Form
    {
        DataTable dt;
        ManageBook mn = new ManageBook();
        public fmReport()
        {
            InitializeComponent();
        }

        private void fmReport_Load(object sender, EventArgs e)
        {
            dt = mn.getBooksDesc();
            dgvBook.DataSource = dt;
        }
    }
}
