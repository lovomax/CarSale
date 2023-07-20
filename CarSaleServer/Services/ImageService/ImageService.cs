using AutoMapper;
using CarSale.Models;
using CarSaleBackEnd.Data;
using CarSaleBackEnd.DTOs.Photos;
using CarSaleBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.Services.ImageService
{
    public class ImageService : IImageService
    {
        private readonly IPhotoRepository _photoService;
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ImageService(IPhotoRepository photoService, DataContext context, IMapper mapper)
        {
            _context = context;
            _photoService = photoService;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<PhotoForReturnDto>> AddImage(PhotoForCreationDto photoDto)
        {
            ServiceResponse<PhotoForReturnDto> response = new ServiceResponse<PhotoForReturnDto>();
            try
            {

                var photoExists = await _context.Photos.FirstOrDefaultAsync(p => p.CarId == photoDto.CarId);
                var carExists = await _context.Cars.FirstOrDefaultAsync(c => c.Id == photoDto.CarId);

                if(carExists == null)
                {
                    response.Message = "Car doesn't exists!";
                    response.Success = false;
                    return response;
                }
                else if (photoExists != null)
                {
                    response.Message = "Car already has a photo!";
                    response.Success = false;
                    return response;
                }

                var photoResult = await _photoService.AddPhoto(photoDto);

                Photo photo = new Photo
                {
                    PublicId = photoResult.PublicId,
                    PhotoURL = photoResult.PhotoURL,
                    CarId = photoDto.CarId
                };


                _context.Photos.Add(photo);

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<PhotoForReturnDto>(photo);
            } 
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }

            return response;
        }
        public async Task<ServiceResponse<string>> DeleteImage(PhotoForDeletionDto photoDto)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            try
            {
                var result = await _photoService.DeletePhoto(photoDto);
                Photo photo = await _context.Photos.FirstAsync(p => p.PublicId == photoDto.PublicId);

                _context.Photos.Remove(photo);

                await _context.SaveChangesAsync();


                response.Data = result;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<ServiceResponse<PhotoForReturnDto>> GetImage(int request)
        {
            ServiceResponse<PhotoForReturnDto> response = new ServiceResponse<PhotoForReturnDto>();

            try
            {
                var result = await _context.Photos.FirstOrDefaultAsync(p => p.CarId == request);

                if(result == null)
                {
                    response.Message = "This car doesn't have a photo!";
                    response.Success = false;
                }

                response.Data = _mapper.Map<PhotoForReturnDto>(result);

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<ServiceResponse<PhotoForReturnDto>> UpdateImage(PhotoForUpdateDto request)
        {
            ServiceResponse<PhotoForReturnDto> response = new ServiceResponse<PhotoForReturnDto>();

            try
            {
                Photo photo = await _context.Photos.FirstAsync(p => p.PublicId == request.PublicId);
                var photoResult = await _photoService.UpdatePhoto(request);

                photo.PhotoURL = photoResult.PhotoURL;

                await _context.SaveChangesAsync();
                response.Data = photoResult;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
