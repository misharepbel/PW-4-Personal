namespace EShop.Application.Tests;
using EShop.Application;

public class CreditCardService_Tests
{
    // ValidateCard Tests

    [Fact]
    public void ValidateCard_CardNumberTooShort_ReturnsFalse()
    {
        // Arrange
        CreditCardService testCCS = new();

        // Act
        bool result = testCCS.ValidateCard("521156348539");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ValidateCard_CardNumberTooLong_ReturnsFalse()
    {
        // Arrange
        CreditCardService testCCS = new();

        // Act
        bool result = testCCS.ValidateCard("1499085400236481283886001");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ValidateCard_CardNumberSizeableEnough_ReturnsTrue()
    {
        // Arrange
        CreditCardService testCCS = new();

        // Act
        bool result = testCCS.ValidateCard("5530016454538418");

        // Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("3497:7965:8312:797")]
    [InlineData("345a470b784c783d010")]
    [InlineData("3785233п93817437")]
    [InlineData("4024_0071_6540_1778")]
    [InlineData("4532=2080=2150=4434")]
    [InlineData("453AA22W89052S809181")]
    [InlineData("55300ו6454538418")]
    [InlineData("55515ㅇ61443896215")]
    [InlineData("513120851ⵥ7986691")]
    public void ValidateCard_CardNumberImproperlySeparated_ReturnsFalse(string cardNumber)
    {
        // Arrange
        CreditCardService testCCS = new();

        // Act
        bool result = testCCS.ValidateCard(cardNumber);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("3497 7965 8312 797")]
    [InlineData("345-470-784-783-010")]
    [InlineData("378523393817437")]
    [InlineData("4024-0071-6540-1778")]
    [InlineData("4532 2080 2150 4434")]
    [InlineData("4532289052809181")]
    [InlineData("5530016454538418")]
    [InlineData("5551561443896215")]
    [InlineData("5131208517986691")]
    public void ValidateCard_CardNumberIsProper_ReturnsTrue(string cardNumber)
    {
        // Arrange
        CreditCardService testCCS = new();

        // Act
        bool result = testCCS.ValidateCard(cardNumber);

        // Assert
        Assert.True(result);
    }

    // GetCardType Tests

    [Theory]
    [InlineData("3497 7965 8312 797", "American Express")]
    [InlineData("345-470-784-783-010", "American Express")]
    [InlineData("378523393817437", "American Express")]
    [InlineData("4024-0071-6540-1778", "Visa")]
    [InlineData("4532 2080 2150 4434", "Visa")]
    [InlineData("4532289052809181", "Visa")]
    [InlineData("5530016454538418", "MasterCard")]
    [InlineData("5551561443896215", "MasterCard")]
    [InlineData("5131208517986691", "MasterCard")]
    public void GetCardType_GoodData_ReturnsRightType(string cardNumber, string cardType)
    {
        // Arrange
        CreditCardService testCCS = new();

        // Act
        string result = testCCS.GetCardType(cardNumber);

        // Assert
        Assert.Equal(result, cardType);
    }

    [Theory]
    [InlineData("4321121232132179977")] // Visa-like, but doesn't pass Luhn's
    [InlineData("5111111111111112")] // MasterCard-like, but doesn't pass Luhn's
    [InlineData("371234567890123")] // American Express-like, but doesn't pass Luhn's
    [InlineData("6011123456789012")] // Discover-like, but doesn't pass Luhn's
    [InlineData("3528352835283528")] // JCB-like, but doesn't pass Luhn's
    [InlineData("30569309025901")] // Diners Club-like, but doesn't pass Luhn's
    [InlineData("5601234567890123")] // Maestro-like, but doesn't pass Luhn's
    public void GetCardType_BadData_ReturnsInvalidCard(string cardNumber)
    {
        // Arrange
        CreditCardService testCCS = new();

        // Act
        string result = testCCS.GetCardType(cardNumber);

        // Assert
        Assert.Equal("Invalid card.", result);
    }
}