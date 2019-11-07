using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssociativeArrays
{
    class Program
    {
        // deep dive reading: https://docs.microsoft.com/en-us/previous-versions/ms379571(v=vs.80)?redirectedfrom=MSDN 
        static void Main(string[] args)
        {
            Func<int, bool> t = (n) => n > 0;

            var products = new Dictionary<int, string>();

            products.Add(3, "apple");
            products.Add(2, "apple");
            products.Add(9, "apple");
            products.Add(6, "kiwi");
            products.Add(15, "banana");
            products.Add(12, "banana");
            products.Add(11, "banana");

            foreach (KeyValuePair<int, string> dictionaryItem in products)
            {
                Console.WriteLine(dictionaryItem.Key + " " + dictionaryItem.Value);
            }

            // for loop with reading
            for (int i = 0; i < products.Count; i++)
            {
                //var test4 = products[i];
                var test5 = products.ElementAt(i);
            }

            Dictionary<int, string> sortedDict = products
              .OrderBy(pair => pair.Value)
              .ThenBy(pair => pair.Key)
              .ToDictionary(key => key.Key, value => value.Value);

            Dictionary<string, string> test = new Dictionary<string, string>();
            //test.Remove("non-existing key");
            //System.Collections.Generic.KeyNotFoundException: 'The given key 'non-existing key' was not present in the dictionary.'

            // overwriting the value
            test["key1"] = "1234 test value";
            test["key1"] = "new value";
            test["key1"] = "another new value";

            var whatIsTheValue = test["key1"]; // whatIsTheValue will be "another new value"

            test.Add("key3", "1234 test value");
            test.Add("key2", "1234 test value");
            test.Add("key7", "1234 test value");
            test.Add("key6", "1234 test value");

            SortedDictionary<string, string> sortedTest = new SortedDictionary<string, string>();

            sortedTest.Add("key1", "1234 test value");
            sortedTest.Add("key3", "1234 test value");
            sortedTest.Add("key2", "1234 test value");
            sortedTest.Add("key7", "1234 test value");
            sortedTest.Add("key6", "1234 test value");


            // 1. Count Real Numbers
            //double[] realNumbers = new double[] { 8, 2.5, 2.5, 8, 2.5 };
            //CountRealNumbers(realNumbers);

            // 2. Word Synonyms
            WordSynonyms();

            // 3. LINQ and Lambda
            //LinqAndLambda();

            // 4. word filter
            //WordFilter();

            // 5. Sort collection
            //SortCollections();

            // 6. Print the top 3 largest numbers
            PrintLargestNumbers();

            // Lab
            // Odd Occurances
            OddOccurances();
        }

        private static void PrintLargestNumbers()
        {
            int[] numbers = new int[] { 8, 10 };
            //int[] numbers = new int[] { 8, 10, 30, 20, 50, 4, 5, 6 };
            var sortedNumbers = numbers
                                    .OrderByDescending(n => n)
                                    .ToArray();

            // ternary conditional operator
            // condition ? consequent : alternative
            // is this condition true ? yes : no
            int count = numbers.Length >= 3 ? 3 : numbers.Length;

            for (int i = 0; i < count; i++)
            {
                Console.Write($"{sortedNumbers[i]} ");
            }

            Console.WriteLine(); // new line

            // using LINQ and Lambda
            var numbersList = numbers
                .ToList() // convert array to list
                .OrderByDescending(n => n) // sort decending 
                .Take(3); // filter top 3

            numbersList.ToList().ForEach((item) => Console.Write(item + " "));
        }

        private static void LinqAndLambda()
        {
            // named functions
            IsPositive(-15);
            IsPositive(5);

            bool isPositive = IsPositive(5);
            isPositive = IsPositive(8);

            // declare and initialise arrays
            int[] numbers = new int[8] { 1, 5, 2, -3, -10, 1, -4, -2 };
            string[] words = new string[4] { "kiwi", "orange", "banana", "apple" };

            // get positive numbers without LINQ
            List<bool> positiveNumbersList = new List<bool>();
            foreach (var number in numbers)
            {
                var isPositiveResult = IsPositive(number);
                positiveNumbersList.Add(isPositiveResult);
            }

            // get positive numbers with LINQ and a Lambda
            // Select() iterates over each item in a collection.
            var positiveNumberResults = numbers.Select(woiruisour => woiruisour > 0);

            words.Select(w => w + " fruit");
            words.Select(word => word + " fruit");



            // Where() filters the collection
            var positiveNumbers = numbers.Where(number => IsPositive(number));
            var aboveFive = numbers.Where(number => number > 5);

            var array = aboveFive.ToArray();
            var list = array.ToList();
        }

        private static void CountRealNumbers(double[] realNumbers)
        {
            // Key is storing the real number
            // Value is storing the coung of occurances
            var realNumberCount = new SortedDictionary<double, int>();

            foreach (var realNumber in realNumbers)
            {
                if (realNumberCount.ContainsKey(realNumber)) // it is already added
                {
                    var keyValue = realNumberCount[realNumber];


                    realNumberCount[realNumber] = keyValue + 1;
                }
                else // it doesn't exist, so we add the key and a value of 1
                {
                    realNumberCount.Add(realNumber, 1);
                }
            }

            foreach (var realNumber in realNumberCount)
            {
                Console.WriteLine($"{realNumber.Key} -> {realNumber.Value}");
            }
        }

        private static void WordSynonyms()
        {
            Console.WriteLine("Please enter the number of pairs:");
            var numberOfPairs = int.Parse(Console.ReadLine());

            var wordSynonyms = new Dictionary<string, List<string>>();
            // cute, adorable
            //       charming
            //       sexy
            // smart, clever

            wordSynonyms.Add("cute", null);

            wordSynonyms["cute"] = new List<string>();
            if (wordSynonyms["cute"] != null)
            {
                wordSynonyms["cute"].Add("");
            }

            for (int i = 0; i < numberOfPairs; i++)
            {
                Console.WriteLine("Please enter the word:");
                string word = Console.ReadLine();

                Console.WriteLine("Please enter the synonyum:");
                string synonym = Console.ReadLine();

                if (wordSynonyms.ContainsKey(word))
                {
                    // wordSynonyms[word] reads the item by the "word" key into the list variable
                    List<string> list = wordSynonyms[word];
                    list.Add(synonym);
                }
                else
                {
                    wordSynonyms.Add(word, new List<string> { synonym });
                }
            }

            // Build the response text for each word
            foreach (var word in wordSynonyms)
            {
                StringBuilder resultTextBuilder = new StringBuilder();

                resultTextBuilder.Append(word.Key); // "cute"
                resultTextBuilder.Append(" - "); // "cute - "

                for (int i = 0; i < word.Value.Count; i++)
                {
                    resultTextBuilder.Append(word.Value[i]);  // "cute - adorable"  // "cute - adorable, charming" 

                    if (i != word.Value.Count - 1) // do not append the , if it is the last item
                    {
                        resultTextBuilder.Append(", "); // "cute - adorable, "
                    }
                }

                Console.WriteLine(resultTextBuilder);
            }
        }

        public static void WordFilter()
        {
            // Example with string array
            //var stringArray = Console.ReadLine().Split();
            string[] wordsArray = new string[4] { "kiwi", "orange", "banana", "apple" };

            var evenWords = wordsArray.Where(w => w.Length % 2 == 0);

            foreach (var word in evenWords)
            {
                Console.WriteLine(word);
            }
        }

        public static void SortCollections()
        {
            var products = new Dictionary<int, string>();
            var sortedDict = products
              .OrderBy(pair => pair.Value)
              .ThenBy(pair => pair.Key)
              .ToDictionary(pair => pair.Key,
                      pair => pair.Value);

        }

        /// <summary>
        /// Returns true if a number is positive.
        /// </summary>
        /// <param name="inputInteger">The integer input parameter to test for positivity.</param>
        /// <returns>True, ifthe number is positive, otherwise False.</returns>
        public static bool IsPositive(int inputInteger)
        {
            if (inputInteger > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            //return inputInteger > 0;
        }

        public static void OddOccurances()
        {
            Console.WriteLine();

            string[] words = "Java C# PHP PHP JAVA C java java java".Split();
            //
            //string[] words = "3 3 3 3 3 5 5 hi pi HO Hi 5 ho 3 hi pi".Split();

            var counts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                var wordToLowerCase = word.ToLowerInvariant();

                if (counts.ContainsKey(wordToLowerCase))
                {
                    counts[wordToLowerCase]++; // increment by 1
                }
                else
                {
                    counts.Add(wordToLowerCase, 1); // add first item with value 1
                }
            }

            // get the odd with a remainder division
            var oddCountWords = counts.Where(c => c.Value % 2 > 0);

            // print
            oddCountWords.ToList().ForEach(word => Console.Write(word.Key + " "));
        }
    }
}
