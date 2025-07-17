namespace Practice.Files;

class MyFile
{
    public void fileWithAction(string path, string action, string text = "This is default text", string des = "")
    {
        bool fileExist = File.Exists(path);
        try
        {
            if (fileExist)
            {
                if (action == "read")
                {
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else if (action == "write")
                {
                    File.WriteAllText(path, text);
                    Console.WriteLine("Your text replaced successfully");
                }
                else if (action == "copy")
                {
                    File.Copy(path, des);
                    Console.WriteLine("Your file copied successfully");
                }
                else if (action == "move")
                {
                    File.Move(path, des);
                    Console.WriteLine("Your file moved successfully");
                }
                else if (action == "append")
                {
                    File.AppendAllText(path, text);
                    Console.WriteLine("Your text added successfully");

                }
                else if (action == "delete")
                {
                    File.Delete(path);
                    Console.WriteLine("Your text deleted successfully");
                }
            }
            else
            {
                if (action == "create")
                {
                    FileStream fs = File.Create(path);
                    Console.WriteLine("Your file created successfully");
                    fs.Close();
                }
                else
                {
                    Console.WriteLine("No such file");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }
}
class Program
{
    static void Main_01()
    {
        string path = "../test.txt";
        MyFile file = new MyFile();
        file.fileWithAction("../test2.txt", "create");
        file.fileWithAction(path, "read");
        file.fileWithAction(path, "write", "this is my text !");
        file.fileWithAction(path, "append", "this is my text !");
        file.fileWithAction("../test2.txt", "delete");
        file.fileWithAction("../test3.txt", "create");
        file.fileWithAction("../test3.txt", "move", "", "../../testmoved.txt");
        file.fileWithAction("../test4.txt", "create");
        file.fileWithAction("../test4.txt", "copy", "", "../testcopy.txt");

        string pathh = "../students.txt";
        // if (!File.Exists("../students.txt"))
        // {
        //     using (FileStream fs = File.Create("../students.txt"))
        //     {
        //         Console.WriteLine("Students File Created Successfully !"); // when this suppose to run ?

        //     }
        // }
        List<string> names = new List<string> { "sara", "magi", "mona" };
        // no need to use .create file before this line since this method check if file exists first if not it will create the file
        //also AppendAllText , WriteAllText , WriteAllLines , but if u want to print some text or add some code when the file created and closed 
        // use the above way to create the file
        File.AppendAllLines(pathh, names);

        string[] readNames = File.ReadAllLines(pathh);
        foreach (string name in readNames)
        {
            Console.WriteLine(name);
        }
        File.Delete("../students.txt");

        using (StreamWriter writer = new StreamWriter("names.txt")) // using for close file after add these lines
        {
            writer.WriteLine("Ali");
            writer.WriteLine("Sara");
            writer.WriteLine("Samy");
        }

        using (StreamReader reader = new StreamReader("names.txt")) // using here means insure the file will automatically close 
        {
            string? line = reader.ReadLine(); // return first line
            while (line != null)
            {
                Console.WriteLine(line);
                line = reader.ReadLine(); //return next line ,, every time call this method it will return next line 
            }
        }
        // file class vs StreamReader
        // file class : is good for small files with low control because it loads all file content to memory then start work on it 
        // this means needs more memory if file is large and can throw OutOfMemoryException ,, read only from disk not from streem like http
        // StreamReader : loads the file to memory line by line work on it then remove from memory so its good for large files
        // also has extra mehods for more control like read from stream like http and from the disk also 
    } 
}
