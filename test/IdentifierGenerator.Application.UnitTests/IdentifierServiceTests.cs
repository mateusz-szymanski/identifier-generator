using IdentifierGenerator.Application.Commands;
using IdentifierGenerator.Application.UnitTests.Utilities;
using System.Threading.Tasks;
using Xunit;

namespace IdentifierGenerator.Application.UnitTests
{
    public class IdentifierServiceTests
    {
        [Fact]
        public async Task GenerateCodeCommand_ShouldReturnProperCode_ForNewlyCreatedFactoryAndCategory()
        {
            // Arrange
            await using var rootServiceProvider = await new ServiceProviderBuilder()
                .Build();
            var mediatorUtility = new MediatorUtility(rootServiceProvider);

            var factoryCode = "F001";
            var categoryCode = "C001";

            var generateCodeCommand = new GenerateCodeCommand(factoryCode, categoryCode);

            // Act
            var generateCodeCommandResponse = await mediatorUtility.Send(generateCodeCommand);

            // Assert
            Assert.Equal("C001-F001-1", generateCodeCommandResponse.GeneratedCode);
        }

        [Fact]
        public async Task GenerateCodeCommand_ShouldReturnProperCode_ForAlreadyCreatedCode()
        {
            // Arrange
            await using var rootServiceProvider = await new ServiceProviderBuilder()
                .Build();
            var mediatorUtility = new MediatorUtility(rootServiceProvider);

            var factoryCode = "F001";
            var categoryCode = "C001";

            var generateCodeCommand = new GenerateCodeCommand(factoryCode, categoryCode);

            // Act
            await mediatorUtility.Send(generateCodeCommand);
            var generateCodeCommandResponse = await mediatorUtility.Send(generateCodeCommand);

            Assert.Equal("C001-F001-2", generateCodeCommandResponse.GeneratedCode);
        }
    }
}
