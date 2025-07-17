// # HR System Program

interface IPrintablee
{
    public void PrintInfo();
}
abstract class Person : IPrintablee
// abstruct it may contains abstruct methods which is only a shape without body or normal methods 
// can contains fields or properties
// can inhirit -- once its inhirit the abstract methods must be override and has body here 
// child class also can be adstract in this case no need to override the abstract methods in parent class 
// i have to use abstract keyword for a class contains abstract methods 
{

    private string name; // encapsulation
    private int age;
    private string gender;

    public Person(string name, int age, string gender)
    {
        this.age = age;
        this.name = name;
        this.gender = gender;
    }

    public string Name // read oonly
    {
        get
        {
            return name;
        }
    }

    public int Age //read only
    {
        get
        {
            return age;
        }
    }

    public string Gender // i make it read/write
    {
        get
        {
            return gender;
        }
        set // here its not returnable
        {
            Console.WriteLine($"your updated gender is : {value}");
        }
    }
    public abstract string getInfo();

     public void PrintInfo()
    {
        Console.WriteLine("Im a Person");
    }

    public void Describe()
    {
        Console.WriteLine("This is person !");
    }
}

class Employee : Person , IPrintablee
{
    private double employeeID;
    private double salary;
    private string level;
    private double bonus; // double type is less than float in size but large in numbers after decimal point is it correct ?

    public double Salary
    {
        get
        {
            return salary;
        }
    }
    public Employee(string name, int age, string gender, double salary, double employeeID, string level) : base(name, age, gender)
    {
        this.salary = salary;
        this.employeeID = employeeID;
        this.level = level;
    }
    public override string getInfo()
    {
        return $"Your name is : {base.Name} , Your age is : {base.Age} , Your Gender is : {base.Gender}"; // string interpolation
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Your name is : {base.Name}"); // string interpolation
        Console.WriteLine($"Your age is : {base.Age}");
        Console.WriteLine($"Your Gender is : {base.Gender}");
    }
    public virtual double CalculateBonus()
    {
        bonus = salary * .2;
        return bonus;
    }
}

class Manager : Employee , IPrintablee
{
    private string department;
    public Manager(string name, int age, string gender, double salary, double employeeID, string level, string department) : base(name, age, gender, salary, employeeID, level)
    {
        this.department = department;
    }
    public override string getInfo()
    {
        return $"Your name is : {base.Name} , Your age is : {base.Age} , Your Gender is : {base.Gender} , Your Salary is : {base.Salary} , Your Department is : {department}"; // string interpolat
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Your name is : {base.Name}"); // string interpolation
        Console.WriteLine($"Your age is : {base.Age}");
        Console.WriteLine($"Your Gender is : {base.Gender}");
        Console.WriteLine($"Your Salary is : {base.Salary}");
        Console.WriteLine($"Your Department is : {department}");
    }
    public override double CalculateBonus()
    {
        // Console.WriteLine("Normal Bonus is :");
        // base.CalculateBonus();
        double newBounus = base.Salary * .4;
        return newBounus;
    }
}

class Intern : Employee , IPrintablee
{
    private string university;
    public Intern(string name, int age, string gender, double salary, double employeeID, string level, string university) : base(name, age, gender, salary, employeeID, level)
    {
        this.university = university;
    }

    public override string getInfo()
    {
        return $"Your name is : {base.Name} , Your age is : {base.Age} , Your Gender is : {base.Gender} , Your Salary is : {base.Salary} , Your University is : {university}";
    }
    
     public override void PrintInfo()
    {
        Console.WriteLine($"Your name is : {base.Name}"); // string interpolation
        Console.WriteLine($"Your age is : {base.Age}");
        Console.WriteLine($"Your Gender is : {base.Gender}");
        Console.WriteLine($"Your Salary is : {base.Salary}");
        Console.WriteLine($"Your University is : {university}");
    }

    public override double CalculateBonus()
    {
        return 0;
    }
}

class Program5
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        Console.WriteLine("Please Enter Number Of Employees");
        while (true)
        {
            string val = Console.ReadLine();
            if (int.TryParse(val, out int result) && result > 0 && result < 10)
            {
                for (int i = 0; i < result; i++)
                {
                    Console.WriteLine($"Please Enter Type Of Employee {i + 1} -- Enter Manager Or Intern");
                    while (true)
                    {
                        string type = Console.ReadLine();
                        if (type == "Manager" || type == "Intern")
                        {
                            Console.WriteLine("Please Enter The Name :");
                            string name = Console.ReadLine();

                            Console.WriteLine("Please Enter The Age :");
                            int age;
                            while (true)
                            {
                                string agestr = Console.ReadLine();
                                if (int.TryParse(agestr, out int res) && res > 0)
                                {
                                    age = res;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please Enter Correct Age :");
                                }
                            }

                            Console.WriteLine("Please Enter The Gendar :");
                            string gendar = Console.ReadLine();

                            Console.WriteLine("Please Enter The Level :");
                            string level = Console.ReadLine();

                            Console.WriteLine("Please Enter The salary :");
                            double salary;
                            while (true)
                            {
                                string salarystr = Console.ReadLine();
                                if (double.TryParse(salarystr, out double res) && res > 0)
                                {
                                    salary = res;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please Enter Correct Salary :");
                                }
                            }


                            Console.WriteLine("Please Enter The employeeID :");
                            double employeeID;
                            while (true)
                            {
                                string employeeIDStr = Console.ReadLine();

                                if (double.TryParse(employeeIDStr, out double res) && res > 0)
                                {
                                    employeeID = res;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please Enter Correct ID :");
                                }
                            }

                            if (type == "Manager")
                            {
                                Console.WriteLine("Please Enter Department :");
                                string department = Console.ReadLine();

                                Manager manager = new Manager(name, age, gendar, salary, employeeID, level, department);
                                Employee manager_o = manager; //upcasting
                                employees.Add(manager_o);
                            }
                            if (type == "Intern")
                            {
                                Console.WriteLine("Please Enter University :");
                                string university = Console.ReadLine();
                                Employee intern = new Intern(name, age, gendar, salary, employeeID, level, university);
                                employees.Add(intern);
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter correct type");
                        }
                    }
                }
                break;
            }
            else
            {
                Console.WriteLine("Please Enter Correct Number");
            }
        }

        double totalSalary = 0;
        double totalBonus = 0;
        // loop through list of objects type employee
        foreach (Employee employee in employees)
        {
            Console.WriteLine(employee.getInfo());
            employee.PrintInfo();
            totalSalary += employee.Salary;
            totalBonus += employee.CalculateBonus();
        }

        Console.WriteLine($"Total Salary is {totalSalary}");
        Console.WriteLine($"Total Bonus is {totalBonus}");
    }
}
