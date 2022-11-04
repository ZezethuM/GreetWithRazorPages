using MongoDB.Bson;
using MongoDB.Driver;
namespace greetFunction.Databases;

public class MongoGreet : IGreet
{  
    private IMongoCollection<People> people;
    private BsonDocument document;
    public MongoGreet(string mongoUrl)
    {
        var client = new MongoClient(mongoUrl);
        var database = client.GetDatabase("friends");
        people = database.GetCollection<People>("friend");
        document = new BsonDocument();
    }
     public string Messages(string  name, string language)
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
    public void greetedFriends(string userName, int counter)
    {
        var doc = people.Find(s => s.Name == userName).CountDocuments();
        var replace = people.Find(s => s.Name == userName).FirstOrDefault();
        if(doc == 1)
        {
            replace.Count = Convert.ToInt32(doc + 1);
            people.ReplaceOne(s => s.Name == userName, replace);
        }
        else
        {
            People test = new People()
            {
                Name = userName,
                Count = counter
            };
            people.InsertOne(test);
        }
    }
    public Dictionary<string,int> printNames()
    {
        var namesInDB = new Dictionary<string, int>();
        // var document = new BsonDocument();

        foreach (var item in people.Find(document).ToList())
        {
            namesInDB.Add(item.Name!, item.Count);
        }
        return namesInDB;
    }
    public string printName(string friendName)
    {
        string friendsName = "";
        // var document = new BsonDocument();

        foreach (var item in people.Find(document).ToList())
        {
           if(item.Name == friendName)
           {
                friendsName = item.Name + ":" + item.Count;
           }
           else
           {
                friendsName = "Your friend is not on the list please do greet them.";
           }
        }
        return friendsName;
    }
    public int Counter()
    {
        return printNames().Count();
    }     
    
    public string ClearAll()
    {
        // var document = new BsonDocument();
        people.DeleteMany(document);
        return "All your friends have been cleared!!";
    }
    public string Clear(string name)
    {
        // var document = new BsonDocument();
        foreach (var item in people.Find(document).ToList())
        {
            if(item.Name == name)
            {
                people.DeleteOne(document);
            }
        }
        return name + " " + "has been removed from list";
    }
}