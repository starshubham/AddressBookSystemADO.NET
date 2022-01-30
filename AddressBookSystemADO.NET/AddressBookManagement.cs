using System;
using System.Data;
using System.Data.SqlClient;

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

        /* UC2:- Ability to create a Address Book Table with first and last names, 
                 address, city, state, zip, phone number and email as its attributes 
        */

        public void GetAllContact()
        {

            AddressBookModel model = new AddressBookModel();
            try
            {
                using (connection)
                {
                    string query = @"select * from dbo.AddressBookSystem"; // Query to get all the data from the table

                    // Impementing the command on the connection fetched database table
                    SqlCommand command = new SqlCommand(query, connection); 

                    connection.Open();  //Open the connection.

                    SqlDataReader reader = command.ExecuteReader();  // executing the sql data reader to fetch the records
                    if (reader.HasRows)
                    {

                        while (reader.Read())  // Mapping the data to the employee model class object
                        {
                            model.FirstName = reader.GetString(0);
                            model.LastName = reader.GetString(1);
                            model.Address = reader.GetString(2);
                            model.City = reader.GetString(3);
                            model.State = reader.GetString(4);
                            model.Zip = reader.GetString(5);
                            model.PhoneNumber = reader.GetString(6);
                            model.EmailId = reader.GetString(7);
                            model.AddressBookType = reader.GetString(8);
                            model.AddressBookName = reader.GetString(9);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", model.FirstName, model.LastName,
                                model.Address, model.City, model.State, model.Zip, model.PhoneNumber, model.EmailId, model.AddressBookType, model.AddressBookName);
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Records Found in Address Book System Table");
                    }
                    reader.Close();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                connection.Close(); // Always ensuring the closing of the connection
            }
        }

        /* UC3:- Ability to insert new Contacts to Address Book 
         */

        public bool AddDataToTable(AddressBookModel model)
        {
            try
            {
                using (connection) // Using the connection established
                {
                    SqlCommand command = new SqlCommand("dbo.AddressBookSystemProcedure", connection); // Implementing the stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Zip", model.Zip);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailID", model.EmailId);
                    command.Parameters.AddWithValue("@addressBookType", model.AddressBookType);
                    command.Parameters.AddWithValue("@addressBookName", model.AddressBookName);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)  //Return the result of the transaction 
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
