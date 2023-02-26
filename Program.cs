using System;

namespace arrlab
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("How to fill array:\n\t1 - randomize\n\t2 - by yourself\n\t0 - exit");
            int userChoice = -1;
            while (userChoice != 0)
            {
                userChoice = Int32.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case(0):
                    {
                        return;
                    }
                    case (1):
                    {
                        Task(ProcessArrayWithRandomNumbers());
                        return;
                    }
                    case (2):
                    {
                        Task(ProcessArrayWithUserPreference());
                        return;
                    }
                    default:
                    {
                        Console.WriteLine("Enter correct number");
                        continue;
                    }
                }
            }
        }
        
        static void Task(int[] array)
        {
            ChangePositiveIntegersToTheirSquares(array);
            PresentArrayInConsole("Squared array:", array);
            FindTwoMaxValues(array);

            void ChangePositiveIntegersToTheirSquares(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if(arr[i] < 0) continue;
                    arr[i] = (int)Math.Pow(arr[i], 2);
                }
            }

            void FindTwoMaxValues(int[] arr)
            {
                int max1 = int.MinValue;
                int max2 = int.MinValue;

                foreach (int number in arr)
                {
                    if (number > max1) max1 = number;
                }

                foreach (int number in arr)
                {
                    if (number > max2 && number < max1) max2 = number;
                }

                Console.WriteLine($"\tFirst maximum: {max1}\n\tSecond maximum: {max2}");
            }
        }

        static int[] ProcessArrayWithRandomNumbers()
        {
            Console.WriteLine("Randomize");
            Console.WriteLine("\tEnter array length");
            int arrLength = int.Parse(Console.ReadLine());
            int[] processedArray = RandomizeArrayValues(arrLength);
            PresentArrayInConsole("Randomized array:", processedArray);
            return processedArray;
        }

        static int[] ProcessArrayWithUserPreference()
        {
            Console.WriteLine("How would you like to fill array:\n\t1 - in row\n\t2 - in column");
            while (true)
            {
                int userChoice = Int32.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case (1):
                    {
                        return FillArrayInRow();
                    }
                    case (2):
                    {
                        return FillArrayInColumn();
                    }
                    default:
                    {
                        Console.WriteLine("Enter correct number");
                        continue;
                    }
                }
            }

            int[] FillArrayInRow()
            {
                Console.WriteLine("Enter array values through SPACE");
                string[] userArray = Console.ReadLine().Trim().Split();
                return ParseStringArrayToInteger(userArray);
            }

            int[] FillArrayInColumn()
            {
                Console.WriteLine("Enter array length");
                int arrLength = int.Parse(Console.ReadLine());
                int[] userInput = new int[arrLength];
                Console.WriteLine("Enter values");
                for (int i = 0; i < arrLength; i++)
                {
                    int userValue = int.Parse(Console.ReadLine());
                    userInput[i] = userValue;
                }

                return userInput;
            }
        }

        static void PresentArrayInConsole(string stringStart, int[] arr)
        {
            string result = "";
            foreach (int number in arr)
            {
                result += $"{number} ";
            }

            Console.WriteLine($"\t{stringStart} ${result}");
        }

        static int[] RandomizeArrayValues(int length)
        {
            int[] integerArray = new int[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                integerArray[i] = random.Next(-100, 100);
            }

            return integerArray;
        }

        static int[] ParseStringArrayToInteger(string[] arr)
        {
            int[] intArray = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                intArray[i] = int.Parse(arr[i]);
            }

            return intArray;
        }
    }
}