using System;
using System.Collections.Generic;

namespace ConsoleAppRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Choose Method to run            
        }

        static void ValidateWord()
        {
           string word = "123Hello";
           Console.WriteLine("Is Valid Word: " + StringHelper.IsValidWord(word));
           Console.ReadLine();
        }

        static void AnagramChecker()
        {
            Anagrams.Runner(new List<string> { "opts", "post", "pots", "spot", "stop", "hello" }, "tops");
            Anagrams.SimpleChecker("hello", "Check");
            Anagrams.SimpleChecker("stop", "tops");
        }

        static void RunBitwiseOperators()
        {
            int a = 60;            /* 60 = 0011 1100 */ // 
            int b = 13;            /* 13 = 0000 1101 */
            int c = 0;

            /* 12 = 0000 1100 */
            c = BitwiseOperators.BitwiseAnd(a, b);  
            Console.WriteLine("Line 1 - Value of c is {0}", c);

            /* 61 = 0011 1101 */
            c = BitwiseOperators.BitwiseOR(a, b);   
            Console.WriteLine("Line 2 - Value of c is {0}", c);

            /* 49 = 0011 0001 */
            c = BitwiseOperators.BitwiseXOR(a, b);  
            Console.WriteLine("Line 3 - Value of c is {0}", c);

            /*-61 = 1100 0011 */
            c = BitwiseOperators.BitwiseComplement(a);   
            Console.WriteLine("Line 4 - Value of c is {0}", c);

            /* 240 = 1111 0000 */
            c = BitwiseOperators.BitwiseLeftShift(a,2);
            Console.WriteLine("Line 5 - Value of c is {0}", c);

            /* 15 = 0000 1111 */
            c = BitwiseOperators.BitwiseRightShift(a, 2);
            Console.WriteLine("Line 6 - Value of c is {0}", c);
            Console.ReadLine();
        }

        static void FootballHttpGetNumDraws()
        {
            Console.WriteLine("Enter Year:");
            int year = Convert.ToInt32(Console.ReadLine().Trim());
            int resultNumDraws = FootballGetNumDraws.getNumDraws(year);
            Console.WriteLine("Number Draws" + resultNumDraws);                       
            Console.ReadLine();
        }

        static void FootballHttpGetWinnerGoals()
        {
            Console.WriteLine("Enter Competition Name:");
            string competition = Console.ReadLine();
            Console.WriteLine("Enter Year:");
            int year = Convert.ToInt32(Console.ReadLine().Trim());
            int resultWinnerGoals = FootballGetWinnerTotalGoals.getWinnerTotalGoals(competition, year);
            Console.WriteLine("Winner Goals" + resultWinnerGoals);
            Console.ReadLine();
        }
    }

   
}
