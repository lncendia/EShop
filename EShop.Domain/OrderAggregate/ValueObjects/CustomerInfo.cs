using EShop.Domain.Extensions;

namespace EShop.Domain.OrderAggregate.ValueObjects;

public class CustomerInfo
{
    private const int MaxCustomerNameLength = 100;

    private readonly string _name = null!;
    private readonly string _phone = null!;
    private readonly string _email = null!;

    public required string Name
    {
        get => _name;
        init => value.ValidateLength(MaxCustomerNameLength);
    }

    public required string PhoneNumber
    {
        get => _phone;
        init => _phone = value.ValidatePhone();
    }

    public required string Email
    {
        get => _email;
        init => _email = value.ValidateEmail();
    }
}