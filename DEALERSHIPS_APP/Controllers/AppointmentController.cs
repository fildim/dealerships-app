using AutoMapper;
using DEALERSHIPS_APP.DTOS.Appointment;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Services;
using Microsoft.AspNetCore.Mvc;

namespace DEALERSHIPS_APP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task Create([FromBody]CreateAppointmentDTO dto)
        {
            var appointment = _mapper.Map<Appointment>(dto);

            await _service.Create(appointment);
        }


        [HttpGet("{id:int}")]
        public async Task<ReadOnlyAppointmentDTO> Get([FromRoute]int id)
        {
            var appointment = await _service.GetById(id);

            return _mapper.Map<ReadOnlyAppointmentDTO>(appointment);
        }



    }
}
