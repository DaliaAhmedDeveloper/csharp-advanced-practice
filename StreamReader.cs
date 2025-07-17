namespace Practice.Stream;
class Program
{
    static async Task Main()
    {
        try // for error handling ,, for unexpected errors
        {
            using (HttpClient client = new HttpClient()) // START connection run the block of code then close it 
            {
                await Task.Run(async () => // await here is for run the task inside a thread of thread pool and wait the response 
                {
                    // await here means stop here and wait for external response if no await outside it will continue the rest of code outside this method 
                    HttpResponseMessage response = await client.GetAsync("https://raw.githubusercontent.com/dwyl/english-words/master/words.txt");
                    if (response.IsSuccessStatusCode)
                    {
                        // using here to close the stream after
                        using (Stream stream = await response.Content.ReadAsStreamAsync()) // create new stream to get file content chunk by chunck to save memory -- using to close the stream and free the resources
                        using (StreamReader reader = new StreamReader(stream)) // / Reads text line by line from the stream ,, i have to use using here to free resources used by streamReader even its read read from another stream without creating a new one 
                        {
                            string? line; // line can be null or string ,, means put null if no string 
                            while ((line = reader.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                                if (line.Contains("error"))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    // Console.WriteLine(response);
                });
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error : {e.Message}");
        }
    }
}