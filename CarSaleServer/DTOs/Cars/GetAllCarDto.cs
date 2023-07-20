using CarSaleBackEnd.DTOs.Makes;
using CarSaleBackEnd.DTOs.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.DTOs.Cars
{
    public class GetAllCarDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Kilometers { get; set; }
        public int Price { get; set; }
        public DateTime Year { get; set; }
        public GetMakeDto Make { get; set; }
        public GetBasicPhotoDto Photo { get; set; }
    }
}
