namespace Practice.Dictionary;

class Program
{

    // determine avarage and if its less than 400 make it 400 
    static void avg(ref double avg) // why we cant use pass by value here 
                                    // -- its because if u pass value you have to create another variable to store it 
                                    // but pass as refrence u will change the value of it direct so you can access it from outside method scope 
    {
        if (avg < 50)
        {
            avg = 50;
        }
        //return avg; and u dont need to return the value here 
    }

    // determine max degree 
    static void max(out double max, int[] degrees)
    {
        max = double.MinValue;
        foreach (double x in degrees)
        {
            if (x > max)
            {
                max = x;
            }
        }
    }
    static void Main()
    {
        Dictionary<string, int[]> students = new Dictionary<string, int[]>();
        students.Add("Ali", [80, 50, 10, 15, 10]);
        students.Add("Samy", [120, 90, 20, 25, 70]);
        students.Add("Sara", [180, 100, 20, 15, 80]);
        students.Add("Somaia", [200, 90, 20, 15, 60]);

        List<int> avarages = new List<int>();  //List generec
        foreach (KeyValuePair<string, int[]> student in students)
        {
            double avgValue = student.Value.Average();
            avg(ref avgValue);
            avarages.Add((int)avgValue); // explicit casting
            double maxval;
            max(out maxval, student.Value); // i used out here to be access outside method without return value 
                                            // but im little bit confusing here -- when to decide to use out or ref 
                                            // in this case i can use ref as i can assign double.maxvalue before calling the method

            var studentInfo = () => Console.WriteLine($" Student Name is  : {student.Key}"); // lamba 

            var degreesInfo = delegate ()
            { // anouynoumus 
                Console.WriteLine($"{student.Key} Avarage of degrees is : {avgValue}");
                Console.WriteLine($"{student.Key} Max degree is : {maxval}");
            };

            // here ican assign method to var no need to delegate 
            // but if i want to add more than one method i have to use delegate 

            studentInfo();
            degreesInfo();
        }

        Console.WriteLine("All Averages Are :");
        foreach (int avg in avarages)
        {
            Console.Write($"{avg} , ");
        }
    }

}