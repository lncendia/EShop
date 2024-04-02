using EShop.Domain.Extensions;

namespace EShop.Domain.OrderAggregate.ValueObjects;

public class DeliveryInfo
{
    private const int MaxDeliveryApartmentLength = 10;

    private const int MaxDeliveryBuildingLength = 10;

    private const int MaxDeliveryStreetLength = 400;

    private const int MaxDeliveryCommentLength = 400;

    private const int MaxDeliveryCityLength = 400;

    private const int MaxDeliveryRegionLength = 400;

    private readonly string _region = null!;
    private readonly string _city = null!;
    private readonly string _street = null!;
    private readonly string _building = null!;
    private readonly string? _apartment;
    private readonly string? _comment;

    public int? Flat { get; init; }

    public required string Region
    {
        get => _region;
        init => _region = value.ValidateLength(MaxDeliveryRegionLength);
    }

    public required string City
    {
        get => _city;
        init => _city = value.ValidateLength(MaxDeliveryCityLength);
    }

    public required string Street
    {
        get => _street;
        init => _street = value.ValidateLength(MaxDeliveryStreetLength);
    }

    public required string Building
    {
        get => _building;
        init => _building = value.ValidateLength(MaxDeliveryBuildingLength);
    }

    public string? Apartment
    {
        get => _apartment;
        init => _apartment = value?.ValidateLength(MaxDeliveryApartmentLength);
    }

    public string? Comment
    {
        get => _comment;
        init => _comment = value?.ValidateLength(MaxDeliveryCommentLength);
    }
}