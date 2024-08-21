using Imagekit.Sdk;

namespace FileUpload.Services;

public interface IImagekitAPIService
{
    Task<string> UploadImageAsync(IFormFile imageFile);
}

public class ImagekitAPIService : IImagekitAPIService
{
    private readonly ImagekitClient _imagekit;
    private readonly IConfiguration _configuration;
    private readonly string _privateKey;

    public ImagekitAPIService(IConfiguration configuration)
    {
        _configuration = configuration;
        _privateKey = _configuration["ImagekitPrivateKey"]!;
        _imagekit = new ImagekitClient(
            "public_K106eYgtmUt733AiOTC7G2", // change to your public key
            _privateKey,
            "https://ik.imagekit.io/sjw2xjkmu/" // change to your endpoint
        );
    }

    public async Task<string> UploadImageAsync(IFormFile? imageFile)
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
            folder = "ukuleles", // optional Imagekit folder name (if you have one)
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
        {
            throw new ArgumentException("Invalid file.");
        }

        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        var fileBytes = memoryStream.ToArray();
        return Convert.ToBase64String(fileBytes);
    }
}
