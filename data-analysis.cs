
namespace Practice.DataAnalysis;
class DataAnalysis
{
    private int noOfEntry;
    private List<int> numbersArr = new List<int>();
    private List<int> primes = new List<int>();
    public DataAnalysis(int noOfEntry)
    {
        this.noOfEntry = noOfEntry;
        // this.numbersArr = new int[noOfEntry];
    }

    public void numbers()
    {
        for (int i = 0; i < noOfEntry; i++)
        {
            Console.WriteLine($"Please Enter Number {i + 1} : ");
            string val = Console.ReadLine();
            if (int.TryParse(val, out int result))
            {
                // numbersArr[i] = result;
                numbersArr.Add(result);
            }
            else
            {
                Console.WriteLine("Please Enter a Valid Number");
                i--;
            }
        }
    }

    private bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    private void evenOrOdd(int number)
    {
        if (number % 2 == 0)
        {
            Console.WriteLine("This Number Is Even Number");
        }
        else
        {
            Console.WriteLine("This Number Is Odd Number");
        }
    }

    private void negativeOrPositive(int number)
    {
        if (number > 0)
        {
            Console.WriteLine("This Number Is Positive");
        }
        else if (number < 0)
        {
            Console.WriteLine("This Number Is Negative");
        }
        else
        {
            Console.WriteLine("This Number Is zero");
        }
    }

    private void divideByThreeAndFive(int number)
    {
        if (number % 3 == 0 && number % 5 == 0)
        {
            Console.WriteLine("This Number is Able to divide by 3 and 5 together");
        }
    }
    private void maxAndMin()
    {
        int max = int.MinValue;
        int min = int.MaxValue;
        foreach (int number in numbersArr)
        {
            if (number > max)
            {
                max = number;
            }
            if (number < min)
            {
                min = number;
            }
        }

        Console.WriteLine($"Max Value is {max} , min value is {min}");
    }

    private void avg()
    {
        double sum = numbersArr.Sum(x => Convert.ToDouble(x));
        double avg = sum / numbersArr.Count();
        Console.WriteLine($"The Avarage of numbers is {avg}");
    }
    public void showData()
    {
        foreach (int number in numbersArr)
        {
            Console.WriteLine($"Information For Number {number} is : ");
            // even or odd
            evenOrOdd(number);

            //prime
            if (IsPrime(number))
            {
                Console.WriteLine("This Number Is Prime");
                primes.Add(number);
            }
            else
            {
                Console.WriteLine("This Number Is Not Prime");
            }

            // is negative , positive , 0
            negativeOrPositive(number);

            // divide by 3 and 5 together
            divideByThreeAndFive(number);
        }

        maxAndMin();
        avg();

        Console.WriteLine("Primes Are : ");
        foreach (int prime in primes)
        {
            Console.WriteLine(prime);
        }
    }
}

class Program
{
    static void Main() // tell me again why this main method is static void 
    {

        Console.WriteLine("Please Enter Number Of Entries");
        while (true)
        {
            string val = Console.ReadLine();
            if (int.TryParse(val, out int result))
            {
                DataAnalysis data_analysis = new DataAnalysis(result);
                data_analysis.numbers();
                data_analysis.showData();
                break;
            }
            else
            {
                Console.WriteLine("Please Enter a Valid Number");
            }
        }
    }
}