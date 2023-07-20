using AutoMapper;
using CarSale.Models;
using CarSaleBackEnd.Data;
using CarSaleBackEnd.DTOs.Cars;
using CarSaleBackEnd.DTOs.Photos;
using CarSaleBackEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPhotoRepository _photoRepository;

        public CarService(DataContext context, IMapper mapper, IPhotoRepository photoRepository)
        {
            _context = context;
            _mapper = mapper;
            _photoRepository = photoRepository;
        }

        public async Task<ServiceResponse<List<GetAllCarDto>>> GetAllCars()
        {
            ServiceResponse<List<GetAllCarDto>> response = new ServiceResponse<List<GetAllCarDto>>();

            try
            {
                var dbCars = await _context.Cars.Include(c => c.Photo).Include(c => c.Make).OrderBy(c => c.Price).ToListAsync();

                response.Data = dbCars.Select(c => _mapper.Map<GetAllCarDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<ServiceResponse<GetCarDto>> GetCar(int request)
        {
            ServiceResponse<GetCarDto> response = new ServiceResponse<GetCarDto>();

            try
            {
                var dbCar = await _context.Cars.Include(c => c.Photo).Include(c => c.Make).FirstAsync(c => c.Id == request);

                response.Data = _mapper.Map<GetCarDto>(dbCar);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<ServiceResponse<GetCarDto>> AddCar(AddCarDto request)
        {
            ServiceResponse<GetCarDto> response = new ServiceResponse<GetCarDto>();

            try
            {
                Car car = _mapper.Map<Car>(request);

                await _context.Cars.AddAsync(car);

                await _context.SaveChangesAsync();

                car.Make = await _context.Makes.FirstOrDefaultAsync(m => m.Id == car.MakeId);

                response.Data = _mapper.Map<GetCarDto>(car);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<ServiceResponse<string>> DeleteCar(int request)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            try
            {
                Car car = await _context.Cars.Include(c => c.Photo).FirstOrDefaultAsync(c => c.Id == request);

                if(car.Photo != null)
                {
                    await _photoRepository.DeletePhoto(new PhotoForDeletionDto { PublicId = car.Photo.PublicId });
                }


                _context.Cars.Remove(car);

                await _context.SaveChangesAsync();

                response.Data = "Your car has been deleted";
                response.Message = "Operation Complete";
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<ServiceResponse<GetCarDto>> UpdateCar(UpdateCarDto request)
        {
            ServiceResponse<GetCarDto> response = new ServiceResponse<GetCarDto>();

            try
            {
                Car car = await _context.Cars.Include(c => c.Photo).Include(c => c.Make).FirstOrDefaultAsync(c => c.Id == request.Id);
                _mapper.Map(request, car);
                response.Data = _mapper.Map<GetCarDto>(request);

                await _context.SaveChangesAsync();

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
