using Microsoft.AspNetCore.Mvc;
using Vitasmart.WebApi.Models;
using AutoMapper;
using Vitasmart.Application.Visitings.Queries.GetVisitingList;
using Vitasmart.Application.Visitings.Queries.GetVisitingDetails;
using Vitasmart.Application.Visitings.Commands.CreateVisiting;
using Vitasmart.Application.Patients.Commands.UpdatePatient;
using Vitasmart.Application.Visitings.Commands.DeleteVisiting;

namespace Vitasmart.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class VisitingController : BaseController
    {
        private readonly IMapper _mapper;
        public VisitingController(IMapper mapper) => _mapper = mapper;

        [HttpGet("{PatientId}")]
        public async Task<ActionResult<VisitingListVm>> GetAll(Guid patientId)
        {
            var query = new GetVisitingListQuery()
            {
                PatientId = patientId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<VisitingDetailsVm>> Get(Guid id)
        {
            var query = new GetVisitingDetailsQuery()
            {
                Id = id,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateVisitingDto createVisitingDto)
        {
            var command = _mapper.Map<CreateVisitingCommand>(createVisitingDto);
            var patientId = await Mediator.Send(command);
            return Ok(patientId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateVisitingDto updateVisitingDtos)
        {
            var command = _mapper.Map<UpdatePatientCommand>(updateVisitingDtos);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteVisitingCommand
            {
                Id = id,
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}