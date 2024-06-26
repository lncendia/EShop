using EShop.Authentication.Abstractions.EmailService.Structs;

namespace EShop.Authentication.Abstractions.EmailService;

/// <summary>
/// Интерфейс посетителя Email
/// </summary>
public interface IEmailVisitor
{
    /// <summary>
    /// Посещает ConfirmRegistrationEmail.
    /// </summary>
    /// <param name="email">Объект ConfirmRegistrationEmail.</param>
    void Visit(ConfirmRegistrationEmail email);
    
    /// <summary>
    /// Посещает ConfirmRecoverPasswordEmail.
    /// </summary>
    /// <param name="email">Объект ConfirmRecoverPasswordEmail.</param>
    void Visit(ConfirmRecoverPasswordEmail email);
    
    /// <summary>
    /// Посещает ConfirmMailChangeEmail.
    /// </summary>
    /// <param name="email">Объект ConfirmMailChangeEmail.</param>
    void Visit(ConfirmMailChangeEmail email);
}