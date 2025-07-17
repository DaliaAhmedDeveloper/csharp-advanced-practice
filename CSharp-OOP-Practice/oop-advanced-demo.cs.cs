//Encapsulation (private و protected و properties)
//Inheritance
//Polymorphism (virtual و override) , Overloading
//Constructor chaining usi ng base(...)
//Overriding methods and change the behavour inside each subclass

namespace Practice.OOP;

class Employee
{
    private string name; // accessable inside same class
    private int salary; // accessable inside same class
    protected string level; // accessable inside same class - child class

    public int Salary // encapsolation  -- it makes salary field read only 
    //  -- public means accessable inside same class - child class - also all objects
    {
        get
        {
            return salary;
        }
    }

    public Employee(string name, int salary, string level)
    {
        this.name = name;
        this.salary = salary;
        this.level = level;
    }

    public virtual float CalculateBonus() // lets say bounus is 20% of salary
    {
        float bounus = salary * 0.2F;
        return bounus;
    }
    // Overloaded method
    public float CalculateBonus(float customPercentage) // Polymorphism(overloading)
    {
        return salary * customPercentage;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine("Employee Information : ");
        Console.WriteLine($"Name is : {name}");
        Console.WriteLine($"Salary is : {salary}");
        Console.WriteLine($"Level is : {level}");
    }

}

class Manager : Employee 
{
    public Manager(string name, int salary, string level) : base(name, salary, level)
    {

    }

    public override float CalculateBonus()
    {
        // float oldBonus = base.CalculateBonus();
        // int extraBonus = 3000;
        // return oldBonus + extraBonus;
        return base.Salary * 0.4F;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        float bounus = CalculateBonus();
        Console.WriteLine($"Bonus is : {bounus}");
    }
}

class Developer : Employee
{
    private int noOfProjects;
    public Developer(int noOfProjects, string name, int salary, string level) : base(name, salary, level)
    {
        this.noOfProjects = noOfProjects;
    }

    public override float CalculateBonus()
    {
        float precentage = base.Salary * .02F;
        float bounus = noOfProjects * precentage;
        return bounus;
    }
}

class Program
{
    static void Main() // tell me again why this main method is static void 
    {
        Manager manager = new Manager("Ali", 20000, "top manager");
        manager.PrintInfo();
        Console.WriteLine(manager.CalculateBonus());
        Developer developer = new Developer(5, "Samy", 6000, "mid level developer");
        developer.PrintInfo();
        Console.WriteLine(developer.CalculateBonus());
    }
}