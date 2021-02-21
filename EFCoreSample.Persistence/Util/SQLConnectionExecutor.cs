using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EFCoreSample.Persistence.Util
{
    class SQLConnectionExecutor
    {

        public static int ExecuteSQLNonQuery(string ConnectionString, string query)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    Console.WriteLine("Opening Connection");
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        Console.WriteLine("Execute Statement");
                        return command.ExecuteNonQuery();

                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return -1;
        }

        public static List<string> ExecuteSQLQuery(string ConnectionString, string query)
        {
            List<string> result = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    Console.WriteLine("Opening Connection");
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        Console.WriteLine("Execute Statement");
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string recordContent = "";
                                for (int curFieldOfRecord = 0;reader.FieldCount > curFieldOfRecord;curFieldOfRecord++)
                                {
                                    recordContent += reader.GetValue(curFieldOfRecord).ToString() + ";";
                                }

                                result.Add(recordContent);
                            }
                        }

                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return result;
        }
    }
}
