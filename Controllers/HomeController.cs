using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithValidations.Models;

namespace DojoSurveyWithValidations.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public static Survey SurveyResult = new();

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(Survey newSurvey)
    {
        SurveyResult = newSurvey;

        Console.WriteLine($"{newSurvey.Name} attended the {newSurvey.DojoLocation} class, their favorite language was {newSurvey.FavoriteLanguage} and they commented \"{newSurvey.Comment}\".");
        if (!ModelState.IsValid) return View("Index");
        
        return RedirectToAction("Result");
    }

    [HttpGet("result")]
    public IActionResult Result()
    {
        return View(SurveyResult);
    }

    // public IActionResult Privacy()
    // {
    //     return View();
    // }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
