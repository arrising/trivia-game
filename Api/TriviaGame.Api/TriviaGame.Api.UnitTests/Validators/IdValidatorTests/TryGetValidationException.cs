using TriviaGame.Api.Validators.Interfaces;

namespace TriviaGame.Api.UnitTests.Validators.IdValidatorTests;

public class TryGetValidationException : IClassFixture<IdValidatorFixture>
{
    private readonly IdValidatorFixture _fixture;
    private readonly IIdValidator _instance;

    public TryGetValidationException(IdValidatorFixture fixture)
    {
        _fixture = fixture;
        _instance = fixture.CreateInstance();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("     ")]
    public void InputValidator_TryGetValidationException_ValueIsMissing_True(string? value)
    {
        // Arrange
        var parameterName = _fixture.AutoFixture.Create<string>();
        var expectedMessage = $"{parameterName} must have a non empty value (Parameter '{parameterName}')";

        // Act
        var actual = _instance.TryGetValidationException(value, parameterName, out var exception);

        // Assert
        actual.Should().BeTrue();
        exception.Should().BeOfType<ArgumentException>();
        exception?.Message.Should().NotBeNull().And.Be(expectedMessage);
    }

    [Fact]
    public void InputValidator_TryGetValidationException_ValueIsNotGUid_False()
    {
        // Arrange
        var value = "Not_A_GUID";
        var parameterName = _fixture.AutoFixture.Create<string>();
        var expectedMessage = $"'{value}' at {parameterName} is not a valid GUID (Parameter '{parameterName}')";

        // Act
        var actual = _instance.TryGetValidationException(value, parameterName, out var exception);

        // Assert
        actual.Should().BeTrue();
        exception.Should().BeOfType<ArgumentException>();
        exception?.Message.Should().NotBeNull().And.Be(expectedMessage);
    }

    [Fact]
    public void InputValidator_TryGetValidationException_HasValidValue_False()
    {
        // Arrange
        var value = _fixture.AutoFixture.Create<string>();
        var parameterName = _fixture.AutoFixture.Create<string>();

        // Act
        var actual = _instance.TryGetValidationException(value, parameterName, out var exception);

        // Assert
        actual.Should().BeFalse();
        exception.Should().BeNull();
    }
}
