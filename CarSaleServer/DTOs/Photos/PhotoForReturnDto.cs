using CarSaleBackEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.DTOs.Photos
{
    public class PhotoForReturnDto
    {
        public string PhotoURL { get; set; } = string.Empty;
        public string PublicId { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
