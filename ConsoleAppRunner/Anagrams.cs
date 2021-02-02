using System;
using System.Collections.Generic;

namespace ConsoleAppRunner
{
	public class Anagrams
	{	
		private static Dictionary<string,string> _dictionary = new Dictionary<string, string>();

		public static void Runner(List<string> words, string anagramWord)
		{
			// Read and sort dictionary
			ReadInword(words);

			// check again anagramWord and show anagrams
			AnagramCheck(anagramWord);
		}
		static void ReadInword(List<string> input)
		{			
			// Read each line
			foreach (var line in input)
			{
				// Alphabetize the line for the key
				// Then add to the value string
				string sortedWord = Alphabetize(line);
				string value;
				if (_dictionary.TryGetValue(sortedWord, out value))
				{
					_dictionary[sortedWord] = value + "," + line;
				}
				else
				{
					_dictionary.Add(sortedWord, line);
				}
			}
		}

		static string Alphabetize(string word)
		{
			// Convert to char array, then sort and return
			char[] a = word.ToCharArray();
			Array.Sort(a);
			return new string(a);
		}

		static void AnagramCheck(string wordToCheck)
		{
			// Write value for alphabetized word
			string value;
			if (_dictionary.TryGetValue(Alphabetize(wordToCheck), out value))
			{				
				Console.WriteLine("Words that are anagrams");
				Console.WriteLine(value);
			}
			else
			{
				Console.WriteLine("Word(s) that are not anagrams");
				Console.WriteLine(wordToCheck);
			}
			Console.ReadLine();
		}

		public static void SimpleChecker(string wordOne, string wordTwo)
		{
			char[] ch1 = wordOne.ToLower().ToCharArray();
			char[] ch2 = wordTwo.ToLower().ToCharArray();
			Array.Sort(ch1);
			Array.Sort(ch2);
			string val1 = new string(ch1);
			string val2 = new string(ch2);

			if (val1 == val2)
			{
				Console.WriteLine("Both the strings are Anagrams");
			}
			else
			{
				Console.WriteLine("Both the strings are not Anagrams");
			}
		}
	}
}
