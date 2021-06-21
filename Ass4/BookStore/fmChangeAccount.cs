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
    public partial class fmChangeAccount : Form
    {
        Employee emp;
        public fmChangeAccount(Employee e)
        {
            InitializeComponent();
            emp = e;
            txtID.Text = emp.EmpID;
            txtPass.Text = emp.EmpPass;
            txtRole.Text = emp.EmpRole;
            this.FormClosing += FmChangeAccount_FormClosing;
        }

        private void FmChangeAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!txtPass.Text.Equals(""))
            {
                ManageBook mn = new ManageBook();
                emp.EmpPass = txtPass.Text;
                if (mn.UpdateEmp(emp))
                {
                    MessageBox.Show("Update success");
                }
                else
                {
                    MessageBox.Show("Update success");
                }
            }
        }

        private void fmChangeAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
