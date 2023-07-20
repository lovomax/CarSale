using CarSaleBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.DTOs.Cars
{
    public class AddCarDto
    {
        public string Model { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Color { get; set; }
        public int Kilometers { get; set; }
        public DateTime Year { get; set; }
        public int MakeId { get; set; }
    }
}
