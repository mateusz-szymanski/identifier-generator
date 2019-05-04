using IdentifierGenerator.Model.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdentifierGenerator.Domain.Tests
{
    [TestClass]
    public class IdentifierTests
    {
        [TestMethod]
        public void IdentifierShouldPropertlyInitializeAndSetCounterToZero()
        {
            var factoryCode = "F001";
            var categoryCode = "C001";

            var identifier = new Identifier(factoryCode, categoryCode);

            Assert.AreEqual(0, identifier.Value);
            Assert.AreEqual(categoryCode, identifier.CategoryCode);
            Assert.AreEqual(factoryCode, identifier.FactoryCode);
        }

        [TestMethod]
        public void IdentifierShouldIncrementValueAndReturnProperCodeAfterMoveToNextValueCalled()
        {
            var factoryCode = "F001";
            var categoryCode = "C001";
            var identifier = new Identifier(factoryCode, categoryCode);

            var identifierGenerated = identifier.MoveToNextValue();

            Assert.AreEqual(1, identifier.Value);

            Assert.AreEqual("C001-F001-1", identifierGenerated.Code);
            Assert.AreEqual(identifier.GlobalId, identifier.GlobalId);
        }
    }
}
