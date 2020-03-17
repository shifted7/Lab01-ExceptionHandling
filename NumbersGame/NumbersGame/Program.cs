using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the number game!");
                StartSequence();
            }
            catch (Exception e) // Handle generic exception
            {
                Console.WriteLine("Something happened that was not correct.");
                Console.WriteLine(e.Message);
            }
        }
        static void StartSequence()
        {
            try
            {
                Console.WriteLine($"Please enter a number greater than zero: ");
                string userInput = Console.ReadLine();
                int[] userNumbers = new int[Convert.ToInt32(userInput)]; // Creates array of length specified by user
                userNumbers = Populate(userNumbers);
                int sum = GetSum(userNumbers);
                int product = GetProduct(userNumbers, sum);
                GetQuotient(product);
            }
            catch(FormatException e) // Handle format exception
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e) // Handle overflow exception
            {
                Console.WriteLine(e.Message);
            }
        }
        static int[] Populate(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Please enter a number ({i}/{array.Length} entered): ");
                string userInput = Console.ReadLine();
                array[i] = Int32.Parse(userInput); // Populates each index of the array with a value specified by user
            }
            return array;
        }
        static int GetSum(int[] array)
        {
            int sum = 0;
            foreach(int value in array)
            {
                sum += value;
            }
            return sum>20 ? sum : throw new Exception($"Value of {sum} is too low"); // Throw an error if the sum is less than 20
        }
        static int GetProduct(int[] array, int sum)
        {
            try
            {
                int product = 0;
                Console.WriteLine($"Choose a random number between 1 and {array.Length}:");
                string userInput = Console.ReadLine();
                int userRandomIndex = Int32.Parse(userInput) - 1; // Gets an index number from the user
                product = sum * array[userRandomIndex]; 
                return product;
            }
            catch(IndexOutOfRangeException e) // Handles if user enters an index outside the range of the array
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        static decimal GetQuotient(int product)     
        {
            try
            {
                Console.WriteLine($"Product is {product}. Enter divisor to divide by:");
                string userInput = Console.ReadLine();
                int userDivisor = Int32.Parse(userInput);
                if (userDivisor == 1) // Stretch goal added exception for divisor of one
                {
                    throw new Exception($"Dividend of 1 is not valid (stretch goal)");
                }
                decimal quotient = decimal.Divide((decimal)product, userDivisor); 
                return quotient;
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                return 0; // Returns zero if program tries to divide by zero.
            }
        }
    }
}
