using greetFunction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace razor_pages_greet.Pages
{
    public class GreetedFriendsModel : PageModel
    {
        private IGreet _greet;

        private readonly ILogger<IndexModel> _logger;

        public GreetedFriendsModel(ILogger<IndexModel> logger, IGreet greet)
        {
            _logger = logger;
            _greet = greet;
        }
        [BindProperty]
            public string? Handler
            {
                get;
                set;
             }
        [BindProperty]
        public Greet Greeter
        {
            get;
            set;
        }


        public Dictionary<string, int> GreetingF { get { return _greet.printNames(); } }

          public void OnPostRemove(string Name)
            {
                if(Handler == "remove"){
                _greet.Clear(Greeter.Name);
                Greeter.Name = String.Empty;
                ModelState.Clear(); 
            }
    }

        public void OnPostDelete()
        {
            _greet.ClearAll();
        }

    }
}



