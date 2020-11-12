using IdentifierGenerator.Model.Domain;
using Xunit;

namespace IdentifierGenerator.Domain.UnitTests
{
    public class IdentifierTests
    {
        [Fact]
        public void Identifier_ShouldPropertlyInitializeAndSetCounterToZero_AfterCreation()
        {
            // Arrange
            var factoryCode = "F001";
            var categoryCode = "C001";

            // Act
            var identifier = new Identifier(factoryCode, categoryCode);

            // Assert
            Assert.Equal(0, identifier.Value);
            Assert.Equal(categoryCode, identifier.CategoryCode);
            Assert.Equal(factoryCode, identifier.FactoryCode);
        }

        [Fact]
        public void Identifier_ShouldIncrementValueAndReturnProperCode_AfterIncrementValueCalled()
        {
            // Arrange
            var factoryCode = "F001";
            var categoryCode = "C001";
            var identifier = new Identifier(factoryCode, categoryCode);

            // Act
            var identifierGenerated = identifier.IncrementValue();

            // Assert
            Assert.Equal(1, identifier.Value);

            Assert.Equal("C001-F001-1", identifierGenerated.Code);
            Assert.Equal(identifier.GlobalId, identifier.GlobalId);
        }
    }
}
