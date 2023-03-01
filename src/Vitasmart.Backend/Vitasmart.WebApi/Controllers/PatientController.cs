using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vitasmart.Application.Patients.Queries.GetPatientDetails;
using Vitasmart.Application.Patients.Queries.GetPatientList;
using Vitasmart.Application.Patients.Commands.CreatePatient;
using Vitasmart.WebApi.Models;
using AutoMapper;
using Vitasmart.Application.Patients.Commands.UpdatePatient;

namespace Vitasmart.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : BaseController
    {
        private readonly IMapper _mapper;
        public PatientController(IMapper mapper) => _mapper = mapper;
        
        [HttpGet]
        public async Task<ActionResult<PatientListVm>> GetAll()
        {
            var query = new GetPatientListQuery(){ };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PatientDetailsVm>> Get(Guid id)
        {
            var query = new GetPatientDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePatientDto createPatientDto)
        {
            var command = _mapper.Map<CreatePatientCommand>(createPatientDto);
            var patientId = await Mediator.Send(command);
            return Ok(patientId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePatientDto updatePatientDto)
        {
            var command = _mapper.Map<UpdatePatientCommand>(updatePatientDto);
            await Mediator.Send(command);
            return NoContent();
        }
    }
}