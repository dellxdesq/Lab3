namespace Lab3
{
    public class Program
    {
        public static void Main()
        {
            Menu();
            ConsoleKey choose = Console.ReadKey().Key;
            switch (choose)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    DoLinkedList.Do();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    StackOperations.babum();
                    break;
            }
        }
        public static void Menu()
        {
            Console.WriteLine("Выберите функцию калькулятора, указав цифру");
            Console.WriteLine("работа со списком");

        }
    }
}
