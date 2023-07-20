using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.DTOs.Photos
{
    public class PhotoForUpdateDto
    {
        public IFormFile File { get; set; }
        public string PublicId { get; set; }
    }
}
