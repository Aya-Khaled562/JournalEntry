using JournalEntryTask.Api.Common.Dto;
using JournalEntryTask.Application.AccountCharts.Queries.ListAccountCharts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JournalEntryTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsChartController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public AccountsChartController(IMapper mapper , ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _mediator.Send(new ListAccountChartsQuery());
            return accounts.Match(
                accounts => Ok(_mapper.Map<List<AccountChartResponse>>(accounts)),
                errors => Problem(errors));
        }
    }
}
