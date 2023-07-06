using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado.net_basics_console_
{
    public class Creating
    {
        

        public void Createtbl()
        {
            string connection = "Data Source=VGATTU-L-5481;Initial Catalog=Exercise;User ID=SA;Password=Welcome2evoke@1234";
            SqlConnection _con = null;
            try
            {
                _con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("create table Company(id int not null,name varchar(50),phone int)",_con);
                _con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _con.Close();
            }
        }

        public void InsertRec()
        {
            string connection = "Data Source=VGATTU-L-5481;Initial Catalog=Exercise;User ID=SA;Password=Welcome2evoke@1234";
            SqlConnection _con = null;
            try
            {
                _con = new SqlConnection(connection);
                SqlCommand sqlcommand = new SqlCommand("insert into Company(id,name,phone)values (1,'zscalaer',040695555802)",_con);
                _con.Open();
                sqlcommand.ExecuteNonQuery();
                Console.WriteLine("values inserted successfully");
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _con.Close();
            }

        }
        public void Retrive()
        {
            string connection = "Data Source=VGATTU-L-5481;Initial Catalog=Exercise;User ID=SA;Password=Welcome2evoke@1234";
            SqlConnection _con = null;
            try
            {
                _con = new SqlConnection(connection);
                SqlCommand sqlcommand = new SqlCommand("select * from Company", _con);
                _con.Open();
                SqlDataReader reader = sqlcommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["id"] + " " + reader["name"] + " " + reader["phone"]);
                }
                Console.WriteLine("the records in the table are:");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _con.Close();
            }

        }
        public void Delete()
        {
            string connection= "Data Source=VGATTU-L-5481;Initial Catalog=Exercise;User ID=SA;Password=Welcome2evoke@1234";
            SqlConnection _con = null;
            try
            {
                _con = new SqlConnection(connection);
                SqlCommand sqlCommand = new SqlCommand("delete from Company where id=1", _con);
                _con.Open();
                sqlCommand.ExecuteNonQuery();
                Console.WriteLine("record deleted successfully");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _con.Close();
            }
        }

    }
}

