using System.ComponentModel.DataAnnotations;
// using greetFunction;
namespace razor_pages_greet.Pages;

    public class Greet 
    {

        [Required, StringLength(10)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "Please enter a valid name.") ]
        public string? Name
        {
            get;
            set;
        }
        [Required, StringLength(10)]
        public string? Language { get; set; }    
    }
