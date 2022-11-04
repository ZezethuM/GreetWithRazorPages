using greetFunction.Databases;
namespace greetFunction;

public interface IGreet
{
    public string Messages(string name, string language);
    public string MessagesConsole(string[] usercomm);
    public void greetedFriends(string friends, int count);
    public  Dictionary<string,int> printNames();

    public string printName(string friendName);
    public int Counter();
    public string ClearAll();
    public string Clear(string name);
}