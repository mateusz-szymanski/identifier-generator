using IdentifierGenerator.Model.Domain;
using System.Threading.Tasks;

namespace IdentifierGenerator.Domain
{
    public interface IIdentifierRepository
    {
        Task<Identifier> GetIdentifierFor(string factoryCode, string categoryCode);
        void Add(Identifier identifier);
        void Add(IdentifierGenerated identifierGenerated);
        Task SaveChanges();
    }
}
