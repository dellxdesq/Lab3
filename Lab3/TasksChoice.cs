namespace Lab3
{
    public static class TasksChoice
    {
        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите структуру данных (для выбора, нажмите цифру и enter)");
            Console.WriteLine("(1) Стек");
            Console.WriteLine("(2) Очередь");
            Console.WriteLine("(3) Динамические структуры");
            Console.WriteLine("(4) Лист");
        }

        public static void ReturnToMainMenu(string previousMethod)
        {
            Console.WriteLine("Введите 1, чтобы вернуться назад.");
            Console.WriteLine("Введите 2, чтобы ввернуться в главное меню.");
            Console.WriteLine("Введите 3, чтобы завершить программу.");
            while (true)
            {
                int choice = GetMenuChoice();
                switch (choice)
                {
                    case 1:
                        switch (previousMethod)
                        {
                            case "Stack":
                                Tasks.DoStackTasks();
                                break;
                            case "Queue":
                                Tasks.RunQueueTasks();
                                break;
                            case "DynamicStructures":
                                Tasks.RunDynamicStructuresTasks();
                                break;
                            case "List":
                                Tasks.RunListTasks();
                                break;  
                            default:
                                Program.Main();
                                break;
                        }
                        return;
                    case 2:
                        Program.Main();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 3!");
                        break;
                }
            }
        }


        public static int GetMenuChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            return -1;
        }
    }
}
