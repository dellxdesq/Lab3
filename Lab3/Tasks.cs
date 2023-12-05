using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab3;

namespace Lab3
{
    class Tasks
    {
        public static void DoStackTasks()
        {
            Console.Clear();

            Console.WriteLine("Выберите пункт задания");
            Console.WriteLine("(1) Запуск различных наборов операций из файла input.txt с выводом на экран");
            Console.WriteLine("(2) Запуск с замером времени различных наборов операций из файла input.txt.");
            Console.WriteLine("(3) Вычисление в постфиксной записи");
            Console.WriteLine("(4) Перевод из инфиксной записи в постфиксную запись");
            Console.WriteLine("(5) Запуск с замером времени различных наборов операций из файла input.txt, для встроенного класса Stack в C#");

            while (true)
            {
                int choice = TasksChoice.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        StackOperations.DoStackOperations();
                        break;
                    case 2:
                        Console.Clear();
                        StackOperations.DoStackOperationsFromFile();
                        break;
                    case 3:
                        Console.Clear();
                        StackOperations.DoPostfixOperation();
                        break;
                    case 4:
                        Console.Clear();
                        StackOperations.DoInfixToPostfixOperation();
                        break;
                    case 5:
                        Console.Clear();
                        StackOperations.DoStandartStackOperation();
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 5!");
                        continue;
                }
            }
        }

        public static void RunQueueTasks()
        {
            Console.Clear();

            Console.WriteLine("Выберите пункт задания");
            Console.WriteLine("(1) Запуск различных наборов операций из файла input.txt с выводом на экран");
            Console.WriteLine("(2) Запуск с замером времени с файлом одинаковым по длине, со случайными операциями из файла input.txt.");
            Console.WriteLine("(3) Запуск с замером времени с файлом прогрессирующим по длине, со случайными операциями из файла input.txt.");
            Console.WriteLine("(4) Запуск с замером времени с файлом прогрессирующим по длине, со случайными операциями из файла input.txt, для встроенного Queue");


            while (true)
            {
                int choice = TasksChoice.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        QueuesOperations.DoQueuesOperations();
                        break;
                    case 2:
                        Console.Clear();
                        QueuesOperations.DoQueueOperationsWithSameLenghtFile();
                        break;
                    case 3:
                        Console.Clear();
                        QueuesOperations.DoDifferentQueueOperationWithFile();
                        break;
                    case 4:
                        Console.Clear();
                        QueuesOperations.DoStandartQueueOperation();
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 4!");
                        continue;
                }
            }
        }

        public static void RunDynamicStructuresTasks()
        {
            Console.Clear();

            Console.WriteLine("Выберите пункт задания");
            Console.WriteLine("(1) Пример использования структуры данных Список");
            Console.WriteLine("(2) Пример использования структуры данных Стек");
            Console.WriteLine("(3) Пример использования структуры данных Очередь");
            Console.WriteLine("(4) Пример использования структуры данных Дерево");

            while (true)
            {
                int choice = TasksChoice.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        ListThirdTask.WordFrequency();
                        TasksChoice.ReturnToMainMenu("DinamicStructure");
                        break;
                    case 2:
                        Console.Clear();
                        StackThirdTask.PalindromeCheck();
                        TasksChoice.ReturnToMainMenu("DinamicStructure");
                        break;
                    case 3:
                        Console.Clear();
                        QueueThirdTask.BankServiceSimulation();
                        TasksChoice.ReturnToMainMenu("DinamicStructure");
                        break;
                    case 4:
                        Console.Clear();
                        TreeThirdTask.DepthTree();
                        TasksChoice.ReturnToMainMenu("DinamicStructure");
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 4!");
                        continue;
                }
            }
        }

        public static void RunListTasks()
        {
            Console.Clear();

            Console.WriteLine("Выберите пункт задания");
            Console.WriteLine("(1) Перевернуть список");
            Console.WriteLine("(2) Поменять местами первый и последний элемент");
            Console.WriteLine("(3) Количество целых чисел");
            Console.WriteLine("(4) Удалить все неуникальные элементы");
            Console.WriteLine("(5) Вставка самого себя после первого вхождения X");
            Console.WriteLine("(6) Вставка элемента с сохранением порядка");
            Console.WriteLine("(7) Удалить элементы E");
            Console.WriteLine("(8) Вставка элемента F перед первым вхождением E");
            Console.WriteLine("(9) Считать 2 списка из файла и записать их в 1");
            Console.WriteLine("(10) Разбить список по заданному числу");
            Console.WriteLine("(11) Удвоить список");
            Console.WriteLine("(12) Переставить элементы");

            while (true)
            {
                int choice = TasksChoice.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        DoLinkedList.ReverseLinkedList();
                        break;
                    case 2:
                        Console.Clear();
                        DoLinkedList.MoveLastToFrontToLast();
                        break;
                    case 3:
                        Console.Clear();
                        DoLinkedList.DistinctElementsCount();
                        break;
                    case 4:
                        Console.Clear();
                        DoLinkedList.RemoveNonUniqueElements();
                        break;
                    case 5:
                        Console.Clear();
                        DoLinkedList.InsertYourself();
                        break;
                    case 6:
                        Console.Clear();
                        DoLinkedList.InsertOrdered();
                        break;
                    case 7:
                        Console.Clear();
                        DoLinkedList.RemoveAllOccurrences();
                        break;
                    case 8:
                        Console.Clear();
                        DoLinkedList.InsertBeforeFirstOccurrence();
                        break;
                    case 9:
                        Console.Clear();
                        DoLinkedList.AppendList();
                        break;
                    case 10:
                        Console.Clear();
                        DoLinkedList.SplitListExample();
                        break;
                    case 11:
                        Console.Clear();
                        DoLinkedList.DuplicateListExample();
                        break;
                    case 12:
                        Console.Clear();
                        DoLinkedList.SwapElementsExample();
                        break;
                    default:
                        Console.WriteLine("Введите номер от 1 до 12!");
                        continue;
                }
            }
        }
    }

}
