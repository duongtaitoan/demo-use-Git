using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class ManageBook
    {
        string strConnection;
        public ManageBook()
        {
            strConnection = getConnectionString();
        }
        //Phuong thuc lay chuoi ket noi
        public string getConnectionString()
        {
            string strConnection = "server=.;database=BookStore;uid=sa;pwd=123";
            return strConnection;
        }
        //Phuong thuc lay tat cac Sach
        public DataTable getBooks()
        {
            string SQL = "select * from Books";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtBook = new DataTable();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                da.Fill(dtBook);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dtBook;
        }

        //Phuong thuc them moi Sach
        public bool addNewBook(Book book)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Insert Books values(@ID,@Name,@Price)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", book.BookID);
            cmd.Parameters.AddWithValue("@Name", book.BookName);
            cmd.Parameters.AddWithValue("@Price", book.BookPrice);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        //Phuong thuc cap nhat Sach
        public bool updateBook(Book book)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL =
                "Update Books set BookName=@Name, BookPrice=@Price where BookID=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", book.BookID);
            cmd.Parameters.AddWithValue("@Name", book.BookName);
            cmd.Parameters.AddWithValue("@Price", book.BookPrice);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
        //Phuong thuc xoa sach
        public bool deleteBook(int BookID)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "Delete Books where BookID=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", BookID);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public DataTable getBooksDesc()
        {
            string SQL = "select * from Books order by BookPrice desc";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtBook = new DataTable();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                da.Fill(dtBook);
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dtBook;
        }

        public bool UpdateEmp(Employee e)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL =
                "Update Employee set EmpPassword = @Pass where EmpID=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", e.EmpID);
            cmd.Parameters.AddWithValue("@Pass", e.EmpPass);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

    }
}
