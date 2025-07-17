namespace Practice.SimpleDelegate;
public delegate void MessageHandler(string message);
class Manager
{
    public event MessageHandler OnSent;

    public void Send(string message)
    {
        OnSent?.Invoke(message);
    }
}

class Program
{
    static void Main()
    {
        Manager manager = new Manager();
        manager.OnSent += (msg) => Console.WriteLine(msg);
        manager.OnSent += (msg) => Console.WriteLine(msg + " World");
        manager.Send("hello");
    }
}