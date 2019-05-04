using IdentifierGenerator.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
