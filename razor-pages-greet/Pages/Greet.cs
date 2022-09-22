using System.ComponentModel.DataAnnotations;
// using greetFunction;
namespace razor_pages_greet.Pages;

    public class Greet 
    {

        [Required, StringLength(10)]
        public string? Name
        {
            get;
            set;
        }
        [Required, StringLength(10)]
        public string? Language { get; set; }

        // public override string ToString()
        // {
        //     if(Name != null)
        //     {
        //         return Name;
        //     }
        //     else {return "null";} 
        // }    
            // string message = "";
        // public string? Greeting 
    //     {
    //         get{
    // //             if(Name != null && Language != null)
    // //             {
    // //                 if(Language == "English")
    // //                 {
    // //                     message = "Hello, " + Name;
    // //                 }
    // //                 else if(Language == "French")
    // //                 {
    // //                     message = "Bonjour, " + Name;
    // //                 }
    // //                 else if(Language == "Isixhosa")
    // //                 {
    // //                     message =  "Molo, " + Name;
    // //                 }
    // //             }
    // //             else 
    // //             {
    // //                 message = "Heita, " + Name;
    // //             }
    // //     return message;
    // // }
              
    //     //    return csGreet.Messages(Name, Language);
    //         //     if(Name != null && Language != null)
    //         //     {
    //         //         return Language + "," + Name;
    //         //     }
    //         //     return "";
    //         // }
    //     }
    //     }
          
    }
