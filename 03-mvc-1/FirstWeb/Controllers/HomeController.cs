using Microsoft.AspNetCore.Mvc;

namespace FirstWeb.Controllers;

public class HomeController : Controller
{
    // attribute
    [HttpGet("")]
    // action method
    public string Index()
    {
        return "Index page edited";
    }

    [HttpGet("about")]
    public string About()
    {
        return "About page";
    }

    [HttpGet("services")]
    public string Services()
    {
        return "Here are our company's services.";
    }

    // dynamic route segment
    // route parameter
    [HttpGet("services/{service}")]
    public string ServicePage(string service)
    {
        return $"Service: {service}";
    }

    [HttpGet("services/{service}/{serviceId}")]
    public string ServiceIdPage(string service, int serviceId)
    {
        return $"{service}: {serviceId}";
    }

    [HttpGet("portfolio/{portfolioId}")]
    public string PortfolioPage(int portfolioId)
    {
        return $"Viewing project {portfolioId}";
    }

    [HttpGet("repeat/{word}/{number}")]
    public string Repeat(string word, int number)
    {
        var output = "";

        for (var i = 1; i <= number; i++)
        {
            output = output + word + "\n";
        }

        return output;
    }
}
