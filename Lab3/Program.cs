
using Lab3;
using OfficeOpenXml;

class Program
{
    public static void Main()
    {
        ExcelPackage.LicenseContext = LicenseContext.Commercial;

        TasksChoice.ShowMainMenu();

        while (true)
        {
            int choice = TasksChoice.GetMenuChoice();

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Tasks.DoStackTasks();
                    break;
                case 2:
                    Console.Clear();
                    Tasks.RunQueueTasks();
                    break;
                case 3:
                    Console.Clear();
                    Tasks.RunDynamicStructuresTasks();
                    break;
                case 4:
                    Console.Clear();
                    Tasks.RunListTasks();
                    break;
                default:
                    Console.WriteLine("Error: Введите номер от 1 до 4!");
                    break;
            }
        }

    }
}
