namespace Practice.Indexer;
class Student
{
    private int number_of_students;
    private string[] students;
    public int NumberOfStudents
    {
        get
        {
            return number_of_students;
        }
        set
        {
            number_of_students = value;
            students = new string[number_of_students];
        }
    }
    // define an indexer to work with students array direct from the class object in the array way instead of creating a method for this
    public string this[int index] // i have a question here i didnt give indexer a name what if i have more than one array so i need more than one indexer
    {
        get
        {
            return students[index];
        }
        set
        {
            students[index] = value;
        }
    }
}

class Degrees // why i put here public
{
    public double? math;
    public double? arabic;
    public  double? english;
    public static double degreesAvg { get; set; }

}

static class MathExtensions
{
    public static double CustomAvg(this Degrees degrees)
    {
        double sum = 0;
        if (degrees.math != null)
        {
            sum += (double)degrees.math;
        }
        if (degrees.arabic != null)
        {
            sum += (double)degrees.arabic;
        }
        if (degrees.english != null)
        {
            sum += (double)degrees.english;
        }
        return sum / 3;
    
    }
}

class Program16
{
    static void Main16()
    {
        Console.WriteLine("Please Enter The Number Of Students");
        Student student = new Student();
        int n_of_names;
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int res))
            {
                student.NumberOfStudents = res;
                n_of_names = res;
                break;
            }
            else
            {
                Console.WriteLine("Please Enter The Correct Number Of Students");
            }
        }

        Console.WriteLine("Please Enter The names of students if you want to exist write exist");
        int i = 0;
        while (i < n_of_names)
        {
             Console.WriteLine($"Please Enter Name Number {i+1}");
            string input = Console.ReadLine();
            if (input == "exist")
            {
                break;
            }
            student[i] = input;
            Console.WriteLine("Please Enter The Degrees of student in order math , arabic and english enter empty if you dont know the degree yet ,, hit enter after each input");
            int y = 1;
            Degrees degrees = new Degrees();
            while (true)
            {
                // Console.WriteLine(y);
                string input2 = Console.ReadLine();
                if (double.TryParse(input2, out double res))
                {
                    if (y == 1)
                    {
                        degrees.math = res;
                    }
                    else if (y == 2)
                    {
                        degrees.arabic = res;
                    }
                    else if (y == 3)
                    {
                        degrees.english = res;
                        break;
                    }
                }
                else if (input2 == "empty")
                {
                    if (y == 1)
                    {
                        degrees.math = null;
                    }
                    else if (y == 2)
                    {
                        degrees.arabic = null;
                    }
                    else if (y == 3)
                    {
                        degrees.english = null;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter Correct Value");
                    y--;
                }
                y++;
            }
            Degrees.degreesAvg = degrees.CustomAvg();
            Console.WriteLine($"Avarage degrees is : {Degrees.degreesAvg}");
            i++;
        }
    }
}