namespace IdentifierGenerator.Application.Commands
{
    public class GenerateCodeCommandResponse
    {
        public string GeneratedCode { get; private set; }

        public GenerateCodeCommandResponse(string generatedCode)
        {
            GeneratedCode = generatedCode;
        }
    }
}
