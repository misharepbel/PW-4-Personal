namespace EShop.Application.Tests;
using EShop.Application;
using EShop.Domain;

public class CreditCardService_Tests
{
    // ValidateCard Tests

    [Fact]
    public void ValidateCard_CardNumberTooShort_ThrowsTooShortError()
    {
        // Arrange
        CreditCardService testCCS = new();

        // Act & Assert
        Assert.Throws<CardNumberTooShortException>(() => testCCS.ValidateCard("521156348539"));
    }

    [Fact]
    public void ValidateCard_CardNumberTooLong_ThrowsTooLongError()
    {
        // Arrange
        CreditCardService testCCS = new();

        // Act & Assert
        Assert.Throws<CardNumberTooLongException>(() => testCCS.ValidateCard("1499085400236481283886001"));
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
    public void ValidateCard_CardNumberImproperlySeparated_ThrowsInvalidExceptionWithBadCharactersMessage(string cardNumber)
    {
        // Arrange
        CreditCardService testCCS = new();

        // Act
        var exception = Assert.Throws<CardNumberInvalidException>(() => testCCS.ValidateCard(cardNumber));

        // Assert
        Assert.Equal("The card number has characters in it that cannot be accepted.", exception.Message);
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
    [InlineData("3497 7965 8312 797", CreditCardProvider.AmericanExpress)]
    [InlineData("345-470-784-783-010", CreditCardProvider.AmericanExpress)]
    [InlineData("378523393817437", CreditCardProvider.AmericanExpress)]
    [InlineData("4024-0071-6540-1778", CreditCardProvider.Visa)]
    [InlineData("4532 2080 2150 4434", CreditCardProvider.Visa)]
    [InlineData("4532289052809181", CreditCardProvider.Visa)]
    [InlineData("5530016454538418", CreditCardProvider.MasterCard)]
    [InlineData("5551561443896215", CreditCardProvider.MasterCard)]
    [InlineData("5131208517986691", CreditCardProvider.MasterCard)]
    public void GetCardType_GoodData_ReturnsRightType(string cardNumber, CreditCardProvider cardType)
    {
        // Arrange
        CreditCardService testCCS = new();

        // Act
        CreditCardProvider result = testCCS.GetCardType(cardNumber);

        // Assert
        Assert.Equal(result, cardType);
    }

    [Theory]
    [InlineData("3426745901227")]
    [InlineData("793044846331550")]
    [InlineData("8796158134589313")]
    [InlineData("33948638233131120")]
    [InlineData("7410482247917144279")]
    public void GetCardType_BadData_ThrowsInvalidExceptionWithNoTypeMatchMessage(string cardNumber)
    {
        // Arrange
        CreditCardService testCCS = new();

        // Act
        var exception = Assert.Throws<CardNumberInvalidException>(() => testCCS.GetCardType(cardNumber));

        // Assert
        Assert.Equal("The provided card number does not match any of the registered card types.", exception.Message);
    }
}