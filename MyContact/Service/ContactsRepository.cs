using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyContact
{
    class ContactsRepository : IContactsRepository
    {
        private string connectionstring = "Data Source=.;Initial Catalog=Contact_DB;Integrated Security=true";
        public bool Delete(int contactId)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                string query = "Delete From MYContact2 Where ContactID=@ID ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Insert(string name, string family, string mobile, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                string query = "Insert Into MYContact2 (Name,Family,Mobail,Email,Age,Address) values (@Name,@Family,@Mobail,@Email,@Age,@Address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobail", mobile);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();

            }
        }

        public DataTable Search(string Parameter)
        {
            string query = "Select * From MYContact2  Where Name like @parameter Or Family like @parameter";
            SqlConnection conection = new SqlConnection(connectionstring);
            SqlDataAdapter adaptor = new SqlDataAdapter(query, conection);
            adaptor.SelectCommand.Parameters.AddWithValue("@parameter", "%" + Parameter + "%");
            DataTable data = new DataTable();
            adaptor.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "Select * From MYContact2";
            SqlConnection conection = new SqlConnection(connectionstring);
            SqlDataAdapter adaptor = new SqlDataAdapter(query,conection);
            DataTable data = new DataTable();
            adaptor.Fill(data);
            return data;


        }

        
        public DataTable SelectRow(int contactId)
        {
            string query = "Select * From MYContact2 where ContactID=" + contactId;
            SqlConnection conection = new SqlConnection(connectionstring);
            SqlDataAdapter adaptor = new SqlDataAdapter(query, conection);
            DataTable data = new DataTable();
            adaptor.Fill(data);
            return data;
            
        }

        public bool Update(int contactId, string name, string family, string Mobail, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                string query = "Update MYContact2 Set Name=@Name,Family=@Family,Mobail=@Mobail,Email=@Email,Age=@Age,Address=@Address Where ContactID=@ID"; 
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobail", Mobail);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
