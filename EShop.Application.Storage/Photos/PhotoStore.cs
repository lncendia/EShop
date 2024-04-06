using EShop.Application.Abstractions.Exceptions;
using EShop.Application.Abstractions.Photos;
using RestSharp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace EShop.Application.Storage.Photos;

public class PhotoStore(string rootPath, string path) : IPhotoStore
{
    private readonly RestClient _client = new();

    public async Task<Uri> SaveAsync(string base64)
    {
        try
        {
            var bytes = Convert.FromBase64String(base64);
            var stream = new MemoryStream(bytes);
            using var image = await Image.LoadAsync(stream);
            image.Mutate(x => x.Resize(350, 500));
            var fileName = $"{Guid.NewGuid()}.jpg";
            await image.SaveAsync(Path.Combine(Path.Combine(rootPath, path), fileName));
            return new Uri(Path.Combine(path, fileName), UriKind.Relative);
        }
        catch (Exception ex)
        {
            throw new PhotoSaveException(ex);
        }
    }

    public async Task<Uri> SaveAsync(Uri url)
    {
        try
        {
            var stream = await _client.DownloadStreamAsync(new RestRequest(url));
            using var image = await Image.LoadAsync(stream ?? throw new NullReferenceException());
            image.Mutate(x => x.Resize(350, 500));
            var fileName = $"{Guid.NewGuid()}.jpg";
            await image.SaveAsync(Path.Combine(Path.Combine(rootPath, path), fileName));
            return new Uri(Path.Combine(path, fileName), UriKind.Relative);
        }
        catch (Exception ex)
        {
            throw new PhotoSaveException(ex);
        }
    }

    public Task DeleteAsync(Uri uri)
    {
        File.Delete(Path.Combine(rootPath, uri.ToString()));
        return Task.CompletedTask;
    }
}