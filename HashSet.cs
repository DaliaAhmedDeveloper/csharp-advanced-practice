namespace Practice.HashSet;
class Program
{
    static void Main()
    {
        HashSet<string> names = new HashSet<string>(); // generic class can take any type of data

        while (true)
        {
            Console.WriteLine("Enter New Name ,, to show to show all list or exit to close");
            string name = Console.ReadLine();
            if (name == "show")
            {
                 if (names.Count > 0)
                {
                    foreach (string nameVal in names)
                {
                    Console.WriteLine(nameVal);
                }
                }
                else
                {
                    Console.WriteLine("Nothing to show");
                }
               
            }
            else if (name == "exit")
            {
                break;
            }
            else
            {
                if (!names.Contains(name))
                {
                    names.Add(name);
                    Console.WriteLine($"Welcome {name}");
                }
                else
                {
                    Console.WriteLine("This Name Is Alrady Registered !");
                }
            }

        }
    }
}