namespace Practice.AbstractInterface;
abstract class Shape // abstruct class -- can contain abstruct methods without body or normal method 
//-- also can contain fields and properties
{
    public string name // property called name of type string and public to be access in the child class and objects
    {
        get;
    }

    public abstract double CalculateArea(); // abstruct method withoutcode 
    public void Describe() // normal method
    {
        Console.WriteLine("This Is a Shape");
    }

}
interface IPrintable
{
    public void PrintInfo();
}

class Rectangle : Shape, IPrintable
{
    private double height;
    private double width;
    private string shapeName;
    public string name
    {
        get
        {
            return shapeName;
        }
    }

    public Rectangle(double height, double width, string name)
    {
        this.height = height;
        this.width = width;
        shapeName = name; // prefer to add this to be more understanable -- but i will keep it like this to proven i understand
    }
    public override double CalculateArea()
    {
        double area = height * width;
        return area;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Width of {name} equals {width}");
        Console.WriteLine($"Height of {name} equals {height}");
        Console.WriteLine($"Area of {name} equals {CalculateArea()}");
    }
}
class Circle : Shape, IPrintable
{
    private double raduis;
    private string shapeName;
    public string name
    {
        get
        {
            return shapeName;
        }
    }
    public Circle(double raduis, string name)
    {
        this.raduis = raduis;
        shapeName = name; // prefer to add this to be more understanable -- but i will keep it like this to proven i understand
    }
    public override double CalculateArea()
    {
        double area = raduis * raduis;
        return area;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Raduis of {name} equals {raduis}");
        Console.WriteLine($"Area of {name} equals {CalculateArea()}");
    }
}
class Program
{
    static void Main() // the entry point of the project
    {
        Rectangle rec = new Rectangle(100, 200, "rec");
        Console.WriteLine(rec.name);
        rec.CalculateArea();
        rec.Describe();
        rec.PrintInfo();

        Circle circle = new Circle(100, "Circle");
        Console.WriteLine(circle.name);
        circle.CalculateArea();
        circle.PrintInfo();
    }
}