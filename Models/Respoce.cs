using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models
{
    public class Respoce
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<Users> listUsers { get; set; }
        public Users user { get; set; }

        public List<Medicine> listMedicine { get; set; }
        public Medicine medicine { get; set; }
        public List<Order> listOrder { get; set; }
        public Order order { get; set; }

        public List<Card> listCard { get; set; }
        public Card card { get; set; }

        public List<OrderItems> listOrderItems { get; set; }
        public OrderItems ortherItem { get; set; }


    }
}