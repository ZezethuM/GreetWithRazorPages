namespace greetFunction;


public class GreetFunc
{
    public string Name
    {
        get;
        set;
    } = string.Empty;
    public string Language
    {
        get;
        set;
    } = string.Empty;
    
    public static Dictionary<string, int> myFriends = new Dictionary<string, int>();
    public  int count = 1;
    public string Messages(string name, string language)
    {
        string message = "";
        if(name != null && language != null)
        {
            if(language == "English")
            {
                message = "Hello, " + name;
            }
            else if(language == "French")
            {
                message = "Bonjour, " + name;
            }
            else if(language == "Isixhosa")
            {
                message =  "Molo, " + name;
            }
        }
        return message;
    }
    public  void greetedFriends(string friends, int count)
    { 
         if(myFriends.ContainsKey(friends))
        {
            myFriends[friends]++;
        }
        else
        {
            myFriends.Add(friends, count);
        }
    }
    public  Dictionary<string,int> printNames()
    {
            return myFriends;
    }
    public string printName(string friendName)
    { 
         if(myFriends.ContainsKey(friendName))
         {
           return friendName + ":" +  myFriends[friendName]; 
         }
        else
        {
            return "Your friend is not on the list please do greet them.";
        }    
    }
    public string Counter()
    {
        if(myFriends.Count() == 0)
        {
            return "No friends have been greeted, list is empty!";
        }
        else 
        {
            return myFriends.Count() + "," + "friend/s have been greeted.";
        }
    }
    public  string Clear()
    {
        if(myFriends.Count() != 0)
        {
         myFriends.Clear();
        }
        return "All your friends have been cleared!!";
    }
     public  string ClearAll(string name)
    {
        if(myFriends.ContainsKey(name))
        {
            myFriends.Remove(name);
        }
        return name + " " + "has been removed from list";
    }
}