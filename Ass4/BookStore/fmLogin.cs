using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class fmLogin : Form
    {
        public fmLogin()
        {
            InitializeComponent();
            this.FormClosing += FmLogin_FormClosing;
        }

        private void FmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public Employee Login(string userName, string password)
        {
            Employee emp = null; ;
            string strConnection = "server=.;database=BookStore;uid=sa;pwd=123";
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "select * from Employee where " +
                " EmpID = @ID and EmpPassword = @Pass";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", userName);
            cmd.Parameters.AddWithValue("@Pass", password);
            SqlDataReader dr;
            try
            {
                cnn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    emp = new Employee(dr.GetString(0), dr.GetString(1), dr.GetBoolean(2).ToString());
                }
                //result = dr.HasRows;
                //dr.Read();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return emp;
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            Employee emp = Login(txtUsername.Text, txtPassword.Text);
            if (emp != null)
            {
                if (emp.EmpRole.Equals("False"))
                {
                    this.Hide();
                    fmChangeAccount f = new fmChangeAccount(emp);
                    f.Show();
                }
                else
                {
                    this.Hide();
                    fmMaintainBooks f = new fmMaintainBooks();
                    f.Show();
                }

            }
            else
            {
                MessageBox.Show("Login fail.");
            }
        }

        private void fmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
