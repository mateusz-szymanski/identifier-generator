namespace IdentifierGenerator.Application
{
    public interface IIdentifierService
    {
        string GenerateCodeFor(string factoryCode, string categoryCode);
    }
}