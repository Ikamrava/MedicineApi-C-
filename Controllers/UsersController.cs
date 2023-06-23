using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace MedicineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;


        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public Respoce Register(Users users)
        {
            Respoce response = new Respoce();
            string connectionString = _configuration.GetConnectionString("EMedCS").ToString();
            DAL dal = new DAL();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    response = dal.register(users, connection);

                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the connection process.
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return response;
        }




    }
}