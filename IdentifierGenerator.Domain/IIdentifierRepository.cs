using IdentifierGenerator.Model.Domain;

namespace IdentifierGenerator.Domain
{
    public interface IIdentifierRepository
    {
        Identifier GetIdentifierFor(string factoryCode, string categoryCode);
        void Add(Identifier identifier);
        void Add(IdentifierGenerated identifierGenerated);
        void SaveChanges();
    }
}
