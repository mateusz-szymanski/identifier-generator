using MediatR;

namespace IdentifierGenerator.Application.Commands
{
    public class GenerateCodeCommand : IRequest<GenerateCodeCommandResponse>
    {
        public string FactoryCode { get; private set; }
        public string CategoryCode { get; private set; }

        public GenerateCodeCommand(string factoryCode, string categoryCode)
        {
            FactoryCode = factoryCode;
            CategoryCode = categoryCode;
        }
    }
}
