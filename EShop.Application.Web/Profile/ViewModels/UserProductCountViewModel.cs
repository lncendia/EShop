using EShop.Application.Web.Common.Enums;

namespace EShop.Application.Web.Profile.ViewModels;

public class UserProductCountViewModel : UserProductViewModel
{
    public required int Count { get; init; }
}