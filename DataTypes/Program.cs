using System;
using System.Linq;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            double length, height = 0;
            Console.WriteLine("Length: ");
            length = double.Parse(Console.ReadLine());
            Console.WriteLine("Width: ");
            double width = 0;
            width = double.Parse(Console.ReadLine());
            Console.WriteLine("Heigth: ");
            height = double.Parse(Console.ReadLine());
            double result = (length + width + height) / 3;
            Console.WriteLine($"Pyramid Volume: {height:f2}");

            string nullString;
            string nullString1 = string.Empty;

            int test;
            nullString1 = null;

            //string a = "a";
            //string b = "b";
            //Console.WriteLine(a + b); // ab

            //VariableScope();

            //IntegerWrap();

            //IntegerLiterals();

            //FloatingPointNumbericTypes();
        }

        private static void VariableScope()
        {
            string outer = "I'm inside the Main()";
            for (int i = 0; i < 10; i++)
            {
                string inner = "I'm inside the loop";
            }

            Console.WriteLine(outer);
            //Console.WriteLine(inner); // Variable outside of scope
        }

        public static void IntegerWrap()
        {
            var n1 = 20;//long.MaxValue;      // 2147483647 (0x7FFFFFFF)
            n1 = n1 + 1;                // Now -2147483648 (wrapped)
        }

        public static void IntegerLiterals()
        {
            // assignemnts
            int n1 = 16;
            int n2 = 0x10; // 16

            // hex is: 0 1 2 3 4 5 6 7 8 9 A B C D E F   
            int n3 = 0xFF; //254
            int n4 = 0xA8F1; //43249
            long n5 = 0xFFFFFFFF; //4294967295, same as uint.MaxValue

            // decimal, hex and binary literals
            int decimalLiteral = 42;        //42
            int hexLiteral = 0x2A;              //42
            int binaryLiteral = 0b_0010_1010;   //42

            // unsigned long and long literals
            ulong unsignedLong = 42UL;

            var longVariable = 0;
            var longVariable2 = 0;

            ulong anotherUnsignedLong = 42;
            var anotherLong = (long)42;

            int n6 = n3 + n4;
        }

        public static void FloatingPointNumbericTypes()
        {
            //int fail = 0.7;

            // double alias
            double a = 12.3;
            System.Double b = 12.3;
            System.Double c = 12.32222222111111111333333333333331; // 12.322222221111112

            // default keyword
            float zero = default(float); // 0

            float zeroZero = 0; // 0
            //float zeroToNine = 0.123456789; // not valid

            // assignment to implicit types
            var oneTwoThreeFloat = 123.45F; // float 123.45
            var oneTwoThreeDecimal = 123.45M; // decimal 123.45
            var oneTwoThreeDouble = 123.45D; // decimal 123.45

            // conversion
            float floatPI = 3.141592653589793238f;
            double doublePI = 3.141592653589793238;
            Console.WriteLine("Float PI is: {0}", floatPI);
            Console.WriteLine("Double PI is: {0}", doublePI);

            var result = floatPI.ToString();

            Console.WriteLine(8 % 2.5); // Remainder operator

            int n = 15;
            for (int num = 1; num <= n; num++)
            {
                int sumOfDigits = 0;
                int digits = num;
                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits = digits / 10;
                }
                // TODO: check whether the sum is special
            }
        }
    }
}
