namespace EShop.Authentication.Abstractions.Exceptions;

/// Исключение, возникающее при неверно введенном пароле.
public class InvalidPasswordException() : Exception("Invalid password entered");