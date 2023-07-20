using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.DTOs.Cars
{
    public class UpdateCarDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public int? Kilometers { get; set; }
        public int? Price { get; set; }
        public string Color { get; set; }
        public DateTime? Year { get; set; }
    }
}
