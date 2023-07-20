using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarSaleBackEnd.DTOs.Cars;
using CarSaleBackEnd.DTOs.Makes;
using CarSaleBackEnd.DTOs.Photos;
using CarSaleBackEnd.Models;

namespace CarSaleBackEnd
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<Photo, GetBasicPhotoDto>();
            CreateMap<Car, GetAllCarDto>();
            CreateMap<Car, GetCarDto>();
            CreateMap<AddCarDto, Car>();
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<DateTime?, DateTime>().ConvertUsing(((src, dest) => src ?? dest));
            CreateMap<UpdateCarDto, Car>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdateCarDto, GetCarDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
            CreateMap<Make, GetMakeDto>();
        }
    }
}
