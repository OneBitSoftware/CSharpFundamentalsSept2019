using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    using System;
    class C
    {
        public void M()
        {
            Console.WriteLine("Hello world");
            Console.WriteLine(new C());
        }
    }

    class Program
    {
        private class SomeClass
        {
            public bool Method(int value)
            {
                Console.WriteLine($"Boom! {value}");
                return true;
            }
        }

        private Task<SomeClass> Danger()
        {
            return Task.FromResult(new SomeClass());
        }

        private async void Killer()
        {
            new int[5].Select((await Danger()).Method);

            Func<Type> f = (await Task.FromResult(1)).GetType; // boom

        }



        static void Main(string[] args)
        {

            //var x = await Task.FromResult(1);
            //Func<Type> f = x.GetType; // ok
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int size = 10;

    //        int[] numbers = new int[8];
    //        int a = numbers[5] = 2;

    //        int[] testArrayInt = { 1,2,4,3,7,5,9 };


    //        // Declare and initialise an array of integers
    //        var numbers4 = new int[10];

    //        var testLength = numbers.Length;

    //        int[] numbers10 = new int[10];
    //        string[] stringsArray = new string[10];
    //        // all elements are set to default(type)


    //        // Foreach
    //        double[] numbersArray = new double[] { 0.9, 1.5, 2.4, 2.5, 3.14 };
    //        numbersArray[0] = 0.9;
    //        numbersArray[1] = 1.5;


    //        double sum = 0;
    //        foreach (var number in numbersArray)
    //        {
    //            sum += number;
    //        }




    //        // Assign values
    //        numbers10[2] = 10000;
    //        numbers10[5] = 20000;

    //        // Read values
    //        int getResult1 = numbers10[2]; // 10000
    //        var getResult2 = numbers10[5]; // 20000
    //        var getResult3 = numbers10[6]; // default(int) -> 0

    //        var test1 = numbers10[0];
    //        var test9 = numbers10[9];
    //        //var test10 = numbers10[10];


    //        // get item at index 5 and 8
    //        var result0 = numbers10[0];
    //        var result5 = numbers10[5];
    //        var result8 = numbers10[8];
    //        //var result10 = numbers10[10]; // Exception: System.IndexOutOfRangeException
    //        //var resultNegativeOne = numbers10[-1]; // Exception: System.IndexOutOfRangeException


    //        // get array length 
    //        var length = numbers10.Length;







    //        // read values with loop - with integer
    //        for (int i = 0; i < 10; i++)
    //        {
    //            var valueAtIndex = numbers10[i];
    //        }

    //        // read values with loop - with .Length
    //        for (int i = 0; i < numbers10.Length; i++)
    //        {
    //            var valueAtIndex = numbers10[i];
    //        }

    //        // read values with loop - with variable
    //        for (int i = 0; i < length; i++)
    //        {
    //            var valueAtIndex = numbers10[i];
    //        }

    //        // Set values with loop
    //        for (int i = 0; i < 10; i++)
    //        {
    //            numbers10[i] = 555;
    //        }

    //        // Index out of range
    //        for (int i = 0; i <= numbers10.Length; i++)
    //        {
    //            //var result = numbers10[i]; // Exception: System.IndexOutOfRangeException
    //        }

    //        // VALID - no index out of range
    //        for (int i = 0; i <= numbers10.Length - 1; i++)
    //        {
    //            //var result = numbers10[i];
    //        }



    //        // "Collection initialisers"
    //        // Declare, initialise and set values with collection initialisers
    //        int[] array4;
    //        array4 = new int[] { 1, 3, 5, 7, 9 };       // OK
    //        int[] array2 = new int[] { 1, 3, 5, 7, 9 };
    //        //array4 = {1, 3, 5, 7, 9};                 // Doesn't compile.
    //        //array4 = new int[500] { 1, 3, 5, 7, 9 };    // Doesn't compile.
    //        //array4 = new int[3] { 1, 3, 5, 7, 9 };    // Doesn't compile.

    //        // Declare and set array element values.
    //        //int[] array2 = new int[] { 1, 3, 5, 7, 9 };

    //        string[] weekDays = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

    //        // Alternative syntax.
    //        int[] array3 = { 1, 2, 3, 4, 5, 6 };




    //        // Complex syntax with Linq, Func delegate, cast to array
    //        string inputLine = "1 2 3 4 5 6"; //Console.ReadLine();
    //        string[] items3 = inputLine.Split();
    //        int[] arr = items3.Select(int.Parse).ToArray();




    //        // Simple syntax with a loop
    //        string inputLine2 = "1,  2,  3,  4,  5,  6";
    //        int[] array45 = new int[10];
    //        array45[0] = 1;

    //        string[] stringArray = inputLine2.Split(",  ");
    //        var result123 = string.Join("", array45); // "12345"
    //        var result1234 = string.Join(" ", array45); // "1 2 3 4 5"
    //        var result12345 = string.Join("  ", array45); // "1  2  3  4  5"
    //        var result12346 = string.Join(", ", array45); // "1, 2, 3  4  5"


    //        int[] integersArray = new int[stringArray.Length];

    //        for (int i = 0; i < stringArray.Length; i++)
    //        {
    //            integersArray[i] = int.Parse(stringArray[i]);
    //        }

    //        int[] arr2 = Console
    //            .ReadLine()
    //            .Split(", ")
    //            .Select(int.Parse)
    //            .ToArray();

    //        // Rounding
    //        double[] nums = new double[] { 0.9, 1.5, 2.4, 2.5, 3.14, };
    //        //double[] nums = { -5.01, -1.599, -2.5, -1.50, 0 };
    //        int[] roundedNums = new int[nums.Length];
    //        for (int i = 0; i < nums.Length; i++)
    //        {
    //            roundedNums[i] = (int)Math
    //                  .Round(nums[i], MidpointRounding.AwayFromZero);
    //        }







    //        // Reverse Array of Strings - iterate through the entire array
    //        string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", };
    //        string[] lettersReversed = new string[letters.Length];
    //        int index4 = 0;
    //        for (int i = letters.Length - 1; i >= 0; i--)
    //        {
    //            lettersReversed[index] = letters[i];
    //            index++;
    //        }





    //        // Reverse Array of Strings - iterate through the entire array
    //        string[] items = { "a", "b", "c", "d", "e" }; //Console.ReadLine().Split(' ').ToArray();
    //        for (int i = 0; i < items.Length / 2; i++) // 2 if 5, 2 if 4.
    //        {
    //            // 0, 1, 2
    //            var oldElement = items[i];
    //            items[i] = items[items.Length - 1 - i]; // 1-based index to 0-based index, minus 1
    //            items[items.Length - 1 - i] = oldElement;
    //        }

    //        Console.WriteLine(string.Join(" ", items));




    //        // Reverse with System.Linq :)
    //        var reverseAgainWithLinq = items.Reverse();


    //        // Lab
    //        //1. Day of Week
    //        int n = 7;
    //        string[] days = new string[7] {
    //            "Monday",
    //            "Tuesday",
    //            "Wednesday",
    //            "Thursday",
    //            "Friday",
    //            "Saturday",
    //            "Sunday"
    //        };

    //        if (n >= 1 && n <= 7)
    //        {
    //            Console.WriteLine(days[n - 1]);
    //        }
    //        else
    //        {
    //            Console.WriteLine("Invalid day!");
    //        }

    //        //2. Print Numbers in Reverse Order
    //        int[] receivedNumbers = { 30, 20, 10 };
    //        //int[] receivedNumbers = { 10, 20, 30 };
    //        //int[] receivedNumbers = { 10 };

    //        for (int i = receivedNumbers.Length - 1; i >= 0; i--)
    //        {
    //            Console.WriteLine(receivedNumbers[i]);
    //        }

    //        //5.	Sum Even Numbers

    //    }
    //}
}
