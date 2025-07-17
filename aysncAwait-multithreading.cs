namespace Practice.DownloadCenter;
class Download // creata a class for downloads methods
{
    // also i can combine all in one method like 
    public async Task<string> DownloadFile(string fileName, string ext, string type)
    {
        Console.WriteLine($"{fileName}.{ext} Start Downloading");
        if (type == "pdf")
        {
            await Task.Delay(4000);
        }
        else if (type == "image")
        {
            await Task.Delay(2000);
        }
        else if (type == "report")
        {
            await Task.Delay(6000);
        }
        return $"{fileName}.{ext} is Successfully Downloaded";
    }

}
class Program
{
    static async Task Main()
    {
        Download file = new Download();
        // start all tasks 
        Task<string> t1 = file.DownloadFile("myresume", "pdf", "pdf");
        Task<string> t2 = file.DownloadFile("myImage", "png", "image");
        Task<string> t3 = file.DownloadFile("my-report", "docx", "report");

        // Multithreading ,, it means 10 tasks at same time ? ant it will stop the next code and wait to finish 
        // ?? can i put it inside varibale and call it later ? yes put it inside task.run and assign it to var with task type then use wait later
        Parallel.For(0, 10, i =>
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Running on thread {Thread.CurrentThread.ManagedThreadId}");
        });

        Console.WriteLine("My Download Center App After Starting Tasks");
        // wait for first finished task
        Task<string> result = await Task.WhenAny(t1, t2, t3); // will return the first finished task and store it in result
        string resulttxt = await result; // here the actual wait for first finished task returns the result (string)
        // i have a question here if dont write the above line it will continue to the next code or wait for something here 
        // because we said whenany is just return a task
        Console.WriteLine(resulttxt);

        // wait for all tasks to finished
        await Task.WhenAll(t1, t2, t3);
        Console.WriteLine("All Downloads Are Complete");

        await Task.Run(async () => // here i have to use wait with so it will wait to finish , can i put it inside variable and await it later ?? yes task type
        {
            for (int i = 1; i <= 3; i++)
            {
                string time = DateTime.Now.ToString("HH:mm:ss tt");
                Console.WriteLine(time);
                await Task.Delay(1000); // delay inside Task.Run (synchronous wait)
            }
        });

    }
}

// Task.Run()  -- fast way to run task instead of async/await ,, speacially if you dont want to use await 
// It runs the task inside a new thread from the thread pool.
// Be careful when using it repeatedly, as too many concurrent threads can overload the CPU.