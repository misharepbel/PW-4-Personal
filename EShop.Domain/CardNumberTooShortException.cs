namespace EShop.Domain;

public class CardNumberTooShortException : Exception
{
    public CardNumberTooShortException() { }

    public CardNumberTooShortException(string message) : base(message) { }

    public CardNumberTooShortException(string message, Exception innerException) : base(message, innerException) { }

}
