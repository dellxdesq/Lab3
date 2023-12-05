using System;
using System.Collections.Generic;
using System.Linq;

public class ListThirdTask
{
    public static void WordFrequency()
    {
        Console.WriteLine("Введите строку: ");
        string text = Console.ReadLine();     
        string[] words = text.Split(' ', '.', ',', '!', '?');
    
        List<KeyValuePair<string, int>> wordFrequencyList = new List<KeyValuePair<string, int>>();

        foreach (var word in words)
        {
            string formattedWord = word.ToLower();
            var existingWord = wordFrequencyList.Find(w => w.Key == formattedWord);

            if (existingWord.Equals(default(KeyValuePair<string, int>)))
            {
                wordFrequencyList.Add(new KeyValuePair<string, int>(formattedWord, 1));
            }
            else
            {
                int index = wordFrequencyList.IndexOf(existingWord);
                wordFrequencyList[index] = new KeyValuePair<string, int>(formattedWord, existingWord.Value + 1);
            }
        }

        Console.WriteLine("Количество слов в строке: ");
        foreach (var entry in wordFrequencyList)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} раз");
        }
    }
}
