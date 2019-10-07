using IdentifierGenerator.Model.Domain;
using System;
using Xunit;

namespace IdentifierGenerator.Domain.UnitTests
{
    public class IdentifierTests
    {
        [Fact]
        public void IdentifierShouldPropertlyInitializeAndSetCounterToZero()
        {
            var factoryCode = "F001";
            var categoryCode = "C001";

            var identifier = new Identifier(factoryCode, categoryCode);

            Assert.Equal(0, identifier.Value);
            Assert.Equal(categoryCode, identifier.CategoryCode);
            Assert.Equal(factoryCode, identifier.FactoryCode);
        }

        [Fact]
        public void IdentifierShouldIncrementValueAndReturnProperCodeAfterMoveToNextValueCalled()
        {
            var factoryCode = "F001";
            var categoryCode = "C001";
            var identifier = new Identifier(factoryCode, categoryCode);

            var identifierGenerated = identifier.MoveToNextValue();

            Assert.Equal(1, identifier.Value);

            Assert.Equal("C001-F001-1", identifierGenerated.Code);
            Assert.Equal(identifier.GlobalId, identifier.GlobalId);
        }
    }
}
