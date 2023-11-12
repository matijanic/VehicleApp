using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Model;
using Project.Service;
using Project.Service.Common;
using Project.WebAPI.Resources;
using Project.WebAPI.Validation;
using System.Globalization;

namespace Project.WebAPI.Controllers
{
    [Route("/api")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {


        private readonly IVehicleModelService _vehicleModelService;
        private readonly IMapper _mapper;

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            this._vehicleModelService = vehicleModelService;
            this._mapper = mapper;

        }

        [HttpGet("VehicleModels")]
        
        public async Task <ActionResult<List<VehicleModelResources>>> GetAllVModelsAsync()
        {
            try
            {
                var listAll=await  _vehicleModelService.GetAllVModels();

                if (listAll.Count == 0)
                {
                    return NotFound();
                }

               var newList =  _mapper.Map<List<VehicleModelResources>>(listAll);
                
                return Ok(newList);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("VehicleModel/{id}")]

        public async Task<ActionResult<VehicleModelResources>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _vehicleModelService.GetVModelById(id);

                if (entity == null)
                {
                    return NotFound();
                }

                var entityResource = _mapper.Map<VehicleModelResources>(entity);

                return Ok(entityResource);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("AddVehicleModel")]
        [ValidateModel]

        public async Task<ActionResult>CreateVehicleModel([FromBody] CreateVehicleModelResource input)
        {
            try
            {
                var entity = _mapper.Map<VehicleModelModel>(input);
                await _vehicleModelService.CreateVModel(entity);
                return Ok();

            }
            catch (Exception ex)
          
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpDelete("DeleteVehicleModel/{id}")]

        public async Task <ActionResult> DeleteVehicleModel(int id) 
        
        {

            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid ID");
                }

                var isTrue = await _vehicleModelService.DeleteVModel(id);

                if (!isTrue)
                {
                    return NotFound();
                }

                return NoContent();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateVehicleModel")]
        [ValidateModel]

        public async Task<ActionResult> UpdateVehicleModel(int id, [FromBody] UpdateVehicleModelResource input)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid ID");
                }

                var newEntity = _mapper.Map<VehicleModelModel>(input);
                await _vehicleModelService.UpdateVModel(id, newEntity);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //GetAllModelWithVehicleMale by id

        [HttpGet("GetVehicleModelWithVehicleMake/{id}")]

        public async Task<IActionResult> GetVehicleModelWithVehicleMakeById(int id)
        {

            try
            {
                var entity = await _vehicleModelService.GetVModelWithVMakeById(id);

                if (entity == null)
                {
                    return NotFound();
                }


                return Ok(_mapper.Map<VehicleModelWithVehicleMakeResource>(entity));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

           

        }

        [HttpGet("GetFilterByName")]

        public async Task <ActionResult<List<VehicleModelWithVehicleMakeResource>>> GetFilterByName([FromQuery] string? Name = null)
        {

            try
            {
                var list = await _vehicleModelService.GetFilterByName(Name);

                if (list == null)
                {
                    return NotFound();

                }

                return Ok(_mapper.Map<List<VehicleModelWithVehicleMakeResource>>(list));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

            
            

        }
        [HttpGet("GetSortByName")]

        public async Task<ActionResult<List<VehicleModelResources>>> GetSortByName (string? Name = null, bool isAscending = true)
        {
            try
            {
                var list = await _vehicleModelService.GetSortByName(Name,isAscending);

                if(list.Count == 0)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<VehicleModelResources>>(list));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("PagingVehicleMake")]

        public async Task<ActionResult<List<VehicleMakeResources>>> PagingVehiclaModels([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {

            try
            {
                var list = await _vehicleModelService.PagingVehicleModels(pageNumber, pageSize);

                if (list.Count == 0)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<VehicleModelResources>>(list));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
