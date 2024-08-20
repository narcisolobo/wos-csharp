using DadJokes.Areas.Identity.Data;
using DadJokes.Models;
using DadJokes.Services;
using DadJokes.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DadJokes.Controllers;

public class AccountController(
    DadJokesContext context,
    UserManager<DadJokeUser> userManager,
    SignInManager<DadJokeUser> signInManager,
    IImagekitAPIService imagekit) : Controller
{
    private readonly DadJokesContext _context = context;
    private readonly UserManager<DadJokeUser> _userManager = userManager;
    private readonly SignInManager<DadJokeUser> _signInManager = signInManager;
    private readonly IImagekitAPIService _imagekit = imagekit;
    private readonly long _maxFileSize = 2 * 1024 * 1024; // 2 MB

    [HttpGet("accounts")]
    public IActionResult LoginReg()
    {
        return View("LoginReg");
    }

    [HttpPost("accounts/register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("LoginReg");
        }

        var newUser = new DadJokeUser();
        var hasher = new PasswordHasher<DadJokeUser>();

        newUser.Email = model.RegisterEmail;
        newUser.EmailConfirmed = true;
        newUser.UserName = model.RegisterEmail;
        newUser.PasswordHash = hasher.HashPassword(newUser, model.RegisterPassword!);

        var newProfile = new Profile()
        {
            DadJokeUser = newUser,
            ImageUrl = "~/images/smoking-pipe.png"
        };

        _context.DadJokeUsers.Add(newUser);
        _context.Profiles.Add(newProfile);
        _context.SaveChanges();

        await _signInManager.SignInAsync(newUser, isPersistent: false);

        return RedirectToAction("RandomJoke", "DadJoke");
    }

    [HttpPost("accounts/login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("LoginReg");
        }

        var user = _context.DadJokeUsers.SingleOrDefault((u) => u.Email == model.LoginEmail);
        if (user is null)
        {
            return RedirectToAction("LoginReg", new { message = "invalid-credentials" });
        }

        var hasher = new PasswordHasher<DadJokeUser>();

        PasswordVerificationResult result = hasher.VerifyHashedPassword(
            user,
            user.PasswordHash!,
            model.LoginPassword!
        );

        if (result == PasswordVerificationResult.Failed)
        {
            return RedirectToAction("Index", new { message = "invalid-credentials" });
        }

        await _signInManager.SignInAsync(user, isPersistent: false);

        return RedirectToAction("RandomJoke", "DadJoke");
    }

    [HttpGet("accounts/profile")]
    public async Task<IActionResult> Profile()
    {
        var viewModel = await CreateViewModel();

        return View("Profile", viewModel);
    }

    public async Task<IActionResult> UploadImage(IFormFile profileImage)
    {
        if (profileImage == null || profileImage.Length == 0)
        {
            ModelState.AddModelError("ProfileImage", "Please upload a valid image.");
            var viewModel = await CreateViewModel();
            return View("Profile", viewModel);
        }

        if (profileImage.Length > _maxFileSize)
        {
            ModelState.AddModelError("ProfileImage", "The image file size exceeds the 2 MB limit.");
            var viewModel = await CreateViewModel();
            return View("Profile", viewModel);
        }

        var permittedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var ext = Path.GetExtension(profileImage.FileName).ToLowerInvariant();

        if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
        {
            ModelState.AddModelError("ProfileImage", "Invalid file type. Only JPG, PNG, and GIF are allowed.");
            var viewModel = await CreateViewModel();
            return View("Profile", viewModel);
        }

        try
        {
            var imageUrl = await _imagekit.UploadImageAsync(profileImage);
            var user = await GetUser();
            var profile = GetProfile(user!)!;
            profile.ImageUrl = imageUrl;
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("ProfileImage", ex.Message);
            var viewModel = await CreateViewModel();
            return View("Profile", viewModel);
        }
    }

    private async Task<ProfilePageViewModel?> CreateViewModel()
    {
        var user = await GetUser();

        if (user is null)
        {
            return null;
        }

        var profile = GetProfile(user);

        var viewModel = new ProfilePageViewModel()
        {
            DadJokeUser = user,
            Profile = profile,
        };

        return viewModel;
    }

    private async Task<DadJokeUser?> GetUser()
    {
        return await _userManager.GetUserAsync(User);
    }

    private Profile? GetProfile(DadJokeUser user)
    {
        return _context.Profiles.FirstOrDefault((p) => p.DadJokeUser == user);
    }
}
