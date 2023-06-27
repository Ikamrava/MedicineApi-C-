using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace MedicineApi.Models
{
    public class DAL
    {

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
                System.Console.WriteLine(command.Parameters.AddWithValue("@firstname", user.FirstName));

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

        public Respoce login(Users user, NpgsqlConnection connection)
        {
            Respoce respoce = new Respoce();
            connection.Open();
            string query = "SELECT * FROM users WHERE email=@email AND password=@password";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                Users loggedinUser = new Users();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    respoce.StatusCode = 200;
                    respoce.Message = "Login Successfully";
                    loggedinUser.Id = Convert.ToInt32(reader["id"]);
                    loggedinUser.FirstName = reader["firstname"].ToString();
                    loggedinUser.LastName = reader["lastname"].ToString();
                    loggedinUser.Email = reader["email"].ToString();
                    loggedinUser.Type = reader["type"].ToString();
                    respoce.user = loggedinUser;
                }
                else
                {
                    respoce.StatusCode = 100;
                    respoce.Message = "Login Failed";
                    respoce.user = null;
                }
                connection.Close();
            }
            return respoce;
        }


        public Respoce viewUser(Users user, NpgsqlConnection connection)
        {
            Respoce respoce = new Respoce();
            connection.Open();
            string query = "SELECT * FROM users WHERE id=@id";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", user.Id);
                NpgsqlDataReader reader = command.ExecuteReader();
                Users loggedinUser = new Users();
                if (reader.Read())
                {
                    respoce.StatusCode = 200;
                    respoce.Message = "User Exist";
                    loggedinUser.Id = Convert.ToInt32(reader["id"]);
                    loggedinUser.FirstName = reader["firstname"].ToString();
                    loggedinUser.LastName = reader["lastname"].ToString();
                    loggedinUser.Email = reader["email"].ToString();
                    loggedinUser.Fund = Convert.ToInt32(reader["fund"]);
                    loggedinUser.CreatedOn = Convert.ToDateTime(reader["createdon"]);
                    loggedinUser.Type = reader["type"].ToString();
                    respoce.user = loggedinUser;

                }
                else
                {
                    respoce.StatusCode = 100;
                    respoce.Message = "User does not exist";
                    respoce.user = null;
                }
                connection.Close();
            }
            return respoce;
        }


        public Respoce updateUser(Users user, NpgsqlConnection connection)
        {
            Respoce respoce = new Respoce();
            connection.Open();
            string query = "UPDATE users SET firstname=@firstname,lastname=@lastname,password=@password,email=@email WHERE id=@id";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@firstname", user.FirstName);
                command.Parameters.AddWithValue("@lastname", user.LastName);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@id", user.Id);
                int i = command.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    respoce.StatusCode = 200;
                    respoce.Message = "Update Successfully";
                }
                else
                {
                    respoce.StatusCode = 100;
                    respoce.Message = "Update Failed";
                }


            }

            return respoce;

        }

        public Respoce addToCard(Card card, NpgsqlConnection connection)
        {
            Respoce respoce = new Respoce();
            connection.Open();
            string query = "INSERT INTO card (userid,unitprice,discount,qty,totalprice,medicineid) VALUES(@userid,@unitprice,@discount,@qty,@totalprice,@medicineid)";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@userid", card.UserId);
                command.Parameters.AddWithValue("@unitprice", card.UnitPrice);
                command.Parameters.AddWithValue("@medicineid", card.MedicineId);
                command.Parameters.AddWithValue("@discount", card.Discount);
                command.Parameters.AddWithValue("@qty", card.Qty);
                command.Parameters.AddWithValue("@totalprice", card.TotalPrice);

                int i = command.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    respoce.StatusCode = 200;
                    respoce.Message = "Add to card Successfully";
                }
                else
                {
                    respoce.StatusCode = 100;
                    respoce.Message = "Add to card Failed";
                }


            }

            return respoce;

        }

        public Respoce removeFromCard(Card card, NpgsqlConnection connection)
        {
            Respoce respoce = new Respoce();
            connection.Open();
            string query = "DELETE FROM card WHERE id=@id";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", card.Id);
                int i = command.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    respoce.StatusCode = 200;
                    respoce.Message = "Remove from card Successfully";
                }
                else
                {
                    respoce.StatusCode = 100;
                    respoce.Message = "Remove from card Failed";
                }


            }

            return respoce;

        }

        public Respoce getOrderList(Users user, NpgsqlConnection connection)
        {
            Respoce respoce = new Respoce();
            connection.Open();
            string query = "SELECT * FROM user WHERE type=@type";
            var listOrder = new List<Order>();
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@type", user.Type);
                command.Parameters.AddWithValue("@id", user.Id);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Order order = new Order();
                        NpgsqlDataReader reader = command.ExecuteReader();
                        order.Id = Convert.ToInt32(reader["id"]);
                        order.OrderNum = Convert.ToString(reader["ordernum"]);
                        order.OrderTotal = Convert.ToDecimal(reader["ordertotal"]);
                        order.OrderStatus = Convert.ToString(reader["orderstatus"]);
                        listOrder.Add(order);
                    }
                    if (listOrder.Count > 0)
                    {
                        respoce.StatusCode = 200;
                        respoce.Message = "Order List";
                        respoce.listOrder = listOrder;

                    }


                    else
                    {
                        respoce.StatusCode = 100;
                        respoce.Message = "No list";
                        respoce.listOrder = null;
                    }


                }
                else
                {
                    respoce.StatusCode = 100;
                    respoce.Message = "No list";
                    respoce.listOrder = null;

                }

                return respoce;
            }

        }

        public Respoce placeOrder(Users user, NpgsqlConnection connection)
        {
            Respoce respoce = new Respoce();
            connection.Open();
            string query = "INSERT INTO user (userid) VALUES(@userid)";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@userid", user.Id);

                int i = command.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    respoce.StatusCode = 200;
                    respoce.Message = "Place Order Successfully";
                }
                else
                {
                    respoce.StatusCode = 100;
                }
                return respoce;
            }
        }

        public Respoce addupdateMedicine(Medicine medicine, NpgsqlConnection connection)
        {
            Respoce respoce = new Respoce();

            string query = "INSERT INTO medicine (name,manufacturer,unitprice,discount,qty,expirydate,imgurl,status,type) VALUES(@name,@manufacturer,@unitprice,@discount,@qty,@expirydate,@imgurl,@status,@type)";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@name", medicine.Name);
                command.Parameters.AddWithValue("@manufacturer", medicine.Manufacturer);
                command.Parameters.AddWithValue("@unitprice", medicine.UnitPrice);
                command.Parameters.AddWithValue("@discount", medicine.Discount);
                command.Parameters.AddWithValue("@qty", medicine.Qty);
                command.Parameters.AddWithValue("@imgurl", medicine.ImageUrl);
                command.Parameters.AddWithValue("@status", medicine.Status);
                command.Parameters.AddWithValue("@type", medicine.Type);
                command.Parameters.AddWithValue("@expirydate", medicine.ExpiryDate);


                connection.Open();
                int i = command.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    respoce.StatusCode = 200;
                    respoce.Message = "Add Medicine Successfully";
                }
                else
                {
                    respoce.StatusCode = 100;
                    respoce.Message = "Add Medicine Failed";


                }
                return respoce;
            }




        }
    }
}