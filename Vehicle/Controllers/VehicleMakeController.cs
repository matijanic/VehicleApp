using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Service.Common;
using Project.WebAPI.Resources;
using Project.WebAPI.Validation;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Project.WebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {

        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IMapper _mapper;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {

            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
        }

        [HttpGet("VehicleMakes")]
        public async Task<ActionResult<List<VehicleMakeResources>>> GetAllVMakesAsync()
        {

            try
            {
                var listAll = await _vehicleMakeService.GetAllVMakes();

                if (listAll.Count == 0)
                {
                    NotFound();
                }

                var dataResources = _mapper.Map<List<VehicleMakeResources>>(listAll);
                return Ok(dataResources);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("VehicleMake/{id}")]

        public async Task<ActionResult<VehicleMakeResources>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _vehicleMakeService.GetVMakeById(id);
                if (entity == null)
                {
                    return NotFound();
                }
                var entityResource = _mapper.Map<VehicleMakeResources>(entity);
                return Ok(entityResource);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteVehicleMake/{id}")]

        public async Task<ActionResult> DeleteVehicleMakeAsync(int id)
        {

            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid ID");
                }

               var isTrue = await _vehicleMakeService.DeleteVMake(id);

               if(!isTrue)
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

        [HttpPost("AddVehicleMake")]
        [ValidateModel]

        public async Task<ActionResult> CreateVehicleMakeAsync([FromBody] ChangeVehicleMakeResource input)
        {
            try
            {
                var vehicleMake = _mapper.Map<VehicleMakeModel>(input);
                await _vehicleMakeService.CreateVMake(vehicleMake);
                return Ok();


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut("UpdateVehicleMake")]
        [ValidateModel]

        public async Task<ActionResult> UpdateVehicleMake(int id, [FromBody] ChangeVehicleMakeResource entity)
        {

            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid ID");
                }
                var newEntity = _mapper.Map<VehicleMakeModel>(entity);
                await _vehicleMakeService.UpdateVMake(id, newEntity);

               return NoContent();
                

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpGet("AllVehicleMakesWithModels")]
        public async Task<ActionResult<List<VehicleMakeWithModelsResources>>> GetAllVMakesWithModelsAsync()
        {

            try
            {

                var listAllDomainModel = await _vehicleMakeService.GetAllWithModels();
                

                var dataResource = _mapper.Map<List<VehicleMakeWithModelsResources>>(listAllDomainModel); 
                return Ok(dataResource);
                
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetFilterByName")]

        public async Task<ActionResult<List<VehicleMakeWithModelsResources>>> GetFilterByName([FromQuery] string? Name = null)
        {
            try
            {
                var list = await _vehicleMakeService.GetFilterByName(Name);

                if(list.Count == 0)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<VehicleMakeWithModelsResources>>(list));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           

        }

        [HttpGet("GetSortByName")]

        public async Task <ActionResult<List<VehicleMakeResources>>> GetSortByName([FromQuery] string? Name = null, [FromQuery] bool isAscending = true)
        {

            try
            {
                var list = await _vehicleMakeService.GetSortByName(Name, isAscending);

                if(list.Count == 0)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<VehicleMakeResources>>(list));
                

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("PagingVehicleMake")]

        public async Task<ActionResult<List<VehicleMakeResources>>> PagingVehiclaMakes([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {

            try
            {
                var list = await _vehicleMakeService.PagingVehicleMakes(pageNumber, pageSize);

                if(list.Count == 0)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<VehicleMakeResources>>(list));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


    }
}
