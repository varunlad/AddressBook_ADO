using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ADO_AddressBook
{
    class AddressBookRepository
    {
        //Connecting to Database
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13; Initial Catalog = AddressBook058; Integrated Security = True";
        //passing the string to sqlconnection to make connection 
        SqlConnection sqlconnection = new SqlConnection(connectionString);
        //GetAllAddressBook method

        public void GetAllAddressBook()
        {
            try
            {
                //Creating object for addressModel and access the fields
                AddressModel addressModel = new AddressModel();
                //Retrieve query
                string query = @"select * from AddressBookTable where City='Panvel' ";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                //Open the connection
                this.sqlconnection.Open();
                //ExecuteReader: Returns data as rows.
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        addressModel.AddressId = Convert.ToInt32(reader["AddressID"] == DBNull.Value ? default : reader["AddressID"]);
                        addressModel.FName = reader["FirstName"] == DBNull.Value ? default : reader["FirstName"].ToString();
                        addressModel.LName = reader["LastName"] == DBNull.Value ? default : reader["LastName"].ToString();
                        addressModel.State = reader["State"] == DBNull.Value ? default : reader["State"].ToString();
                        addressModel.City = reader["City"] == DBNull.Value ? default : reader["City"].ToString();
                        addressModel.ZipCode = Convert.ToDouble(reader["ZipCode"] == DBNull.Value ? default : reader["ZipCode"]);
                        addressModel.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                        addressModel.Phone = Convert.ToDouble(reader["PhoneNumber"] == DBNull.Value ? default : reader["PhoneNumber"]);
                        addressModel.Email= reader["Email"] == DBNull.Value ? default : reader["Email"].ToString();
                        addressModel.startDate = (DateTime)(reader["StartDate"] == DBNull.Value ? default(DateTime) : reader["StartDate"]);

                        Console.WriteLine("{0} {1} {2}  {3} {4} {5}  {6}  {7} {8} {9} ", addressModel.AddressId, addressModel.FName, addressModel.LName, addressModel.State, addressModel.City, addressModel.ZipCode, addressModel.Address, addressModel.Phone, addressModel.Email,addressModel.startDate);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("No data found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        
    }
}
