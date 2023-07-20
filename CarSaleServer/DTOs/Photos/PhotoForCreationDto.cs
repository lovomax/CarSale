using CarSaleBackEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.DTOs.Photos
{
    public class PhotoForCreationDto
    {
        public IFormFile File { get; set; }
        public int CarId { get; set; }
    }
}
