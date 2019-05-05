using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentifierGenerator.Application;
using IdentifierGenerator.Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;

namespace IdentifierGenerator.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentifierController : ControllerBase
    {
        private readonly IIdentifierService _identifierService;
        private readonly FactoryCategoryGeneratedIdentifiersQuery _factoryCategoryGeneratedIdentifiersQuery;
        private readonly AllIdentifierQuery _allIdentifierQuery;

        public IdentifierController(IIdentifierService identifierService,
            FactoryCategoryGeneratedIdentifiersQuery factoryCategoryGeneratedIdentifiersQuery,
            AllIdentifierQuery allIdentifierQuery)
        {
            _identifierService = identifierService;
            _factoryCategoryGeneratedIdentifiersQuery = factoryCategoryGeneratedIdentifiersQuery;
            _allIdentifierQuery = allIdentifierQuery;
        }

        [HttpGet("{factoryCode}/{categoryCode}")]
        public dynamic Get(string factoryCode, string categoryCode)
        {
            return _factoryCategoryGeneratedIdentifiersQuery.Get(factoryCode, categoryCode);
        }

        [HttpGet]
        public dynamic Get()
        {
            return _allIdentifierQuery.Get();
        }

        [HttpPost("{factoryCode}/{categoryCode}")]
        public string Post(string factoryCode, string categoryCode)
        {
            var code = _identifierService.GenerateCodeFor(factoryCode, categoryCode);
            return code;
        }
    }
}