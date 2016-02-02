using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void FactoryProvider()
        {
            Console.WriteLine("***** Fun with Data Provider Factories *****\n");

            // Get connection string from app.config
            string dp = ConfigurationManager.AppSettings["provider"];
            string cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            //Get the factory provider
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            // Get the connection
            using (DbConnection cn = df.CreateConnection())
            {
                Console.WriteLine("Your connection object is a: {0}", cn.GetType().Name);
                cn.ConnectionString = cnStr;
                cn.Open();

                // Make command object.
                DbCommand cmd = df.CreateCommand();
                Console.WriteLine("Your command object is a: {0}", cmd.GetType().Name);
                cmd.Connection = cn;
                cmd.CommandText = "Select * From Inventory";

                // Print out data with data reader.
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    Console.WriteLine("Your data reader object is a: {0}", dr.GetType().Name);
                    Console.WriteLine("\n***** Current Inventory *****");
                    while (dr.Read())
                        Console.WriteLine("-> Car #{0} is a {1}.",
                        dr["CarID"], dr["Make"].ToString());
                }
            }
        }

        static void DataReader()
        {
            Console.WriteLine("**** Fun with DataReader ****\n");

            // Get connection string from app.config
            string dp = ConfigurationManager.AppSettings["provider"];
            string cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            using(SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnStr;
                cn.Open();

                // Create a SQL command object.
                string strSQL = "Select * From Inventory";
                SqlCommand myCommand = new SqlCommand(strSQL, cn);

                // Obtain a data reader a la ExecuteReader().
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    // Loop over the results.
                    while (myDataReader.Read())
                    {
                        Console.WriteLine("-> Make: {0}, PetName: {1}, Color: {2}.",
                        myDataReader["Make"].ToString(),
                        myDataReader["PetName"].ToString(),
                        myDataReader["Color"].ToString());
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            FactoryProvider();
            DataReader();
        }
    }
}
