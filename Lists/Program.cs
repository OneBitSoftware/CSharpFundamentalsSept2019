namespace Lists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            // https://pastebin.com/nMekkL93

            int task = 0;

            do
            {
                Console.WriteLine("1 - Gauss' Trick");
                Console.WriteLine("2 - Merging lists");
                Console.WriteLine("3 - Sort products");
                Console.WriteLine("4 - Remove negative numbers");
                Console.WriteLine("5 - Sum adjacent equal numbers");
                Console.WriteLine("6 - List manipulation (Advanced)");
                Console.WriteLine("9 - Exit");

                task = int.Parse(Console.ReadLine());

                switch (task)
                {

                    case 1:

                        var numbers = new List<int>() { 1, 2, 3, 4, 5, 32, 64, 10, 465 };
                        GaussTrick(numbers);

                        break;
                    case 2:

                        var primaryList = new List<int> { 1, 2, 3, 4, 5 };
                        var secondaryList = new List<int> { 6, 7, 8 };
                        MergeLists(primaryList, secondaryList);

                        break;
                    case 3:

                        var productList = new List<string> { "Potatos", "Tomatos", "Onions", "Apples" };

                        SortProducts(productList);

                        Console.WriteLine(string.Join("\n", productList)); // \n is a new line

                        break;

                    case 4:

                        PrintNumbersTask();
                        break;

                    case 5:

                        PrintSequenceNumbers();
                        break;

                    case 6:

                        ListManipulation();
                        break;

                    default:
                        break;
                }

                Console.WriteLine(string.Empty);
            } while (task != 9);
        }

        private static void PrintSequenceNumbers()
        {
            var sequenceListA = new List<int> { 3, 3, 6, 1 };
            var sequenceListB = new List<int> { 8, 2, 2, 4, 8, 16 };
            var sequenceListC = new List<int> { 5, 4, 2, 1, 1, 4 };
            var sequenceListD = new List<int> { 1, 1 };
            var sequenceListE = new List<int> { 1 };

            SumAdjacentEqualNumbers(sequenceListA);
            SumAdjacentEqualNumbers(sequenceListB);
            SumAdjacentEqualNumbers(sequenceListC);
            SumAdjacentEqualNumbers(sequenceListD);
            SumAdjacentEqualNumbers(sequenceListE);
        }

        private static void PrintNumbersTask()
        {
            var numbersListA = new List<int> { 10, -5, 7, 9, -33, 50 };
            var numbersListB = new List<int> { 7, -2, -10, -10, -10, 1 };
            var numbersListC = new List<int> { -1, -2, -10, -5, -33 };

            RemoveNegativesAndReverse(numbersListA);
            RemoveNegativesAndReverse(numbersListB);
            RemoveNegativesAndReverse(numbersListC);
        }

        static void GaussTrick(List<int> seriesOfNumbers)
        {
            // retrieve and keep the initial count
            var itemCount = seriesOfNumbers.Count;

            // iterate the amount of times as the count
            for (int i = 0; i < itemCount / 2; i++)
            {
                // retrieve relevant values
                var valueAtIndexPosition = seriesOfNumbers[i];
                var valueOfIndexAtLastPosition = seriesOfNumbers.Count - 1; // zero based
                var valueAtLastPosition = seriesOfNumbers[valueOfIndexAtLastPosition];

                // sum the index and current last value
                var iterationSum = valueAtIndexPosition + valueAtLastPosition;

                // assign the summed value to the iteration index position
                seriesOfNumbers[i] = iterationSum;

                // Remove the item at the last position
                seriesOfNumbers.RemoveAt(valueOfIndexAtLastPosition);
            }

            Console.WriteLine(string.Join(" ", seriesOfNumbers));
        }

        static void MergeLists(List<int> primaryList, List<int> secondaryList)
        {
            // Get the lists counts and get the size of the larger list.
            var primaryListCount = primaryList.Count;
            var secondaryListCount = secondaryList.Count;
            var largerListCount = Math.Max(primaryListCount, secondaryListCount);

            // Create a new list to store the merged values with the larger list size
            List<int> mergedList = new List<int>();

            // iterate
            for (int i = 0; i < largerListCount; i++)
            {
                if (i < primaryListCount)
                {
                    mergedList.Add(primaryList[i]);
                }

                if (i < secondaryListCount)
                {
                    mergedList.Add(secondaryList[i]);
                }
            }

            Console.WriteLine(string.Join(" ", mergedList));
        }

        static void SortProducts(List<string> productNames)
        {
            // sort the list values
            productNames.Sort();

            // iterate through all product names after the sort
            for (int i = 0; i < productNames.Count; i++)
            {
                // prepend the item number -> "1.Apples" with the index value
                productNames[i] = $"{i + 1}.{productNames[i]}";
            }

            // Do nothing, return nothing
        }

        static void RemoveNegativesAndReverse(List<int> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (i < values.Count && values[i] < 0)
                {
                    values.RemoveAt(i--); // remove at i then - 1, since a previous position is removed
                }
            }

            values.Reverse();

            if (values.Count < 1)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", values));
            }
        }

        static void SumAdjacentEqualNumbers(List<int> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                // exit if the list is with 1 item
                if (values.Count <= i + 1) 
                {
                    break;
                }

                var valueAtIndex = values[i];
                var valueAfterIndex = values[i + 1];

                if (values[i] == valueAfterIndex)
                {
                    values[i] = valueAtIndex + valueAfterIndex;
                    values.RemoveAt(i + 1);
                    i = -1; // reset index to start from the begginning 
                }
            }

            Console.WriteLine(string.Join(" ", values));
        }

        static void ListManipulation()
        {
            string numbersString = "4 19 2 53 6 43";

            Console.WriteLine("Numbers: " + numbersString);
            var numbers = numbersString
                .Split() // returns string[]
                .Select(int.Parse) // retrieves the result of the in.Parse method
                .ToList(); // convert the result to a List<int>

            var line = string.Empty;

            do
            {
                Console.WriteLine("Enter a command:");
                line = Console.ReadLine();

                string[] lineParameters = line.Split();

                switch (lineParameters[0])
                {
                    case "Add":

                        int numberToAdd = int.Parse(lineParameters[1]);
                        numbers.Add(numberToAdd);
                        break;

                    case "Remove":

                        int numberToRemove = int.Parse(lineParameters[1]);
                        numbers.Remove(numberToRemove);
                        break;

                    case "RemoveAt":

                        int indexToRemove = int.Parse(lineParameters[1]);
                        numbers.RemoveAt(indexToRemove);
                        break;

                    case "Insert":

                        int numberToInsert = int.Parse(lineParameters[1]);
                        int indexToInsert = int.Parse(lineParameters[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        break;

                    case "Contains":

                        int containsNumber = int.Parse(lineParameters[1]);
                        OutputContains(numbers, containsNumber);
                        break;

                    case "PrintEven":

                        PrintEven(numbers);
                        break;

                    case "PrintOdd":

                        PrintOdd(numbers);
                        break;

                    case "GetSum":

                        GetSum(numbers);

                        break;
                    case "Filter":

                        string condition = lineParameters[1];
                        int filterNumber = int.Parse(lineParameters[2]);

                        FilterAndPrint(numbers, condition, filterNumber);

                        break;
                    default:
                        break;
                }
            } while (line == "End");
        }

        // This method is an anwser to an in-class question.
        // It uses .Where Linq, which is not part of the course
        private static string ArrayParsingWithLinq()
        {
            string numbersString = "4 19 2 53 6 43";
            //string numbersString = "2 13 43 876 342 23 543";

            var arrayOfNumbers = numbersString.Split().Select(int.Parse).ToList();

            var resultOfJoin = string.Join(" ", arrayOfNumbers.Where(x => x < 5));
            return numbersString;
        }

        private static void FilterAndPrint(List<int> numbers, string condition, int filterNumber)
        {
            foreach (var item in numbers)
            {
                switch (condition)
                {
                    case "<":

                        if (item < filterNumber)
                        {
                            Console.Write(item + " ");
                        }

                        break;
                    case ">":
                        if (item > filterNumber)
                        {
                            Console.Write(item + " ");
                        }
                        break;
                    case ">=":
                        if (item >= filterNumber)
                        {
                            Console.Write(item + " ");
                        }

                        break;
                    case "<=":
                        if (item <= filterNumber)
                        {
                            Console.Write(item + " ");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void GetSum(List<int> numbers)
        {
            int sum = 0;

            foreach (var item in numbers)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }

        private static void PrintOdd(List<int> numbers)
        {
            foreach (var item in numbers)
            {
                if (item % 2 == 1) // even
                {
                    Console.Write(item + " ");
                }
            }
        }

        private static void PrintEven(List<int> numbers)
        {
            foreach (var item in numbers)
            {
                if (item % 2 == 0) // even
                {
                    Console.Write(item + " ");
                }
            }
        }

        private static void OutputContains(List<int> numbers, int containsNumber)
        {
            if (numbers.Contains(containsNumber))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }
    }
}
