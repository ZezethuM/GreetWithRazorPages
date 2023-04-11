using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using greetWithMVC.Models;
using greetFunction;
// using greetWithMVC;

namespace greetWithMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGreet _greetRepo;

    public HomeController(ILogger<HomeController> logger, IGreet greetRepo)
    {
        _logger = logger;
        _greetRepo = greetRepo;
    }

    public IActionResult Index()
    {
         ViewData["Count"] = _greetRepo.Counter();
        return View();
    }

    // public IActionResult Greeted()
    // {
    //     return View();
    // }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Index(Greet greet)
    {
        try
            {
                if (ModelState.IsValid)
                {
                    _greetRepo.greetedFriends(greet.FriendsName, 1);
                    ViewData["FriendsName"] = _greetRepo.Messages(greet.FriendsName, greet.Language!);
                    ModelState.Clear();
                    return View("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
    } 
    
    public ActionResult Greeted()
    {
       ViewData["GreetingF"] = _greetRepo.printNames();
        return View();
    }
    
    [HttpPost]
    public ActionResult Remove(Greet greet)
    {
        _greetRepo.Clear(greet.FriendsName);
        Console.WriteLine(greet.FriendsName);
        ViewData["GreetingF"] = _greetRepo.printNames();
        return View("Greeted"); 
    }
    public ActionResult ClearAll()
    {
        _greetRepo.ClearAll();
       ViewData["GreetingF"] = _greetRepo.printNames();
        return View("Greeted"); 
    }   


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
