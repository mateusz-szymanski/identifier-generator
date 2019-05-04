using System;

namespace IdentifierGenerator.Model.Domain
{
    public class Identifier
    {
        protected Identifier() { }

        public Identifier(string factoryCode, string categoryCode)
        {
            if (string.IsNullOrWhiteSpace(factoryCode))
                throw new ArgumentException("factoryCode must be specified", nameof(factoryCode));

            if (string.IsNullOrWhiteSpace(categoryCode))
                throw new ArgumentException("categoryCode must be specified", nameof(categoryCode));

            GlobalId = Guid.NewGuid();
            FactoryCode = factoryCode;
            CategoryCode = categoryCode;
            Value = 0;
        }

        public int Id { get; private set; }
        public Guid GlobalId { get; private set; }
        public int Value { get; private set; }
        public string FactoryCode { get; private set; }
        public string CategoryCode { get; private set; }

        public IdentifierGenerated MoveToNextValue()
        {
            ++Value;
            return new IdentifierGenerated(GlobalId, GetValueCode());
        }

        private string GetValueCode()
        {
            return $"{CategoryCode}-{FactoryCode}-{Value}";
        }
    }
}
