using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Linq;

namespace Classes.SubNameSpace
{
    class Program
    {
        static void DayOfWeekProblem()
        {
            string dateAsText = "7-24-2019"; //Console.ReadLine()""

            DateTime date = DateTime.ParseExact(
                dateAsText,
                "M-d-yyyy",
                CultureInfo.InvariantCulture);


            DateTime myDate1 = new DateTime();
            DateTime myDate2 = new DateTime(2019, 11, 13);
            DateTime myDate3 = new DateTime(2019, 12, 21);

            //date.AddDays(12);

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //DayOfWeekProblem();

            //RandomiseWord();

            //Factorial();

            //PrintSongs();

            //PrintBoxes();

            //Students();

            CarsPrintSample();
        }

        static void RandomiseWord()
        {
            // get words, convert them to an array, then to a list.
            string words = "OneBit Software web development Azure cloud .NET Core JavaScript";

            string[] wordsArray = words.Split();

            List<string> wordsList = new List<string>();

            foreach (var arrayValue in wordsArray)
            {
                wordsList.Add(arrayValue);
            }

            Shuffle(wordsList);

            Console.WriteLine(string.Join(Environment.NewLine, wordsList));
        }

        // n! = 5 * 4 * 3 * 2 * 1 = 120
        static void Factorial()
        {
            int n = 50;
            BigInteger largeInteger = 1;


            // the integer starts at 1. We increment from 2 onwards and multiply.
            for (int i = 2; i <= n; i++)
            {
                largeInteger *= i; // multiply and assign
            }
            Console.WriteLine(largeInteger);
        }

        static void PrintSongs()
        {


            var songList = new List<Song>();

            songList.Add(
                new Song()
                {
                    Name = "Downtown",
                    Time = "4:16",
                    Type = "Favourite"
                });


            songList.Add(new Song() { Name = "Kiss", Time = "4:16", Type = "Favourite" });
            songList.Add(new Song() { Name = "Smooth Criminal", Time = "4:16", Type = "ListenLater" });



            var filteredList = songList.Where(s => s.Type == "ListenLater").ToList();






            string command = "all";
            string typeFilter = "ListenLater";

            switch (command)
            {
                case "all":
                    Console.WriteLine(songList[songList.Count - 1].Name);
                    break;
                default:

                    foreach (var song in songList)
                    {
                        if (song.Type == typeFilter)
                        {
                            Console.WriteLine(song.Name);
                        }
                    }

                    break;
            }
        }

        static void PrintBoxes()
        {
            string userInput = string.Empty;
            List<Box> boxList = new List<Box>();
            do
            {
                userInput = Console.ReadLine();

                if (userInput == "end")
                {
                    break;
                }

                var userInputAsArray = userInput.Split();

                var newBox = new Box();

                newBox.SerialNumber = userInputAsArray[0];
                newBox.Item.Name = userInputAsArray[1];
                newBox.Quantity = int.Parse(userInputAsArray[2]);
                newBox.Item.Price = decimal.Parse(userInputAsArray[3]);
                newBox.PriceInBox = newBox.Quantity * newBox.Item.Price;

                boxList.Add(newBox);

            } while (true);

            Console.WriteLine("End received. Pringing boxes...");

            foreach (var box in boxList)
            {
                Console.WriteLine(box.SerialNumber);

                Console.WriteLine($"-- {box.Item.Name}");
                Console.WriteLine($"-- {box.PriceInBox}");
            }
        }


        static void CarsPrintSample()
        {
            Console.WriteLine("Enter a brand:");
            string consoleInputValue = Console.ReadLine();

            Console.WriteLine("The value of consoleInputValue is:" + consoleInputValue);

            Car newCar = new Car();
            newCar.Brand = consoleInputValue;


            Catalog catalog = new Catalog();

            Console.WriteLine("The value of the newCar object brand is:" + newCar.Brand);
        }

        static void Students()
        {
            var studentList = new List<Student>();

            string userInput;
            do
            {
                userInput = Console.ReadLine();

                var userInputAsArray = userInput.Split();

                if (userInputAsArray.Length > 1)
                {
                    var newStudent = new Student();

                    newStudent.FirstName = userInputAsArray[0];
                    newStudent.LastName = userInputAsArray[1];
                    newStudent.Age = int.Parse(userInputAsArray[2]);
                    newStudent.City = userInputAsArray[3];

                    studentList.Add(newStudent);
                }

            } while (userInput != "end");

            string userInputCity = Console.ReadLine();

            foreach (var student in studentList)
            {
                if (student.City == userInputCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        static void Shuffle(List<string> list)
        {
            Random rnd = new Random();



            int listCount = list.Count;
            while (listCount > 1) // loop backwards
            {
                listCount--;
                int randomPosition = rnd.Next(listCount + 1);
                string valueOfRandomElement = list[randomPosition];
                list[randomPosition] = list[listCount];
                list[listCount] = valueOfRandomElement;
            }
        }
    }
}
