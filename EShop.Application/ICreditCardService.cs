using EShop.Domain.Enums;

namespace EShop.Application;

public interface ICreditCardService
{
    bool ValidateCard(string cardNumber);
    CreditCardProvider GetCardType(string cardNumber);
}
