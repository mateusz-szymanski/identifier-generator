using IdentifierGenerator.Application.Commands;
using IdentifierGenerator.Application.Queries.AllIdentifiers;
using IdentifierGenerator.Application.Queries.IdentifiersForFactoryAndCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentifierGenerator.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentifierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentifierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{factoryCode}/{categoryCode}")]
        public async Task<IEnumerable<IdentifiersForFactoryAndCategoryReadModel>> Get(string factoryCode, string categoryCode)
        {
            var identifiersForFactoryAndCategoryQuery = new IdentifiersForFactoryAndCategoryQuery(factoryCode, categoryCode);
            var identifiersForFactoryAndCategoryQueryResponse = await _mediator.Send(identifiersForFactoryAndCategoryQuery);

            return identifiersForFactoryAndCategoryQueryResponse.Identifiers;
        }

        [HttpGet]
        public async Task<IEnumerable<IdentifierReadModel>> Get()
        {
            var allIdentifiersQuery = new AllIdentifiersQuery();
            var allIdentifiersQueryResponse = await _mediator.Send(allIdentifiersQuery);

            return allIdentifiersQueryResponse.Identifiers;
        }

        [HttpPost("{factoryCode}/{categoryCode}")]
        public async Task<string> Post(string factoryCode, string categoryCode)
        {
            var generateCodeCommand = new GenerateCodeCommand(factoryCode, categoryCode);
            var generateCodeCommandResponse = await _mediator.Send(generateCodeCommand);

            return generateCodeCommandResponse.GeneratedCode;
        }
    }
}