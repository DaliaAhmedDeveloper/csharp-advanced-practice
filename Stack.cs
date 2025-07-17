namespace Practice.Stack;
class Program
{
    static void Main13()
    {
        Stack<string> strings = new Stack<string>(); // generic class can take any type of data

        while (true)
        {
            Console.WriteLine("Enter New String ,, if you want to undo just write undo or show to show all text or exit to close");
            string txt = Console.ReadLine();

            if (txt == "undo")
            {
                if (strings.Count > 0)
                {
                    strings.Pop();
                    Console.WriteLine("Last text is removed successfully");
                }
                else
                {
                    Console.WriteLine("Nothing to undo");
                }
            }
            else if (txt == "show")
            {

                foreach (string txtt in strings.Reverse())
                {
                    Console.Write($" {txtt} ");
                }
            }
            else if (txt == "exit")
            {
                break;
            }
            else
            {
                strings.Push(txt);
                Console.WriteLine("Text Is Added Successfully");
            }

        }
    }
}