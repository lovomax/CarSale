using CarSale.Models;
using CarSaleBackEnd.DTOs.Photos;
using CarSaleBackEnd.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.Data
{
    public class PhotoRepository : IPhotoRepository
    {
        public readonly IConfiguration Config;
        private readonly CloudinarySettings _cloudinarySettings;
        private Cloudinary _cloudinary;


        public PhotoRepository(IConfiguration config)
        {
            Config = config;
            _cloudinarySettings = Config.GetSection("CloudinarySettings").Get<CloudinarySettings>();
            Account account = new Account(_cloudinarySettings.CloudName, _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<PhotoForReturnDto> AddPhoto(PhotoForCreationDto photo)
        {
            var file = photo.File;

            var uploadResult = new ImageUploadResult();

            if(file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }
            }

            var newPhoto = new PhotoForReturnDto
            {
                PhotoURL = uploadResult.Url.ToString(),
                PublicId = uploadResult.PublicId,
            };

            return newPhoto;
        }

        public async Task<string> DeletePhoto(PhotoForDeletionDto photo)
        {
            var result = await _cloudinary.DestroyAsync(new DeletionParams(photo.PublicId));
            return result.Result;
        }

        public async Task<PhotoForReturnDto> UpdatePhoto(PhotoForUpdateDto request)
        {
            var file = request.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        PublicId = request.PublicId
                    };

                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }
            }

            var result = new PhotoForReturnDto
            {
                PhotoURL = uploadResult.Url.ToString(),
                PublicId = uploadResult.PublicId,
            };

            return result;
        }
    }
}
