using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleMSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            int parsedOrderID = 0;

            using (SqlConnection connection = new SqlConnection(Properties.Resources.ConnectionString))
            {
                // Define a t-SQL query string that has a parameter for orderID.
                //const string sql = "SELECT * FROM Sales.Orders WHERE orderID = @orderID";
                const string sql = "SELECT * FROM Sales.Orders";
                // Create a SqlCommand object.
                using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                {
                    // Define the @orderID parameter and set its value.
                    sqlCommand.Parameters.Add(new SqlParameter("@orderID", SqlDbType.Int));
                    sqlCommand.Parameters["@orderID"].Value = parsedOrderID;

                    try
                    {
                        connection.Open();

                        // Run the query by calling ExecuteReader().
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                Console.Write(dataReader.GetName(0) + '\t' 
                                    + dataReader.GetName(1) + '\t'
                                    + dataReader.GetName(2) + '\t'
                                    + dataReader.GetName(3) + '\t'
                                    + dataReader.GetName(4) + '\t'
                                    + dataReader.GetName(5) + '\n');
                                

                                while (dataReader.Read())
                                {
                                    Console.Write(dataReader.GetValue(0).ToString() + '\t'
                                                 + dataReader.GetValue(1).ToString() + '\t'
                                                 + dataReader.GetValue(2).ToString() + '\t'
                                                 + dataReader.GetValue(3).ToString() + '\t'
                                                 + dataReader.GetValue(4).ToString() + '\t'
                                                 + dataReader.GetValue(5).ToString() + '\n'
                                                 );
                             
                                   
                                   
                                }
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Запрос не может быть выведен в консоль.");
                    }
                    finally
                    {
                        // Close the connection.
                        connection.Close();
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
