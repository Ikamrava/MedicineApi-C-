using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OrderNum { get; set; }
        public decimal OrderTotal { get; set; }
        public string OrderStatus { get; set; }
    }
}