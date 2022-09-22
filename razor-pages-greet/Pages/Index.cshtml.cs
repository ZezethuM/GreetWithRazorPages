using greetFunction;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor_pages_greet.Pages;

public class IndexModel : PageModel
{
    private IGreet _greet;
    
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, IGreet greet)
    {
        _logger = logger;
        _greet = greet;
    }

    public string Greeting{get;set;}
    public Dictionary<string, int> Greetor{get;set;}

    public int Count 
    {
        get{ 
            return _greet.Counter();
        }
    }
    
    [BindProperty]
    public Greet Greeter
    {
        get;
        set;
    }
  
    [BindProperty]
     public string? Handler{
        get;
        set;
    }

    public void OnGet()
    {

    }
     static string regexo = @"^[A-Z][a-zA-Z]*$";
         Regex regX = new Regex(regexo);
    public void OnPostGreet()
    {
        if(Handler == "greet")
        {
            if(Greeter.Name != null && Greeter.Language != null)
                {
                    if(regX.IsMatch(Greeter.Name))
                    {
                        _greet.greetedFriends(Greeter.Name, 1);
                        Greeting = _greet.Messages(Greeter.Name, Greeter.Language);
                    }
                    else{Greeting = "Invalid Name";}
                    Greeter.Name = String.Empty;
                    Greeter.Language = String.Empty;
                    ModelState.Clear();        
                }

        }
    }
}
