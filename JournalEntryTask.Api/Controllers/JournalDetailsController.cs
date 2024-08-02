using JournalEntryTask.Api.Common.Dto;
using JournalEntryTask.Application.JournalDetails.Commands.CreateJournalDetails;
using JournalEntryTask.Application.JournalDetails.Commands.DeleteJournalDetails;
using JournalEntryTask.Application.JournalDetails.Commands.UpdateJournalDetails;
using JournalEntryTask.Application.JournalDetails.Queries.GetJournalDetailsById;
using JournalEntryTask.Application.JournalDetails.Queries.ListJournalDetails;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JournalEntryTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalDetailsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public JournalDetailsController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("{journalHeaderId}")]
        public async Task<IActionResult> GetAll(Guid journalHeaderId)
        {
            var journalDetails = await _mediator.Send(new ListJournalDetailsQuery(journalHeaderId));
            return journalDetails.Match(
                journalDetails => Ok(_mapper.Map<List<JournalDetailsResponse>>(journalDetails)),
                errors => Problem(errors));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var journalDetail = await _mediator.Send(new GetJournalDetailsByIdQuery(id));
            return journalDetail.Match(
                journalDetail => Ok(_mapper.Map<JournalDetailsResponse>(journalDetail)),
                errors => Problem(errors));
        }

        [HttpPost]
        public async Task<IActionResult> CreateJournalDetails(CreateJournalDetailsCommand command)
        {
            var createdJournalDetails = await _mediator.Send(command);
            return createdJournalDetails.Match(
                createdJournalDetails => Ok(_mapper.Map<JournalDetailsResponse>(createdJournalDetails)),
                errors => Problem(errors));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateJournalDetails(UpdateJournalDetailsCommand command)
        {
            var updatedJournalDetails = await _mediator.Send(command);
            return updatedJournalDetails.Match(
                updatedJournalDetails => Ok(_mapper.Map<JournalDetailsResponse>(updatedJournalDetails)),
                errors => Problem(errors));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJournalHeader(Guid id)
        {
            var deletedJournalDetails = await _mediator.Send(new DeleteJournalDetailsCommand(id));
            return deletedJournalDetails.Match(
                deletedJournalDetails => Ok(deletedJournalDetails),
                errors => Problem(errors));
        }
    }
}
