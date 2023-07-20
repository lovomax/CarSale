using CarSale.Models;
using CarSaleBackEnd.DTOs.Photos;
using CarSaleBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.Data
{
    public interface IPhotoRepository
    {
        Task<PhotoForReturnDto> AddPhoto(PhotoForCreationDto request);
        Task<string> DeletePhoto(PhotoForDeletionDto request);
        Task<PhotoForReturnDto> UpdatePhoto(PhotoForUpdateDto request);
    }
}
