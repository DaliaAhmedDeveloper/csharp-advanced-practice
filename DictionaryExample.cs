namespace Practice.DictionaryExample;
class Program
{
    static void Main()
    {
        Dictionary<string, string> countries = new Dictionary<string, string>(); // it means take an object from dictionary class

        while (true)
        {
            Console.WriteLine("Enter Key Of Country or finish to finish adding : ");
            string key;
            while (true)
            {
                key = Console.ReadLine();
                if (countries.ContainsKey(key) || key == null || key == "")
                {
                    Console.WriteLine("Please Enter Non Repeated Key and make sure its not empty value");
                }
                else
                {
                    break;
                }
            }
            if (key == "finish")
            {
                foreach (KeyValuePair<string, string> item in countries) // what is KeyValuePair why cant say Dictionary instead
                {
                    Console.WriteLine($"Code: {item.Key} - Country: {item.Value}");
                }
                break;
            }

            Console.WriteLine("Enter Name Of Country : ");
            string name = Console.ReadLine();
            countries.Add(key, name);
        }

        // check other dictionary class methods or properities
        Console.WriteLine(countries.ContainsKey("eg"));
        Console.WriteLine(countries.ContainsValue("egypt"));
        Console.WriteLine(countries.Count);
        var keys = countries.Keys; // what is the type of returned list
        var values = countries.Values; // what is the type of returned list
        countries.Remove("eg"); // this work as ref  -- i dont have to store in new var or it will effect on countries

        if (countries.TryGetValue("ee", out string res))
        {
            Console.WriteLine(res);
        }

        Console.WriteLine("Keys Are :");
        foreach (var key in keys)
        {
            Console.WriteLine(key);
        }
        Console.WriteLine("values Are :");
        foreach (var value in values)
        {
            Console.WriteLine(value);
        }

    }
}