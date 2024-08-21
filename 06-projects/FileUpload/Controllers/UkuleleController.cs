using FileUpload.Context;
using FileUpload.Models;
using FileUpload.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers;

public class UkuleleController : Controller
{
    private readonly IImagekitAPIService _imagekit;
    private readonly ApplicationContext _context;

    public UkuleleController(IImagekitAPIService imagekit, ApplicationContext context)
    {
        _imagekit = imagekit;
        _context = context;
    }

    [HttpGet("ukuleles/imagekit")]
    public ViewResult ImageKitUkuleles()
    {
        var ukuleles = _context.Ukuleles.Where((u) => !u.IsStatic).ToList();
        return View("ImageKitUkuleles", ukuleles);
    }

    [HttpGet("ukuleles/static")]
    public ViewResult StaticUkuleles()
    {
        var ukuleles = _context.Ukuleles.Where((u) => u.IsStatic).ToList();
        return View("StaticUkuleles", ukuleles);
    }

    [HttpGet("ukuleles/imagekit/new")]
    public ViewResult ImageKitNew()
    {
        return View("ImageKitNew");
    }

    [HttpPost("ukuleles/imagekit/upload")]
    public async Task<IActionResult> ImagekitUpload(UkuleleForm form)
    {
        if (!ModelState.IsValid)
        {
            return View("ImageKitNew");
        }

        var imageUrl = await _imagekit.UploadImageAsync(form.Image!);

        var newUkulele = new Ukulele()
        {
            Brand = form.Brand,
            Model = form.Model,
            ImageUrl = imageUrl,
            Description = form.Description,
            IsStatic = false,
        };

        _context.Ukuleles.Add(newUkulele);
        _context.SaveChanges();
        return RedirectToAction("ImagekitUkuleles");
    }

    [HttpGet("ukuleles/static/new")]
    public ViewResult StaticNew()
    {
        return View("StaticNew");
    }

    public async Task<IActionResult> StaticUpload(UkuleleForm form)
    {
        if (!ModelState.IsValid)
        {
            return View("StaticNew");
        }

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(form.Image!.FileName);
        var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/ukuleles");

        var filePath = Path.Combine(imagesPath, fileName);
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await form.Image.CopyToAsync(fileStream);
        }

        string imageUrl = "images/ukuleles/" + fileName;

        var newUkulele = new Ukulele()
        {
            Brand = form.Brand,
            Model = form.Model,
            ImageUrl = imageUrl,
            Description = form.Description,
            IsStatic = true,
        };

        _context.Ukuleles.Add(newUkulele);
        _context.SaveChanges();
        return RedirectToAction("StaticUkuleles");
    }
}
