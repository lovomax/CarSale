using CarSale.Models;
using CarSaleBackEnd.DTOs.Photos;
using CarSaleBackEnd.Models;
using CarSaleBackEnd.Services.ImageService;
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
    public class ImageController : ControllerBase
    {
        private readonly IImageService _service;

        public ImageController(IImageService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<PhotoForReturnDto>>> AddPhoto([FromForm]PhotoForCreationDto photo)
        {
            ServiceResponse<PhotoForReturnDto> response;

            response = await _service.AddImage(photo);

            if(response.Data == null || response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<ActionResult<ServiceResponse<string>>> DeletePhoto([Required] PhotoForDeletionDto request)
        {
            ServiceResponse<string> response;
            response = await _service.DeleteImage(request);

            if (response.Data == null || response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<PhotoForReturnDto>>> UpdatePhoto([Required] [FromForm] PhotoForUpdateDto request)
        {
            ServiceResponse<PhotoForReturnDto> response;
            response = await _service.UpdateImage(request);

            if (response.Data == null || response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("get/{request}")]
        public async Task<ActionResult<ServiceResponse<PhotoForReturnDto>>> GetPhoto([Required] int request)
        {
            ServiceResponse<PhotoForReturnDto> response;
            response = await _service.GetImage(request);

            if (response.Data == null || response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
