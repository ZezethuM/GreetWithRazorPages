using greetFunction.Databases;
using greetFunction;
namespace greet_test;

public class UnitTest1
{
    [Fact]
    public void ShouldBeAbleToGreetDifferentPeopleInAllLanguages()
    {
        IGreet greets = new GreetWithDB();
        
        Assert.Equal("Hello, Zeze", greets.Messages("Zeze", "English"));
        Assert.Equal("Molo, Avile", greets.Messages("Avile", "Isixhosa"));
        Assert.Equal("Bonjour, Phumza", greets.Messages("Phumza", "French"));
        Assert.Equal("Hello, Khazimla", greets.Messages("Khazimla", "English"));
    }
     [Fact]
    public void ShouldBeAbleToStoreNamesAndReturnThem()
    {
        IGreet greets = new GreetWithDB();

        greets.greetedFriends("Zeze",1 );
        greets.greetedFriends("Avile",1);
        greets.greetedFriends("Phumza", 1);
        greets.greetedFriends("Khazimla", 1);

        Dictionary<string, int> myPeople = new Dictionary<string, int>(){{"Zeze", 1}, {"Avile", 1}, {"Phumza", 1}, {"Khazimla", 1}};
        Assert.Equal(myPeople, greets.printNames()); 
    }

    [Fact]

    public void ShouldBeAbleToPrintANameThatWasGreeted()
    {
        IGreet greets = new GreetWithDB();

        greets.greetedFriends("Andre", 1);
        greets.greetedFriends("Yanga", 1);

        Dictionary<string, int> printNam = new Dictionary<string, int>(){{"Andre", 1}, {"Yanga", 1}};
        Assert.Equal("Yanga:1", greets.printName("Yanga"));
        
    }
    [Fact]
    public void ShouldReturnAMassageThatNameIsNotOnListIfUserSearchANameThatHasNotBeenGreeted()
    {
        IGreet greets = new GreetWithDB();

        greets.Messages("Yanga", "Isixhosa");

        Dictionary<string, int> printNam = new Dictionary<string, int>(){{"Yanga", 1}};
        
        Assert.Equal("Your friend is not on the list please do greet them.", greets.printName("Andre"));
    }
    [Fact]
    public void ShouldBeAbleCountTheNumberOfNamesInTheListAndReturnTheyAre()
    {
        IGreet greets = new GreetWithDB();

        greets.greetedFriends("Zeze",1 );
        greets.greetedFriends("Avile",1);
        greets.greetedFriends("Phumza", 1);
        greets.greetedFriends("Khazimla", 1);

        Dictionary<string, int> myPeople = new Dictionary<string, int>(){{"Zeze", 1}, {"Avile", 1}, {"Phumza", 1}, {"Khazumla", 1}};
        Assert.Equal(myPeople.Count(), greets.Counter());
    }
    [Fact]
    public void ShouldBeAbleToClearANameFromTheList()
    {
        IGreet greets = new GreetWithDB();

        greets.Messages("Yanga", "Isixhosa");
        greets.Messages("Anthony", "Isixhosa");

        Dictionary<string, int> clearName = new Dictionary<string, int>(){{"Yanga", 1},{"Anthony", 1}};
        Assert.Equal("Anthony has been removed from list", greets.Clear("Anthony"));
    }
    [Fact]
    public void SHouldBeABleToClearAllTheNamesInTheList()
    {
        IGreet greets = new GreetWithDB();

        greets.Messages("Siphe", "French");
        greets.Messages("Cara", "Isixhosa");

        Dictionary<string, int> clearAll = new Dictionary<string, int>(){{"Siphe", 1},{"Cara", 1}};

        Assert.Equal("All your friends have been cleared!!", greets.ClearAll());
    }
}