using Microsoft.AspNetCore.Mvc;


namespace PruebaBaguerMD.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html/login.html");
        return PhysicalFile(filePath, "text/html");
    }

    public IActionResult Register()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html", "register.html");
        return PhysicalFile(filePath, "text/html");
    }

    public IActionResult Index()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html", "index.html");
        return PhysicalFile(filePath, "text/html");
    }

}
