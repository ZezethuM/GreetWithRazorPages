﻿using Npgsql;
using Dapper;
using greetFunction.Databases;
using greetFunction;

IGreet greets = new GreetWithBD();
// IGreet greets = new MongoGreet("mongodb://0.0.0.0:27017");
// IGreet greets = new RedisGreet();


    string userCommand = "";
    string Name = "";
    string connectionString = "Server=tiny.db.elephantsql.com;Port=5432;Database=yadlvyzc;UserId=yadlvyzc;Password=b2NCy-wd_58-hEenzMDVqUJA4VYlNWkJ";

    var connection = new NpgsqlConnection(connectionString);
        connection.Open();

    string CREATE_FRIENDS_TABLE = @"create table if not exists friends(
        FriendsName  varchar(40) NOT NULL,
        Count int NOT NULL);";

    connection.Execute(CREATE_FRIENDS_TABLE);

while(userCommand != "exit")
{
Console.WriteLine("Welcome to the Greetings Application.");
Console.WriteLine("Enter: help to see commands you can use on the App");
Console.WriteLine("***********************************");
Console.Write("Please enter a command to: ");
userCommand = Console.ReadLine()!;

string[] users = userCommand.Split(" ");
int counter = 1;

if(users[0] == "greet")
{
    Name = users[1];
    Name = char.ToUpper(Name[0]) + Name.Substring(1);
    Console.WriteLine(greets.MessagesConsole(users));
    greets.greetedFriends(Name, counter);
    Console.WriteLine("****************************************");
}

else if(userCommand == "greeted")
{
    foreach(var key in greets.printNames())
    {
        Console.WriteLine(key.Key + ":" +  key.Value);
    }
    if(greets.printNames().Count() == 0)
    {
        Console.WriteLine("There are no friends in the list");
    }
}
else if(users[0] == "greeted")
{
    Name = users[1];
    // if(greets.printNames().ContainsKey(Name))
    // {
        Console.WriteLine(greets.printName(Name));
        Console.WriteLine("*********************************");
    // }
}
else if(userCommand == "counter")
{
    Console.WriteLine(greets.Counter());
    Console.WriteLine("*********************************");
}
else if(userCommand == "clear")
{   
    Console.WriteLine(greets.ClearAll());
    Console.WriteLine("*********************************");
}
 else if(users[0] == "clear")
{
    if(greets.printNames().Count() != 0)
    {
        Name = users[1];
        Console.WriteLine(greets.Clear(Name));
    }
}
else if(userCommand == "help")
{
    Console.WriteLine("Languages you can greet in are : Isixhosa, English, French and default is Kasi slang");
    Console.WriteLine("Enter: greet [name of friend] language- to greet a friend");
    Console.WriteLine("Enter: greeted - to see names greeted a friend");
    Console.WriteLine("Enter: greeted [name of friend] - to see if a friend has been greeted");
    Console.WriteLine("Enter: clear - to remove all the greeted friends");
    Console.WriteLine("Enter: clear [name of friend] - to remove a name from the greeted names");
    Console.WriteLine("Enter: exit -To exit the Application");
    Console.WriteLine("****************************************************");
}
}
Console.WriteLine("Thank you for using the App Bye!!");