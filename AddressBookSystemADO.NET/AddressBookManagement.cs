using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystemADO.NET
{
    public class AddressBookManagement
    {
        /* UC1:- Address Book ServiceDB
                 - Use SQL Client to create DB and DB Records.
        */
        //Specifying the connection string from the sql server connection.
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookDB;Integrated Security=True";

        // Establishing the connection using the Sqlconnection.
        SqlConnection connection = new SqlConnection(connectionString);   

        public void DataBaseConnection()
        {
            try
            {
                DateTime now = DateTime.Now; //create object DateTime class //DateTime.Now class access system date and time 
                connection.Open(); // open connection
                using (connection)  //using SqlConnection
                {
                    Console.WriteLine($"Connection is created Successful {now}"); //print msg

                }
                connection.Close(); //close connection
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
