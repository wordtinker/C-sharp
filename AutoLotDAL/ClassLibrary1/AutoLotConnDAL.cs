﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotConnectedLayer
{
    public class NewCar
    {
        public int CarID { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string PetName { get; set; }
    }

    public class InventoryDAL
    {
        // This member will be used by all methods.
        private SqlConnection sqlCn = null;
        public void OpenConnection(string connectionString)
        {
            sqlCn = new SqlConnection();
            sqlCn.ConnectionString = connectionString;
            sqlCn.Open();
        }
        public void CloseConnection()
        {
            sqlCn.Close();
        }
        public void InsertAuto(int id, string color, string make, string petName)
        {
            // Note the "placeholders" in the SQL query.
            string sql = string.Format("Insert Into Inventory" +
            "(CarID, Make, Color, PetName) Values" +
            "(@CarID, @Make, @Color, @PetName)");
            // This command will have internal parameters.
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                // Fill params collection.
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@CarID";
                param.Value = id;
                param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Make";
                param.Value = make;
                param.SqlDbType = SqlDbType.Char;
                param.Size = 10;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Color";
                param.Value = color;
                param.SqlDbType = SqlDbType.Char;
                param.Size = 10;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@PetName";
                param.Value = petName;
                param.SqlDbType = SqlDbType.Char;
                param.Size = 10;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
        }
        public void InsertAuto(NewCar car)
        {
            InsertAuto(car.CarID, car.Color, car.Make, car.PetName);
        }
        public void DeleteCar(int id)
        {
            // Get ID of car to delete, then do so.
            string sql = string.Format("Delete from Inventory where CarID = '{0}'",
            id);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
            }
        }
        public void UpdateCarPetName(int id, string newPetName)
        {
            // Get ID of car to modify and new pet name.
            string sql = string.Format("Update Inventory Set PetName = '{0}' Where CarID = '{1}'",
                newPetName, id);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public List<NewCar> GetAllInventoryAsList()
        {
            // This will hold the records.
            List<NewCar> inv = new List<NewCar>();
            // Prep command object.
            string sql = "Select * From Inventory";
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    inv.Add(new NewCar
                    {
                        CarID = (int)dr["CarID"],
                        Color = (string)dr["Color"],
                        Make = (string)dr["Make"],
                        PetName = (string)dr["PetName"]
                    });
                }
                dr.Close();
            }
            return inv;
        }
        public DataTable GetAllInventoryAsDataTable()
        {
            // This will hold the records.
            DataTable inv = new DataTable();
            // Prep command object.
            string sql = "Select * From Inventory";
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCn))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                // Fill the DataTable with data from the reader and clean up.
                inv.Load(dr);
                dr.Close();
            }
            return inv;
        }
        public string LookUpPetName(int carID)
        {
            string carPetName = string.Empty;
            // Establish name of stored proc.
            using (SqlCommand cmd = new SqlCommand("GetPetName", this.sqlCn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                // Input param.
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@carID";
                param.SqlDbType = SqlDbType.Int;
                param.Value = carID;
                // The default direction is in fact Input, but to be clear:
                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);
                // Output param.
                param = new SqlParameter();
                param.ParameterName = "@petName";
                param.SqlDbType = SqlDbType.Char;
                param.Size = 10;
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                // Execute the stored proc.
                cmd.ExecuteNonQuery();
                // Return output param.
                carPetName = (string)cmd.Parameters["@petName"].Value;
            }
            return carPetName;
        }
    }
}