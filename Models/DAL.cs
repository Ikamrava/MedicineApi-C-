using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace MedicineApi.Models
{
    public class DAL
    {
        private string? connectionString;



        public Respoce register(Users user, NpgsqlConnection connection)
        {
            Respoce respoce = new Respoce();
            connection.Open();
            string query = "INSERT INTO users (firstname,lastname,email,password,fund,type,status) VALUES(@firstname,@lastname,@email,@password,@fund,@type,@status)";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@firstname", user.FirstName);
                command.Parameters.AddWithValue("@lastname", user.LastName);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@fund", 0);
                command.Parameters.AddWithValue("@type", "Users");
                command.Parameters.AddWithValue("@status", "Pending");

                int i = command.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    respoce.StatusCode = 200;
                    respoce.Message = "Register Successfully";
                }
                else
                {
                    respoce.StatusCode = 100;
                    respoce.Message = "Register Failed";
                }


            }

            return respoce;

        }
    }
}