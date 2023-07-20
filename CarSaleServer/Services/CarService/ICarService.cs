using CarSale.Models;
using CarSaleBackEnd.DTOs.Cars;
using CarSaleBackEnd.DTOs.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.Services.CarService
{
    public interface ICarService
    {
        public Task<ServiceResponse<List<GetAllCarDto>>> GetAllCars();
        public Task<ServiceResponse<GetCarDto>> GetCar(int request);
        public Task<ServiceResponse<GetCarDto>> AddCar(AddCarDto request);
        public Task<ServiceResponse<string>> DeleteCar(int request);
        public Task<ServiceResponse<GetCarDto>> UpdateCar(UpdateCarDto request);
    }
}
