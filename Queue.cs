namespace Practice.Queue;
class Program
{
    static void Main()
    {
        Queue<string> names = new Queue<string>();
        while (true)
        {
            Console.WriteLine("Please Enter add to add new , next to remove the next completed one or exist to finish");
            string option;
            while (true)
            {
                option = Console.ReadLine();
                if (option != "add" && option != "next" && option != "exist")
                {
                    Console.WriteLine("Please Enter add to add new , next to remove the next completed one or exist to finish");
                }
                else
                {
                    if (option == "add")
                    {
                        Console.WriteLine("Please Enter The Name");
                        string name = Console.ReadLine();
                        if (!names.Contains(name))
                        {
                            names.Enqueue(name);
                        }
                        else
                        {
                            Console.WriteLine("Name Is Alrady Found");
                        }

                    }
                    else if (option == "next")
                    {
                        if (names.Count > 0)
                        {
                            string name = names.Dequeue();
                            Console.WriteLine($"Next Is {name}");
                        }
                        else
                        {
                            Console.WriteLine("No Body There Please Add New");
                        }
                    }
                    break;
                }
            }

             if (option == "exist")
            {
                break;  
            }
        }
    }
}