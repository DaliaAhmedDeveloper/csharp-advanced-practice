namespace Practice.Linq;
class Employeee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
    public bool IsActive { get; set; }
}

class Program
{
    static void ShowEmployeesData(List<Employeee> employees)
    {
        int i = 1;
        foreach (Employeee employee in employees)
        {
            Console.WriteLine($"Employee Number {i}");
            Console.WriteLine($"Name :{employee.Name}");
            Console.WriteLine($"Age :{employee.Age}");
            Console.WriteLine($"Salary :{employee.Salary}");
            Console.WriteLine($"Department :{employee.Department}");
            Console.WriteLine($"Status :{employee.IsActive}");
            i++;
        }
    }
    static void Main()
    {
        List<Employeee> employees = new List<Employeee>
        {
            new() { Name = "Ahmed", Age = 35, Department = "IT", Salary = 10000, IsActive = true },
            new() { Name = "Sara", Age = 29, Department = "HR", Salary = 8000, IsActive = false },
            new() { Name = "Khaled", Age = 40, Department = "IT", Salary = 12000, IsActive = true },
            new() { Name = "Laila", Age = 32, Department = "Finance", Salary = 9500, IsActive = true },
            new() { Name = "Tamer", Age = 45, Department = "IT", Salary = 11000, IsActive = false }
        };

        List<Employeee> ItEmployees = employees.Where(employee => employee.Department == "IT").ToList();

        double avg = employees.Where(employee => employee.IsActive == true).Average(employee => employee.Salary);
        double MaxSalary = employees.Max(employee => employee.Salary);
        List<Employeee> EmployeesAge = employees.Where(employee => employee.Age > 30 && employee.Age < 40).ToList();
        var newList = employees.Select(employee => new { employee.Name, employee.Department }); // it generate new list type 

        employees.OrderByDescending(employee => employee.Salary);
        // this suppose to change on epmployees as its obj no need to add result here to new var ?
        // no linq generate new size in  memory so u have to add the result inside new var

        //employees in it departement
        Console.WriteLine("It Departement Employees Are :");
        ShowEmployeesData(ItEmployees);

        //ave and max
        Console.WriteLine($"Average of salary is : {avg}");
        Console.WriteLine($"Max Salary is : {MaxSalary}");
        // employees of age between 30 and 40
        Console.WriteLine(" employees of age between 30 and 40 :");
        ShowEmployeesData(EmployeesAge);
        
        // employees of age between 30 and 40
        Console.WriteLine("employees Name And Deps Are :");
         int i = 1;
        foreach (var employee in newList)
        {
            Console.WriteLine($"Employee Number {i}");
            Console.WriteLine($"Name :{employee.Name}");
            Console.WriteLine($"Department :{employee.Department}");
            i++;
        }

    }
}