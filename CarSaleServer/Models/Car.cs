using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Color { get; set; }
        public int Kilometers { get; set; }
        public DateTime Year { get; set; }
        [Timestamp]
        public byte[] TimeStamp { get; set; }
        public Make Make { get; set; }
        public int MakeId { get; set; }
        public Photo Photo { get; set; }
    }
}
