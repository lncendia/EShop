namespace EShop.Authentication.Abstractions.Exceptions;

/// <summary>
/// Исключение, возникающее при отсутствии пользователя.
/// </summary>
public class UserNotFoundException() : Exception("Can't find user");