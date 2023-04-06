using System.ComponentModel.DataAnnotations;

namespace greetWithMVC.Models;

public class Greet
{
    [Required(ErrorMessage = "First name is required.")] 
    public string FriendsName 
    {
        get;
        set;
    } = string.Empty;
    public int Count 
    {
        get;
        set;
    }
    public string? Language
    {
        get; set;
    }
}