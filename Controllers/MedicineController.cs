using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MedicineApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace MedicineApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MedicineController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        [Route("addtocard")]
        public Respoce AddToCard(Card card)
        {
            Respoce response = new Respoce();
            string connectionString = _configuration.GetConnectionString("EMedCS").ToString();
            DAL dal = new DAL();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    response = dal.addToCard(card, connection);

                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the connection process.
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return response;
        }

        [HttpPost]
        [Route("removefromcard")]
        public Respoce RemoveFromCard(Card card)
        {
            Respoce response = new Respoce();
            string connectionString = _configuration.GetConnectionString("EMedCS").ToString();
            DAL dal = new DAL();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    response = dal.removeFromCard(card, connection);

                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the connection process.
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return response;
        }

        [HttpPost]
        [Route("orderlist")]
        public Respoce GetOrderList(Users user)
        {
            Respoce response = new Respoce();
            string connectionString = _configuration.GetConnectionString("EMedCS").ToString();
            DAL dal = new DAL();

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    response = dal.getOrderList(user, connection);

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