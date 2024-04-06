namespace EShop.Application.Abstractions.Photos;

public interface IPhotoStore
{
    Task<Uri> SaveAsync(string base64);
    Task<Uri> SaveAsync(Uri url);
    Task DeleteAsync(Uri url);
}