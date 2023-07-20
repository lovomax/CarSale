using CarSale.Models;
using CarSaleBackEnd.DTOs.Cars;
using CarSaleBackEnd.DTOs.Photos;
using CarSaleBackEnd.Services.CarService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSaleBackEnd.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _service;

        public CarController(ICarService service)
        {
            _service = service;
        }


        [HttpGet("getallcars")]
        public async Task<ActionResult<ServiceResponse<List<GetAllCarDto>>>> GetAllCars()
        {
            ServiceResponse<List<GetAllCarDto>> response;

            response = await _service.GetAllCars();

            return Ok(response);
        }

        [HttpGet("getcar/{request}")]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> GetCar([Required] int request)
        {
            ServiceResponse<GetCarDto> response;

            response = await _service.GetCar(request);

            if(response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpDelete("deletecar/{request}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteCar([Required] int request)
        {
            ServiceResponse<string> response;

            response = await _service.DeleteCar(request);

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPut("updatecar")]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> UpdateCar(UpdateCarDto request)
        {
            ServiceResponse<GetCarDto> response;

            response = await _service.UpdateCar(request);

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPost("addcar")]
        public async Task<ActionResult<ServiceResponse<GetCarDto>>> AddCar([Required] AddCarDto request)
        {
            ServiceResponse<GetCarDto> response;

            response = await _service.AddCar(request);

            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
