using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Foo
{
    /*
     * Complete the 'SearchSuggestions' function below.
     *
     * The function is expected to return a list of string lists (2D_STRING_ARRAY).
     * The function accepts following parameters:
     * 	1. List (STRING_ARRAY) - reviewsRepository
     * 	2. String - userInput
     */

    public static List<List<string>> SearchSuggestions(List<string> reviewsRepository, string userInput)
    {
        List<List<string>> reviewsRepositoryNew = new List<List<string>>();
        List<string> words = new List<string>();

        reviewsRepository.Sort();

        string inputStr = userInput[0].ToString();
        for (int i = 1; i < userInput.Length; i++)
        {
            inputStr += userInput[i];

            for (int j = 0; j < reviewsRepository.Count; j++)
            {
                if (reviewsRepository[j].Substring(0, i+1).ToLower() == inputStr.ToLower())
                {
                    words.Add(reviewsRepository[j]);
                }

            }
            var newWords= words.Take(3);
            reviewsRepositoryNew.Add(newWords.ToList());
            words = new List<string>();
        }
        if (reviewsRepositoryNew == null)
            return null;
        else
            return reviewsRepositoryNew;
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine("How many words are in the section: ");
        int reviewsRepositoryCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> reviewsRepository = new List<string>();

        Console.WriteLine("Insert them here: ");
        for (int i = 0; i < reviewsRepositoryCount; i++)
        {
            string reviewsRepositoryItem = Console.ReadLine();
            reviewsRepository.Add(reviewsRepositoryItem);
        }

        Console.Write("Search: ");
        string userInput = Console.ReadLine();
        if (userInput.Length >= 2)
        {

            List<List<string>> foo = Foo.SearchSuggestions(reviewsRepository, userInput);

            Console.WriteLine("Recommended: ");
            Console.WriteLine(String.Join("\n", foo.Select(x => String.Join(" ", x))));
        }
        else
        {
            Console.WriteLine("Please input at least two characters!");

        }
    }
}
