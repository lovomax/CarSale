using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string PublicId { get; set; }
        public string PhotoURL { get; set; } = string.Empty;
        [Timestamp]
        public byte[] TimeStamp { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
    }
}
