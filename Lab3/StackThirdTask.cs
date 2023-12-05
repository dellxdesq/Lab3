
public class StackThirdTask
{
    public static void PalindromeCheck()
    {
        string palindrome1 = "Надо меч в кулак, а лук - в чемодан";
        string palindrome2 = "Нажал кабан на баклажан";
        string notPalindrome = "Привет, как дела?";

        Console.WriteLine($"\"{palindrome1}\" Это палиндром: {IsPalindrome(palindrome1)}");
        Console.WriteLine($"\"{palindrome2}\" Это палиндром: {IsPalindrome(palindrome2)}");
        Console.WriteLine($"\"{notPalindrome}\" Это палиндром: {IsPalindrome(notPalindrome)}");
    }

    static bool IsPalindrome(string text)
    {
        Stack<char> stack = new Stack<char>();
        string cleanedText = CleanText(text);

        foreach (char c in cleanedText)
        {
            stack.Push(c);
        }

        foreach (char c in cleanedText)
        {
            if (c != stack.Pop())
            {
                return false;
            }
        }

        return true;
    }

    static string CleanText(string text)
    {
        // Убираем пробелы, знаки препинания и переводим все символы в нижний регистр
        return new string(text.ToLower().ToCharArray().Where(c => Char.IsLetter(c)).ToArray());
    }
}
