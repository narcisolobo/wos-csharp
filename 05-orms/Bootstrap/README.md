# Updating Bootstrap and Getting Dark Mode
Here are the steps I go through to update Bootstrap to the latest version and enable dark mode.

1. Download the latest CSS and JavaScript files at [my Google Drive link](https://drive.google.com/drive/folders/1AhqMXPmt10z9EajUjOZKeMtHvMnbEY0W?usp=sharing).
2. Unzip the file and replace the entire existing `bootstrap` directory.
   1. Optional - delete the `_Layout.cshtml.css` file at (`Views/Shared/_Layout.cshtml.css`)
3. Add the `.footer` class to your `site.css` file.
```css
.footer {
  position: absolute;
  bottom: 0;
  width: 100%;
  white-space: nowrap;
  line-height: 60px;
}
```
4. Edit your `_Layout.cshtml` file at (`Views/Shared/_Layout.cshtml`).

**Example:**
```html
<!DOCTYPE html>
<html lang="en" data-bs-theme="dark">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - MovieCRUD</title>
    <link rel="stylesheet" href="~/lib/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
</head>

<body>
    <header>
        <nav class="navbar navbar-expand-lg bg-body-tertiary shadow">
            <div class="container">
                <a class="navbar-brand" href="/">MovieCRUD</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
                    aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav ms-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="/">Home</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
    <div class="container">
        <main role="main" class="py-3">
            @RenderBody()
        </main>
    </div>

    <footer class="border-top footer text-muted">
        <div class="container">
            &copy; 2024 - MovieCRUD - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
        </div>
    </footer>
    <script src="~/lib/bootstrap/js/bootstrap.bundle.min.js"></script>
</body>

</html>
```