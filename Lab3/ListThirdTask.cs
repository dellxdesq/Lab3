using System;
using System.Collections.Generic;
using System.Linq;

public class ListThirdTask
{
    public static void WordFrequency()
    {
        string text = "Пример использования списка в C# для подсчета частоты слов в тексте.";

        // Разбиваем текст на слова
        string[] words = text.Split(' ', '.', ',', '!', '?');

        // Создаем список для хранения частоты слов
        List<KeyValuePair<string, int>> wordFrequencyList = new List<KeyValuePair<string, int>>();

        // Подсчитываем частоту каждого слова
        foreach (var word in words)
        {
            // Приводим слова к нижнему регистру
            string formattedWord = word.ToLower();

            // Ищем слово в списке
            var existingWord = wordFrequencyList.Find(w => w.Key == formattedWord);

            if (existingWord.Equals(default(KeyValuePair<string, int>)))
            {
                // Если слово не найдено, добавляем его в список
                wordFrequencyList.Add(new KeyValuePair<string, int>(formattedWord, 1));
            }
            else
            {
                // Если слово найдено, увеличиваем частоту
                int index = wordFrequencyList.IndexOf(existingWord);
                wordFrequencyList[index] = new KeyValuePair<string, int>(formattedWord, existingWord.Value + 1);
            }
        }

        // Выводим результаты
        Console.WriteLine("Частота слов в тексте:");
        foreach (var entry in wordFrequencyList)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} раз");
        }
    }
}
