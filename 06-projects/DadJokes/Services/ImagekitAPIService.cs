using System.Configuration;
using Imagekit;
using Imagekit.Sdk;

namespace DadJokes.Services;

public interface IImagekitAPIService
{
    Task<string> UploadImageAsync(IFormFile imageFile);
}

public class ImagekitAPIService : IImagekitAPIService
{
    private readonly ImagekitClient _imagekit;
    private readonly IConfiguration _configuration;
    private readonly string? _privateKey;

    public ImagekitAPIService(IConfiguration configuration)
    {
        _configuration = configuration;
        _privateKey = _configuration["ImagekitPrivateKey"];
        _imagekit = new ImagekitClient(
            "public_K106eYgtmUt733AiOTC7G2+Tptg=",
            _privateKey,
            "https://ik.imagekit.io/sjw2xjkmu/"
        );
    }

    public async Task<string> UploadImageAsync(IFormFile imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            throw new ArgumentException("Invalid image file.");
        }

        var base64Image = await ConvertToBase64Async(imageFile);
        var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);
        var request = new FileCreateRequest()
        {
            file = base64Image,
            fileName = fileName,
            folder = "dadjokes-avatars",
        };

        var response = await _imagekit.UploadAsync(request);

        if (response.HttpStatusCode != 200)
        {
            throw new Exception("Image upload failed.");
        }

        return response.url;
    }

    public async Task<string> ConvertToBase64Async(IFormFile? file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("Invalid file.");

        using (var memoryStream = new MemoryStream())
        {
            // Copy the file content to the memory stream
            await file.CopyToAsync(memoryStream);

            // Convert the file to a byte array
            var fileBytes = memoryStream.ToArray();

            // Convert the byte array to a Base64 string
            return Convert.ToBase64String(fileBytes);
        }
    }
}
