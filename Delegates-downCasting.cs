namespace Practice.Delegates;
delegate double Operation(double x, double y);
delegate void Notify(string str);

class Notifier
{
    public event Notify OnNotify;
    public void NotificationReceived(string str)
    {
        Console.WriteLine("Notification Received");
        OnNotify?.Invoke(str);
    }
}

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}
class Animal
{
    public virtual void speak()
    {
        Console.WriteLine("This is speak method");
    }
    public virtual void downCast()
    {
         Console.WriteLine("Down casting ...");
    }
}
class Dog : Animal
{
    public override void speak()
    {
        base.speak();
        Console.WriteLine("Haw Haw Haw ...");
    }
    public new void downCast()
    {
         Console.WriteLine("Down casting inside dog  ...");
    }
}

class Cat : Animal
{
    public override void speak()
    {
        base.speak();
        Console.WriteLine("naw naw naw ...");
    }
}

struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
    
}
class Program
{
    static void Main()
    {
        // first task 
        Operation addition = (x, y) => x + y;
        Operation sub = (x, y) => x - y;
        Func<int, int, int> multiply = (x, y) => x * y;
        Predicate<string> checkString = (str) => str.StartsWith("A");

        Console.WriteLine(addition(6, 8));
        Console.WriteLine(sub(100, 80));
        Console.WriteLine(multiply(10, 80));
        Console.WriteLine(checkString("Ali"));

        //second task 
        Notifier notification = new Notifier();
        notification.OnNotify += (str) => Console.WriteLine($"String Is : {str}");
        notification.OnNotify += (str) => Console.WriteLine($"Hello form the other side this is my str  : {str}");
        notification.NotificationReceived("hiiii");

        // third task
        List<Product> products = new List<Product>
        {
            new Product{Name = "product 1" , Price = 233 , Stock = 5 },
            new Product{Name = "product 2" , Price = 33 , Stock = 6 },
            new Product{Name = "product 3" , Price = 200 , Stock = 8 },
            new Product{Name = "product 4" , Price = 213 , Stock = 0 },
            // i have question here how can i create list of anoynoumus type without create Product class
        };

        var products2 = new[]
        {
            new { Name = "product 1", Price = 233.0, Stock = 5 },
            new { Name = "product 2", Price = 33.0, Stock = 6 },
            new { Name = "product 3", Price = 200.0, Stock = 8 },
            new { Name = "product 4", Price = 213.0, Stock = 0 }
        }.ToList();

        try
        {
            List<Product> productsLessThanFifty = products.Where(product => product.Price < 50).ToList();
            List<Product> outOfStock = products.Where(product => product.Stock == 0).ToList();
            double avg = products.Average(product => product.Price);
            var newObj = products.Select(product => new { product.Name, product.Price });

            // products less than 50
            foreach (Product product in productsLessThanFifty)
            {
                Console.WriteLine("Products Less Than 50");
                Console.WriteLine($"Name Is : {product.Name}");
                Console.WriteLine($"Price Is : {product.Price}");
                Console.WriteLine($"Stock Is : {product.Stock}");
            }

            // out of stock products 
            foreach (Product product in outOfStock)
            {
                Console.WriteLine("Products Less Than 50");
                Console.WriteLine($"Name Is : {product.Name}");
                Console.WriteLine($"Price Is : {product.Price}");
                Console.WriteLine($"Stock Is : {product.Stock}");
            }

            // new product object
            foreach (var product in newObj)
            {
                Console.WriteLine("Products of new list");
                Console.WriteLine($"Name Is : {product.Name}");
                Console.WriteLine($"Price Is : {product.Price}");
            }

            Console.WriteLine($"Avarage of prices Is : {avg}");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something Went Wrong" + e.GetBaseException());
        }

        //forth task
        List<Animal> animals = new List<Animal>();
        Animal dog = new Dog();
        animals.Add(dog);
        Animal cat = new Cat();
        animals.Add(cat);
        foreach (Animal animal in animals)
        {
            animal.speak();
        }

        dog.downCast(); // will call from animal class
        Dog dogi = (Dog)dog; // down casting from animal to dog
        dogi.downCast();  // will call from dog class

        Point point = new Point();
        point.X = 7;

        Point point2 = point;
        point2.X = 10;

        Console.WriteLine(point.X);
        Console.WriteLine(point2.X);

    }
}
