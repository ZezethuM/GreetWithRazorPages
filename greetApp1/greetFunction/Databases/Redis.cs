using StackExchange.Redis;
namespace greetFunction.Databases;

public class RedisGreet : IGreet
{
    private IDatabase friends;
    public RedisGreet()
    {
        var conn = ConnectionMultiplexer.Connect("localhost");
        friends = conn.GetDatabase();
    }
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
    public string MessagesConsole(string[] usercomm)
    {
        string message = "";
        
        if(usercomm.Length == 3)
        {
            if(usercomm[2] == "English" && usercomm[0] == "greet")
            {
                message = "Hello, " + usercomm[1];
            }
            else if(usercomm[2] == "French" && usercomm[0] == "greet")
            {
                message = "Bonjour, " + usercomm[1];
            }
            else if(usercomm[2] == "Isixhosa" && usercomm[0] == "greet")
            {
                message =  "Molo, " + usercomm[1];
            }
        }
        else 
        {
            message = "Heita, " + usercomm[1];
        }
        return message;
    }
    public void greetedFriends(string friend, int count)
    {
        // if(friends.KeyExists(friend))
        // {
        //     int newCount = Convert.ToInt32(friends.StringGet(friend)) + 1;
        //     friends.StringSet(friend, newCount);
        // }
        // else
        // {
        //     friends.StringSet(friend, count);
        // }

        if(friends.HashExists("myPeople", friend))
        {
            int newCount = Convert.ToInt32(friends.HashGet("myPeople", friend)) + 1;
            friends.HashSet("myPeople", new HashEntry[] {new HashEntry(friend, newCount)});
        }
        else
        {
            friends.HashSet("myPeople", new HashEntry[] {new HashEntry(friend, count)});
        }

    }
    public  Dictionary<string,int> printNames()
    {
        var namesInDB = new Dictionary<string, int>();
        foreach (var item in friends.HashGetAll("myPeople"))
        {
            namesInDB.Add(item.Name!, Convert.ToInt32(item.Value));
        } 
        return namesInDB;
    }
    public string printName(string friendName)
    {
        string greetedFriend = "";

        foreach (var item in friends.HashGetAll("myPeople"))
        {
            if(friends.HashExists("myPeople", friendName))
            {
                greetedFriend = friendName + ":" + item.Value;
            }
            else
            {
                greetedFriend = friendName + " " + "is not on the list please do greet them.";
            }
        }
        return greetedFriend;
    }
    public int Counter()
    {
        return Convert.ToInt32(friends.HashLength("myPeople"));
        // return printNames().Count();
    }
    public string ClearAll()
    {
        if(Convert.ToInt32(friends.HashLength("myPeople")) == 0)
        {
            return "The list is empty please greet people";
        }
        else
        {
            foreach (var item in friends.HashGetAll("myPeople"))
            {
                friends.HashDelete("myPeople", item.Name); 
            }
            return "All your friends have been cleared!!";
        }
    }
    public string Clear(string name)
    {
        if(friends.HashExists("myPeople", name))
        {
            Convert.ToString(friends.HashDelete("myPeople", name));
        }
        return name + " " + "has been removed from list";
    }
}