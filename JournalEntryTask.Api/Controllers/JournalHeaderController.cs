using JournalEntryTask.Api.Common.Dto;
using JournalEntryTask.Application.JournalHeaders.Commands.CreateJournalHeader;
using JournalEntryTask.Application.JournalHeaders.Commands.DeleteJournalHeader;
using JournalEntryTask.Application.JournalHeaders.Commands.UpdateJournalHeader;
using JournalEntryTask.Application.JournalHeaders.Queries.GetJournalHeaderById;
using JournalEntryTask.Application.JournalHeaders.Queries.ListJournalHeaders;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JournalEntryTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalHeaderController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public JournalHeaderController(IMapper mapper , ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var journals = await _mediator.Send(new ListJournalHeadersQuery());
            return journals.Match(
                journals => Ok(_mapper.Map<List<JournalHeaderResponse>>(journals)),
                errors => Problem(errors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var journal = await _mediator.Send(new GetJournalHeaderByIdQuery(id));
            return journal.Match(
                journal => Ok(_mapper.Map<JournalHeaderResponse>(journal)),
                errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> CreateJournalHeader(CreateJournalHeaderCommand command)
        {
            var createdJournalHeader = await _mediator.Send(command);
            return createdJournalHeader.Match(
                createdJournalHeader => Ok(_mapper.Map<JournalHeaderResponse>(createdJournalHeader)),
                errors => Problem(errors));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateJournalHeader(UpdateJournalHeaderCommand command)
        {
            var updatedJournalHeader = await _mediator.Send(command);
            return updatedJournalHeader.Match(
                updatedJournalHeader => Ok(_mapper.Map<JournalHeaderResponse>(updatedJournalHeader)),
                errors => Problem(errors)); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJournalHeader(Guid id)
        {
            var deletedJournalHeader = await _mediator.Send(new DeleteJournalHeaderCommand(id));
            return deletedJournalHeader.Match(
                deletedJournalHeader => Ok(deletedJournalHeader),
                errors => Problem(errors)); 
        }
    }
}
