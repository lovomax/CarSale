using CarSale.Models;
using CarSaleBackEnd.DTOs.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.Services.ImageService
{
    public interface IImageService
    {
        Task<ServiceResponse<PhotoForReturnDto>> AddImage(PhotoForCreationDto request);
        Task<ServiceResponse<string>> DeleteImage(PhotoForDeletionDto request);
        Task<ServiceResponse<PhotoForReturnDto>> UpdateImage(PhotoForUpdateDto request);
        Task<ServiceResponse<PhotoForReturnDto>> GetImage(int request);
    }
}
