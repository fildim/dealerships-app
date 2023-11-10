using AutoMapper;
using DEALERSHIPS_APP.DTOS.Appointment;
using DEALERSHIPS_APP.DTOS.Garage;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Services;
using Microsoft.AspNetCore.Mvc;

namespace DEALERSHIPS_APP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GarageController : ControllerBase
    {
        private readonly IGarageService _service;
        private readonly IMapper _mapper;

        public GarageController(IGarageService garageService, IMapper mapper)
        {
            _service = garageService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task Create([FromBody]CreateGarageDTO dto)
        {
            var garage = _mapper.Map<Garage>(dto);

            await _service.Create(garage);
        }

        [HttpGet("{id:int}")]
        public async Task<ReadOnlyGarageDTO> Get([FromRoute]int id)
        {
            var garage = await _service.GetById(id);
            return _mapper.Map<ReadOnlyGarageDTO>(garage);
        }

        [HttpGet("{garageId:int}/[action]")]
        public async Task<List<ReadOnlyAppointmentDTO>> GetAppointmentsByGarageId([FromRoute] int garageId)
        {
            var listOfAppointments = await _service.GetAllAppointmentsByGarageId(garageId);
            return _mapper.Map<List<ReadOnlyAppointmentDTO>>(listOfAppointments);
        }

        [HttpGet("{garageId:int}/[action]/{ownerId:int}")]
        public async Task<List<ReadOnlyAppointmentDTO>> GetAppointmentsByGarageIdForOwnerId([FromRoute] int garageId, [FromRoute] int ownerId)
        {
            var listOfAppointments = await _service.GetAllAppoinmentsByOwnerId(garageId, ownerId);
            return _mapper.Map<List<ReadOnlyAppointmentDTO>>(listOfAppointments);
        }


        [HttpGet("{garageId:int}/[action]/{appoinmentId:int}")]
        public async Task<ReadOnlyAppointmentDTO> GetAppointmentById([FromRoute] int garageId, [FromRoute] int appointmentId)
        {
            var appointment = await _service.GetAppointmentById(garageId, appointmentId);
            return _mapper.Map<ReadOnlyAppointmentDTO>(appointment);
        }


    }
}
