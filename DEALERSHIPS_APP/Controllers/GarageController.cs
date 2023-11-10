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
		public async Task Create([FromBody] CreateGarageDTO dto)
		{
			var garage = _mapper.Map<Garage>(dto);

			await _service.Create(garage);
		}

		[HttpGet("{id:int}")]
		public async Task<GarageDTO> Get([FromRoute] int id)
		{
			var garage = await _service.GetById(id);

			return _mapper.Map<GarageDTO>(garage);
		}

		[HttpGet("{id:int}/appointments")]
		public async Task<List<AppointmentDTO>> GetAppointments([FromRoute] int id)
		{
			var appointments = await _service.GetAppointments(id);

			return _mapper.Map<List<AppointmentDTO>>(appointments);
		}

		[HttpGet("{id:int}/appointments/{ownerId:int}")]
		public async Task<List<AppointmentDTO>> GetAppointmentsByOwnerId([FromRoute] int id, [FromRoute] int ownerId)
		{
			var appointments = await _service.GetAppointmentsByOwnerId(id, ownerId);

			return _mapper.Map<List<AppointmentDTO>>(appointments);
		}

		[HttpGet("{id:int}/appointments/{appoinmentId:int}")]
		public async Task<AppointmentDTO> GetAppointmentByAppointmentId([FromRoute] int id, [FromRoute] int appointmentId)
		{
			var appointment = await _service.GetAppointmentByAppointmentId(id, appointmentId);
			return _mapper.Map<AppointmentDTO>(appointment);
		}
	}
}
