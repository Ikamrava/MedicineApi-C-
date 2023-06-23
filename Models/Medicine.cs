using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineApi.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Manufacturer { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Discount { get; set; }
        public int Status { get; set; }


    }
}