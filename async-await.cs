namespace Practice.AsyncAwait;
class Program
{
    static string data = "Basic text";
    // Task returned void
    // Task<T> returned value
    static async Task DownloadFile(string fileName, int delay, string result)
    // async means this method contains await ,, 
    // Task is the reurned data yes no return key word here  but because in contains await the returned value will be task 
    // its like promise ,, i will do something and after some time i will return back with result i dont know what result is maybe its exception
    {
        Console.WriteLine($"Start Downloading {fileName}");
        await Task.Delay(delay); // delay 1 sec , await keyword means wait for result then print done , if no await the next line will run without waiting this delay time
        Console.WriteLine($"Done downloading {fileName}.");
        data = result;
    }
    static async Task Main() // program entry point ,, here also async means this will contains await , Task Means returned value
    {
        try
        {
            Task task1 = DownloadFile("file_1", 1000, "this is the first file"); // task started but didnt wait yet
            Task task2 = DownloadFile("file_2", 3000, "this is the second file"); // task started but didnt wait yet
            Task task3 = DownloadFile("file_3", 5000, "this is the third file"); // task started but didnt wait yet

            Console.WriteLine(data); // suppose to return basic txt;
            await task1;
            Console.WriteLine(data); // suppose to return this is the first file
            await task2;
            Console.WriteLine(data); // suppose to return this is the second file
            await task3;   // if not wiat it will print prev value
            Console.WriteLine(data); // suppose to return this is the third file
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error : Something Went Wrong {e.Message}");
        }

    }
}