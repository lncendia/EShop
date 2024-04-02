namespace EShop.Authentication.Abstractions.Exceptions;

/// <summary>
/// Исключение, возникающее при неверно введенном коде подтверждения.
/// </summary>
public class InvalidCodeException() : Exception("Invalid code specified");