# Upload Image to Imagekit

This is not a step-by-step guide, but rather a checklist of sorts. Make sure you've got all of these items covered.

Before you start, head to [imagekit.io](https://imagekit.io/) and create a free account.

1. Make sure there's a `string?` property in your model for the image url.
   ```cs
    using System.ComponentModel.DataAnnotations;

    namespace ImagekitUpload.Models;

    public class Pet
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        public string? PetName { get; set; }

        // here is the image url property
        public string? PetImageUrl { get; set; }

        [Required]
        public string? PetImageDescription { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
    ```
2. Install the Imagekit SDK.
   ```shell
   dotnet add package Imagekit
   ```
3. Create a new key-value pair in your `appsettings.json` file for your Imagekit private key. The key can be found in your [Imagekit Dashboard](https://imagekit.io/dashboard/developer/api-keys) under "Developer options".
   ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;port=3306;userid=root;password=root;database=your_db;"
      },
      "ImagekitPrivateKey": "change this to your imagekit private key"
    }
   ```
4. Create a service to upload files to Imagekit. Refer to the [ImagekitAPIService](./Services/ImagekitAPIService.cs) in this project.
   - There are some items you need to change. Look for the comments I wrote.
5. Edit your `Program.cs` file. We need to add the service. Refer to line 10 in [Program.cs](./Program.cs).
   ```cs
   builder.Services.AddTransient<IImagekitAPIService, ImagekitAPIService>();
   ```
6. Inject your service into your controller(s). Refer to the [PetController](./Controllers/PetController.cs) for an example.
7. You will need a separate model for the form validation. Refer to [PetForm.cs](./Models/PetForm.cs) for an example.
8. I have also created a validation attribute that validates the image file. Refer to [ImageFileAttribute.cs](./Attributes/ImageFileAttribute.cs) for an example.
9. The form in your `.cshtml` file **must have** this attribute: `enctype="multipart/form-data"` in order to accept files. Refer to [NewPet.cshtml](./Views/Pet/NewPet.cshtml) for an example.
10. In your action method that processes the form, call `UploadImageAsync` to upload the file and get the file's url. Refer to line 40 in [PetController.cs](./Controllers/PetController.cs) for an example.