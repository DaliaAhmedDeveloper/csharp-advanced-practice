namespace Practice.Tuple;
class Program
{
    enum JobTitle { Manager, Developer, Intern };

    struct Address
    {
        private string country;
        private string city;
        public string Country
        {
            get
            {
                return country;
            }
        }
        public string City
        {
            get
            {
                return city;
            }
        }

        public Address(string country, string city)
        {
            this.country = country;
            this.city = city;
        }
    }
    static void Main()
    {
        static (string name, int age, JobTitle job, Address address) GetEmployeeData(string name, int age, JobTitle job, Address address)
        {
            var person = (Name: name, Age: age, Job: job, Address: address);
            return person;
        }

        Address address = new Address("Egypt", "cairo");
        (string name, int age, JobTitle job, Address address) info = GetEmployeeData("Ali", 23, JobTitle.Manager, address);
        Console.WriteLine($"Name is {info.name}");
        Console.WriteLine($"Age is {info.age}");
        Console.WriteLine($"job is {info.job}");
        Console.WriteLine($"country is {info.address.Country}");
        Console.WriteLine($"country is {info.address.City}");
    }
}