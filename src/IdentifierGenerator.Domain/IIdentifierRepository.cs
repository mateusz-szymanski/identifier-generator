using IdentifierGenerator.Model.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace IdentifierGenerator.Domain
{
    public interface IIdentifierRepository
    {
        Task<Identifier> GetIdentifierFor(string factoryCode, string categoryCode, CancellationToken cancellationToken);
        void Add(Identifier identifier);
        void Add(IdentifierGenerated identifierGenerated);
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
