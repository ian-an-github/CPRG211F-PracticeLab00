namespace PracticeLab00F;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to CPRG211F - Lab0");

        // Task 1 - Creating variables
        // Declare Variables
        double sum = 0;
        bool hasPrime = false;

        // Store the low number as an int variable.
        int lowNum = GetLowNumber();

        // Store high number as int
        int highNum = GetHighNumber(lowNum);

        // Calculate difference
        int difference = highNum - lowNum;

        // Print Difference
        Console.Write($"Difference of {lowNum} and {highNum} is {difference}. \n");

        // Task 3 - Using Arrays ans File I/O
        //  Store the numbers between low and high
        List<double> numbers = new List<double>();
        for (double i = highNum - 1; i >= lowNum + 1; i--)
        {
            numbers.Add(i);
        }

        using (StreamWriter file = new StreamWriter(@"..\..\..\numbers.txt"))
        {
            foreach (double number in numbers)
            {
                file.WriteLine(number);
            }
        }

        using (StreamReader reader = new StreamReader(@"..\..\..\numbers.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                sum += double.Parse(line);
            }
        }
        Console.WriteLine($"The sum of numbers between {lowNum} and {highNum}: {sum}");

        Console.WriteLine($"The Prime numbers between {lowNum} and {highNum} are: ");

        foreach (double number in numbers)
        {
            if (IsPrime(number))
            {
                Console.WriteLine(number);
                hasPrime = true;
            }
        }

        if (hasPrime == false)
            { 
            Console.WriteLine(" There are no prime numbers ");
             }
    }

    public static int GetLowNumber()
    {
        int newLow = 0;
        Console.Write("Please enter a low number: ");
        while (true)
        {
            string userInput = Console.ReadLine();
            // Task 2 - loop until higher number
            bool t = int.TryParse(userInput, out newLow);
            if (t && newLow > 0)
            {
                return newLow;
            }
            else
            {
                Console.Write("Invalid input, please re-enter a positive number: ");
            }
        }
    }

    public static int GetHighNumber(int lowNum)
    {
        int newHigh = 0;
        Console.Write("Please enter a high number: ");
        while (true)
        {
            string userInput = Console.ReadLine();
            // Task 2 - loop until higher number
            bool t = int.TryParse(userInput, out newHigh);
            if (t && newHigh > lowNum)
            {
                return newHigh;
            }
            else
            {
                Console.Write($"Invalid input, please re-enter a number greater than {lowNum}: ");
            }
        }
    }

    public static bool IsPrime(double number)
    {
        if (number < 2) return false;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}