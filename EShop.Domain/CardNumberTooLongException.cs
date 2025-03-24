﻿namespace EShop.Domain;

public class CardNumberTooLongException : Exception
{
    public CardNumberTooLongException() { }

    public CardNumberTooLongException(string message) : base(message) { }

    public CardNumberTooLongException(string message, Exception innerException) : base(message, innerException) { }

}
