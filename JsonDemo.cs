namespace Practice.JsonExample;

using System.Text.Json; // Using System.Text.Json namespace to access built-in JSON serialization classes (not added dynamically; it's a standard library in .NET Core and later).

//basic methods of json 
//1.JsonSerializer.Serialize() : Covert Object To Json
//2.JsonSerializer.Deserialize<T>() : Convert Json To Object
//3.JsonSerializer.Serialize(myObject, options) : convert object to json with options
//4.JsonDocument.Parse() : only read the json without convert it to object -- useful if u dont know the structure
//5.GetProperty("propertyName") : Read properity with a key
//6.JsonElement root = doc.RootElement; :  An object representing any part of the JSON tree. Use it when working with JSON that has no known format.

class User
{
    // encapsulation -- make user data private cant access it direct ,, you can only read its value using property and cant able to change its value 
    private int id;
    private string name;
    private string email;
    private bool isActive;

    public int ID
    {
        get
        {
            return id;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
    }
    public string Email
    {
        get
        {
            return email;
        }
    }
    public bool IsActive
    {
        get
        {
            return isActive;
        }
    }
    public User(int id, string email, string name, bool isActive)
    {
        this.id = id;
        this.email = email;
        this.name = name;
        this.isActive = isActive;
        //'this' refers to the current instance — used here to avoid naming conflict between parameters and fields
    }
}
class Program // program can be any other name
{
    static void Main() // static for accessing Main method direct from its class since it the entry point of the program , void means return nothing
    {
        // create list of 3 users
        List<User> users = new List<User>() // <T> means Generic so you can specify the type here -- list is generic class
         {
            new User(12987 , "dalia@gmail.com" , "dalia" , true),
            new User(10766 , "ali@gmail.com" , "ali" , true),
            new User(17989 , "mona@gmail.com" , "mona" , false),
        };
        try
        {
            // convert list of objects to json
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, 
                PropertyNameCaseInsensitive = false 
            };

            string jsonData = JsonSerializer.Serialize(users, options); // options here is optional
            File.WriteAllText("../users.json", jsonData); // Creates the file if it doesn't exist, or overwrites it if it does

            if (File.Exists("../users.json"))
            {
                string jsonContent = File.ReadAllText("../users.json");
                Console.WriteLine(jsonContent);
                List<User>? usersBackFromJson = JsonSerializer.Deserialize<List<User>>(jsonContent);
                if (usersBackFromJson != null)
                {
                    foreach (User user in usersBackFromJson)
                    {
                        Console.WriteLine($"User ID Is {user.ID}"); // string interpolation ,, to be able to add  variabled inside string using dollar sign at the begaining
                        Console.WriteLine($"Name Is {user.Name}");
                        Console.WriteLine($"Email Is {user.Email}");
                        Console.WriteLine($"Active Status Is {user.IsActive}");
                        Console.WriteLine("-------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("The File May Not Having Any Content Inside");
                }
            }
            else
            {
                Console.WriteLine("No Such File");
            }

            // read from json without convert it to obj
            string jsonDoc = "{\"ID\":12987,\"Name\":\"dalia\",\"Email\":\"dalia@gmail.com\",\"IsActive\":true}";
            var doc = JsonDocument.Parse(jsonDoc); // read only users.json file without manually convert it to obj -- make it readable
            var name = doc.RootElement.GetProperty("Name").GetString(); // create obj from json that u can read properties from it
            Console.WriteLine($"The Name From Json File Is {name}"); // dalia

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error : {e.Message}");
        }
    }
}