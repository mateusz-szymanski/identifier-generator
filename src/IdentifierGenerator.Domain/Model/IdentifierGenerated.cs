using System;

namespace IdentifierGenerator.Model.Domain
{
    public class IdentifierGenerated
    {
        public IdentifierGenerated(Guid identifierGlobalId, string code)
        {
            Code = code;
            GeneratedOn = DateTime.UtcNow;
            IdentifierGlobalId = identifierGlobalId;
        }

        public int Id { get; private set; }
        public Guid IdentifierGlobalId { get; private set; }
        public string Code { get; private set; }
        public DateTime GeneratedOn { get; private set; }
    }
}
