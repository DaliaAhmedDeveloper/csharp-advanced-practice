namespace Practice.DelegateEvent;
delegate void TestSpeed(); // declare a delegate type  to store method without return -- and without params
class Car
{
    public event TestSpeed TestSpeedEvent; // declare event of type testspeed -- its public but cant change outside this class -- only you can add to it 
    private int speed;
    public int Speed
    {
        get
        {
            return Speed;
        }
    }

    public Car(int speed)
    {
        this.speed = speed;
    }

    public void checkSpeed() // here will invoke the event 
    {
        Console.WriteLine("Check Speed Stated ...");
        TestSpeedEvent?.Invoke();  // null conditional operator 
    }
}

class Program
{
    static void limitExceeded() // this  should be static to add to event ?? yes because u use it inside static method
                                // static methods must working with static methods also inside 
                                //أي دالة static في C#، زي Main()، لا يمكن تنادي على دوال أو خصائص غير static إلا من خلال كائن (object).
    {
        Console.WriteLine("Warning : speed limit exceeded!");
    }
    static void Main()
    {
        Console.WriteLine("Enter Speed :");
        string speed = Console.ReadLine();
        while (true)
        {
            if (int.TryParse(speed, out int res) && res > 0) {
                if (res > 100)
                {
                    Car car = new Car(res);
                    car.TestSpeedEvent += limitExceeded; // i can add many methods as i want 
                    car.checkSpeed();
                }
                else
                {
                    Console.WriteLine("Safe Speed");
                }
                break;
            } else
            {
                Console.WriteLine("Wrong value");
            }
        }
    }
}