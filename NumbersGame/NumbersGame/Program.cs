using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the number game!");
            StartSequence();
        }
        static void StartSequence()
        {
            try
            {
                Console.WriteLine($"Please enter a number greater than zero: ");
                string userInput = Console.ReadLine();
                int[] userNumbers = new int[Convert.ToInt32(userInput)];
                Populate(userNumbers);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
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
                array[i] = Convert.ToInt32(userInput);
            }
            return array;
        }
    }
}
