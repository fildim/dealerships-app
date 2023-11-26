using AutoMapper;
using DEALERSHIPS_APP.DTOS.Appointment;
using DEALERSHIPS_APP.DTOS.Garage;
using DEALERSHIPS_APP.DTOS.Owner;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEALERSHIPS_APP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GarageController : ControllerBase
    {
        private readonly IGarageService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateGarageDTO> _validator;
        private readonly IValidator<LoginGarageDTO> _loginValidator;

        public GarageController(IGarageService garageService, IMapper mapper, IValidator<CreateGarageDTO> validator, IValidator<LoginGarageDTO> loginValidator)
        {
            _service = garageService;
            _mapper = mapper;
            _validator = validator;
            _loginValidator = loginValidator;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<string> Login([FromBody] LoginGarageDTO login)
        {
            await _loginValidator.ValidateAndThrowAsync(login);
            return await _service.Login(login.Phone, login.Password);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task Create([FromBody] CreateGarageDTO dto)
        {
            await _validator.ValidateAndThrowAsync(dto);
            var garage = _mapper.Map<Garage>(dto);
            await _service.Create(garage, dto.Password);
        }

        [HttpGet("{id:int}")]
        public async Task<ReadOnlyGarageDTO> Get([FromRoute] int id)
        {
            var garage = await _service.GetById(id);

            return _mapper.Map<ReadOnlyGarageDTO>(garage);
        }

        [HttpGet("{id:int}/[action]")]
        public async Task<List<ReadOnlyAppointmentDTO>> GetAppointments([FromRoute] int id)
        {
            var listOfAppointments = await _service.GetAppointments(id);

            return _mapper.Map<List<ReadOnlyAppointmentDTO>>(listOfAppointments);
        }



        [HttpGet("{id:int}/[action]/{appointmentId:int}")]
        public async Task<ReadOnlyAppointmentDTO> GetAppointmentById([FromRoute] int id, [FromRoute] int appointmentId)
        {
            var appointment = await _service.GetAppointmentByAppointmentId(id, appointmentId);
            return _mapper.Map<ReadOnlyAppointmentDTO>(appointment);
        }


        [HttpGet("{id:int}/[action]/{ownerId:int}")]
        public async Task<List<ReadOnlyAppointmentDTO>> GetAppointmentsForOwnerId([FromRoute] int id, [FromRoute] int ownerId)
        {
            var listOfAppointments = await _service.GetAllAppoinmentsByOwnerId(id, ownerId);

            return _mapper.Map<List<ReadOnlyAppointmentDTO>>(listOfAppointments);
        }

        [HttpGet("[action]")]
        public async Task<List<ReadOnlyGarageDTO>> GetAll()
        {
            var listOfGarages = await _service.GetAll();

            return _mapper.Map<List<ReadOnlyGarageDTO>>(listOfGarages);
        }

        [HttpPut("[action]")]
        public async Task UpdateAppointment([FromBody]ReadOnlyAppointmentDTO appointment)
        {
            var appointmentToUpdate = _mapper.Map<Appointment>(appointment);

            await _service.UpdateAppointment(appointmentToUpdate);
        }

    }
}
